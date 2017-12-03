using RestSharp;

namespace Rewards.Services.Interfaces
{
    public interface IApiClient
    {
        IRestResponse<T> Retrieve<T>(IRestRequest request) where T : new();
    }
}