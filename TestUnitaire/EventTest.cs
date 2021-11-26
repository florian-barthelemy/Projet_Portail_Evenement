using Microsoft.VisualStudio.TestTools.UnitTesting;
using portal_project.Models;
using System;
using System.Collections.Generic;
using TestUnitaire.Mock;

namespace TestUnitaire
{
    [TestClass]
    public class EventTest
    {
        EventMockDao dao;
        [TestInitialize] //Setup: s'execute avant chaque méthode de test
        public void Setup()
        {
            dao = new EventMockDao();
            dao.Events.Add(new Event() { Titre = "CDM", Id = 1 });
            Adresse adr = new Adresse(1, 3.062618, 50.637243, "1 rue esquermoise", "59800", "Lille");
            dao.Events[0].EventAdresse = adr;
            DateTime dateDebut = new DateTime(2018, 9, 7);
            DateTime dateFin = new DateTime(2018, 12, 12);
            dao.Events[0].DateDebut = dateDebut;
            dao.Events[0].DateFin = dateFin;
            SousCategorie sousCategorie = new SousCategorie() { Libelle = "Foot"};
            dao.Events[0].EventSousCat = sousCategorie;
            Categorie categorie = new Categorie() { Libelle = "Sportif" };
            dao.Events[0].EventSousCat.EventCategorie = categorie;
        }

        [TestCleanup] //Clean: s'execute après chaque méthode de test
        public void Clean()
        {
            dao.Events.Clear();
        }

        [TestMethod]
        [TestCategory("Event")]
        [TestProperty("Test Event", "Create")]
        public void CreateCategorie_DifferentId_Return_Count_Equals2()
        {

            dao.createEvent(new Event() { Id = 2 });
            Assert.AreEqual(2, dao.Events.Count);
        }

        [TestMethod]
        [TestCategory("Event")]
        [TestProperty("Test Event", "Create")]
        public void CreateCategorie_SameId_Return_Count_Equals1()
        {

            dao.createEvent(new Event() { Id = 1 });
            Assert.AreEqual(1, dao.Events.Count);
        }

        [TestMethod]
        [TestCategory("Event")]
        [TestProperty("Test Event", "Delete")]
        public void DeleteCategorie_Id_Known_Return_Count_Equals0()
        {
            dao.deleteEvent(1);
            Assert.AreEqual(0, dao.Events.Count);
        }

        [TestMethod]
        [TestCategory("Event")]
        [TestProperty("Test Event", "Delete")]
        public void DeleteCategorie_Id_Unknown_Return_Count_Equals1()
        {
            dao.deleteEvent(2);
            Assert.AreEqual(1, dao.Events.Count);
        }

        [TestMethod]
        [TestCategory("Event")]
        [TestProperty("Test Event", "Edit")]
        public void EditCategorie_Id_Known_Return_Item_Edited()
        {
            Event e1 = new Event { Id = 1, Titre = "CDM2018" };
            dao.editEvent(e1);
            Assert.AreEqual(e1.Titre, dao.findOneById(1).Titre);
        }

        [TestMethod]
        [TestCategory("Event")]
        [TestProperty("Test Event", "Edit")]
        public void EditCategorie_Id_Unknown_Return_Item_NotEdited()
        {
            Event e1 = new Event { Id = 2, Titre = "CDM2018" };
            dao.editEvent(e1);
            Assert.AreEqual("CDM", dao.findOneById(1).Titre);
        }

        [TestMethod]
        [TestCategory("Event")]
        [TestProperty("Test Event", "FindById")]
        public void FindById_UnknowId_Return_Object_Null()
        {
            Event evt = dao.findOneById(2);
            Assert.AreEqual(null, evt);
        }

        [TestMethod]
        [TestCategory("Event")]
        [TestProperty("Test Event", "FindById")]
        public void FindById_KnownId_Return_Titre_CDM()
        {
            Event evt = dao.findOneById(1);
            Assert.AreEqual("CDM", evt.Titre);
        }
        [TestMethod]
        [TestCategory("Event")]
        [TestProperty("Test Event", "FindAll")]
        public void FindAll_Event_Return_Count_Equals1()
        {
            List<Event> events = dao.getAllEvents();
            Assert.AreEqual(1, events.Count);
        }
        [TestMethod]
        [TestCategory("Event")]
        [TestProperty("Test Event", "FindByDateDebut")]
        public void FindByDateDebut_CorrectDate_Return_Count_Equals1()
        {
            List<Event> events = dao.findAllEventsByDateDebut(new DateTime(2018, 9, 7));
            Assert.AreEqual(1, events.Count);
        }

        [TestMethod]
        [TestCategory("Event")]
        [TestProperty("Test Event", "FindByDateDebut")]
        public void FindByDateDebut_IncorrectDate_Return_Count_Equals0()
        {
            List<Event> events = dao.findAllEventsByDateDebut(new DateTime(2018, 10, 7));
            Assert.AreEqual(0, events.Count);
        }

