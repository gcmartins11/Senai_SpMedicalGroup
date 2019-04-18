using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
    public class ConsultasController : ControllerBase
    {
        private IConsultasRepository ConsultasRepository { get; set; }

        public ConsultasController()
        {
            ConsultasRepository = new ConsultasRepository();
        }

        [Authorize(Roles = "Administrador, Medico, Paciente")]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                string credencial = HttpContext.User.Claims.First(x => x.Type == ClaimTypes.Role).Value;

                int idUsuario = Convert.ToInt32(
                    HttpContext.User.Claims.First(x => x.Type == JwtRegisteredClaimNames.Jti).Value
                    );

                List<ConsultasViewModel> listaConsultas = ConsultasRepository.Listar(credencial, idUsuario);

                return Ok(listaConsultas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public IActionResult Post(Consultas consulta)
        {
            try
            {
                ConsultasRepository.Cadastrar(consulta);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Authorize(Roles = "Administrador")]
        [Route("status")]
        [HttpPut]
        public IActionResult PutStatus(ConsultasViewModel consulta)
        {
            try
            {
                ConsultasRepository.AtualizarStatus(consulta);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Authorize(Roles = "Medico")]
        [Route("descricao")]
        [HttpPut]
        public IActionResult PutDescricao(ConsultasViewModel consulta)
        {
            try
            {
                ConsultasRepository.AtualizarDescricao(consulta);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
