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
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        public StudentsController(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }

        // GET: api/Students/email
        [HttpGet("{email}")]
        public async Task<ActionResult<StudentModel>> GetStudent(string email)
        {
            var studentDTO = await _studentService.GetUserByEmailAsync(email);
            if (studentDTO == null)
            {
                return NotFound();
            }

            var student = _mapper.Map<StudentModel>(studentDTO);
            student.Email = email;
            return student;
        }

        // PATCH: api/Students/email
        [HttpPut("{email}")]
        public async Task<ActionResult<StudentModel>> UpdateStudent(string email, StudentModel studentModel)
        {
            var studentDTO = _mapper.Map<StudentDTO>(studentModel);
            var updatedStudent = await _studentService.UpdateStudentAsync(studentDTO, email);
            var updatedStudentModel = _mapper.Map<StudentModel>(updatedStudent);
            if (updatedStudent == null)
            {
                return BadRequest(email);
            }
            return Accepted(updatedStudentModel);
        }
    }
}
