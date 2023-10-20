using Javni_admin_modul.Data.Base;
using Javni_admin_modul.Models;
using Microsoft.EntityFrameworkCore;

namespace Javni_admin_modul.Data.Services
{
    public class CountriesService : EntityBaseRepository<Country>, ICountriesService
    {
        

        public CountriesService(AppDbContext context) : base(context) { }
        

       

    }
}
