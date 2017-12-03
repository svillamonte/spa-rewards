using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rewards.Services;

namespace Rewards.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        [HttpGet("[action]")]
        public IEnumerable<RewardModel> Rewards(int pageNumber)
        {
            var service = new RewardsService();
            var rewards = service.GetRewards(pageNumber);

            return rewards.Select(x => new RewardModel
            {
                Id = x.Id,
                DateCreatedFormatted = x.CreatedAt.ToShortDateString(),
                Title = x.Title,
                DiscountType = x.DiscountType
            });
        }

        public class RewardModel
        {
            public string Id { get; set; }

            public string DateCreatedFormatted { get; set; }
            
            public string Title { get; set; }

            public string DiscountType { get; set; }
        }
    }
}
