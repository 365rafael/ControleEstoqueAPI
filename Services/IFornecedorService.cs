using ControleEstoqueAPI.Dtos;

namespace ControleEstoqueAPI.Services
{
    public interface IFornecedorService
    {
        Task<IEnumerable<FornecedorDto>> GetAllAsync();
        Task<FornecedorDto?> GetByIdAsync(int id);
        Task<FornecedorDto> CreateAsync(CreateFornecedorDto dto);
        Task<bool> UpdateAsync(int id, CreateFornecedorDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
