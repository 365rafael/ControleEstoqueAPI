using ControleEstoqueAPI.Dtos;
using ControleEstoqueAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ControleEstoqueAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _service;

        public ProdutoController(IProdutoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoDto>>> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoDto>> GetById(int id)
        {
            var produto = await _service.GetByIdAsync(id);
            if (produto == null) return NotFound();
            return Ok(produto);
        }

        [HttpPost]
        public async Task<ActionResult<ProdutoDto>> Create(CreateProdutoDto dto)
        {
            var produto = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = produto.ProdutoId }, produto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CreateProdutoDto dto)
        {
            var result = await _service.UpdateAsync(id, dto);
            if (!result) return NotFound();
            return NoContent();
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
