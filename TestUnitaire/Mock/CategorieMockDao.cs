using portal_project.Metier;
using portal_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestUnitaire.Mock
{
    public class CategorieMockDao : ICategorie
    {
        public List<Categorie> Categories;

        public CategorieMockDao()
        {
            Categories = new List<Categorie>();
        }

        public void createCategorie(Categorie categorie)
        {
            Categorie categorie1 = Categories.Find(c => c.Id == categorie.Id);
            if(categorie1 == null)
            {
                Categories.Add(categorie);
            }
                }

        public void deleteCategorie(int id_categorie)
        {
            Categorie categorie1 = Categories.Find(c => c.Id == id_categorie);
            if (categorie1 != null)
            {
                Categories.Remove(categorie1);
            }
        }

        public void editCategorie(Categorie categorie)
        {
            Categorie categorie1 = Categories.Find(c => c.Id == categorie.Id);
            if (categorie1 != null)
            {
                Categories.Remove(categorie1);
                Categories.Add(categorie);
            }
        }

        public Categorie findOneById(int id)
        {
            return Categories.Find(c => c.Id == id);
        }

        public List<Categorie> getAllCategories()
        {
            return Categories;
        }

    }
}
