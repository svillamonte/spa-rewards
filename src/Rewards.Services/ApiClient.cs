using System;
using RestSharp;
using Rewards.Services;

namespace Rewards.Services
{
    public class ApiClient : RestClient
    {
        public ApiClient() : base("https://loyalty.collectapps.io/api/v1/")
        {            
        }
        
        public override IRestResponse Execute(IRestRequest request)
        {
            Authenticator = new ApiAuthenticator();
            return base.Execute(request);
        }        
    }
}
