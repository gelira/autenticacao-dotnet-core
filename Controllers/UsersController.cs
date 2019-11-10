using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Autenticacao.Helpers;
using Autenticacao.Models;
using Autenticacao.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Autenticacao.Controllers
{
    [ApiController]
    [Route("users")]
    public class UsersController : ControllerBase
    {
        private readonly SecretKeyConfig secretKeyConfig;
        private IHttpContextAccessor httpContext;
        private IUserService users;

        public UsersController(
            IOptions<SecretKeyConfig> options,
            IHttpContextAccessor accessor,
            IUserService userService)
        {
            secretKeyConfig = options.Value;
            httpContext = accessor;
            users = userService;
        }

        [HttpPost("token")]
        public IActionResult Autenticar([FromBody] LoginUser loginUser) 
        {
            var user = users.Autenticar(loginUser.Username, loginUser.Password);
            if (user == null)
            {
                return Unauthorized(new { message = "Wrong credentials" });
            }

            var key = secretKeyConfig.SecretKeyBytes;
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(6),
                SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(key), 
                        SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            
            return Ok(new 
            { 
                message = "You are logged in!!",
                token = tokenString 
            });
        }

        [HttpGet("verify")]
        [Authorize]
        public IActionResult VerificarToken()
        {
            var id = int.Parse(httpContext.HttpContext.User.FindFirst(ClaimTypes.Name).Value);
            var user = users.GetUserById(id);
            if (user == null)
            {
                return Unauthorized();
            }

            return Ok(new 
            { 
                message = "Valid token",
                nome = user.Nome
            });   
        }
    }
}