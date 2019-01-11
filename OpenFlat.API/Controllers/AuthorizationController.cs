using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OpenFlat.API.Helpers;
using OpenFlat.API.Models;
using OpenFlat.API.Models.Dtos;

namespace OpenFlat.API.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("auth")]
    public class AuthorizationController : ControllerBase
    {
        private readonly AppSettings _appSettings;
        public AuthorizationController(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        [HttpPost("token")]
        public IActionResult GetToken([FromBody]LoginDto login)
        {
            using (var db = new FlatContext())
            {
                var usr = db.Users.SingleOrDefault(x => x.UserName == login.UserName && x.Password == login.Password);

                // return null if user not found
                if (usr == null)
                    return Unauthorized();

                // authentication successful so generate jwt token
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                        {
                            new Claim(ClaimTypes.Name, usr.Name),
                            new Claim(ClaimTypes.NameIdentifier, usr.Id.ToString()),
                        }),
                    Expires = DateTime.UtcNow.AddMinutes(_appSettings.TokenExpireMinute),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return Ok(tokenHandler.WriteToken(token));
            }
        }
    }
}
