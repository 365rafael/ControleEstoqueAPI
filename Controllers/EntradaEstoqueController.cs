using ControleEstoqueAPI.Dtos;
using ControleEstoqueAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ControleEstoqueAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntradaEstoqueController : ControllerBase
    {
        private readonly IEntradaEstoqueService _service;

        public EntradaEstoqueController(IEntradaEstoqueService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EntradaEstoqueDto>>> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EntradaEstoqueDto>> GetById(int id)
        {
            var entrada = await _service.GetByIdAsync(id);
            if (entrada == null) return NotFound();
            return Ok(entrada);
        }

        [HttpPost]
        public async Task<ActionResult<EntradaEstoqueDto>> Create(CreateEntradaEstoqueDto dto)
        {
            try
            {
                var entrada = await _service.CreateAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = entrada.EntradaEstoqueId }, entrada);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
