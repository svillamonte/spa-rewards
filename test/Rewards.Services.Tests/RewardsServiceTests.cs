using System;
using System.Collections.Generic;
using Moq;
using RestSharp;
using Rewards.Services.Interfaces;
using Rewards.Services.Models;
using Xunit;

namespace Rewards.Services.Tests
{
    public class RewardsServiceTests
    {
        private readonly Mock<IApiClient> _mockApiClient;
        private readonly IRewardsService _rewardsService;

        public RewardsServiceTests()
        {
            _mockApiClient = new Mock<IApiClient>();
            _rewardsService = new RewardsService(_mockApiClient.Object);
        }

        [Fact]
        public void GetRewards()
        {
            // Arrange
            var rewardOne = new Reward { Title = "Reward one" };
            var rewardTwo = new Reward { Title = "Reward two" };
            var rewardThree = new Reward { Title = "Reward three" };

            var rewardData = new RewardData
            {
                Rewards = new List<Reward>() { rewardOne, rewardTwo, rewardThree },
                PaginationData = new PaginationData()
            };

            var mockRestResponse = new Mock<IRestResponse<RewardData>>();
            mockRestResponse
                .Setup(x => x.Data)
                .Returns(rewardData);

            _mockApiClient
                .Setup(x => x.Retrieve<RewardData>(It.IsAny<RestRequest>()))
                .Returns(mockRestResponse.Object);

            // Act
            var result = _rewardsService.GetRewards(It.IsAny<int>());

            // Assert
            Assert.Equal(rewardData, result);
        }
    }
}
