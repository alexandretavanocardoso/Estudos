using APICatalogo.Models;
using AutoMapper;

namespace ApiCatalogo.Dtos.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Produto, ProdutoDto>().ReverseMap();
        }
    }
}
