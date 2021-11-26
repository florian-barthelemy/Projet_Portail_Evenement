using Microsoft.VisualStudio.TestTools.UnitTesting;
using portal_project.Models;
using System;
using System.Collections.Generic;
using TestUnitaire.Mock;

namespace portal_project.test
{
    [TestClass]
    public class AdresseTest
    {
        AdresseMockDao dao;
        [TestInitialize] //Setup: s'execute avant chaque méthode de test
        public void Setup()
        {
            dao = new AdresseMockDao();
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

        public void CreateAdresse_Different_Return_Count_Equals2()
        {
            dao.createAdress(new Adresse(2.318485, 48.842827, "11 Rue Antoine Bourdelle", "75015", "Paris"));
            Assert.AreEqual(2, dao.Adresses.Count);
        }

        [TestMethod]
        [TestCategory("Adresse")]
        [TestProperty("Test Adresse", "Create")]

        public void CreateAdresse_Same_Return_Count_Equals1()
        {
            dao.createAdress(new Adresse(3.062618, 50.637243, "1 rue esquermoise", "59800", "Lille"));
            Assert.AreEqual(1, dao.Adresses.Count);
        }

        [TestMethod]
        [TestCategory("Adresse")]
        [TestProperty("Test Adresse", "Delete")]
        public void DeleteAdresse_Id_Known_Return_Count_Equals0()
        {
            dao.deleteAdresse(1);
            Assert.AreEqual(0, dao.Adresses.Count);
        }

        [TestMethod]
        [TestCategory("Adresse")]
        [TestProperty("Test Adresse", "Delete")]
        public void DeleteAdresse_Id_Unknown_Return_Count_Equals1()
        {
            dao.deleteAdresse(2);
            Assert.AreEqual(1, dao.Adresses.Count);
        }

        [TestMethod]
        [TestCategory("Adresse")]
        [TestProperty("Test Adresse", "Edit")]
        public void EditAdresse_Id_Known_Return_Item_Edited()
        {
            Adresse adr = new Adresse(1, 2.318485, 48.842827, "11 Rue Antoine Bourdelle", "75015", "Paris");
            dao.editAdress(adr);
            Assert.AreEqual(adr.Axe_X, dao.findOneById(1).Axe_X);
            Assert.AreEqual(adr.Axe_Y, dao.findOneById(1).Axe_Y);

        }

        [TestMethod]
        [TestCategory("Adresse")]
        [TestProperty("Test Adresse", "Edit")]
        public void EditAdresse_Id_UnKnown_Return_Item_NotEdited()
        {
            Adresse adr = new Adresse(2, 2.318485, 48.842827, "11 Rue Antoine Bourdelle", "75015", "Paris");
            dao.editAdress(adr);
            Assert.AreEqual(3.062618, dao.findOneById(1).Axe_X);
            Assert.AreEqual(50.637243, dao.findOneById(1).Axe_Y);

        }

        [TestMethod]
        [TestCategory("Adresse")]
        [TestProperty("Test Adresse", "FindByCp")]
        public void FindByCp_5_Return_Count_Equals0()
        {
            List<Adresse> adr = dao.findByCodePostal("5");
            Assert.AreEqual(0, adr.Count);
        }
        [TestMethod]
        [TestCategory("Adresse")]
        [TestProperty("Test Adresse", "FindByCp")]
        public void FindByCp_59800_Return_Count_Equals1()
        {
            List<Adresse> adr = dao.findByCodePostal("59800");
            Assert.AreEqual(1, adr.Count);
        }

        [TestMethod]
        [TestCategory("Adresse")]
        [TestProperty("Test Adresse", "FindByVille")]
        public void FindByVille_Containsl_Return_Count_Equals1()
        {
            List<Adresse> adr = dao.findByVille("l");
            Assert.AreEqual(1, adr.Count);
        }

        [TestMethod]
        [TestCategory("Adresse")]
        [TestProperty("Test Adresse", "FindByVille")]
        public void FindByVille_Containsp_Return_Count_Equals0()
        {
            List<Adresse> adr = dao.findByVille("p");
            Assert.AreEqual(0, adr.Count);
        }

        [TestMethod]
        [TestCategory("Adresse")]
        [TestProperty("Test Adresse", "FindByCoordinates")]
        public void FindByCoordinates_CoordinatesLille_Return_Ville_EqualsLille()
        {
            Adresse adr = dao.findOneByCoordinates(3.062618, 50.637243);
            Assert.AreEqual("Lille", adr.Ville);
        }

        [TestMethod]
        [TestCategory("Adresse")]
        [TestProperty("Test Adresse", "FindByCoordinates")]
        public void FindByCoordinates_CoordinatesParis_Return_Object_Null()
        {
            Adresse adr = dao.findOneByCoordinates(2.318485, 48.842827);
            Assert.AreEqual(null, adr);
        }

        [TestMethod]
        [TestCategory("Adresse")]
        [TestProperty("Test Adresse", "FindById")]
        public void FindById_1_Return_Ville_EqualsLille()
        {
            Adresse adr = dao.findOneById(1);
            Assert.AreEqual("Lille", adr.Ville);
        }

        [TestMethod]
        [TestCategory("Adresse")]
        [TestProperty("Test Adresse", "FindById")]
        public void FindById_UnkwnonId_Return_Object_Null()
        {
            Adresse adr = dao.findOneById(2);
            Assert.AreEqual(null, adr);
        }


        [TestMethod]
        [TestCategory("Adresse")]
        [TestProperty("Test Adresse", "FindAll")]
        public void FindAll_Adresse_Return_Count_Equals1()
        {
            List<Adresse> adresses = dao.getAllAdresses();
            Assert.AreEqual(1, adresses.Count);
        }

    }
}
