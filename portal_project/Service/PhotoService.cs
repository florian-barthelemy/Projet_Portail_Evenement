using portal_project.Metier;
using portal_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portal_project.Service
{
   public class PhotoService
    {
        private IPhoto dao;

        public PhotoService(IPhoto dao)
        {
            this.dao = dao;
        }

        public void createPhoto(Photo p)
        {
            dao.createPhoto(p);
        }

        public void deletePhoto(int id_photo)
        {
            dao.deletePhoto(id_photo);
        }

        public void editPhoto(Photo p)
        {
            dao.editPhoto(p);
        }

        public List<Photo> findByDateUpload(DateTime dt)
        {
            return dao.findByDateUpload(dt);
        }

        public List<Photo> findByTitle(string title)
        {
            return dao.findByTitle(title);
        }

        public Photo findOneById(int id)
        {
            return dao.findOneById(id);
        }

        public List<Photo> getAllPhotos()
        {
            return dao.getAllPhotos();
        }

        public List<Photo> getAllUserPhoto(User u)
        {
            return dao.getAllUserPhoto(u);
        }
    }
}
