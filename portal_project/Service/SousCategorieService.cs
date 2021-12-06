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
            dao.createSousCategorie(sousCategorie);
        }

        public void editSousCategorie(SousCategorie sousCategorie)
        {
            dao.editSousCategorie(sousCategorie);
        }

        public void deleteSousCategorie(int id_categorie)
        {
            dao.deleteSousCategorie(id_categorie);
        }

        public List<SousCategorie> getAllSousCategories()
        {
            return dao.getAllSousCategories();
        }

        public List<SousCategorie> getAllSousCategoriesbyCategorie(string titre)
        {
            return dao.getAllSousCategoriesbyCategorie(titre);
        }

        public SousCategorie findOneById(int id)
        {
            return dao.findOneById(id);
        }
    }
}
