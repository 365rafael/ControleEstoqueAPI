using ControleEstoqueAPI.Dtos;
using ControleEstoqueAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ControleEstoqueAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorService _service;

        public FornecedorController(IFornecedorService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FornecedorDto>>> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FornecedorDto>> GetById(int id)
        {
            var fornecedor = await _service.GetByIdAsync(id);
            if (fornecedor == null) return NotFound();
            return Ok(fornecedor);
        }

        [HttpPost]
        public async Task<ActionResult<FornecedorDto>> Create(CreateFornecedorDto dto)
        {
            var fornecedor = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = fornecedor.FornecedorId }, fornecedor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CreateFornecedorDto dto)
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
