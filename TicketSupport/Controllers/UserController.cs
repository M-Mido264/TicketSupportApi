using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TS.BL;
using TS.DAL.Models;

namespace TicketSupport.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService userService;

        public UserController(UserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(userService.GetAll().Select(x=>new UserInfo
            {
                Id = x.Id,
                Name = x.Name,
                RoleId = x.RoleId,
                UserName = x.UserName
            }));
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            var user = await userService.GetUserByCredentials(userForLoginDto.UserName.ToLower(), userForLoginDto.Password);
            if (user == null) return BadRequest(new { message = "Username or password is not correct!" });
            var claims = new[]{
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Name,user.UserName)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mohamedmedhatmohamed123456"));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddHours(8),
                SigningCredentials = cred
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return Ok(new
            {
                access_token = tokenHandler.WriteToken(token),
                UserInfo = new UserInfo
                {
                    Id = user.Id,
                    Name = user.Name,
                    UserName = user.UserName,
                    RoleId = user.RoleId
                }
            });
        }
    }
}