using AutoMapper;
using ControleEstoqueAPI.Dtos;
using ControleEstoqueAPI.Models;
using ControleEstoqueAPI.Repositories;

namespace ControleEstoqueAPI.Services
{
    public class FornecedorService : IFornecedorService
    {
        private readonly IFornecedorRepository _repository;
        private readonly IMapper _mapper;

        public FornecedorService(IFornecedorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FornecedorDto>> GetAllAsync()
        {
            var fornecedores = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<FornecedorDto>>(fornecedores);
        }

        public async Task<FornecedorDto?> GetByIdAsync(int id)
        {
            var fornecedor = await _repository.GetByIdAsync(id);
            return fornecedor == null ? null : _mapper.Map<FornecedorDto>(fornecedor);
        }

        public async Task<FornecedorDto> CreateAsync(CreateFornecedorDto dto)
        {
            var fornecedor = _mapper.Map<Fornecedor>(dto);
            await _repository.AddAsync(fornecedor);
            return _mapper.Map<FornecedorDto>(fornecedor);
        }

        public async Task<bool> UpdateAsync(int id, CreateFornecedorDto dto)
        {
            var fornecedor = await _repository.GetByIdAsync(id);
            if (fornecedor == null) return false;

            _mapper.Map(dto, fornecedor);
            await _repository.UpdateAsync(fornecedor);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var fornecedor = await _repository.GetByIdAsync(id);
            if (fornecedor == null) return false;

            await _repository.DeleteAsync(fornecedor);
            return true;
        }
    }
}
