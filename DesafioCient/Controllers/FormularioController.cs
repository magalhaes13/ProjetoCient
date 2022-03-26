using DesafioCient.Business;
using DesafioCient.Dtos;
using Microsoft.AspNetCore.Http;
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(List<EmpresaDto>), 200)]
        public async Task<ActionResult<List<EmpresaDto>>> Listar([FromQuery] string cnpj)
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(EmpresaDto), 200)]
        public async Task<ActionResult<EmpresaDto>> BuscarPorId(Guid id)
        {
            try
            {
                var formulario = await _formularioBusiness.BuscarPorId(id);

                if (formulario == null)
                    return NotFound("Empresa não encontrada!");

                return Ok(formulario);
            }
            catch(Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(EmpresaDto), 200)]
        public async Task<ActionResult<EmpresaDto>> CadastrarEmpresa([FromBody] EmpresaDto empresa)
        {
            try
            {
                await _formularioBusiness.Cadastro(empresa);
                return Created("Cadastrado com sucesso!",empresa);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(EmpresaDto), 200)]
        public async Task<ActionResult<EmpresaDto>> AtualizarEmpresa([FromBody] EmpresaDto empresa)
        {
            try
            {
                await _formularioBusiness.Atualizar(empresa);
                return Ok(
                    new { 
                        message = "Atualizado com sucesso",
                        empresa = empresa
                    });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<EmpresaDto>> DeletarEmpresa(Guid id)
        {
            try
            {
                await _formularioBusiness.Deletar(id);

                return Ok(
                    new
                    {
                        message = "Excluido com sucesso!"
                    });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
