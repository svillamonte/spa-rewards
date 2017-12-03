using Rewards.Services.Models;

namespace Rewards.Services.Interfaces
{
    public interface IRewardsService
    {
        RewardData GetRewards(int pageNumber);
    }
}