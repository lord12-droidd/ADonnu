using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ADonnu.Models;
using BLL.Services;
using AutoMapper;
using BLL.Interfaces;
using BLL.DTO;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Linq;

namespace ADonnu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJwtService _jwtService;
        private readonly IMapper _mapper;

        public UsersController(
            IJwtService jwtService,
            IUserService userService,
            IMapper mapper
            )
        {
            _userService = userService;
            _jwtService = jwtService;
            _mapper = mapper;
        }

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<UserModel>> PostUser(UserModel user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userDTO = _mapper.Map<UserDTO>(user);
            var result = await _userService.AddAsync(userDTO);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return CreatedAtAction("GetUser", new { email = user.Email }, new { IsCreated = result.Succeeded, user.Email });
        }

        // GET: api/Users/email
        [HttpGet("{email}")]
        public async Task<ActionResult<UserModel>> GetUser(string email)
        {
            var user = await _userService.GetUserByEmailAsync(email);

            if (user == null)
            {
                return NotFound();
            }

            return new UserModel
            {
                Email = user.Email
            };
        }

        // POST: api/Users/BearerToken
        [HttpPost("BearerToken")]
        public async Task<ActionResult<AuthenticationResponseModel>> CreateBearerToken(AuthenticationRequestModel request)
        {
            var user = await _userService.GetUserByEmailAsync(request.Email);
            var roles = user.Roles;
            return await CreateAuthToken(request, user => _mapper.Map<AuthenticationResponseModel>(_jwtService.CreateToken(user, roles).Result));
        }


        private async Task<ActionResult<TAuthTokenType>> CreateAuthToken<TAuthTokenType>(
            AuthenticationRequestModel request,
            Func<UserDTO, TAuthTokenType> createToken
        )
        {
            var user = await Authenticate(request);

            if (user == null)
            {
                return BadRequest("Bad credentials");
            }

            var token = createToken(user);

            return Ok(token);
        }

        private async Task<UserDTO> Authenticate(AuthenticationRequestModel request)
        {
            if (!ModelState.IsValid)
            {
                return null;
            }

            var user = await _userService.GetUserByEmailAsync(request.Email);

            if (user == null)
            {
                return null;
            }

            var isPasswordValid = await _userService.CheckPasswordAsync(request.Email, request.Password);

            if (!isPasswordValid)
            {
                return null;
            }

            return user;
        }
    }
}