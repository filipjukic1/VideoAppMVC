using Javni_admin_modul.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Javni_admin_modul.Models
{
    public class Video:IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int TotalTime { get; set; }
        public string StreamingUrl { get; set; }

        //tagovi many2many jer video ima vise tagova i tag ima vise videa
        public List<VideoTag> VideoTags { get; set; }
        public List<Tag> Tags { get; set; }

        //zanr videa
        public int GenreId { get; set; }
        [ForeignKey("GenreId")]
        public Genre Genre { get; set; }

    }
}
