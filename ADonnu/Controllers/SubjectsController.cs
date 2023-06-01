using ADonnu.Models;
using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADonnu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly ISubjectService _subjectService;
        private readonly IMapper _mapper;
        public SubjectsController(ISubjectService subjectService, IMapper mapper)
        {
            _subjectService = subjectService;
            _mapper = mapper;
        }

        // GET: api/Subjects
        [HttpGet]
        public async Task<ActionResult<SubjectDTO>> GetSubjects()
        {
            var res = await _subjectService.GetAllSubjects();
            return Ok(res);
        }

        // GET: api/Subjects/Student/{email}
        [HttpGet("Student/{email}")]
        public async Task<ActionResult<SubjectDTO>> GetStudentSubjects(string email)
        {
            var res = await _subjectService.GetStudentSubjectsByEmail(email);
            return Ok(res);
        }
    }
}
