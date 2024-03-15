using AutoMapper;
using MediatR;
using OG.StoreManagement.Core.DTOs;
using OG.StoreManagement.Core.Entities;
using OG.StoreManagement.Core.Services;
using OG.StoreManagement.Product.Application.Common.Interfaces;
using static OG.StoreManagement.Core.Consts.QueueConsts;

namespace OG.StoreManagement.Product.Application.Features.Commands
{
    public class AddProductCommand(ProductDTO product) : IRequest<Unit>
    {
        public ProductDTO Product { get; set; } = product;
    }

    internal class AddProductCommandHandler(IServiceBus serviceBus, IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<AddProductCommand, Unit>
    {
        private readonly IServiceBus _serviceBus = serviceBus;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;

        public async Task<Unit> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var product = request.Product;

            var entity = _mapper.Map<ProductEntity>(product);

            product.ProductId = await _unitOfWork.ProductRepository.Add(entity);

            _unitOfWork.Commit();

            _serviceBus.Publish(QueueEnum.Inventory, product);

            return await Unit.Task;
        }
    }
}
