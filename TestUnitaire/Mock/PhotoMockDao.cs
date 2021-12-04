using portal_project.Metier;
using portal_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestUnitaire.Mock
{
   public class PhotoMockDao : IPhoto
    {
        public List<Photo> Photos;

        public PhotoMockDao()
        {
            Photos = new List<Photo>();
        }

        public void createPhoto(Photo p)
        {
            Photo dbPhoto =Photos.Find(dp => dp.Id == p.Id);
            if (dbPhoto == null)
            {
                Photos.Add(p);
            }
        }

        public void deletePhoto(int id_photo)
        {
            Photo dbPhoto = Photos.Find(dp => dp.Id == id_photo);
            if (dbPhoto != null)
            {
                Photos.Remove(dbPhoto);

            }
        }

        public void editPhoto(Photo p)
        {
            Photo dbPhoto =Photos.Find(dp => dp.Id == p.Id);
            if (dbPhoto != null)
            {
                Photos.Remove(dbPhoto);
                Photos.Add(p);

            }
        }

        public List<Photo> findByDateUpload(DateTime dt)
        {
            return Photos.FindAll(p => p.DateUpload.Date == dt.Date);
        }

        public List<Photo> findByTitle(string title)
        {
            return Photos.FindAll(p => p.PhotoTitle == title);
        }

        public Photo findOneById(int id)
        {
            return Photos.Find(p => p.Id == id);
        }

        public List<Photo> getAllPhotos()
        {
            return Photos;
        }

        public List<Photo> getAllUserPhoto(User u)
        {
            return Photos.FindAll(p => p.UserUploader.Id == u.Id);
        }
    }
}
