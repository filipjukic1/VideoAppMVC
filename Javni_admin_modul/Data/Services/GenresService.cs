using Javni_admin_modul.Data.Base;
using Javni_admin_modul.Models;
using Microsoft.EntityFrameworkCore;

namespace Javni_admin_modul.Data.Services
{
    public class GenresService : EntityBaseRepository<Genre>, IGenresService
    {
        public GenresService(AppDbContext context) : base(context) { }
    }
}
