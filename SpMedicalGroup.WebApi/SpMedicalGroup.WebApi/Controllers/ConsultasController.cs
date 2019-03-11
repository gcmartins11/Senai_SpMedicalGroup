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

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(ConsultasRepository.Listar());
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }

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
