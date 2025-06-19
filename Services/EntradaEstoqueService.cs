using AutoMapper;
using ControleEstoqueAPI.Dtos;
using ControleEstoqueAPI.Models;
using ControleEstoqueAPI.Repositories;

namespace ControleEstoqueAPI.Services
{
    public class EntradaEstoqueService : IEntradaEstoqueService
    {
        private readonly IEntradaEstoqueRepository _repository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;

        public EntradaEstoqueService(
            IEntradaEstoqueRepository repository,
            IProdutoRepository produtoRepository,
            IMapper mapper)
        {
            _repository = repository;
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EntradaEstoqueDto>> GetAllAsync()
        {
            var entradas = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<EntradaEstoqueDto>>(entradas);
        }

        public async Task<EntradaEstoqueDto?> GetByIdAsync(int id)
        {
            var entrada = await _repository.GetByIdAsync(id);
            return entrada == null ? null : _mapper.Map<EntradaEstoqueDto>(entrada);
        }

        public async Task<EntradaEstoqueDto> CreateAsync(CreateEntradaEstoqueDto dto)
        {
            // Verificar se número de série já existe
            var existente = await _repository.GetByNumeroSerieAsync(dto.NumeroSerie);
            if (existente != null)
                throw new Exception("Número de série já cadastrado.");

            var produto = await _produtoRepository.GetByIdAsync(dto.ProdutoId);
            if (produto == null)
                throw new Exception("Produto não encontrado.");

            var entrada = _mapper.Map<EntradaEstoque>(dto);
            entrada.Disponivel = true;
            entrada.DataEntrada = DateTime.Now;

            await _repository.AddAsync(entrada);

            return _mapper.Map<EntradaEstoqueDto>(entrada);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entrada = await _repository.GetByIdAsync(id);
            if (entrada == null) return false;

            await _repository.DeleteAsync(entrada);
            return true;
        }
    }
}
