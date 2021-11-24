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
    class AdresseImpl : IAdresse
    {
        MyContext context = new MyContext();
        public void createAdress(Adresse adresse)
        {
            Adresse adr = context.Adresses.SingleOrDefault(ad => ad.Id == adresse.Id);
            if (adr == null)
            {
                context.Adresses.Add(adresse);
                context.SaveChanges();
            }
            
            
        }

        public void deleteAdresse(int id_adresse)
        {
            Adresse adr = context.Adresses.Find(id_adresse);
            if(adr != null)
            {
                context.Adresses.Remove(adr);
                context.SaveChanges();
            }
            
        }

        public void editAdress(Adresse adresse)
        {
            Adresse adr = context.Adresses.AsNoTracking().SingleOrDefault(ad => ad.Id == adresse.Id);
            if(adr != null)
            {
                context.Adresses.Attach(adresse);
                context.Entry(adresse).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public List<Adresse> findByCodePostal(string code_postal)
        {
            return context.Adresses.AsNoTracking().Where( adr => adr.CodePostal.Equals(code_postal) ).ToList();
        }

        public List<Adresse> findByVille(string ville)
        {
            return context.Adresses.AsNoTracking().Where( adr => adr.Ville.Contains(ville) ).ToList();
        }

        public Adresse findOneByCoordinates(double axe_x, double axe_y)
        {
            return (Adresse) context.Adresses.AsNoTracking().Where( adr => adr.Axe_X.Equals(axe_x) && adr.Axe_Y.Equals(axe_y) );
        }

        public Adresse findOneById(int id)
        {
            Adresse adr = context.Adresses.SingleOrDefault(ad => ad.Id == id);
            return adr;
        }

        public List<Adresse> getAllAdresses()
        {
            return context.Adresses.ToList();
        }
    }
}
