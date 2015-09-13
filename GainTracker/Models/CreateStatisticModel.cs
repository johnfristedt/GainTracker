using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GainTracker.Models
{
    public class CreateStatisticModel
    {
        public int Type { get; set; }
        public DateTime Time { get; set; }
        public string IPAddress { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}