using System;
using System.Collections.Generic;

namespace Rewards.Services.Models
{
    public class RewardData
    {
        public List<Reward> Rewards { get; set; }

        public PaginationData PaginationData { get; set; }
    }
}
