using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpMedicalGroup.WebApi.Domains;
using SpMedicalGroup.WebApi.Interfaces;
using SpMedicalGroup.WebApi.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.WebApi.Controllers
{
    [Authorize(Roles = "Administrador")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicasController : ControllerBase
    {

        private IClinicasRepository ClinicasRepository { get; set; }

        public ClinicasController()
        {
            ClinicasRepository = new ClinicasRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(ClinicasRepository.Listar());
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(ClinicasRepository.GetById(id));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Route("Medicos")]
        [HttpGet]
        public IActionResult GetComMedicos()
        {
            try
            {
                return Ok(ClinicasRepository.ListarComMedicos());
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public IActionResult Post(Clinicas clinica)
        {
            try
            {
                ClinicasRepository.Cadastrar(clinica);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        public IActionResult Put(Clinicas clinica)
        {
            try
            {
                ClinicasRepository.Atualizar(clinica);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
