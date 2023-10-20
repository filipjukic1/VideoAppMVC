using Javni_admin_modul.Models;

namespace Javni_admin_modul.Data.ViewModels
{
    public class NewVideoDropdownsVM
    {

        public NewVideoDropdownsVM()
        {
            Genres=new List<Genre>();
            Tags=new List<Tag>();
        }
        public List<Genre> Genres { get; set; }
        public List<Tag> Tags { get; set; }

    }
}
