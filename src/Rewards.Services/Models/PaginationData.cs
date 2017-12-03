using System;
using System.Collections.Generic;

namespace Rewards.Services.Models
{
    public class PaginationData 
    {
        public int TotalRecords { get; set; }

        public int CurrentPage { get; set; }

        public int PageSize { get; set; }
    }
}
