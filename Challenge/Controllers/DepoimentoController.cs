using Challenge.Data.Dtos;
using Challenge.Models;
using Challenge.Services;
using Microsoft.AspNetCore.Mvc;

namespace Challenge.Controllers
{
    [Route("[controller]")]
    public class DepoimentoController : Controller
    {
        private DepoimentoService _depoimentoService;
        public DepoimentoController(DepoimentoService depoimentoService)
        {
            _depoimentoService = depoimentoService;
        }

        // Post
        [HttpPost]
        public async Task<IActionResult> AdicionaDepoimento([FromBody] CreateDepoimento dto)
        {
            await _depoimentoService.AdicionaDepoimento(dto);
            return Ok("Depoimento cadastrado.");
        }

        // Get 3 depoimentos aleatorios
        [HttpGet("aleatorio")]
        public async Task<IActionResult> RecuperaDepoimentoAleatorio()
        {
            Random rnd = new Random();
            var depoimentos = await _depoimentoService.RecuperaDepoimentos();
            var _resultSet = depoimentos.OrderBy(x => Guid.NewGuid()).Take(3);
            return Ok(_resultSet);
        }

        // Get 1 depoimento
        [HttpGet]
        public async Task<IActionResult> RecuperaDepoimento()
        {
            var depoimentos = await _depoimentoService.RecuperaDepoimentos();
            return Ok(depoimentos);
        }

        // Put atualiza um depoimento
        [HttpPut]
        public async Task<IActionResult> AtualizaDepoimento(UpdateDepoimento dto, int id)
        {
            await _depoimentoService.AtualizaDepoimento(dto, id);
            return NoContent();
        }

        // Delete exclui um depoimento
        [HttpDelete]
        public async Task<IActionResult> RemoveDepoimento(int id)
        {
            await _depoimentoService.RemoveDepoimento(id);
            return NoContent();
        }
    }
}