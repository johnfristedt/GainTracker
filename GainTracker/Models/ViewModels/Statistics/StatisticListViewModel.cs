using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GainTracker.Models.ViewModels
{
    public class StatisticListViewModel
    {
        public List<StatisticListRowViewModel> Rows { get; set; }
        public List<string> GraphLabels { get; set; }

        public void Initialize()
        {
            foreach (var item in Rows)
            {
                GraphLabels.Add(item.Date.ToString("yyyy-MM-dd"));
            }
        }
    }
}