using AutoMapper;
using ControleEstoqueAPI.Dtos;
using ControleEstoqueAPI.Models;
using ControleEstoqueAPI.Repositories;

namespace ControleEstoqueAPI.Services
{
    public class SaidaEstoqueService : ISaidaEstoqueService
    {
        private readonly ISaidaEstoqueRepository _repository;
        private readonly IEntradaEstoqueRepository _entradaRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;

        public SaidaEstoqueService(
            ISaidaEstoqueRepository repository,
            IEntradaEstoqueRepository entradaRepository,
            IProdutoRepository produtoRepository,
            IMapper mapper)
        {
            _repository = repository;
            _entradaRepository = entradaRepository;
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SaidaEstoqueDto>> GetAllAsync()
        {
            var saidas = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<SaidaEstoqueDto>>(saidas);
        }

        public async Task<SaidaEstoqueDto?> GetByIdAsync(int id)
        {
            var saida = await _repository.GetByIdAsync(id);
            return saida == null ? null : _mapper.Map<SaidaEstoqueDto>(saida);
        }

        public async Task<SaidaEstoqueDto> CreateAsync(CreateSaidaEstoqueDto dto)
        {
            // Localiza a entrada pelo número de série
            var entrada = await _entradaRepository.GetByNumeroSerieAsync(dto.NumeroSerie);
            if (entrada == null || !entrada.Disponivel)
                throw new Exception("Produto não disponível no estoque.");

            var produto = await _produtoRepository.GetByIdAsync(dto.ProdutoId);
            if (produto == null)
                throw new Exception("Produto não encontrado.");

            entrada.Disponivel = false;

            var saida = _mapper.Map<SaidaEstoque>(dto);
            saida.DataSaida = DateTime.Now;

            await _repository.AddAsync(saida);

            return _mapper.Map<SaidaEstoqueDto>(saida);
        }
    }
}
