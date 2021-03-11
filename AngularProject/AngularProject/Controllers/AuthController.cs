using AngularProject.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AngularProject.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public IConfiguration Configuration { get; }
        public AuthController(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = new ConfigurationBuilder().AddJsonFile($"appSettings.{environment.EnvironmentName}.json").Build();
        }
        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginModel user)
        {
            var settings = new Settings();
            Configuration.Bind(settings);

            if (user == null)
            {
                return BadRequest("Invalid data");
            }
            if (user.UserName == "jhondoe" && user.Password == "12345")
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@123"));

                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var tokenOptions = new JwtSecurityToken(
                     issuer: settings.AutentificationSettings.ValidIssuer,
                     audience: settings.AutentificationSettings.ValidAudience,
                     claims: new List<Claim>(),
                     expires: DateTime.Now.AddMinutes(5),
                     signingCredentials: signinCredentials
                    );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return Ok(new { token = tokenString });
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
