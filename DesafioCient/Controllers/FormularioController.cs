using DesafioCient.Business;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioCient.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class FormularioController : ControllerBase
    {
        private readonly FormularioBusiness _formularioBusiness;
        public FormularioController(FormularioBusiness formularioBusiness)
        {
            _formularioBusiness = formularioBusiness;
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]string cnpj)
        {
            try
            {
                return Ok(await _formularioBusiness.ListarEmpresas(cnpj));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        } 
        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var formulario = await _formularioBusiness.BuscarPorId(id);
                if (formulario == null) return NotFound();
                return Ok();
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
