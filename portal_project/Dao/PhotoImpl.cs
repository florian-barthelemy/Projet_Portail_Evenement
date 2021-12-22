using portal_project.Metier;
using portal_project.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portal_project.Dao
{
    public class PhotoImpl : IPhoto
    {
        MyContext context = new MyContext();
        public void createPhoto(Photo p)
        {
                context.Photos.Add(p);
                context.SaveChanges();
        }

        public void deletePhoto(int id_photo)
        {
            Photo dbPhoto = context.Photos.SingleOrDefault(dp => dp.Id == id_photo);
                context.Photos.Remove(dbPhoto);
                context.SaveChanges();
        }

        public void editPhoto(Photo p)
        {
                context.Photos.Attach(p);
                context.Entry(p).State = EntityState.Modified;
                context.SaveChanges();
        }


        public List<Photo> findByDateUpload(DateTime dt)
        {
            return context.Photos.AsNoTracking().Where(p => p.DateUpload.Date == dt.Date).ToList();
        }

        public List<Photo> findByTitle(string title)
        {
            return context.Photos.AsNoTracking().Where(p => p.PhotoTitle == title).ToList();
        }

        public Photo findOneById(int id)
        {
            return context.Photos.AsNoTracking().SingleOrDefault(dp => dp.Id == id);
        }

        public List<Photo> getAllPhotos()
        {
            return context.Photos.ToList();
        }

        public List<Photo> getAllUserPhoto(User u)
        {
            return context.Photos.AsNoTracking().Where(p => p.UserUploader.Id == u.Id).ToList();
        }
    }
}
