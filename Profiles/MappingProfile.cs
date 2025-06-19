using AutoMapper;
using ControleEstoqueAPI.Dtos;
using ControleEstoqueAPI.Models;

namespace ControleEstoqueAPI.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Fornecedor, FornecedorDto>().ReverseMap();
            CreateMap<CreateFornecedorDto, Fornecedor>();

            CreateMap<Produto, ProdutoDto>()
                .ForMember(dest => dest.FornecedorNome, opt => opt.MapFrom(src => src.Fornecedor.Nome));
            CreateMap<CreateProdutoDto, Produto>();

            CreateMap<EntradaEstoque, EntradaEstoqueDto>()
                .ForMember(dest => dest.ProdutoNome, opt => opt.MapFrom(src => src.Produto.Nome));
            CreateMap<CreateEntradaEstoqueDto, EntradaEstoque>();

            CreateMap<SaidaEstoque, SaidaEstoqueDto>()
                .ForMember(dest => dest.ProdutoNome, opt => opt.MapFrom(src => src.Produto.Nome));
            CreateMap<CreateSaidaEstoqueDto, SaidaEstoque>();
        }
    }
}
