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
    public class SousCategorieImpl : ISousCategorie
    {
        MyContext context = new MyContext();

        public void createSousCategorie(SousCategorie sousCategorie)
        {
                context.SousCategories.Add(sousCategorie);
                context.SaveChanges();
        }


        public void deleteSousCategorie(int id_sousCategorie)
        {
            SousCategorie deletedCat = context.SousCategories.SingleOrDefault(e => e.Id == id_sousCategorie);
                context.SousCategories.Remove(deletedCat);
                context.SaveChanges();
        }

        public void editSousCategorie(SousCategorie sousCategorie)
        {
                context.SousCategories.Attach(sousCategorie);
                context.Entry(sousCategorie).State = EntityState.Modified;
                context.SaveChanges();
        }

        public SousCategorie findOneById(int id)
        {
            return context.SousCategories.AsNoTracking().SingleOrDefault(e => e.Id == id);
        }

        public List<SousCategorie> getAllSousCategories()
        {
            return context.SousCategories.ToList();
        }

        public List<SousCategorie> getAllSousCategoriesbyCategorie(string titre)
        {
            return context.SousCategories.AsNoTracking().Where(evnt => evnt.EventCategorie.Libelle.Equals(titre)).ToList();
        }
    }
}
