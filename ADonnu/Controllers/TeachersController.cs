using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADonnu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherService _teacherService;
        private readonly IMapper _mapper;
        public TeachersController(ITeacherService teacherService, IMapper mapper)
        {
            _teacherService = teacherService;
            _mapper = mapper;
        }

        // GET: api/Teachers/{email}/Students/IndScheduleRequests
        [HttpGet("{email}/Students/IndScheduleRequests")]
        public async Task<ActionResult<IList<TeachersStudentIndScheduleRequestDTO>>> GetTeacherIndScheduleRequests(string email)
        {
            var res = await _teacherService.GetStudentsWithRequests(email);
            return Ok(res);
        }
    }
}
