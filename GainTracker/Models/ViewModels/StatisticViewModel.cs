using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GainTracker.Models.ViewModels
{
    public class StatisticViewModel
    {
        public string Type { get; set; }
        public DateTime Time { get; set; }
        [Display(Name = "IP Address")]
        public string IPAddress { get; set; }
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Display(Name = "E-Mail Address")]
        public string Email { get; set; }
    }
}