        [TestMethod]
        [TestCategory("Event")]
        [TestProperty("Test Event", "FindByDateFin")]
        public void FindByDateFin_CorrectDate_Return_Count_Equals1()
        {
            List<Event> events = dao.findAllEventsByDateFin(new DateTime(2018, 12, 12));
            Assert.AreEqual(1, events.Count);
        }

        [TestMethod]
        [TestCategory("Event")]
        [TestProperty("Test Event", "FindByDateFin")]
        public void FindByDateFin_InCorrectDate__Return_Count_Equals0()
        {
            List<Event> events = dao.findAllEventsByDateFin(new DateTime(2018, 10, 7));
            Assert.AreEqual(0, events.Count);
        }

        [TestMethod]
        [TestCategory("Event")]
        [TestProperty("Test event", "FindByIntervalle")]
        public void FindByIntervall_DateDebut_Correct_DateFin_Correct_Return_Count_Equals1()
        {
            List<Event> events = dao.findAllEventsByDateInterval(new DateTime(2018, 9, 7), new DateTime(2018, 12, 12));
            Assert.AreEqual(1, events.Count);
        }

        [TestMethod]
        [TestCategory("Event")]
        [TestProperty("Test event", "FindByIntervalle")]
        public void FindByIntervall_DateDebut_Incorrect_DateFin_Correct_Return_Count_Equals0()
        {
            List<Event> events = dao.findAllEventsByDateInterval(new DateTime(2018, 10, 7), new DateTime(2018, 12, 12));
            Assert.AreEqual(0, events.Count);
        }

        [TestMethod]
        [TestCategory("Event")]
        [TestProperty("Test event", "FindByIntervalle")]
        public void FindByIntervall_DateDebut_Correct_DateFin_Incorrect_Return_Count_Equals0()
        {
            List<Event> events = dao.findAllEventsByDateInterval(new DateTime(2018, 9, 7), new DateTime(2018, 11, 12));
            Assert.AreEqual(0, events.Count);
        }

        [TestMethod]
        [TestCategory("Event")]
        [TestProperty("Test event", "FindByIntervalle")]
        public void FindByIntervall_DateDebut_Incorrect_DateFin_Incorrect_Return_Count_Equals0()
        {
            List<Event> events = dao.findAllEventsByDateInterval(new DateTime(2018, 10, 7), new DateTime(2018, 11, 12));
            Assert.AreEqual(0, events.Count);
        }

        [TestMethod]
        [TestCategory("Event")]
        [TestProperty("Test Event", "FindByTitre")]
        public void FindByTitre_CDM_Return_Count_Equals1()
        {
            List<Event> events = dao.findAllEventsByTitre("CDM");
            Assert.AreEqual(1, events.Count);
        }

        [TestMethod]
        [TestCategory("Event")]
        [TestProperty("Test Event", "FindByTitre")]
        public void FindByTitre_CDM2018_Return_Count_Equals0()
        {
            List<Event> events = dao.findAllEventsByTitre("CDM2018");
            Assert.AreEqual(0, events.Count);
        }

        [TestMethod]
        [TestCategory("Event")]
        [TestProperty("Test Event", "FindByVille")]
        public void FindByVille_Lille_Return_Count_Equals1()
        {
            List<Event> events = dao.findAllEventsByVille("Lille");
            Assert.AreEqual(1, events.Count);
        }

        [TestMethod]
        [TestCategory("Event")]
        [TestProperty("Test Event", "FindByVille")]
        public void FindByVille_Paris_Return_Count_Equals0()
        {
            List<Event> events = dao.findAllEventsByVille("Paris");
            Assert.AreEqual(0, events.Count);
        }

        [TestMethod]
        [TestCategory("Event")]
        [TestProperty("Test Event", "FindByCategorie")]
        public void FindByCategorie_Sportif_Return_Count_Equals1()
        {
            List<Event> events = dao.findAllEventsByCategorie("Sportif");
            Assert.AreEqual(1, events.Count);
        }

        [TestMethod]
        [TestCategory("Event")]
        [TestProperty("Test Event", "FindByCategorie")]
        public void FindByCategorie_Culturel_Return_Count_Equals0()
        {
            List<Event> events = dao.findAllEventsByCategorie("Culturel");
            Assert.AreEqual(0, events.Count);
        }

        [TestMethod]
        [TestCategory("Event")]
        [TestProperty("Test Event", "FindBySousCategorie")]
        public void FindBySousCategorie_Foot_Return_Count_Equals1()
        {
            List<Event> events = dao.findAllEventsBySousCategorie("Foot");
            Assert.AreEqual(1, events.Count);
        }

        [TestMethod]
        [TestCategory("Event")]
        [TestProperty("Test Event", "FindBySousCategorie")]
        public void FindBySousCategorie_Hand_Return_Count_Equals0()
        {
            List<Event> events = dao.findAllEventsBySousCategorie("Hand");
            Assert.AreEqual(0, events.Count);
        }
    }
}
