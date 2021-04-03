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
    public class ListaController : ControllerBase
    {
        private IListaService _listaService;

        private readonly ILogger<ListaController> _logger;

        public ListaController(ILogger<ListaController> logger, IListaService listaService)
        {
            _logger = logger;
            _listaService = listaService;
        }

        [HttpGet("listaLista/{idLista}")]
        public IActionResult Get(int id)
        {
            var lista = _listaService.FindById(id);
            if (lista == null) return NotFound();
            return Ok(lista);
        }

        [HttpGet("listaLista")]
        public IActionResult GetAll()
        {
            return Ok(_listaService.FindAll());
        }

        [HttpPost]
        public IActionResult Post([FromBody] Lista lista)
        {
            if (lista == null) return BadRequest();
            return Ok(_listaService.Create(lista));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Lista lista)
        {
            if (lista == null) return BadRequest();
            return Ok(_listaService.Update(lista));
        }

        [HttpDelete("listaLista/{idLista}")]
        public IActionResult Delete(int id)
        {
            _listaService.Delete(id);
            return NoContent();
        }

    }
}
