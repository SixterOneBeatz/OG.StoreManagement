using static OG.StoreManagement.Core.Consts.QueueConsts;

namespace OG.StoreManagement.Core.Services
{
    public interface IServiceBus
    {
        void Publish<T>(QueueEnum queue, T message);
    }
}
