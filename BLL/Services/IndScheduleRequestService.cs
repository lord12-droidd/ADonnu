using AutoMapper;
using Azure.Storage.Blobs;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Interfaces;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class IndScheduleRequestService : IIndScheduleRequestService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly string FONT = "c:/windows/fonts/Times.ttf";
        public IndScheduleRequestService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<byte[]> CreateIndScheduleRequestFile(IndScheduleRequestDTO studentRequestInfo, string email)
        {
            var studentFullDbInfo = await _unitOfWork.UserRepository.GetUserByEmailAsync(email);
            studentRequestInfo.Id = studentFullDbInfo.Id;

            await UploadTemplate($"{email} {studentRequestInfo.Id}/Signature.png", new MemoryStream(Convert.FromBase64String(studentRequestInfo.Signature)));
            await _unitOfWork.IndScheduleRequestRepository.CreateIndScheduleRequestRecord(studentRequestInfo.Id, $"{studentRequestInfo.Surname} {studentRequestInfo.Id}/IndScheduleRequestFilled.pdf");
            var registryListTemplateByteArray = await FillRegistryListTemplate(studentRequestInfo, email);
            var indRequestTemplateByteArray =  await FillIndRequestTemplate(studentRequestInfo, email);
            var resultDocumentByteArray = MergePDFs(new List<byte[]>() { registryListTemplateByteArray, indRequestTemplateByteArray });
            await UploadTemplate($"{email} {studentRequestInfo.Id}/IndScheduleRequestFilled.pdf", new MemoryStream(resultDocumentByteArray));

            for (int i = 0; i < studentRequestInfo.Files.Count; i++)
            {
                var fileType = studentRequestInfo.Files[i].Split(';')[0].Split('/')[1];
                var addByteArray = Convert.FromBase64String(studentRequestInfo.Files[i].Split(",")[1]);
                await UploadTemplate($"{email} {studentRequestInfo.Id}/Adds/Add{i}.{fileType}", addByteArray);
            }
            
            return resultDocumentByteArray;
        }

        public async Task<bool> ApproveIndScheduleRequest(ApproveIndScheduleRequestDTO approveIndScheduleRequestDTO, string teacherEmail, string studentEmail)
        {
            var teacherEntity = await _unitOfWork.UserRepository.GetUserByEmailAsync(teacherEmail);
            var studentEntity = await _unitOfWork.UserRepository.GetUserByEmailAsync(studentEmail);
            var studentIndRequestByteArray = await DownloadTemplate($"{studentEmail} {studentEntity.Id}/IndScheduleRequestFilled.pdf");
            var studentIndRequestRecord = await _unitOfWork.IndScheduleRequestRepository.GetIndScheduleRequestTeacherEntityById(studentEntity.Id, teacherEntity.Id);
            var teacherSignatureByteArray = Convert.FromBase64String(approveIndScheduleRequestDTO.Signature.Substring(approveIndScheduleRequestDTO.Signature.LastIndexOf(',') + 1));
            await InsertTeacherSignature(teacherSignatureByteArray, studentIndRequestByteArray, studentIndRequestRecord.TeacherPosition, studentEntity.Id, studentEmail, approveIndScheduleRequestDTO.Comment);
            var res = await _unitOfWork.IndScheduleRequestRepository.DeleteIndScheduleRequestTeacherEntityRecord(studentEntity.Id, teacherEntity.Id);
            if (res != null)
            {
                return true;
            }
            return false;
        }

        public async Task<IList<ApprovedIndScheduleRequestDTO>> GetApprovedIndScheduleRequest()
        {
            var indScheduleRequests = await _unitOfWork.IndScheduleRequestRepository.GetApprovedIndScheduleRequestRecords();
            var approvedIndScheduleRequestDTOs = new List<ApprovedIndScheduleRequestDTO>();
            foreach (var indScheduleRequest in indScheduleRequests)
            {
                var student = await _unitOfWork.StudentRepository.GetStudentByIdAsync(indScheduleRequest.Id);
                approvedIndScheduleRequestDTOs.Add(new ApprovedIndScheduleRequestDTO()
                {
                    FilledRequestDownloadPath = indScheduleRequest.AzureAccessPath,
                    AddsDownloadPath = indScheduleRequest.AzureAccessPath.Split("/")[0] + "/Adds",
                    StudentName = $"{student.Surname} {student.Name} {student.MiddleName}"
                });
            }
            return approvedIndScheduleRequestDTOs;
        }

        private async Task<byte[]> InsertTeacherSignature(byte[] teacherSignatureByteArray, byte[] studentIndRequestByteArray, int teacherPosition, string studentId, string studentEmail , string teacherComment)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding.GetEncoding("windows-1252");
            byte[] resultFileByteArray;

            //Another in-memory PDF
            using (var ms = new MemoryStream())
            {
                //Bind a reader to the bytes that we created above
                using (var reader = new PdfReader(studentIndRequestByteArray))
                {
                    //Store our page count
                    var pageCount = reader.NumberOfPages;


                    Rectangle size = reader.GetPageSizeWithRotation(1);
                    Document document = new iTextSharp.text.Document(size);


                    //Bind a stamper to our reader
                    using (var stamper = new PdfStamper(reader, ms))
                    {
                        //Setup a font to use
                        BaseFont bf = BaseFont.CreateFont(FONT, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

                        //Get the raw PDF stream "on top" of the existing content
                        var cb = stamper.GetOverContent(1);

                        //Draw some text
                        cb.SetColorFill(BaseColor.BLACK);
                        cb.SetFontAndSize(bf, 12);
                        // чим менше х тим лівіше, чим менше у тим нижче

                        DrawText(cb, teacherComment, 415, GetYPosition(teacherPosition), 0);

                        Image image = Image.GetInstance(teacherSignatureByteArray, true);
                        image.ScaleAbsoluteHeight(12);
                        image.ScaleAbsoluteWidth(50);
                        image.SetAbsolutePosition(480, GetYPosition(teacherPosition));
                        image.BorderColor = BaseColor.WHITE;
                        cb.AddImage(image);
                    }
                }
                resultFileByteArray = ms.ToArray();
                await UploadTemplate($"{studentEmail} {studentId}/IndScheduleRequestFilled.pdf", resultFileByteArray);
                return resultFileByteArray;
            }
        }

        private async Task<byte[]> FillRegistryListTemplate(IndScheduleRequestDTO studentRequestInfo, string studentEmail)
        {
            var templateByteArray = await DownloadTemplate("Templates/" + "RegistryListTemplate.pdf");
            await UploadTemplate($"{studentEmail} {studentRequestInfo.Id}/RegistryListTemplate.pdf", new MemoryStream(templateByteArray));
            var studentFolderTemplateByteArray = await DownloadTemplate($"{studentEmail} {studentRequestInfo.Id}/RegistryListTemplate.pdf");
            var studentSignatureByteArray = await DownloadTemplate($"{studentEmail} {studentRequestInfo.Id}/Signature.png");
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding.GetEncoding("windows-1252");
            byte[] resultFileByteArray;

            //Another in-memory PDF
            using (var ms = new MemoryStream())
            {
                //Bind a reader to the bytes that we created above
                using (var reader = new PdfReader(studentFolderTemplateByteArray))
                {
                    //Store our page count
                    var pageCount = reader.NumberOfPages;


                    Rectangle size = reader.GetPageSizeWithRotation(1);
                    Document document = new iTextSharp.text.Document(size);


                    //Bind a stamper to our reader
                    using (var stamper = new PdfStamper(reader, ms))
                    {

                        //Setup a font to use
                        BaseFont bf = BaseFont.CreateFont(FONT, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

                        //Loop through each page
                        for (var i = 1; i <= pageCount; i++)
                        {
                            //Get the raw PDF stream "on top" of the existing content
                            var cb = stamper.GetOverContent(i);

                            //Draw some text
                            cb.SetColorFill(BaseColor.BLACK);
                            cb.SetFontAndSize(bf, 12);
                            // чим менше х тим лівіше, чим менше у тим нижче
                            DrawText(cb, studentRequestInfo.Surname + " " + studentRequestInfo.Name + " " + studentRequestInfo.MiddleName, 320, 650, 0);
                            DrawText(cb, studentRequestInfo.Course, 155, 605, 0);
                            DrawText(cb, studentRequestInfo.Group, 265, 605, 0);
                            DrawText(cb, studentRequestInfo.Faculty, 225, 590, 0);
                            DrawText(cb, studentRequestInfo.EducationForm, 255, 577, 0);
                            DrawText(cb, studentRequestInfo.FinancingForm, 260, 563, 0);
                            DrawText(cb, studentRequestInfo.Speciality, 290, 549, 0);
                            DrawText(cb, studentRequestInfo.EducationDegree, 205, 535, 0);
                            //Предмети та викладачі
                            int positionDiff = 465;
                            for (int j = 0; j < studentRequestInfo.SubjectsForm.Count; j++)
                            {
                                DrawText(cb, studentRequestInfo.SubjectsForm[j].SubjectName, 180, positionDiff, 0);
                                DrawText(cb, studentRequestInfo.SubjectsForm[j].CombinedTeacherName, 310, positionDiff, 0);
                                positionDiff = positionDiff - 15;
                                var teacherEntity = await _unitOfWork.UserRepository.GetUserByEmailAsync(studentRequestInfo.SubjectsForm[j].Email);
                                await _unitOfWork.IndScheduleRequestRepository.CreateIndScheduleRequestTeacherEntityRecord(studentRequestInfo.Id, teacherEntity.Id, j);
                            }

                            DrawText(cb, studentRequestInfo.Surname + " " + studentRequestInfo.Name[0] + "." + studentRequestInfo.MiddleName[0] + ".", 145, 235, 0);
                            DrawText(cb, DateTime.Now.Day.ToString(), 352, 235, 0);
                            DrawText(cb, DateTime.Now.Month.ToString(), 403, 235, 0);
                            DrawText(cb, DateTime.Now.Year.ToString()[2..], 460, 235, 0);

                            Image image = Image.GetInstance(studentSignatureByteArray, true);
                            var scalePercent = (((document.PageSize.Width / image.Width) * 100) - 19.5f);
                            image.ScalePercent(scalePercent);
                            image.SetAbsolutePosition(240, 235);
                            image.BorderColor = BaseColor.WHITE;
                            cb.AddImage(image);
                        }

                    }
                }
                resultFileByteArray = ms.ToArray();
                await UploadTemplate($"{studentEmail} {studentRequestInfo.Id}/RegistryListTemplate.pdf", resultFileByteArray);
                return resultFileByteArray;
            }
        }

        private async Task<byte[]> FillIndRequestTemplate(IndScheduleRequestDTO studentRequestInfo, string studentEmail)
        {
            var templateByteArray = await DownloadTemplate("Templates/" + "IndRequestTemplate.pdf");
            await UploadTemplate($"{studentEmail} {studentRequestInfo.Id}/IndRequestTemplate.pdf", new MemoryStream(templateByteArray));
            var studentFolderTemplateByteArray = await DownloadTemplate($"{studentEmail} {studentRequestInfo.Id}/IndRequestTemplate.pdf");
            var studentSignatureByteArray = await DownloadTemplate($"{studentEmail} {studentRequestInfo.Id}/Signature.png");
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding.GetEncoding("windows-1252");
            byte[] resultFileByteArray;

            //Another in-memory PDF
            using (var ms = new MemoryStream())
            {
                //Bind a reader to the bytes that we created above
                using (var reader = new PdfReader(studentFolderTemplateByteArray))
                {
                    //Store our page count
                    var pageCount = reader.NumberOfPages;


                    Rectangle size = reader.GetPageSizeWithRotation(1);
                    Document document = new iTextSharp.text.Document(size);


                    //Bind a stamper to our reader
                    using (var stamper = new PdfStamper(reader, ms))
                    {

                        //Setup a font to use
                        BaseFont bf = BaseFont.CreateFont(FONT, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

                        //Loop through each page
                        for (var i = 1; i <= pageCount; i++)
                        {
                            //Get the raw PDF stream "on top" of the existing content
                            var cb = stamper.GetOverContent(i);

                            cb.SetColorFill(BaseColor.BLACK);
                            cb.SetFontAndSize(bf, 12);

                            DrawText(cb, studentRequestInfo.Surname, 450, 730, 0);
                            DrawText(cb, studentRequestInfo.Name + " " + studentRequestInfo.MiddleName, 450, 707, 0);
                            DrawText(cb, studentRequestInfo.Course, 490, 682, 0);
                            DrawText(cb, studentRequestInfo.EducationForm, 490, 662, 0);
                            DrawText(cb, studentRequestInfo.FinancingForm, 500, 640, 0);
                            DrawText(cb, studentRequestInfo.Speciality, 450, 598, 0);
                            DrawText(cb, studentRequestInfo.Faculty, 470, 575, 0);
                            DrawText(cb, studentRequestInfo.EducationDegree, 460, 555, 0);
                            DrawText(cb, studentRequestInfo.Phone, 460, 530, 0);
                            DrawText(cb, studentRequestInfo.Reason, 335, 445, 0);
                            DrawText(cb, studentRequestInfo.StartDate.Split("-")[2], 108, 419, 0);
                            DrawText(cb, studentRequestInfo.StartDate.Split("-")[1], 160, 419, 0);
                            DrawText(cb, studentRequestInfo.StartDate.Split("-")[0][2..], 214, 419, 0);
                            DrawText(cb, studentRequestInfo.EndDate.Split("-")[2], 262, 419, 0);
                            DrawText(cb, studentRequestInfo.EndDate.Split("-")[1], 314, 419, 0);
                            DrawText(cb, studentRequestInfo.EndDate.Split("-")[0][2..], 368, 419, 0);
                            DrawText(cb, DateTime.Now.ToShortDateString(), 145, 375, 0);
                            DrawText(cb, studentRequestInfo.Adds, 314, 332, 0);

                            Image image = Image.GetInstance(studentSignatureByteArray, true);
                            var scalePercent = (((document.PageSize.Width / image.Width) * 100) - 19.5f);
                            image.ScalePercent(scalePercent);
                            image.SetAbsolutePosition(445, 373);
                            image.BorderColor = BaseColor.WHITE;
                            cb.AddImage(image);
                        }

                    }
                }
                resultFileByteArray = ms.ToArray();
                await UploadTemplate($"{studentEmail} {studentRequestInfo.Id}/IndRequestTemplate.pdf", resultFileByteArray);
                return resultFileByteArray;
            }
        }

        private byte[] MergePDFs(List<byte[]> pdfByteContent)
        {

            using (var ms = new MemoryStream())
            {
                using (var doc = new Document())
                {
                    using (var copy = new PdfSmartCopy(doc, ms))
                    {
                        doc.Open();

                        //Loop through each byte array
                        foreach (var p in pdfByteContent)
                        {

                            //Create a PdfReader bound to that byte array
                            using (var reader = new PdfReader(p))
                            {

                                //Add the entire document instead of page-by-page
                                copy.AddDocument(reader);
                            }
                        }

                        doc.Close();
                    }
                }

                //Return just before disposing
                return ms.ToArray();
            }
        }

        private void DrawText(PdfContentByte cb, string text, float x, float y, float rotation)
        {
            if(text != null)
            {
                cb.BeginText();
                cb.ShowTextAligned(1, text, x, y, rotation);
                cb.EndText();
            }
        }

        private int GetYPosition(int teacherPosition)
        {
            int yPosition = 465;
            int positionDifference = 16;
            switch (teacherPosition)
            {
                case 0:
                    yPosition = yPosition - (positionDifference * 0);
                    return yPosition;
                case 1:
                    yPosition = yPosition - (positionDifference * 1) + 1;
                    return yPosition;
                case 2:
                    yPosition = yPosition - (positionDifference * 2) + 3;
                    return yPosition;
                case 3:
                    yPosition = yPosition - (positionDifference * 3) + 4;
                    return yPosition;
                case 4:
                    yPosition = yPosition - (positionDifference * 4) + 6;
                    return yPosition;
                case 5:
                    yPosition = yPosition - (positionDifference * 5) + 8;
                    return yPosition;
                case 6:
                    yPosition = yPosition - (positionDifference * 6) + 9;
                    return yPosition;
                case 7:
                    yPosition = yPosition - (positionDifference * 7) + 11;
                    return yPosition;
                case 8:
                    yPosition = yPosition - (positionDifference * 8) + 13;
                    return yPosition;
            }
            return yPosition;
        }

        private async Task<MemoryStream> UploadTemplate(string pathToUpload, MemoryStream fileToUpload)
        {
            BlobContainerClient container = new BlobContainerClient("DefaultEndpointsProtocol=https;AccountName=indschedulesstorage;AccountKey=5c3VU5soo19Cv0/K9xAetZOUgKhGKVT+X+Advun9Q3I0vjKZ0DYNARzx0BNHMGDLJ+LXSg3Qaqmg+AStJcM3lg==;EndpointSuffix=core.windows.net",
                "adonnucontainer");
            BlobClient blobClient = container.GetBlobClient(pathToUpload);

            container.CreateIfNotExists();

            fileToUpload.Position = 0;

            await blobClient.UploadAsync(new BinaryData(fileToUpload.ToArray()), true);

            return fileToUpload;
        }

        private async Task<byte[]> UploadTemplate(string pathToUpload, byte[] fileToUpload)
        {
            BlobContainerClient container = new BlobContainerClient("DefaultEndpointsProtocol=https;AccountName=indschedulesstorage;AccountKey=5c3VU5soo19Cv0/K9xAetZOUgKhGKVT+X+Advun9Q3I0vjKZ0DYNARzx0BNHMGDLJ+LXSg3Qaqmg+AStJcM3lg==;EndpointSuffix=core.windows.net",
                "adonnucontainer");
            BlobClient blobClient = container.GetBlobClient(pathToUpload);

            container.CreateIfNotExists();

            await blobClient.UploadAsync(new BinaryData(fileToUpload), true);

            return fileToUpload;
        }

        private async Task<byte[]> DownloadTemplate(string templateFileName)
        {
            BlobContainerClient container = new BlobContainerClient("DefaultEndpointsProtocol=https;AccountName=indschedulesstorage;AccountKey=5c3VU5soo19Cv0/K9xAetZOUgKhGKVT+X+Advun9Q3I0vjKZ0DYNARzx0BNHMGDLJ+LXSg3Qaqmg+AStJcM3lg==;EndpointSuffix=core.windows.net",
                "adonnucontainer");
            BlobClient blobClient = container.GetBlobClient(templateFileName);

            container.CreateIfNotExists();

            var res = await blobClient.DownloadContentAsync();

            return res.Value.Content.ToArray();
        }
    }
}
