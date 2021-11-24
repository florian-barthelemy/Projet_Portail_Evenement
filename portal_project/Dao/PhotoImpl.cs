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
    class PhotoImpl : IPhoto
    {
        MyContext context = new MyContext();
        public void createPhoto(Photo p)
        {
            Photo dbPhoto = context.Photos.SingleOrDefault(dp => dp.Id == p.Id);
            if(dbPhoto == null)
            {
                context.Photos.Add(p);
                context.SaveChanges();
            }
        }

        public void deletePhoto(int id_photo)
        {
            Photo dbPhoto = context.Photos.SingleOrDefault(dp => dp.Id == id_photo);
            if (dbPhoto != null)
            {
                context.Photos.Remove(dbPhoto);
                context.SaveChanges();
            }
        }

        public void editPhoto(Photo p)
        {
            Photo dbPhoto = context.Photos.SingleOrDefault(dp => dp.Id == p.Id);
            if (dbPhoto != null)
            {
                context.Photos.Attach(p);
                context.Entry(p).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public List<Photo> findByDateInterval(DateTime date_debut, DateTime date_fin)
        {
            throw new NotImplementedException();
        }

        public List<Photo> findByDateUpload(DateTime dt)
        {
            throw new NotImplementedException();
        }

        public List<Photo> findByTitle(string title)
        {
            throw new NotImplementedException();
        }

        public Photo findOneById(int id)
        {
            return context.Photos.SingleOrDefault(dp => dp.Id == id);
        }

        public List<Photo> getAllPhotos()
        {
            return context.Photos.ToList();
        }

        public List<Photo> getAllUserPhoto(User u)
        {
            throw new NotImplementedException();
        }
    }
}
