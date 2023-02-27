using ADonnu.Models;
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
    public class AdminsController : Controller
    {
        private readonly IAdminService _adminService;
        private readonly IMapper _mapper;
        public AdminsController(IAdminService adminService, IMapper mapper)
        {
            _adminService = adminService;
            _mapper = mapper;
        }
        // GET: api/Admins/Users
        [HttpGet("Users")]
        public async Task<ActionResult<List<object>>> GetUsers()
        {
            var users = await _adminService.GetAllUsers();
            return Ok(users);
        }

        // DELETE: api/Admins/Delete/User
        [HttpDelete("Delete/User")]
        public async Task<ActionResult<object>> DeleteUser([FromQuery] string email)
        {
            var result = await _adminService.DeleteUserByEmailAsync(email);
            return Ok(new { userEmail = email, isDeleted = result });
        }

        // DELETE: api/Admins/Update/User
        [HttpPut("Update/User")]
        public async Task<ActionResult<object>> UpdateUser([FromQuery] string email, UpdateStudentUserModel updateStudentModel)
        {
            var result = await _adminService.UpdateUserByEmailAsync(email, _mapper.Map<UpdateStudentUserDTO>(updateStudentModel));
            return Ok(result);
        }
    }
}
