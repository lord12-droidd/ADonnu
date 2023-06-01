using ADonnu.Models;
using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
            var resultFileByteArray = await _indScheduleRequestService.CreateIndScheduleRequestFile(indScheduleRequestDTO, indScheduleRequestModel.Email);
            return File(resultFileByteArray, "application/octet-stream", "Сформовані заяви на інд. графік");
        }

        // POST: api/IndScheduleRequest/{teacherEmail}/Approve/Student/{studentEmail}
        [HttpPost("{teacherEmail}/Approve/Student/{studentEmail}")]
        public async Task<ActionResult<object>> ApproveIndScheduleRequest(string teacherEmail, string studentEmail, [FromBody] ApproveIndScheduleRequestModel body)
        {
            var res = await _indScheduleRequestService.ApproveIndScheduleRequest(_mapper.Map<ApproveIndScheduleRequestDTO>(body), teacherEmail, studentEmail);
            return Ok(new { IsDeleted = res });
        }

        // GET: api/IndScheduleRequest/Approved
        [HttpGet("Approved")]
        public async Task<ActionResult<IList<ApprovedIndScheduleRequestDTO>>> GetApprovedIndScheduleRequest()
        {
            var res = await _indScheduleRequestService.GetApprovedIndScheduleRequest();
            return Ok(res);
        }
    }
}
