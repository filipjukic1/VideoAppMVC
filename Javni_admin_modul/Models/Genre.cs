using Javni_admin_modul.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace Javni_admin_modul.Models
{
    public class Genre:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Name")]
        //[Required(ErrorMessage ="Name is required!")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 25 chars")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        //[Required(ErrorMessage = "Description is required!")]
        public string Description { get; set; }
    }
}
