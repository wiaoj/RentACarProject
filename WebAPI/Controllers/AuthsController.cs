﻿using Business.Abstract;
using Entities.DTOs.User;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : ControllerBase {
        private readonly IAuthService _authService;
        public AuthsController(IAuthService authService) => _authService = authService;

        [HttpPost("login")]
        public ActionResult Login(UserForLoginDto userForLoginDto) {
            var userToLogin = _authService.Login(userForLoginDto);
            if (userToLogin.Success.Equals(false)) {
                return BadRequest(userToLogin.Message);
            }

            var result = _authService.CreateAccessToken(userToLogin.Data);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("register")]
        public ActionResult Register(UserForRegisterDto userForRegisterDto) {
            var userExists = _authService.UserExists(userForRegisterDto.EmailAdress);
            if (userExists.Success) {
                return BadRequest(userExists.Message);
            }

            var registerResult = _authService.Register(userForRegisterDto, userForRegisterDto.Password);
            var result = _authService.CreateAccessToken(registerResult.Data);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}