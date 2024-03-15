using AutoMapper;
using OG.StoreManagement.Core.DTOs;
using OG.StoreManagement.Core.Entities;

namespace OG.StoreManagement.Inventory.Application.Common.Mappings
{
    internal class InventoryMappingProfile : Profile
    {
        public InventoryMappingProfile()
        {
            CreateMap<ProductDTO, InventoryItemEntity>()
                .ForMember(t => t.Quantity, src => src.MapFrom(y => y.StockQuantity));
        }
    }
}
