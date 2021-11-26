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
            SousCategorie newCat = context.SousCategories.SingleOrDefault(e => e.Id == sousCategorie.Id);
            if (newCat == null)
            {
                context.SousCategories.Add(newCat);
                context.SaveChanges();
            }
        }


        public void deleteSousCategorie(int id_sousCategorie)
        {
            SousCategorie deletedCat = context.SousCategories.SingleOrDefault(e => e.Id == id_sousCategorie);
            if (deletedCat == null)
            {
                context.SousCategories.Remove(deletedCat);
                context.SaveChanges();
            }
        }

        public void editSousCategorie(SousCategorie sousCategorie)
        {
            SousCategorie dbCategorie = context.SousCategories.SingleOrDefault(u => u.Id == sousCategorie.Id);
            if (dbCategorie != null)
            {
                context.SousCategories.Attach(sousCategorie);
                context.Entry(sousCategorie).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public SousCategorie findOneById(int id)
        {
            return context.SousCategories.SingleOrDefault(e => e.Id == id);
        }

        public List<SousCategorie> getAllSousCategories()
        {
            return context.SousCategories.ToList();
        }

        public List<SousCategorie> getAllSousCategoriesbyCategorie(string titre)
        {
            return context.SousCategories.AsNoTracking().Where(evnt => evnt.EventCategorie.Equals(titre)).ToList();
        }
    }
}
