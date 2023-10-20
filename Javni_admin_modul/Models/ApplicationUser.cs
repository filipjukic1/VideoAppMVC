using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Javni_admin_modul.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Display(Name="Full name")]
        public string FullName { get; set; }
    }
}
