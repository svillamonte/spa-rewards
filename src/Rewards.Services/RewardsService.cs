using System;
using RestSharp;
using Rewards.Services;

namespace Rewards.Services
{
    public class RewardsService
    {
        public string GetRewards()
        {
            var apiClient = new ApiClient();
            var request = new RestRequest("rewards", Method.GET);

            var response = apiClient.Execute(request);
            return response.Content;
        }
    }
}
