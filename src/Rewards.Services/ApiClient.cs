using System;
using RestSharp;
using Rewards.Services;
using Rewards.Services.Interfaces;

namespace Rewards.Services
{
    public class ApiClient : RestClient, IApiClient
    {
        public ApiClient() : base("https://loyalty.collectapps.io/api/v1/")
        {            
        }
        
        public IRestResponse<T> Retrieve<T>(IRestRequest request) where T : new()
        {
            Authenticator = new ApiAuthenticator();
            return Execute<T>(request);
        }        
    }
}
