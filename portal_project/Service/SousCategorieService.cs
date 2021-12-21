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
    public class SousCategorieService
    {
        private ISousCategorie dao;

        public SousCategorieService(ISousCategorie dao)
        {
            this.dao = dao;
        }

        public void createSousCategorie(SousCategorie sousCategorie)
        {
            SousCategorie s = dao.findOneById(sousCategorie.Id);
            if (s == null)
            {
                dao.createSousCategorie(sousCategorie);
            }
            else
            {
                throw new AlreadyCreatedException("La sous catégorie avec l'id " + sousCategorie.Id + " existe déjà");
            }
        }

        public void editSousCategorie(SousCategorie sousCategorie)
        {
            SousCategorie s = dao.findOneById(sousCategorie.Id);
            if (s != null)
            {
                dao.editSousCategorie(sousCategorie);
            }
            else
            {
                throw new NotFoundException("La sous catégorie avec l'id " + sousCategorie.Id + " n'existe pas");
            }
        }

        public void deleteSousCategorie(int id_categorie)
        {
            SousCategorie s = dao.findOneById(id_categorie);
            if (s != null)
            {
                dao.deleteSousCategorie(id_categorie);
            }
            else
            {
                throw new NotFoundException("La sous catégorie avec l'id " + id_categorie + " n'existe pas");
            }
        }

        public List<SousCategorie> getAllSousCategories()
        {
            List<SousCategorie> sousCategories= dao.getAllSousCategories();
            if (sousCategories.Count > 0)
            {
                return sousCategories;
            }
            else
            {
                throw new ListEmptyException("Aucune sous catégorie enregistrée");
            }
        }

        public List<SousCategorie> getAllSousCategoriesbyCategorie(string titre)
        {
            List<SousCategorie> sousCategories= dao.getAllSousCategoriesbyCategorie(titre);
            if (sousCategories.Count > 0)
            {
                return sousCategories;
            }
            else
            {
                throw new ListEmptyException("Aucune sous catégorie associé à la categorie " + titre);
            }
        }

        public SousCategorie findOneById(int id)
        {
            SousCategorie sousCategorie= dao.findOneById(id);
            if (sousCategorie != null)
            {
                return sousCategorie;
            }
            else
            {
                throw new NotFoundException("La sous catégorie avec l'id " + id + " n'existe pas");
            }
        }
    }
}
