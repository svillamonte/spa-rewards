using System;
using System.Collections.Generic;
using RestSharp;
using Rewards.Services;

namespace Rewards.Services
{
    public class RewardsService
    {
        public RewardData GetRewards(int pageNumber)
        {
            var apiClient = new ApiClient();

            var request = new RestRequest("rewards", Method.GET);
            request.AddParameter("PageNumber", pageNumber);
            request.AddParameter("PageSize", 5);

            var response = apiClient.Execute<RewardData>(request);
            return response.Data;
        }
    }
}
