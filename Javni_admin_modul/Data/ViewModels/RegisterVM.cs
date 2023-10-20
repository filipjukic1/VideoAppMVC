﻿using System.ComponentModel.DataAnnotations;

namespace Javni_admin_modul.Data.ViewModels
{
    public class RegisterVM
    {
        [Display(Name = "Full name")]
        [Required(ErrorMessage = "Full name is required")]
        public string FullName { get; set; }
        [Display(Name ="Email address")]
        [Required(ErrorMessage="Email address is required")]
        public string EmailAddress { get; set; }

        
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name ="COnfirm password")]
        [Required(ErrorMessage ="Confirm is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="Passwords do not match")]
        public string ConfirmPassword { get; set; }
    }
}
