using AutoMapper;
using MyPlace.Negocios;
using MyPlace.ViewModels;

namespace MyPlace.Config
{
    public class AutoMapperConfig : Profile{
        
        public AutoMapperConfig()
        {
            CreateMap<Produto, ProdutoViewModel>().ReverseMap();
            CreateMap<Fornecedor, FornecedorViewModel>().ReverseMap();
            CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
        }

    }
}