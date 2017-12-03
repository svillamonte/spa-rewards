using System;
using System.Collections.Generic;
using RestSharp;
using Rewards.Services.Interfaces;
using Rewards.Services.Models;

namespace Rewards.Services
{
    public class RewardsService : IRewardsService
    {
        private readonly IApiClient _apiClient;

        public RewardsService(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public RewardData GetRewards(int pageNumber)
        {
            var request = new RestRequest("rewards", Method.GET);
            request.AddParameter("PageNumber", pageNumber);
            request.AddParameter("PageSize", 5);

            var response = _apiClient.Retrieve<RewardData>(request);
            return response.Data;
        }
    }
}
