using Javni_admin_modul.Data.Base;
using Javni_admin_modul.Data.ViewModels;
using Javni_admin_modul.Models;

namespace Javni_admin_modul.Data.Services
{
    public interface IVideosService:IEntityBaseRepository<Video>
    {
        Task<Video> GetVideoByIdAsync(int id);

        Task<NewVideoDropdownsVM> GetNewVideoDropdownsValues();

        Task AddNewVideoAsync(NewVideoVM data);
        Task UpdateVideoAsync(NewVideoVM data);
    }
}
