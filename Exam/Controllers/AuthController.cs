using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exam.DTOs;
using Exam.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exam.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService authService;

        public AuthController(AuthService authService)
        {
            this.authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> Authenticate(AuthDTO authDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var token = await authService.Authenticate(authDTO.Login, authDTO.Password);

            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized();
            }

            return Ok(new { token });
        }

        [HttpPost]
        public async Task<IActionResult> Registration(AuthDTO authDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var response = await authService.Registration(authDTO.Login, authDTO.Password);

            if (string.IsNullOrEmpty(response))
            {
                return Unauthorized();
            }

            return Ok(response);
        }
    }
}