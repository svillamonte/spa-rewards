using System;
using System.Collections.Generic;

namespace Rewards.Services
{
    public class Reward
    {
        public string Id { get; set; }

        public string AccountId { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Title { get; set; }

        public string Terms { get; set; }

        public int PointsRequired { get; set; }

        public int DiscountAmount { get; set; }

        public string DiscountType { get; set; }

        public bool IsOnline { get; set; }

        public int ClaimedCount { get; set; }

        public int RedeemedCount { get; set; }
    }
}
