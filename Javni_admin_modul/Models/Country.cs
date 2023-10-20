using Javni_admin_modul.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace Javni_admin_modul.Models
{
    public class Country:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        //anotacije za cshtml 
        [Display(Name = "Code")]
        public char Code { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }
    }
}
