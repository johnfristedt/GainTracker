using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GainTracker.Models.AjaxModels
{
    public class AddExerciseModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public int ExerciseId { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
    }
}