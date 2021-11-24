using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using portal_project.Models;
namespace portal_project.Metier
{
    public interface IPhoto
    {
        void createPhoto(Photo p);
        void deletePhoto(int id_photo);
        void editPhoto(Photo p);
        List<Photo> getAllPhotos();
        Photo findOneById(int id);
        List<Photo> getAllUserPhoto(User u);
        List<Photo> findByTitle(string title);
        List<Photo> findByDateUpload(DateTime dt);
        List<Photo> findByDateInterval(DateTime date_debut, DateTime date_fin);

    }
}
