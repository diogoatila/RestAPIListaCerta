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
    public class MarcaController : ControllerBase
    {
        private IMarcaService _marcaService;

        private readonly ILogger<MarcaController> _logger;

        public MarcaController(ILogger<MarcaController> logger, IMarcaService marcaService)
        {
            _logger = logger;
            _marcaService = marcaService;
        }

        [HttpGet("listaMarca/{idMarca}")]
        public IActionResult Get(int id)
        {
            var marca = _marcaService.FindById(id);
            if (marca == null) return NotFound();
            return Ok(marca);
        }

        [HttpGet("listaMarca")]
        public IActionResult GetAll()
        {
            return Ok(_marcaService.FindAll());
        }

        [HttpPost]
        public IActionResult Post([FromBody] Marca marca)
        {
            if (marca == null) return BadRequest();
            return Ok(_marcaService.Create(marca));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Marca marca)
        {
            if (marca == null) return BadRequest();
            return Ok(_marcaService.Update(marca));
        }

        [HttpDelete("listaMarca/{idMarca}")]
        public IActionResult Delete(int id)
        {
            _marcaService.Delete(id);
            return NoContent();
        }

    }
}
