using portal_project.Metier;
using portal_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestUnitaire.Mock
{
    public class SousCategorieMockDao : ISousCategorie
    {
        public List<SousCategorie> SousCategories;

        public SousCategorieMockDao()
        {
            SousCategories = new List<SousCategorie>();
        }

        public void createSousCategorie(Categorie categorie)
        {
            throw new NotImplementedException();
        }

        public void createSousCategorie(SousCategorie categorie)
        {
            throw new NotImplementedException();
        }

        public void deleteSousCategorie(int id_categorie)
        {
            throw new NotImplementedException();
        }

        public void editSousCategorie(Categorie categorie)
        {
            throw new NotImplementedException();
        }

        public void editSousCategorie(SousCategorie categorie)
        {
            throw new NotImplementedException();
        }

        public Categorie findOneById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Categorie> getAllCategories()
        {
            throw new NotImplementedException();
        }

        public List<SousCategorie> getAllSousCategories()
        {
            throw new NotImplementedException();
        }

        public List<SousCategorie> getAllSousCategoriesbyCategorie(string titre)
        {
            throw new NotImplementedException();
        }

        SousCategorie ISousCategorie.findOneById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
