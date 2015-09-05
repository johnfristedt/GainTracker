using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GainTracker.Models.EntityModels
{
    public class Statistic
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public DateTime Time { get; set; }
        public string IPAddress { get; set; }
    }
}