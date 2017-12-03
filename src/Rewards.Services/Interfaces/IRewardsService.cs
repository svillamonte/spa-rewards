namespace Rewards.Services.Interfaces
{
    public interface IRewardsService
    {
        RewardData GetRewards(int pageNumber);
    }
}