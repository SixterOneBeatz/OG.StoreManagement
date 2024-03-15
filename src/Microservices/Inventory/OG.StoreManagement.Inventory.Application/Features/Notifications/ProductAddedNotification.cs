using AutoMapper;
using MediatR;
using OG.StoreManagement.Core.DTOs;
using OG.StoreManagement.Core.Entities;
using OG.StoreManagement.Inventory.Application.Common.Interfaces;

namespace OG.StoreManagement.Inventory.Application.Features.Events
{
    public class ProductAddedNotification(ProductDTO product) : INotification
    {
        public ProductDTO Product { get; set; } = product;
    }

    public class ProductAddedNotificationHandler(IUnitOfWork unitOfWork, IMapper mapper) : INotificationHandler<ProductAddedNotification>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;
        public async Task Handle(ProductAddedNotification notification, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<InventoryItemEntity>(notification.Product);

            await _unitOfWork.InventoryRepository.Add(entity);

            _unitOfWork.Commit();
        }
    }
}
