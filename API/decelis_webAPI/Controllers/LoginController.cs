using decelis_webAPI.Domains;
using decelis_webAPI.Interfaces;
using decelis_webAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace decelis_webAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUserInfoRepository _userRepository { get; set; }
        public LoginController(IUserInfoRepository repo)
        {
            _userRepository = repo;
        }


        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            try
            {
                UserInfo userFetched = _userRepository.Login(login.Email, login.PasswordUser);
                if (userFetched == null)
                {
                    return BadRequest("E-mail ou senha inválidos!");
                }

                var MyClaim = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, userFetched.Email),
                    new Claim(JwtRegisteredClaimNames.Name, userFetched.NameUser),
                    new Claim(JwtRegisteredClaimNames.Jti, userFetched.IdUser.ToString()),
                    new Claim(ClaimTypes.Role, userFetched.IdUserType.ToString()),
                    new Claim( "role", userFetched.IdUserType.ToString() )
                };
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("DUoWyXzWbY-keyDecelis0127=3698"));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var myToken = new JwtSecurityToken(
                       issuer: "decelis_webAPI",
                       audience: "decelis_webAPI",
                       claims: MyClaim,
                       expires: DateTime.Now.AddMinutes(30),
                       signingCredentials: creds
                   );

                return Ok(
                    new
                    {
                        createdToken = new JwtSecurityTokenHandler().WriteToken(myToken)
                    });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
