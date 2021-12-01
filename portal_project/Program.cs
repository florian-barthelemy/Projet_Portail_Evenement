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
            IPhoto interPhoto = new PhotoImpl();
            ICategorie interCategorie = new CategorieImpl();
            ISousCategorie interSousCategorie = new SousCategorieImpl();

            //ADRESSE
            Adresse adr1 = new Adresse(2.598,6.3655,"9 rue Hector","80000","Amiens");
            Adresse adr2 = new Adresse(2.598, 6.3655, "35 rue Aragon", "60110","Méru");
            Adresse adr3 = new Adresse(2.598, 6.3655, "112 boulevard Haussmann", "75000", "Paris");

            interAdr.createAdress(adr1);
            interAdr.createAdress(adr2);
            interAdr.createAdress(adr3);

            List<Adresse> u1_adr = interAdr.getAllAdresses();
            u1_adr.First().CodePostal = "00000";
            interAdr.editAdress(u1_adr.First());
            interAdr.deleteAdresse(u1_adr.Last().Id);


            //User
            DateTime dt = new DateTime();
            dt.AddYears(40);

            /* 
             * public User(
             * string nom, string prenom,
             * string email, string password, bool isAdmin,
             * List<Adresse> adresses, DateTime dateNais,
             * Adresse mainAdresse, Genre userGenre
             * )
             */

            User u1 = new User("Shelby", "Thomas", "PeakyPeaky@World.com", "redrighthand", true, null, dt, null, User.Genre.Homme);
            User u2 = new User("Shelby", "Arthur", "ByOrder@garisson.com", "thisplaceisundernewmanagment", true, null, dt, null, User.Genre.Homme);
            User u3 = new User("Lannister", "Cercei", "drink@knowthings.com", "rainsofcastamere", true, null, dt, null, User.Genre.Femme);

            interUser.createUser(u1);
            interUser.createUser(u2);
            interUser.createUser(u3);

            List < User > usersList = interUser.getAllUsers();
            usersList.First().Email = "blabla@toto.net";
            interUser.editUser(usersList.First());
            interUser.deleteUser(usersList.Last().Id);


            //EVENT
            /*
             public Event(
            string titre, string description,
            Adresse eventAdresse, DateTime dateDebut,
            DateTime dateFin, List<User> participants,
            List<User> intervenants, User creator, double tarif,
            int minAge, List<Photo> photosEvent
            )
             */
            DateTime deb = new DateTime();
            DateTime fin = new DateTime();
            fin.AddMonths(2);
            Event ev1 = new Event("Concert ACDC", "En maison de retraite", null, deb, fin, null, null, null, 12.2,18, null);
            Event ev2 = new Event("Exposition d'art moderne", "Dans le musée Grevin", null, deb, fin, null, null, null, 12.2,0, null);
            Event ev3 = new Event("Concert ACDC", "En maison de retraite", null, deb, fin, null, null, null, 12.2,12, null);
            interEvent.createEvent(ev1);
            interEvent.createEvent(ev2);
            interEvent.createEvent(ev3);

            List<Event> evList = interEvent.getAllEvents();
            evList.First().Description = "aaaaaaaaaaaa";
            interEvent.editEvent(evList.First());
            interEvent.deleteEvent(evList.Last().Id);


            // PHOTO

            Photo p1 = new Photo("c:\\myPhoto\\img.png", null, "Belle photo", "Elle brille meme", null, deb);
            Photo p2 = new Photo("c:\\myPhoto\\img1.png", null, "Picture random", "Toujours plus", null, deb);
            Photo p3 = new Photo("c:\\myPhoto\\img2.png", null, "Peaky Blinders", "Au beau milieu du morne hiver", null, deb);

            interPhoto.createPhoto(p1);
            interPhoto.createPhoto(p2);
            interPhoto.createPhoto(p3);


            List<Photo> pList = interPhoto.getAllPhotos();
            pList.First().PhotoDescription = "aazazazaza";
            interPhoto.editPhoto(pList.First());
            interPhoto.deletePhoto(pList.Last().Id);

            /*
            =============== A TESTER APRES IMPLEMENTATION DE CATEGORIE ET SOUS CATEGORIE =================

            //Categorie && SousCategorie
            Categorie cat1 = new Categorie("Culture");
            Categorie cat2 = new Categorie("Sport");

            interCategorie.createCategorie(cat1);
            interCategorie.createCategorie(cat2);

            Categorie dbCat = interCategorie.findOneById(0);
            SousCategorie subCat1 = new SousCategorie("Musique",dbCat);
            SousCategorie subCat2 = new SousCategorie("Theatre", dbCat);

            interSousCategorie.createSousCategorie(subCat1);
            interSousCategorie.createSousCategorie(subCat2);


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



            */
        }
    }
}
