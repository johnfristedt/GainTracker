using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GainTracker.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name="User Name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage="Does not match Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage="Passwords don't match")]
        [Display(Name="Repeat Password")]
        public string VerifyPassword { get; set; }

        [Required(ErrorMessage="Enter a valid e-mail address")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Enter a valid e-mail address")]
        [Display(Name="E-Mail address")]
        public string Email { get; set; }
    }
}