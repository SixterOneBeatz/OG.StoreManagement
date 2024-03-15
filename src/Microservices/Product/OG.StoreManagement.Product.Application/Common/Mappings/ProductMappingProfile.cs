using AutoMapper;
using OG.StoreManagement.Core.DTOs;
using OG.StoreManagement.Core.Entities;

namespace OG.StoreManagement.Product.Application.Common.Mappings
{
    internal class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<ProductDTO, ProductEntity>().ReverseMap();
        }
    }
}
