using portal_project.Dao;
using portal_project.Metier;
using portal_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portal_project
{
    class Program
    {
        static void Main(string[] args)
        {
            // ------------ à executer au premier lancement de l'application || TEST CRUD ----------------
            /*
            IAdresse interAdr = new AdresseImpl();
            Adresse adr1 = new Adresse(2.598,6.3655,"9 rue Hector","80000","Amiens");
            Adresse adr2 = new Adresse(2.598, 6.3655, "35 rue Aragon", "60110","Méru");
            Adresse adr3 = new Adresse(2.598, 6.3655, "112 boulevard Haussmann", "75000", "Paris");

            interAdr.createAdress(adr1);
            interAdr.createAdress(adr2);
            interAdr.createAdress(adr3);

            interAdr.deleteAdresse(2);
            Adresse adrUp = interAdr.findOneById(1);
            adrUp.Ville = "Lombez";
            interAdr.editAdress(adrUp);
            */



        }
    }
}
