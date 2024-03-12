using static OG.StoreManagement.Core.Consts.HttpClientConsts;

namespace OG.StoreManagement.Core.Services
{
    public interface IRestClientService
    {
        Task<T> GetAsync<T>(MicroServices microservice, string endpoint);
        Task<T> PostAsync<T, U>(MicroServices microservice, string endpoint, U body);
    }
}
