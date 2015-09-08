using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GainTracker.Models.ViewModels
{
    public class CreateTrackedDataViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [Display(Name="Name: ")]
        public string Name { get; set; }
    }
}