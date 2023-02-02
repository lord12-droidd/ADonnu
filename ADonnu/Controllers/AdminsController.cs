using AutoMapper;
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
    }
}
