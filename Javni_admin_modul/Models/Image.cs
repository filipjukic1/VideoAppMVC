using System.ComponentModel.DataAnnotations;

namespace Javni_admin_modul.Models
{
    public class Image
    {
        [Key]
        public int Id { get; set; }
        public string Content { get; set; }
    }
}
