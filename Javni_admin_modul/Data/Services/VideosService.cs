using Javni_admin_modul.Data.Base;
using Javni_admin_modul.Data.ViewModels;
using Javni_admin_modul.Models;
using Microsoft.EntityFrameworkCore;

namespace Javni_admin_modul.Data.Services
{
    public class VideosService : EntityBaseRepository<Video>, IVideosService
    {
        private readonly AppDbContext _context;
        public VideosService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewVideoAsync(NewVideoVM data)
        {
            var newVideo = new Video()
            {
                Name = data.Name,
                Description = data.Description,
                TotalTime = data.TotalTime,
                StreamingUrl = data.StreamingUrl,
                Image = data.Image,
                GenreId = data.GenreId,
                CreatedAt = data.CreatedAt,

            };
            await _context.Videos.AddAsync(newVideo);
            await _context.SaveChangesAsync();

            //Adding Tags
            foreach (var tagId in data.TagIds)
            {
                var newVideoTag = new VideoTag()
                {
                    VideoId = newVideo.Id,
                    TagId = tagId,
                };
                await _context.VideoTags.AddAsync(newVideoTag);
                

            }
            await _context.SaveChangesAsync();
        }

        public async Task<NewVideoDropdownsVM> GetNewVideoDropdownsValues()
        {
            var response = new NewVideoDropdownsVM();
            response.Genres=await _context.Genres.OrderBy(n=>n.Name).ToListAsync();
            response.Tags= await _context.Tags.OrderBy(n => n.Name).ToListAsync();
            return response;
        }

        public async Task<Video> GetVideoByIdAsync(int id)
        {
            var videoDetails = await _context.Videos
                .Include(v => v.Genre)
                .Include(v => v.Tags)
                .Include(v => v.VideoTags).ThenInclude(vt => vt.Tag)
                .FirstOrDefaultAsync(m => m.Id == id);


            return videoDetails;
        }

        public async Task UpdateVideoAsync(NewVideoVM data)
        {
            var dbVideo=await _context.Videos.FirstOrDefaultAsync(n=>n.Id==data.Id);

            if (dbVideo!=null)
            {
                dbVideo.Name = data.Name;
                dbVideo.Description = data.Description;
                dbVideo.TotalTime = data.TotalTime;
                dbVideo.StreamingUrl = data.StreamingUrl;
                dbVideo.Image = data.Image;
                dbVideo.GenreId = data.GenreId;
                dbVideo.CreatedAt = data.CreatedAt;
                await _context.SaveChangesAsync();
               
                
            }
            //Remove existing tags
            var existingTagDb=_context.VideoTags.Where(n=>n.VideoId==data.Id).ToList();
            _context.VideoTags.RemoveRange(existingTagDb);
            await _context.SaveChangesAsync();
      

            //Adding Tags
            foreach (var tagId in data.TagIds)
            {
                var newVideoTag = new VideoTag()
                {
                    VideoId = data.Id,
                    TagId = tagId,
                };
                await _context.VideoTags.AddAsync(newVideoTag);


            }
            await _context.SaveChangesAsync();
        }
    }
}
