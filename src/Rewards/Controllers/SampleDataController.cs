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
        public RewardDataModel Rewards(int pageNumber)
        {
            var service = new RewardsService();
            var rewardData = service.GetRewards(pageNumber);

            var rewardModels = rewardData.Rewards.Select(x => new RewardModel
            {
                Id = x.Id,
                DateCreatedFormatted = x.CreatedAt.ToShortDateString(),
                Title = x.Title,
                DiscountType = x.DiscountType
            });

            return new RewardDataModel
            {
                Rewards = rewardModels,
                PaginationData = new PaginationModel 
                {
                    TotalRecords = rewardData.PaginationData.TotalRecords,
                    PageSize = rewardData.PaginationData.PageSize
                }
            };
        }

        public class RewardDataModel
        {
            public IEnumerable<RewardModel> Rewards { get; set; }

            public PaginationModel PaginationData { get; set; }
        }

        public class PaginationModel
        {
            public int TotalRecords { get; set; }

            public int PageSize { get; set; }
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
