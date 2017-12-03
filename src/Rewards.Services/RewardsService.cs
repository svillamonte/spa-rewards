using System;
using System.Collections.Generic;
using RestSharp;
using Rewards.Services;

namespace Rewards.Services
{
    public class RewardsService
    {
        public List<Reward> GetRewards()
        {
            var apiClient = new ApiClient();
            var request = new RestRequest("rewards", Method.GET);

            var response = apiClient.Execute<RewardData>(request);
            return response.Data.Rewards;
        }
    }
}
