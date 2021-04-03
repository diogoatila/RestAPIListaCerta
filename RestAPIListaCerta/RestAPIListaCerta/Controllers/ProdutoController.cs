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
    public class ProdutoController : ControllerBase
    {
        
            private IProdutoService _produtoService;

            private readonly ILogger<ProdutoController> _logger;

            public ProdutoController(ILogger<ProdutoController> logger, IProdutoService produtoService)
            {
                _logger = logger;
                _produtoService = produtoService;
            }

            [HttpGet("listaProduto/{idProduto}")]
            public IActionResult Get(int id)
            {
                var produto = _produtoService.FindById(id);
                if (produto == null) return NotFound();
                return Ok(produto);
            }

            [HttpGet("listaProduto")]
            public IActionResult GetAll()
            {
                return Ok(_produtoService.FindAll());
            }

            [HttpPost]
            public IActionResult Post([FromBody] Produto produto)
            {
                if (produto == null) return BadRequest();
                return Ok(_produtoService.Create(produto));
            }

            [HttpPut]
            public IActionResult Put([FromBody] Produto produto)
            {
                if (produto == null) return BadRequest();
                return Ok(_produtoService.Update(produto));
            }

            [HttpDelete("listaProduto/{idProduto}")]
            public IActionResult Delete(int id)
            {
                _produtoService.Delete(id);
                return NoContent();
            }

        }
    }

