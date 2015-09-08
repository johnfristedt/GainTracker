using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GainTracker.Models.ViewModels
{
    public class CreateExerciseViewModel
    {
        [Required]
        [Display(Name="Name of new exercise")]
        public string Name { get; set; }
    }
}