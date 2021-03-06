using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestAPIListaCerta.Models;
using RestAPIListaCerta.Services;


namespace RestAPIListaCerta.Controllers
{
    [ApiController]
    [Authorize("Bearer")]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private IClienteService _clienteService;
     
        private readonly ILogger<ClienteController> _logger;

        public ClienteController(ILogger<ClienteController> logger, IClienteService clienteService)
        {
            _logger = logger;
            _clienteService = clienteService;
        }

        [HttpGet ("listaCliente/{idCliente}")]
        public IActionResult Get(int id)
        {
            var cliente = _clienteService.FindById(id);
            if (cliente == null) return NotFound();
            return Ok(cliente);
        }

        [HttpGet("listaCliente")]
        public IActionResult GetAll()
        {
            return Ok(_clienteService.FindAll());
        }

        [HttpPost]
        public IActionResult Post([FromBody] Cliente cliente)
        {
            if (cliente == null) return BadRequest();
            return Ok(_clienteService.Create(cliente));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Cliente cliente)
        {
            if (cliente == null) return BadRequest();
            return Ok(_clienteService.Update(cliente));
        }

        [HttpDelete("listaCliente/{idCliente}")]
        public IActionResult Delete(int id)
        {
            _clienteService.Delete(id);
            return NoContent();
        }

    }
}
