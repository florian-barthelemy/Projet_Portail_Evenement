using Microsoft.VisualStudio.TestTools.UnitTesting;
using portal_project.Exceptions;
using portal_project.Models;
using portal_project.Service;
using System;
using System.Collections.Generic;
using TestUnitaire.Mock;

namespace TestUnitaire
{
    [TestClass]
    public class EventTest
    {
        EventMockDao dao;
        EventService service;
        [TestInitialize] //Setup: s'execute avant chaque méthode de test
        public void Setup()
        {
            dao = new EventMockDao();
            service = new EventService(dao);
           Event e=new Event { Titre = "CDM", Id = 1 };
            Adresse adr = new Adresse(1, 3.062618, 50.637243, "1 rue esquermoise", "59800", "Lille");
            e.EventAdresse = adr;
            DateTime dateDebut = new DateTime(2018, 9, 7);
            DateTime dateFin = new DateTime(2018, 12, 12);
            e.DateDebut = dateDebut;
            e.DateFin = dateFin;
            SousCategorie sousCategorie = new SousCategorie() { Libelle = "Foot"};
            e.EventSousCat = sousCategorie;
            Categorie categorie = new Categorie() { Libelle = "Sportif" };
            e.EventSousCat.EventCategorie = categorie;
            e.Creator = new User { Id = 1 };
            e.Participants = new List<User> { new User { Id = 1 } };
            dao.Events.Add(e);
        }

        [TestCleanup] //Clean: s'execute après chaque méthode de test
        public void Clean()
        {
            dao.Events.Clear();
        }

        [TestMethod]
        [TestCategory("Event")]
        [TestProperty("Test Event", "Create")]
        public void CreateEvent_DifferentId_Return_Count_Equals2()
        {

            service.createEvent(new Event() { Id = 2 });
            Assert.AreEqual(2, dao.Events.Count);
        }

        [TestMethod]
        [TestCategory("Event")]
        [TestProperty("Test Event", "Create")]
        [ExpectedException(typeof(AlreadyCreatedException))]
        public void CreateEvent_SameId_Return_AlreadyCreatedException()
        {
            service.createEvent(new Event() { Id = 1 });
        }

        [TestMethod]
        [TestCategory("Event")]
        [TestProperty("Test Event", "Delete")]
        public void DeleteEvent_Id_Known_Return_Count_Equals0()
        {
            service.deleteEvent(1);
            Assert.AreEqual(0, dao.Events.Count);
        }

        [TestMethod]
        [TestCategory("Event")]
        [TestProperty("Test Event", "Delete")]
        [ExpectedException(typeof(NullReferenceException))]
        public void DeleteEvent_Id_Unknown_Return_NullReferenceException()
        {
            service.deleteEvent(2);
        }

        [TestMethod]
        [TestCategory("Event")]
        [TestProperty("Test Event", "Edit")]
        public void EditCategorie_Id_Known_Return_Item_Edited()
        {
            Event e1 = new Event { Id = 1, Titre = "CDM2018" };
            service.editEvent(e1);
            Assert.AreEqual(e1.Titre, service.findOneById(1).Titre);
        }

        [TestMethod]
        [TestCategory("Event")]
        [TestProperty("Test Event", "Edit")]
        [ExpectedException(typeof(NullReferenceException))]
        public void EditEvent_Id_Unknown_Return_NullReferenceException()
        {
            Event e1 = new Event { Id = 2, Titre = "CDM2018" };
            service.editEvent(e1);
        }

        [TestMethod]
        [TestCategory("Event")]
        [TestProperty("Test Event", "FindById")]
        [ExpectedException(typeof(NullReferenceException))]
        public void FindById_UnknowId_Return_NullReferenceException()
        {
            Event evt = service.findOneById(2);
        }

