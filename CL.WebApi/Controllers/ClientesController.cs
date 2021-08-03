using CL.Core.Domain;
using CL.Core.Shared.ModelViews;
using CL.Manager.Interfaces;
using CL.Manager.Validator;
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

        // GET: api/<ClientesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await clienteManager.GetClientesAsync());
        }

        // GET api/<ClientesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int Id_Cliente)
        {
            return Ok(await clienteManager.GetClienteAsync(Id_Cliente));
        }

        // POST api/<ClientesController>
        [HttpPost]
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

        // PUT api/<ClientesController>/5
        [HttpPut]
        public async Task<IActionResult> Put(AlteraCliente alteraCliente)
        {
            var clienteAtualizado = await clienteManager.UpdateClienteAsync(alteraCliente);
            if (clienteAtualizado == null)
            {
                return NotFound();
            }
            return Ok(clienteAtualizado);
        }

        // DELETE api/<ClientesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int Id_Cliente)
        {
            await clienteManager.DeleteClienteAsync(Id_Cliente);
            return NoContent();
        }
    }
}
