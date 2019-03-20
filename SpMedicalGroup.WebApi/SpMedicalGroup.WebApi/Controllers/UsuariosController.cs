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
    public class UsuariosController : ControllerBase
    {
        private IUsuariosRepository UsuarioRepository { get; set; }

        public UsuariosController()
        {
            UsuarioRepository = new UsuariosRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                using (SpMedGroupContext ctx = new SpMedGroupContext())
                {
                    return Ok(UsuarioRepository.Listar());
                }
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public IActionResult Post(Usuarios usuario)
        {
            try
            {

                if(usuario.IdCredencial < 1 || usuario.IdCredencial > 3)
                {
                    return BadRequest(new
                    {
                        mensagem = "Insira uma credencial válida",
                    });
                }

                UsuarioRepository.Cadastrar(usuario);

                return Ok();
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
                return Ok(UsuarioRepository.GetById(id));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
