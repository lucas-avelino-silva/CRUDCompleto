using AppMvcBasica.Models;
using AutoMapper;
using DevIO.App.ViewModels;

namespace DevIO.App.AutoMapper
{
    public class AutoMapperConfig: Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<FornecedorModel, FornecedorViewModel>().ReverseMap();
            CreateMap<ProdutosModel, ProdutoViewModel>().ReverseMap();
            CreateMap<EnderecosModel, EnderecoViewModel>().ReverseMap();
        }
    
    }
}
