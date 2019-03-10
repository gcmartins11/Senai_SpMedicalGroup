using Microsoft.AspNetCore.Mvc;
using SpMedicalGroup.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CredenciaisController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {
                return Ok(ctx.Credenciais.ToList());
            }
        }

    }
}
