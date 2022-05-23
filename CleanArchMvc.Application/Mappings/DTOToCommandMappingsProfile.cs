using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Products.Commands;

namespace CleanArchMvc.Application.Mappings
{
    public class DTOToCommandMappingsProfile : Profile
    {
        public DTOToCommandMappingsProfile()
        {
            CreateMap<ProductDTO, ProductCreateCommand>();
            CreateMap<ProductDTO, ProductUpdateCommand>();
        }
    }
}