        [TestMethod]
        [TestCategory("Event")]
        [TestProperty("Test Event", "FindById")]
        public void FindById_KnownId_Return_Titre_CDM()
        {
            Event evt = service.findOneById(1);
            Assert.AreEqual("CDM", evt.Titre);
        }
        [TestMethod]
        [TestCategory("Event")]
        [TestProperty("Test Event", "FindAll")]
        public void FindAll_Event_Return_Count_Equals1()
        {
            List<Event> events = service.getAllEvents();
            Assert.AreEqual(1, events.Count);
        }
        [TestMethod]
        [TestCategory("Event")]
        [TestProperty("Test Event", "FindAll")]
        [ExpectedException(typeof(ListEmptyException))]
        public void FindAll_Event_Return_ListEmptyException()
        {
            service.deleteEvent(1);
            List<Event> events = service.getAllEvents();
        }
        [TestMethod]
        [TestCategory("Event")]
        [TestProperty("Test Event", "FindByDateDebut")]
        public void FindByDateDebut_CorrectDate_Return_Count_Equals1()
        {
            List<Event> events = service.findAllEventsByDateDebut(new DateTime(2018, 9, 7));
            Assert.AreEqual(1, events.Count);
        }

        [TestMethod]
        [TestCategory("Event")]
        [TestProperty("Test Event", "FindByDateDebut")]
        [ExpectedException(typeof(ListEmptyException))]
        public void FindByDateDebut_IncorrectDate_Return_ListEmptyException()
        {
            List<Event> events = service.findAllEventsByDateDebut(new DateTime(2018, 10, 7));
        }

        [TestMethod]
        [TestCategory("Event")]
        [TestProperty("Test Event", "FindByDateFin")]
        public void FindByDateFin_CorrectDate_Return_Count_Equals1()
        {
            List<Event> events = service.findAllEventsByDateFin(new DateTime(2018, 12, 12));
            Assert.AreEqual(1, events.Count);
        }

        [TestMethod]
        [TestCategory("Event")]
        [TestProperty("Test Event", "FindByDateFin")]
        [ExpectedException(typeof(ListEmptyException))]
        public void FindByDateFin_InCorrectDate__Return_ListEmptyException()
        {
            List<Event> events = service.findAllEventsByDateFin(new DateTime(2018, 10, 7));
        }

        [TestMethod]
        [TestCategory("Event")]
        [TestProperty("Test event", "FindByIntervalle")]
        public void FindByIntervall_DateDebut_Correct_DateFin_Correct_Return_Count_Equals1()
        {
            List<Event> events = service.findAllEventsByDateInterval(new DateTime(2018, 9, 7),
                new DateTime(2018, 12, 12));
            Assert.AreEqual(1, events.Count);
        }

        [TestMethod]
        [TestCategory("Event")]
        [TestProperty("Test event", "FindByIntervalle")]
        [ExpectedException(typeof(ListEmptyException))]
        public void FindByIntervall_DateDebut_Incorrect_DateFin_Correct_Return_ListEmptyException()
        {
            List<Event> events = service.findAllEventsByDateInterval(new DateTime(2018, 10, 7),
                new DateTime(2018, 12, 12));
        }

        [TestMethod]
        [TestCategory("Event")]
        [TestProperty("Test event", "FindByIntervalle")]
        [ExpectedException(typeof(ListEmptyException))]
        public void FindByIntervall_DateDebut_Correct_DateFin_Incorrect_Return_ListEmptyException()
        {
            List<Event> events = service.findAllEventsByDateInterval(new DateTime(2018, 9, 7)
                , new DateTime(2018, 11, 12));
        }

        [TestMethod]
        [TestCategory("Event")]
        [TestProperty("Test event", "FindByIntervalle")]
        [ExpectedException(typeof(ListEmptyException))]
        public void FindByIntervall_DateDebut_Incorrect_DateFin_Incorrect_Return_ListEmptyException()
        {
            List<Event> events = service.findAllEventsByDateInterval(new DateTime(2018, 10, 7), 
                new DateTime(2018, 11, 12));
        }

        [TestMethod]
        [TestCategory("Event")]
        [TestProperty("Test Event", "FindByTitre")]
        public void FindByTitre_CDM_Return_Count_Equals1()
        {
            List<Event> events = service.findAllEventsByTitre("CDM");
            Assert.AreEqual(1, events.Count);
        }

