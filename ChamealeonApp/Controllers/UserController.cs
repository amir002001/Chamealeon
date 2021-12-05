using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using API.Models.DTOs;
using ChamealeonApp.Models.Authentication;
using ChamealeonApp.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ChamealeonApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly TokenService _tokenService;
        public UserController(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            TokenService tokenService
            )
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            _tokenService = tokenService;
        }

        //register
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            var user = new User
            {
                Email = registerDto.Email,
                UserName = registerDto.UserName
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (result.Succeeded)
                return Ok();

            return BadRequest(result.Errors);
        }


        // login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if (user == null)
                return Unauthorized("email doesn't exist");



            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (result.Succeeded)
                return Ok(new UserDto
                {
                    Token = _tokenService.CreateToken(user)
                });

            return Unauthorized("Not a good password");
        }

        //amir
        //create a user

        //update user details

        //delete user
    }
}