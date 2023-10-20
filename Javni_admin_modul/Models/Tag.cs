using Javni_admin_modul.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace Javni_admin_modul.Models
{
    public class Tag:IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }

        public List<VideoTag> VideoTags { get; set; }
    }
}
