using Javni_admin_modul.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Javni_admin_modul.Data
{
    public class AppDbContext:IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VideoTag>().HasKey(vt => new
            {
                vt.VideoId,
                vt.TagId
            });

            modelBuilder.Entity<VideoTag>().HasOne(v => v.Video).WithMany(vt => vt.VideoTags).HasForeignKey(v => v.VideoId);
            modelBuilder.Entity<VideoTag>().HasOne(v => v.Tag).WithMany(vt => vt.VideoTags).HasForeignKey(v => v.TagId);




            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<VideoTag> VideoTags { get; set; }
    }
}
