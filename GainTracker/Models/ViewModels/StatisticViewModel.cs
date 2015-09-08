using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GainTracker.Models.ViewModels
{
    public class StatisticViewModel
    {
        public string Type { get; set; }
        public DateTime Time { get; set; }
        public string IPAddress { get; set; }
    }
}