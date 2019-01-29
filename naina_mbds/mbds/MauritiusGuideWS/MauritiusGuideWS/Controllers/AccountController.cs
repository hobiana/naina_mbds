using MauritiusGuideWS.Dto;
using MauritiusGuideWS.Key;
using MauritiusGuideWS.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Data.Entity;
using System.Web.Http.Cors;

namespace MauritiusGuideWS.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*", exposedHeaders: "X-Custom-Header")]
    public class AccountController : ApiController
    {
        private GuideContext _context;
        public AccountController()
        {
            _context = new GuideContext();
        }

        [HttpPost]
        public IHttpActionResult Login(AccountDto account)
        {
            if (ModelState.IsValid)
            {
                var user = Check(account.Email, account.Password);
                if (user.Equals(null))
                {
                    return Unauthorized();
                }
                else
                {
                    var key = SecretKey.Key;
                    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

                    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

                    var header = new JwtHeader(credentials);

                    /*
                     iss = origin du token
                     iat = date de creation du token
                     */

                    var payload = new JwtPayload
                    {
                        { "iss ", "Mauritius Guide Server"},
                        { "iat", DateTime.Now.Millisecond },
                        { "Name", user.Name },
                        { "Language", user.Languages.Nom },
                        { "Role", user.Role.RoleName},
                        { "Id", user.ID}
                    };

                    var secToken = new JwtSecurityToken(header, payload);
                    var handler = new JwtSecurityTokenHandler();

                    var tokenString = handler.WriteToken(secToken);
                    return Ok(tokenString);
                }
            }
            return Unauthorized();
        }

        private User Check(string email,string pwd)
        {
            var users = _context.Users
                .Include(m => m.Role)
                .Include(m => m.Languages)
                .Where(m => m.Email.Equals(email))
                .Where(m => m.Pwd.Equals(pwd))
                .ToList();
            if (users.Count() == 1)
            {
                return users[0];
            }
            return null;
        }
    }
}
