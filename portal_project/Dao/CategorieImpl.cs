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
    public class CategorieImpl : ICategorie
    {
        MyContext context = new MyContext();

        public void createCategorie(Categorie categorie)
        {
                context.Categories.Add(categorie);
                context.SaveChanges();
        }

        public void deleteCategorie(int id_categorie)
        {
            Categorie deletedCat = context.Categories.SingleOrDefault(e => e.Id == id_categorie);
                context.Categories.Remove(deletedCat);
                context.SaveChanges();
        }

        public void editCategorie(Categorie categorie)
        {
                context.Categories.Attach(categorie);
                context.Entry(categorie).State = EntityState.Modified;
                context.SaveChanges();
        }

        public Categorie findOneById(int id)
        {
            return context.Categories.SingleOrDefault(e => e.Id == id);
        }

        public List<Categorie> getAllCategories()
        {
            return context.Categories.ToList();
        }

    }
}
