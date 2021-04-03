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
    public class CategoriaController : ControllerBase
    {
        private ICategoriaService _categoriaService;

        private readonly ILogger<CategoriaController> _logger;

        public CategoriaController(ILogger<CategoriaController> logger, ICategoriaService categoriaService)
        {
            _logger = logger;
            _categoriaService = categoriaService;
        }

        [HttpGet("listaCategoria/{idCategoria}")]
        public IActionResult Get(int id)
        {
            var categoria = _categoriaService.FindById(id);
            if (categoria == null) return NotFound();
            return Ok(categoria);
        }

        [HttpGet("listaCategoria")]
        public IActionResult GetAll()
        {
            return Ok(_categoriaService.FindAll());
        }

        [HttpPost]
        public IActionResult Post([FromBody] Categoria categoria)
        {
            if (categoria == null) return BadRequest();
            return Ok(_categoriaService.Create(categoria));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Categoria categoria)
        {
            if (categoria == null) return BadRequest();
            return Ok(_categoriaService.Update(categoria));
        }

        [HttpDelete("listaCategoria/{idCategoria}")]
        public IActionResult Delete(int id)
        {
            _categoriaService.Delete(id);
            return NoContent();
        }

    }
}