        [TestMethod]
        [TestCategory("Event")]
        [TestProperty("Test Event", "FindByTitre")]
        [ExpectedException(typeof(ListEmptyException))]
        public void FindByTitre_CDM2018_Return_ListEmptyException()
        {
            List<Event> events = service.findAllEventsByTitre("CDM2018");
        }

        [TestMethod]
        [TestCategory("Event")]
        [TestProperty("Test Event", "FindByVille")]
        public void FindByVille_Lille_Return_Count_Equals1()
        {
            List<Event> events = service.findAllEventsByVille("Lille");
            Assert.AreEqual(1, events.Count);
        }

        [TestMethod]
        [TestCategory("Event")]
        [TestProperty("Test Event", "FindByVille")]
        [ExpectedException(typeof(ListEmptyException))]
        public void FindByVille_Paris_Return_ListEmptyException()
        {
            List<Event> events = service.findAllEventsByVille("Paris");
        }

        [TestMethod]
        [TestCategory("Event")]
        [TestProperty("Test Event", "FindByCategorie")]
        public void FindByCategorie_Sportif_Return_Count_Equals1()
        {
            List<Event> events = service.findAllEventsByCategorie("Sportif");
            Assert.AreEqual(1, events.Count);
        }

        [TestMethod]
        [TestCategory("Event")]
        [TestProperty("Test Event", "FindByCategorie")]
        [ExpectedException(typeof(ListEmptyException))]
        public void FindByCategorie_Culturel_Return_ListEmptyException()
        {
            List<Event> events = service.findAllEventsByCategorie("Culturel");
        }

        [TestMethod]
        [TestCategory("Event")]
        [TestProperty("Test Event", "FindBySousCategorie")]
        public void FindBySousCategorie_Foot_Return_Count_Equals1()
        {
            List<Event> events = service.findAllEventsBySousCategorie("Foot");
            Assert.AreEqual(1, events.Count);
        }

        [TestMethod]
        [TestCategory("Event")]
        [TestProperty("Test Event", "FindBySousCategorie")]
        [ExpectedException(typeof(ListEmptyException))]
        public void FindBySousCategorie_Hand_Return_ListEmptyException()
        {
            List<Event> events = service.findAllEventsBySousCategorie("Hand");
        }

        [TestMethod]
        [TestCategory("Event")]
        [TestProperty("Test Event", "getAllEventsCreatedByUser")]
        public void getAllEventsCreatedByUser_UserWhoCreatedAnEvent_Return_Count_Equals1()
        {
            User u = new User { Id = 1 };
            List<Event> events = service.getAllEventsCreatedByUser(u);
            Assert.AreEqual(1, events.Count);
        }
        [TestMethod]
        [TestCategory("Event")]
        [TestProperty("Test Event", "getAllEventsCreatedByUser")]
        [ExpectedException(typeof(ListEmptyException))]
        public void getAllEventsCreatedByUser_UserWhoDoesntCreatedAnEvent_Return_ListEmptyException()
        {
            User u = new User { Id = 2 };
            List<Event> events = service.getAllEventsCreatedByUser(u);
        }

        [TestMethod]
        [TestCategory("Event")]
        [TestProperty("Test Event", "getAllEventsParticipatedByUser")]
        public void getAllEventsParticipatedByUser_UserWhoParticipatedToAnEvent_Return_Count_Equals1()
        {
            User u = new User { Id = 1 };
            List<Event> events = service.getAllEventsParticipatedByUser(u);
            Assert.AreEqual(1, events.Count);
        }

        [TestMethod]
        [TestCategory("Event")]
        [TestProperty("Test Event", "getAllEventsParticipatedByUser")]
        [ExpectedException(typeof(ListEmptyException))]
        public void getAllEventsParticipatedByUser_UserWhoDoesntParticipatedToAnEvent_Return_ListEmptyException()
        {
            User u = new User { Id = 2 };
            List<Event> events = service.getAllEventsCreatedByUser(u);
        }
    }
}
