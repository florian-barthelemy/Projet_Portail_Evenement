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
            //interfaces
            IAdresse interAdr = new AdresseImpl();
            IEvent interEvent = new EventImpl();
            IUser interUser = new UserImpl();

            //ADD

            //ADRESSE
            Adresse adr1 = new Adresse(2.598,6.3655,"9 rue Hector","80000","Amiens");
            Adresse adr2 = new Adresse(2.598, 6.3655, "35 rue Aragon", "60110","Méru");
            Adresse adr3 = new Adresse(2.598, 6.3655, "112 boulevard Haussmann", "75000", "Paris");

            interAdr.createAdress(adr1);
            interAdr.createAdress(adr2);
            interAdr.createAdress(adr3);

            List<Adresse> u1_adr = interAdr.getAllAdresses();
            //User
            User u1 = new User("Thomas", "Shelby", "PeakyPeaky@World.com", "redrighthand", true, u1_adr, new DateTime(), u1_adr.First());
            User u2 = new User("Arthur", "Shelby", "ByOrder@garisson.com", "thisplaceisundernewmanagment", true, null, new DateTime(), null);
            User u3 = new User("Tyrion", "Lannister", "drink@knowthings.com", "rainsofcastamere", true, null, new DateTime(), null);

            interUser.createUser(u1);
            interUser.createUser(u2);
            interUser.createUser(u3);

            //Event
            Adresse adrEvent = new Adresse(2.598, 6.3655, "12 rue Lamartine", "75000", "Paris");
            List<User> part1 = interUser.getAllUsers();
            List<User> inter = interUser.getAllAdmins();
            User crea = interUser.findOneById(1); 
            Event ev1 = new Event("Festival de folie 1", "Un nouveau numéro, l\'homme qui aimait les pointeurs en C", adrEvent, new DateTime(), new DateTime(+100),part1,inter,crea,19.99,18,null);
            Event ev2 = new Event("Festival de folie 2", "Le remake", adrEvent, new DateTime(), new DateTime(+100), part1, inter, crea, 69.99, 7, null);
            Event ev3 = new Event("Festival de folie 3", "Le reboot low cost", adrEvent, new DateTime(), new DateTime(+100), part1, inter, crea, 99.99, 12, null);

            interEvent.createEvent(ev1);
            interEvent.createEvent(ev2);
            interEvent.createEvent(ev3);




        }
    }
}
