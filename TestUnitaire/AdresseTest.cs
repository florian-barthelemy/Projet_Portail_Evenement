using Microsoft.VisualStudio.TestTools.UnitTesting;
using portal_project.Exceptions;
using portal_project.Models;
using portal_project.Service;
using System;
using System.Collections.Generic;
using TestUnitaire.Mock;

namespace portal_project.test
{
    [TestClass]
    public class AdresseTest
    {
        AdresseMockDao dao;
        AdresseService service;
        [TestInitialize] //Setup: s'execute avant chaque méthode de test
        public void Setup()
        {
            dao = new AdresseMockDao();
            service = new AdresseService(dao);
            dao.Adresses.Add(new Adresse(1, 3.062618, 50.637243, "1 rue esquermoise", "59800", "Lille"));
        }

        [TestCleanup] //Clean: s'execute après chaque méthode de test
        public void Clean()
        {
            dao.Adresses.Clear();
        }

        [TestMethod]
        [TestCategory("Adresse")]
        [TestProperty("Test Adresse", "Create")]

        public void CreateAdresse_DifferentCoordinates_Return_Count_Equals2()
        {
            service.createAdress(new Adresse(2.318485, 48.842827, "11 Rue Antoine Bourdelle", "75015", "Paris"));
            Assert.AreEqual(2, dao.Adresses.Count);
        }

        [TestMethod]
        [TestCategory("Adresse")]
        [TestProperty("Test Adresse", "Create")]
        [ExpectedException(typeof(AlreadyCreatedException))]

        public void CreateAdresse_SameCoordinates_Return_AlreaddyCreatedException()
        {
            service.createAdress(new Adresse(3.062618, 50.637243, "1 rue esquermoise", "59800", "Lille"));
        }

        [TestMethod]
        [TestCategory("Adresse")]
        [TestProperty("Test Adresse", "Delete")]
        public void DeleteAdresse_Id_Known_Return_Count_Equals0()
        {
            service.deleteAdresse(1);
            Assert.AreEqual(0, dao.Adresses.Count);
        }

        [TestMethod]
        [TestCategory("Adresse")]
        [TestProperty("Test Adresse", "Delete")]
        [ExpectedException(typeof(NotFoundException))]
        public void DeleteAdresse_Id_Unknown_Return_NotFoundException()
        {
            service.deleteAdresse(2);
        }

        [TestMethod]
        [TestCategory("Adresse")]
        [TestProperty("Test Adresse", "Edit")]
        public void EditAdresse_Id_Known_Return_Item_Edited()
        {
            Adresse adr = new Adresse(1, 2.318485, 48.842827, "11 Rue Antoine Bourdelle", "75015", "Paris");
            service.editAdress(adr);
            Assert.AreEqual(adr.Axe_X, service.findOneById(1).Axe_X);
            Assert.AreEqual(adr.Axe_Y, service.findOneById(1).Axe_Y);

        }

        [TestMethod]
        [TestCategory("Adresse")]
        [TestProperty("Test Adresse", "Edit")]
        [ExpectedException(typeof(NotFoundException))]
        public void EditAdresse_Id_UnKnown_Return_NotFoundException()
        {
            Adresse adr = new Adresse(2, 2.318485, 48.842827, "11 Rue Antoine Bourdelle", "75015", "Paris");
            service.editAdress(adr);

        }

        [TestMethod]
        [TestCategory("Adresse")]
        [TestProperty("Test Adresse", "FindByCp")]
        [ExpectedException(typeof(ListEmptyException))]
        public void FindByCp_5_Return_ListEmptyException()
        {
            List<Adresse> adr = service.findByCodePostal("5");
        }
        [TestMethod]
        [TestCategory("Adresse")]
        [TestProperty("Test Adresse", "FindByCp")]
        public void FindByCp_59800_Return_Count_Equals1()
        {
            List<Adresse> adr = service.findByCodePostal("59800");
            Assert.AreEqual(1, adr.Count);
        }

        [TestMethod]
        [TestCategory("Adresse")]
        [TestProperty("Test Adresse", "FindByVille")]
        public void FindByVille_Containsl_Return_Count_Equals1()
        {
            List<Adresse> adr = service.findByVille("l");
            Assert.AreEqual(1, adr.Count);
        }

        [TestMethod]
        [TestCategory("Adresse")]
        [TestProperty("Test Adresse", "FindByVille")]
        [ExpectedException(typeof(ListEmptyException))]
        public void FindByVille_Containsp_Return_ListEmptyException()
        {
            List<Adresse> adr = service.findByVille("p");
        }

        [TestMethod]
        [TestCategory("Adresse")]
        [TestProperty("Test Adresse", "FindByCoordinates")]
        public void FindByCoordinates_CoordinatesLille_Return_Ville_EqualsLille()
        {
            Adresse adr = service.findOneByCoordinates(3.062618, 50.637243);
            Assert.AreEqual("Lille", adr.Ville);
        }

        [TestMethod]
        [TestCategory("Adresse")]
        [TestProperty("Test Adresse", "FindByCoordinates")]
        [ExpectedException(typeof(NotFoundException))]
        public void FindByCoordinates_CoordinatesParis_Return_NotFoundException()
        {
            Adresse adr = service.findOneByCoordinates(2.318485, 48.842827);
        }

        [TestMethod]
        [TestCategory("Adresse")]
        [TestProperty("Test Adresse", "FindById")]
        public void FindById_1_Return_Ville_EqualsLille()
        {
            Adresse adr = service.findOneById(1);
            Assert.AreEqual("Lille", adr.Ville);
        }

        [TestMethod]
        [TestCategory("Adresse")]
        [TestProperty("Test Adresse", "FindById")]
        [ExpectedException(typeof(NotFoundException))]
        public void FindById_UnkwnonId_Return_NotFoundException()
        {
            Adresse adr = service.findOneById(2);

        }


        [TestMethod]
        [TestCategory("Adresse")]
        [TestProperty("Test Adresse", "FindAll")]
        public void FindAll_Adresse_Return_Count_Equals1()
        {
            List<Adresse> adresses =service.getAllAdresses();
            Assert.AreEqual(1, adresses.Count);
        }
        [TestMethod]
        [TestCategory("Adresse")]
        [TestProperty("Test Adresse", "FindAll")]
        [ExpectedException(typeof(ListEmptyException))]
        public void FindAll_Adresse_Return_()
        {
            service.deleteAdresse(1);
            List<Adresse> adresses = service.getAllAdresses();
        }
    }
}
