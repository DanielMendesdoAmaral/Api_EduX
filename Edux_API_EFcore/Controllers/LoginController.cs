using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Edux_Api_EFcore.Contexts;
using Edux_Api_EFcore.Domains;
using Edux_Api_EFcore.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Edux_Api_EFcore.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class LoginController : ControllerBase
   {
       EduxContext _ctx = new EduxContext();

       private IConfiguration _config;

       public LoginController(IConfiguration config)
       {
           _config = config;
       }

       private Usuario AutenticarUsuario(Usuario login)
       {
           login.Senha = Criptografia.Criptografar(login.Senha, login.Email.Substring(0, 4));
           return _ctx
               .Usuarios
               .Include(u => u.Perfil)
               .FirstOrDefault(u => u.Email == login.Email && u.Senha == login.Senha);
        }

        private string GerarJWT(Usuario informacoesUsuario)
       {
           var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
           var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

           var claims = new[] {
               new Claim(JwtRegisteredClaimNames.NameId, informacoesUsuario.Nome),
               new Claim(JwtRegisteredClaimNames.Email, informacoesUsuario.Email),
               new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
               new Claim("role", informacoesUsuario.Perfil.Permissao),
               new Claim(ClaimTypes.Role, informacoesUsuario.Perfil.Permissao)
           };

           var token = new JwtSecurityToken
               (
                   _config["Jwt:Issuer"],
                   _config["Jwt:Issuer"],
                   claims,
                   expires: DateTime.Now.AddMinutes(120),
                   signingCredentials: credentials
               );

           return new JwtSecurityTokenHandler().WriteToken(token);
      }


        /// <summary>
        /// Faz o login do usuário
        /// </summary>
        /// <param name="login">Dados do usuário para fazer o login</param>
        /// <returns>Autorizado ou não</returns>
        [AllowAnonymous]
       [HttpPost]
       public IActionResult Login([FromBody] Usuario login)
       {
           IActionResult response = Unauthorized();

           var user = AutenticarUsuario(login);

           if (user != null)
           {
               var tokenString = GerarJWT(user);
               response = Ok(new { token = tokenString });
           }

           return response;
       }
   }
}
