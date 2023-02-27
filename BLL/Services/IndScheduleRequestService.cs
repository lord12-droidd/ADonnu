using AutoMapper;
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
        private static readonly string initPath = "../BLL/FilesTemplates/IndRequestTemplate";
        private static readonly string initPathSecond = "../BLL/FilesTemplates/RegistryListTemplate";
        private readonly string FONT = "c:/windows/fonts/Times.ttf";
        public IndScheduleRequestService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<string> CreateIndScheduleRequestFile(IndScheduleRequestDTO studentRequestInfo)
        {
            await Task.Run(() => {
                File.WriteAllBytes("../BLL/FilesTemplates/Signature.png", Convert.FromBase64String(studentRequestInfo.Signature));
                FillIndRequestTemplate(studentRequestInfo);
                FillRegistryListTemplate(studentRequestInfo);
                MergePDFs(new List<string>() { initPath + "Filled.pdf", initPathSecond + "Filled.pdf" }, "../BLL/FilesTemplates/ResultRequest.pdf");
            });
            return "../BLL/FilesTemplates/ResultRequest.pdf";
        }

        public async Task<MemoryStream> GetFileFromStorage(string filePath)
        {
            var memory = new MemoryStream();
            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return memory;
        }

        private void FillRegistryListTemplate(IndScheduleRequestDTO studentRequestInfo)
        {
            string oldFile = initPathSecond + ".pdf";
            string newFile = initPathSecond + "Filled.pdf";

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding.GetEncoding("windows-1252");
            BaseFont bf = BaseFont.CreateFont(FONT, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

            // open the reader

            PdfReader reader = new PdfReader(oldFile);
            Rectangle size = reader.GetPageSizeWithRotation(1);
            Document document = new iTextSharp.text.Document(size);

            // open the writer
            FileStream fs = new FileStream(newFile, FileMode.Create, FileAccess.Write);
            PdfWriter writer = PdfWriter.GetInstance(document, fs);

            document.Open();

            // the pdf content
            PdfContentByte cb = writer.DirectContent;
            try
            {

                // select the font properties
                //BaseFont bf = BaseFont.CreateFont(FONT, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
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
                //Предмети

                DrawText(cb, "Проектування інф. систем", 180, 465, 0);
                DrawText(cb, "Методи та системи шт. інт.", 180, 450, 0);
                DrawText(cb, "Дизайн інтерфейсів", 180, 436, 0);
                DrawText(cb, "ОБДтЗ", 180, 422, 0);
                DrawText(cb, "Системний аналіз", 180, 407, 0);
                DrawText(cb, "ООП", 180, 393, 0);

                DrawText(cb, studentRequestInfo.Surname + " " + studentRequestInfo.Name[0] + "." + studentRequestInfo.MiddleName[0] + ".", 145, 235, 0);
                DrawText(cb, DateTime.Now.Day.ToString(), 352, 235, 0);
                DrawText(cb, DateTime.Now.Month.ToString(), 403, 235, 0);
                DrawText(cb, DateTime.Now.Year.ToString()[2..], 460, 235, 0);

                // create the new page and add it to the pdf
                PdfImportedPage page = writer.GetImportedPage(reader, 1);

                cb.AddTemplate(page, 0, 0);

                Image image = Image.GetInstance(@"..\BLL\FilesTemplates\Signature.png", true);
                var scalePercent = (((document.PageSize.Width / image.Width) * 100) - 19.5f);
                image.ScalePercent(scalePercent);
                image.SetAbsolutePosition(240, 235);
                image.BorderColor = BaseColor.WHITE;
                cb.AddImage(image);
            }
            catch
            {
                document.Close();
                fs.Close();
                writer.Close();
                reader.Close();
            }

            document.Close();
            fs.Close();
            writer.Close();
            reader.Close();
            //SignatureToPdf(oldFile, @"C:\Users\USER\source\repos\ConsoleApp2\Signature.png", newFile);
        }

        private void FillIndRequestTemplate(IndScheduleRequestDTO studentRequestInfo)
        {
            string oldFile = initPath + ".pdf";
            string newFile = initPath + "Filled.pdf";

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding.GetEncoding("windows-1252");
            BaseFont bf = BaseFont.CreateFont(FONT, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

            // open the reader

            PdfReader reader = new PdfReader(oldFile);
            Rectangle size = reader.GetPageSizeWithRotation(1);
            Document document = new Document(size);

            // open the writer
            FileStream fs = new FileStream(newFile, FileMode.Create, FileAccess.Write);
            PdfWriter writer = PdfWriter.GetInstance(document, fs);
            document.Open();

            // the pdf content
            PdfContentByte cb = writer.DirectContent;

            try
            {
                // select the font properties
                //BaseFont bf = BaseFont.CreateFont(FONT, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
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

                // create the new page and add it to the pdf
                PdfImportedPage page = writer.GetImportedPage(reader, 1);
                cb.AddTemplate(page, 0, 0);

                Image image = Image.GetInstance(@"..\BLL\FilesTemplates\Signature.png", true);
                var scalePercent = (((document.PageSize.Width / image.Width) * 100) - 19.5f);
                image.ScalePercent(scalePercent);
                image.SetAbsolutePosition(445, 373);
                image.BorderColor = BaseColor.WHITE;
                cb.AddImage(image);
            }
            catch
            {
                document.Close();
                fs.Close();
                writer.Close();
                reader.Close();
                cb.SaveState();
            }
            document.Close();
            fs.Close();
            writer.Close();
            reader.Close();
            cb.SaveState();


            // close the streams and voilá the file should be changed :)

        }

        private void MergePDFs(IEnumerable<string> fileNames, string targetPdf)
        {
            Document doc = new Document();
            PdfCopy writer = new PdfCopy(doc, new FileStream(targetPdf, FileMode.Create));
            if (writer == null)
            {
                return;
            }
            doc.Open();
            foreach (string filename in fileNames)
            {
                PdfReader reader = new PdfReader(filename);
                reader.ConsolidateNamedDestinations();
                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    PdfImportedPage page = writer.GetImportedPage(reader, i);
                    writer.AddPage(page);
                }
                reader.Close();
            }
            writer.Close();
            doc.Close();
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
    }
}
