using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GainTracker.Models.ViewModels
{
    public class CreateDataPointViewModel
    {
        [Required]
        public int TrackedDataId { get; set; }
        [Required]
        [Display(Name="New value")]
        public int Value { get; set; }
    }
}