using AutoMapper;
using ControleEstoqueAPI.Dtos;
using ControleEstoqueAPI.Models;
using ControleEstoqueAPI.Repositories;

namespace ControleEstoqueAPI.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _repository;
        private readonly IMapper _mapper;

        public ProdutoService(IProdutoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProdutoDto>> GetAllAsync()
        {
            var produtos = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProdutoDto>>(produtos);
        }

        public async Task<ProdutoDto?> GetByIdAsync(int id)
        {
            var produto = await _repository.GetByIdAsync(id);
            return produto == null ? null : _mapper.Map<ProdutoDto>(produto);
        }

        public async Task<ProdutoDto> CreateAsync(CreateProdutoDto dto)
        {
            var produto = _mapper.Map<Produto>(dto);
            await _repository.AddAsync(produto);
            return _mapper.Map<ProdutoDto>(produto);
        }

        public async Task<bool> UpdateAsync(int id, CreateProdutoDto dto)
        {
            var produto = await _repository.GetByIdAsync(id);
            if (produto == null) return false;

            _mapper.Map(dto, produto);
            await _repository.UpdateAsync(produto);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var produto = await _repository.GetByIdAsync(id);
            if (produto == null) return false;

            await _repository.DeleteAsync(produto);
            return true;
        }
    }
}
