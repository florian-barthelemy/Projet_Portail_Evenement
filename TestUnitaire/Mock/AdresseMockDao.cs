using portal_project.Metier;
using portal_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestUnitaire.Mock
{
    public class AdresseMockDao : IAdresse
    {
        public AdresseMockDao()
        {
            Adresses = new List<Adresse>();

        }

        public List<Adresse> Adresses { get; set; }

        public void createAdress(Adresse adresse)
        {
            Adresse adresse1 = Adresses.Find(a => a.Axe_X == adresse.Axe_X && a.Axe_Y == adresse.Axe_Y);
            if (adresse1 == null)
            { 
                Adresses.Add(adresse);
            }
        }

        public void deleteAdresse(int id_adresse)
        {

            Adresse adr = Adresses.Find(c=>c.Id ==id_adresse);
            if (adr != null)
            {
                Adresses.Remove(adr);
            }
        }

        public void editAdress(Adresse adresse)
        {
            Adresse adr = Adresses.Find(ad => ad.Id == adresse.Id);
            if (adr != null)
            {
                Adresses.Remove(adr);
                Adresses.Add(adresse);
            }
        }

        public List<Adresse> findByCodePostal(string code_postal)
        {
            return Adresses.FindAll(c => c.CodePostal.Equals(code_postal)); 
        }

        public List<Adresse> findByVille(string ville)
        {
            return Adresses.FindAll(c => c.Ville.Contains(ville));
        }

        public Adresse findOneByCoordinates(double axe_x, double axe_y)
        {
            return Adresses.Find(c => c.Axe_X == axe_x && c.Axe_Y == axe_y);
        }

        public Adresse findOneById(int id)
        {
            return Adresses.Find(c => c.Id == id);
        }

        public List<Adresse> getAllAdresses()
        {
            return Adresses;
        }
    }
}
