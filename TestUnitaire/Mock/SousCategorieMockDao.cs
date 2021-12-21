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


        public void createSousCategorie(SousCategorie souscategorie)
        {
            SousCategories.Add(souscategorie);
    }

        public void deleteSousCategorie(int id_sousCategorie)
        {
            SousCategorie deletedCat = SousCategories.Find(e => e.Id == id_sousCategorie);
                SousCategories.Remove(deletedCat);
        }

        public void editSousCategorie(SousCategorie sousCategorie)
        {
            SousCategorie dbCategorie = SousCategories.Find(u => u.Id == sousCategorie.Id);
                SousCategories.Remove(dbCategorie);
                SousCategories.Add(sousCategorie);
        }

        public SousCategorie findOneById(int id)
        {
            return SousCategories.Find(s => s.Id == id);
        }

        public List<SousCategorie> getAllSousCategories()
        {
            return SousCategories;
        }

        public List<SousCategorie> getAllSousCategoriesbyCategorie(string titre)
        {
            return SousCategories.FindAll(evnt => evnt.EventCategorie.Libelle.Equals(titre));
        }

    }
}
