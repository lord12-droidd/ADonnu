using ADonnu.Models;
using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ADonnu.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IndScheduleRequestController : ControllerBase
    {

        private readonly IIndScheduleRequestService _indScheduleRequestService;
        private readonly IMapper _mapper;

        public IndScheduleRequestController(IIndScheduleRequestService indScheduleRequestService, IMapper mapper)
        {
            _indScheduleRequestService = indScheduleRequestService;
            _mapper = mapper;
        }

        // POST: api/IndScheduleRequest
        [HttpPost]
        public async Task<IActionResult> CreateIndSchedule([FromBody] IndScheduleRequestModel indScheduleRequestModel)
        {

            var indScheduleRequestDTO = _mapper.Map<IndScheduleRequestDTO>(indScheduleRequestModel);
            indScheduleRequestDTO.Signature = indScheduleRequestModel.Signature.Substring(indScheduleRequestModel.Signature.LastIndexOf(',') + 1);
            var filePath = await _indScheduleRequestService.CreateIndScheduleRequestFile(indScheduleRequestDTO);
            var fileToDownload = await _indScheduleRequestService.GetFileFromStorage(filePath);
            return File(fileToDownload, GetContentType(filePath), "Сформовані заяви на інд. графік");
        }

        private string GetContentType(string path)
        {
            var provider = new FileExtensionContentTypeProvider();
            string contentType;
            if (!provider.TryGetContentType(path, out contentType))
            {
                contentType = "application/octet-stream";
            }
            return contentType;
        }
    }
}
