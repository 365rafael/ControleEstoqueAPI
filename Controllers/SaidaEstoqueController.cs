using ControleEstoqueAPI.Dtos;
using ControleEstoqueAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ControleEstoqueAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaidaEstoqueController : ControllerBase
    {
        private readonly ISaidaEstoqueService _service;

        public SaidaEstoqueController(ISaidaEstoqueService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SaidaEstoqueDto>>> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SaidaEstoqueDto>> GetById(int id)
        {
            var saida = await _service.GetByIdAsync(id);
            if (saida == null) return NotFound();
            return Ok(saida);
        }

        [HttpPost]
        public async Task<ActionResult<SaidaEstoqueDto>> Create(CreateSaidaEstoqueDto dto)
        {
            try
            {
                var saida = await _service.CreateAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = saida.SaidaEstoqueId }, saida);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
