using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using Rewards.Controllers;
using Rewards.Services;
using Rewards.Services.Interfaces;
using Rewards.Services.Models;
using Xunit;

namespace Rewards.Tests.Controllers
{
    public class RewardsDataControllerTests
    {
        private readonly Mock<IRewardsService> _mockRewardsService;
        private readonly RewardsDataController _rewardsDataController;

        public RewardsDataControllerTests()
        {
            _mockRewardsService = new Mock<IRewardsService>();
            _rewardsDataController = new RewardsDataController(_mockRewardsService.Object);
        }

        [Fact]
        public void Rewards()
        {
            // Arrange
            var rewardOne = new Reward { Title = "Reward one" };
            var rewardTwo = new Reward { Title = "Reward two" };
            var rewardThree = new Reward { Title = "Reward three" };

            var rewardData = new RewardData
            {
                PaginationData = new PaginationData { TotalRecords = 10, PageSize = 5 },
                Rewards = new List<Reward> { rewardOne, rewardTwo, rewardThree }
            };

            _mockRewardsService
                .Setup(x => x.GetRewards(It.IsAny<int>()))
                .Returns(rewardData);

            // Act
            var result = _rewardsDataController.Rewards(It.IsAny<int>());

            // Assert
            Assert.Equal(rewardOne.Title, result.Rewards.ElementAt(0).Title);
            Assert.Equal(rewardTwo.Title, result.Rewards.ElementAt(1).Title);
            Assert.Equal(rewardThree.Title, result.Rewards.ElementAt(2).Title);
            Assert.Equal(rewardData.PaginationData.TotalRecords, result.PaginationData.TotalRecords);
            Assert.Equal(rewardData.PaginationData.PageSize, result.PaginationData.PageSize);
        }
    }
}
