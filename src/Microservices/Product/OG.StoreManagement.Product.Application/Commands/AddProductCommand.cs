using MediatR;
using OG.StoreManagement.Core.DTOs;
using OG.StoreManagement.Core.Services;
using static OG.StoreManagement.Core.Consts.QueueConsts;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OG.StoreManagement.Product.Application.Commands
{
    public class AddProductCommand(ProductDTO product) : IRequest<Unit>
    {
        public ProductDTO Product { get; set; } = product;
    }

    internal class AddProductCommandHandler(IServiceBus serviceBus) : IRequestHandler<AddProductCommand, Unit>
    {
        private readonly IServiceBus _serviceBus = serviceBus;
        public async Task<Unit> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            _serviceBus.Publish(QueueEnum.Product, request.Product);

            return await Unit.Task;
        }
    }
}
