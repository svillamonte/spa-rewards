using System.Collections.Generic;

namespace Rewards.Models
{
    public class RewardDataModel
    {
        public IEnumerable<RewardModel> Rewards { get; set; }

        public PaginationModel PaginationData { get; set; }
    }
}