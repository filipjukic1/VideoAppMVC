using Javni_admin_modul.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Javni_admin_modul.Models
{
    public class NewVideoVM
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }
        [Display(Name ="Video name")]
        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; }
        [Display(Name = "Video desc")]
        [Required(ErrorMessage = "Desc is required")]
        public string Description { get; set; }

        [Display(Name = "Video pic")]
        [Required(ErrorMessage = "Pic is required")]
        public string Image { get; set; }

        [Display(Name = "Total time of video")]
        [Required(ErrorMessage = "Time is required")]
        public int TotalTime { get; set; }
        [Display(Name = "Video url")]
        [Required(ErrorMessage = "URL is required")]
        public string StreamingUrl { get; set; }

        //tagovi many2many jer video ima vise tagova i tag ima vise videa

        
        public List<int> TagIds { get; set; }
        public List<Tag> Tags { get; set; }

        //zanr videa
        [Display(Name = "Video genre")]
        [Required(ErrorMessage = "Genre is required")]
        public int GenreId { get; set; }
  

    }
}
