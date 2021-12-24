using portal_project.Exceptions;
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
            Photo photoDB = dao.findOneById(p.Id);
            if (photoDB == null)
            {
                dao.createPhoto(p);
            }
            else
            {
                throw new AlreadyCreatedException("La photo avec l'id " + p.Id + " existe déjà");
            }
        }

        public void deletePhoto(int id_photo)
        {
            Photo photoDB = dao.findOneById(id_photo);
            if (photoDB != null)
            {
                dao.deletePhoto(id_photo);
            }
            else
            {
                throw new NotFoundException("La photo avec l'id "+id_photo+" n'existe pas");
            }
        }

        public void editPhoto(Photo p)
        {
            Photo photoDB = dao.findOneById(p.Id);
            if (photoDB != null)
            {
                dao.editPhoto(p);
            }
            else
            {
                throw new NotFoundException("La photo avec l'id " + p.Id + " n'existe pas");
            }
        }

        public List<Photo> findByDateUpload(DateTime dt)
        {
            List<Photo> photos=dao.findByDateUpload(dt);
            if (photos.Count > 0)
            {
                return photos;
            }
            else
            {
                throw new ListEmptyException("Aucune photo uploadé à la date "+dt.Date);
            }
        }

        public List<Photo> findByTitle(string title)
        {
         List<Photo> photos = dao.findByTitle(title);
            if (photos.Count > 0)
            {
                return photos;
            }
            else
            {
                throw new ListEmptyException("Aucune photo ne correspond au titre recherché "+title);
            }
        }

        public Photo findOneById(int id)
        {
            Photo photo= dao.findOneById(id);
            if (photo != null)
            {
                return photo;
            }
            else
            {
                throw new NotFoundException("Aucune photo n'est associé à l'id " + id);
            }
        }

        public List<Photo> getAllPhotos()
        {
            List<Photo> photos= dao.getAllPhotos();
            if (photos.Count > 0)
            {
                return photos;
            }
            else
            {
                throw new ListEmptyException("Aucune photo n'est enregistré");
            }
        }

        public List<Photo> getAllUserPhoto(User u)
        {
            List<Photo> photos= dao.getAllUserPhoto(u);
            if (photos.Count > 0)
            {
                return photos;
            }
            else
            {
                throw new ListEmptyException("Pas de photos enregistré pour l'utilisateur " + u);
            }
        }

        public List<Photo> getAllEventPhoto(Event e)
        {
            List<Photo> photos = dao.getAllPhotos().Where(p => p.PhotoEventId == e.Id).ToList();
            if (photos.Count > 0)
            {
                return photos;
            }
            else
            {
                throw new ListEmptyException("L'évènement "+e.Titre+ " ne contient pas de photos");
            }
        }
    }
}
