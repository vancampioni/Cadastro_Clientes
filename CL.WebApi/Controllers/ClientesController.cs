using CL.Core.Domain;
using CL.Core.Shared.ModelViews;
using CL.Manager.Interfaces;
using CL.Manager.Validator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CL.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteManager clienteManager;
        public ClientesController(IClienteManager clienteManager)
        {
            this.clienteManager = clienteManager;
        }

        /// <summary>
        /// Retorna todos os clientes cadastrados na base.
        /// </summary>

        [HttpGet]
        [ProducesResponseType(typeof(Cliente),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails),StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            return Ok(await clienteManager.GetClientesAsync());
        }

        /// <summary>
        /// Retorna um cliente consultado pelo Id
        /// </summary>
        /// <param name="Id_Cliente" example="123">Id do cliente.</param>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Cliente), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int Id_Cliente)
        {
            return Ok(await clienteManager.GetClienteAsync(Id_Cliente));
        }

        /// <summary>
        /// Insere um novo cliente.
        /// </summary>
        /// <param name="novoCliente"></param>
        [HttpPost]
        [ProducesResponseType(typeof(Cliente), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(NovoCliente novoCliente)
        {
            //ClienteValidator validator = new ClienteValidator();
            //var validation = validator.Validate(cliente);
            //if (validation.IsValid)
            //{
            //    var clienteInserido = await clienteManager.InsertClienteAsync(cliente);
            //    return CreatedAtAction(nameof(Get), new { Id_Cliente = cliente.Id_Cliente }, cliente);
            //} else
            //{
            //    return BadRequest(validation.ToString());
            //}
            var clienteInserido = await clienteManager.InsertClienteAsync(novoCliente);
                return CreatedAtAction(nameof(Get), new { Id_Cliente = clienteInserido.Id_Cliente }, clienteInserido);
        }

        /// <summary>
        /// Altera um cliente.
        /// </summary>
        /// <param name="alteraCliente"></param>
        [HttpPut]
        [ProducesResponseType(typeof(Cliente), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(AlteraCliente alteraCliente)
        {
            var clienteAtualizado = await clienteManager.UpdateClienteAsync(alteraCliente);
            if (clienteAtualizado == null)
            {
                return NotFound();
            }
            return Ok(clienteAtualizado);
        }

        /// <summary>
        /// Exclui um cliente.
        /// </summary>
        /// <param name="Id_Cliente" example="123"></param>
        /// <remarks>Ao excluir um cliente, o registro será removido permanentemente da base.</remarks>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Cliente), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int Id_Cliente)
        {
            await clienteManager.DeleteClienteAsync(Id_Cliente);
            return NoContent();
        }
    }
}
