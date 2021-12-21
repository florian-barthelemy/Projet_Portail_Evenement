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
    public class CategorieService
    {
        private ICategorie dao;

        public CategorieService(ICategorie dao)
        {
            this.dao = dao;
        }

        public void createCategorie(Categorie categorie)
        {
            Categorie categorieDB = dao.findOneById(categorie.Id);
            if (categorieDB == null)
            {
                dao.createCategorie(categorie);
            }
            else
            {
                throw new AlreadyCreatedException("La catégorie avec l'id "+categorie.Id+" existe déjà");
            }
        }

        public void editCategorie(Categorie categorie)
        {
            Categorie categorieDB = dao.findOneById(categorie.Id);
            if (categorieDB != null)
            {
                dao.editCategorie(categorie);
            }
            else
            {
                throw new NotFoundException("La catégorie avec l'id " + categorie.Id
                    + " n'existe pas");
            }
        }

        public void deleteCategorie(int id_categorie)
        {
            Categorie categorie = dao.findOneById(id_categorie);
            if (categorie != null)
            {
                dao.deleteCategorie(id_categorie);
            }
            else
            {
                throw new NotFoundException("La catégorie avec l'id " +
                    id_categorie + "n'existe pas");
            }
        }

        public List<Categorie> getAllCategories()
        {
            List<Categorie> categories= dao.getAllCategories();
            if (categories.Count > 0)
            {
                return categories;
            }
            else
            {
                throw new ListEmptyException("Aucune catégorie enregistrée");
            }
        }

        public Categorie findOneById(int id)
        {
            Categorie categorie = dao.findOneById(id);
            if (categorie != null)
            {
                return categorie;
            }
            else
            {
                throw new NotFoundException("La catégorie avec l'id " + id + " n'existe pas");
            }
        }

    }
}
