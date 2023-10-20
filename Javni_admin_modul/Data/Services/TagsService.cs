using Javni_admin_modul.Data.Base;
using Javni_admin_modul.Models;
using Microsoft.EntityFrameworkCore;

namespace Javni_admin_modul.Data.Services
{
    public class TagsService : EntityBaseRepository<Tag>, ITagsService
    {
        
        public TagsService(AppDbContext context):base(context)
        { 
        }
        
    }
}
