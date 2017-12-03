using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rewards.Models;
using Rewards.Services.Interfaces;

namespace Rewards.Controllers
{
    [Route("api/[controller]")]
    public class RewardsDataController : Controller
    {
        private readonly IRewardsService _rewardsService;

        public RewardsDataController(IRewardsService rewardsService)
        {
            _rewardsService = rewardsService;
        }

        [HttpGet("[action]")]
        public RewardDataModel Rewards(int pageNumber)
        {
            var rewardData = _rewardsService.GetRewards(pageNumber);

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
    }
}
