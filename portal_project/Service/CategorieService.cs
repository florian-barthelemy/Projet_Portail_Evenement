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
            dao.createCategorie(categorie);
        }

        public void editCategorie(Categorie categorie)
        {
            dao.editCategorie(categorie);
        }

        public void deleteCategorie(int id_categorie)
        {
            dao.deleteCategorie(id_categorie);
        }

        public List<Categorie> getAllCategories()
        {
            return dao.getAllCategories();
        }

        public Categorie findOneById(int id)
        {
            return dao.findOneById(id);
        }

    }
}
