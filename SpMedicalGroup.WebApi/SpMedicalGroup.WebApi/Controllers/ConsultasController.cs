using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpMedicalGroup.WebApi.Domains;
using SpMedicalGroup.WebApi.Interfaces;
using SpMedicalGroup.WebApi.Repositorys;
using SpMedicalGroup.WebApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [Authorize(Roles = "1, 2, 3")]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                if (ConsultasRepository.Listar() == null)
                {
                    return BadRequest();
                }

                return Ok(ConsultasRepository.Listar());
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Authorize(Roles = "1")]
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

        [Authorize(Roles = "1")]
        [Route("status")]
        [HttpPut]
        public IActionResult PutStatus(ConsultasViewModel consulta)
        {
            try
            {
                if(consulta.StatusConsulta > 3 || consulta.StatusConsulta < 1)
                {
                    return BadRequest("Status inválido");
                }

                ConsultasRepository.AtualizarStatus(consulta);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Authorize(Roles = "2")]
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
