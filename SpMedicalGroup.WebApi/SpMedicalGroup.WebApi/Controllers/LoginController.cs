using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SpMedicalGroup.WebApi.Domains;
using SpMedicalGroup.WebApi.Interfaces;
using SpMedicalGroup.WebApi.Repositorys;
using SpMedicalGroup.WebApi.ViewModel;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SpMedicalGroup.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private IUsuariosRepository UsuarioRepository { get; set; }

        public LoginController()
        {
            UsuarioRepository = new UsuariosRepository();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            try
            {
                Usuarios usuarioBuscado = UsuarioRepository.BuscarEmailSenha(login.Email, login.Senha);

                if (usuarioBuscado == null)
                {
                    return NotFound(new
                    {
                        mensagem = "Email ou senha inválido"
                    });
                }


                //Define os dados que serão fornecidos no token - PayLoad
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.Id.ToString()),
                    new Claim(ClaimTypes.Role, usuarioBuscado.IdCredencial.ToString()),
                    new Claim("teste", "laranja")
                };

                // Chave de acesso do token
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("SpMedGroup.WebApi"));

                //Credenciais do Token - Header
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                //Gera o token
                var token = new JwtSecurityToken(
                    issuer: "SpMedGroup.WebApi",
                    audience: "SpMedGroup.WebApi",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds
                );

                //Retorna Ok com o Token
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
