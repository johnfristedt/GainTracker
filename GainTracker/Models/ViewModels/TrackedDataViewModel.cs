using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GainTracker.Models.ViewModels
{
    public class TrackedDataiewModel
    {
        [Required]
        public string Name { get; set; }
    }
}