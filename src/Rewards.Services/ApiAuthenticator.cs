using System;
using RestSharp;
using RestSharp.Authenticators;

namespace Rewards.Services
{
    public class ApiAuthenticator : IAuthenticator
    {
        public void Authenticate(IRestClient client, IRestRequest request)
        {
            request.AddHeader("Authorization", "ApiKey hu0BgORHLmFGYbsJpY8vUuSIoa9aBc");
        }
    }
}
