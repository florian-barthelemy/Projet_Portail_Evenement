using Microsoft.VisualStudio.TestTools.UnitTesting;
using portal_project.Exceptions;
using portal_project.Models;
using portal_project.Service;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TestUnitaire.Mock;

namespace TestUnitaire
{
    [TestClass]
    public class SousCategorieTest
    {
        SousCategorieMockDao dao;
        SousCategorieService service;
        [TestInitialize] //Setup: s'execute avant chaque méthode de test
        public void Setup()
        {
            dao = new SousCategorieMockDao();
            service = new SousCategorieService(dao);
            Categorie categorie = new Categorie {Id= 1, Libelle="Sportif"};
            SousCategorie sousCategorie = new SousCategorie {EventCategorie=categorie, Id=1, Libelle="Foot" };
            dao.SousCategories.Add(sousCategorie);
        }
        [TestCleanup] //Clean: s'execute après chaque méthode de test
        public void Clean()
        {
            dao.SousCategories.Clear();
        }

        [TestMethod]
        [TestCategory("SousCategorie")]
        [TestProperty("Test SousCategorie", "Create")]
        public void CreateSousCategorie_DifferentId_Return_Count_Equals2()
        {
            SousCategorie sousCategorie = new SousCategorie { Id = 2, Libelle = "Rugby" };
            service.createSousCategorie(sousCategorie);
            Assert.AreEqual(2, dao.SousCategories.Count);
        }

        [TestMethod]
        [TestCategory("SousCategorie")]
        [TestProperty("Test SousCategorie", "Create")]
        [ExpectedException(typeof(AlreadyCreatedException))]
        public void CreateSousCategorie_SameId_Return_AlreadyCreatedException()
        {
            SousCategorie sousCategorie = new SousCategorie { Id = 1, Libelle = "Rugby" };
            service.createSousCategorie(sousCategorie);
        }

        [TestMethod]
        [TestCategory("SousCategorie")]
        [TestProperty("Test SousCategorie", "Delete")]
        public void DeleteSousCategorie_Id_Known_Return_Count_Equals0()
        {

            service.deleteSousCategorie(1);
            Assert.AreEqual(0, dao.SousCategories.Count);
        }
        [TestMethod]
        [TestCategory("SousCategorie")]
        [TestProperty("Test SousCategorie", "Delete")]
        [ExpectedException(typeof(NotFoundException))]
        public void DeleteSousCategorie_Id_Unknown_Return_NotFoundException()
        {
            service.deleteSousCategorie(2);
        }

        [TestMethod]
        [TestCategory("SousCategorie")]
        [TestProperty("Test SousCategorie", "Edit")]
        public void EditSousCategorie_Id_Known_Return_Item_Edited()
        {
            SousCategorie sousCategorie = new SousCategorie { Id = 1, Libelle = "Rugby" };
            service.editSousCategorie(sousCategorie);
            Assert.AreEqual(sousCategorie.Libelle, service.findOneById(1).Libelle);
        }

        [TestMethod]
        [TestCategory("SousCategorie")]
        [TestProperty("Test SousCategorie", "Edit")]
        [ExpectedException(typeof(NotFoundException))]
        public void EditSousCategorie_Id_Unknown_Return_NotFoundException()
        {
            SousCategorie sousCategorie = new SousCategorie { Id = 2, Libelle = "Rugby" };
            service.editSousCategorie(sousCategorie);
        }

        [TestMethod]
        [TestCategory("SousCategorie")]
        [TestProperty("Test SousCategorie", "FindOneById")]
        public void FindByIdSousCategorie_Id_Known_Return_Libelle_EqualsFoot()
        {
            SousCategorie sousCategorie = service.findOneById(1);
            Assert.AreEqual("Foot", sousCategorie.Libelle);
        }

        [TestMethod]
        [TestCategory("SousCategorie")]
        [TestProperty("Test SousCategorie", "FindOneById")]
        [ExpectedException(typeof(NotFoundException))]
        public void FindByIdSousCategorie_Id_Unknown_Return_NotFoundException()
        {
            SousCategorie sousCategorie = service.findOneById(2);
        }

        [TestMethod]
        [TestCategory("SousCategorie")]
        [TestProperty("Test SousCategorie", "GetAll")]
        public void GetAllSousCategorie_Return_Count_Equals1()
        {
            List<SousCategorie> sousCategories = service.getAllSousCategories();
            Assert.AreEqual(1, sousCategories.Count);
        }

        [TestMethod]
        [TestCategory("SousCategorie")]
        [TestProperty("Test SousCategorie", "GetAll")]
        [ExpectedException(typeof(ListEmptyException))]
        public void GetAllSousCategorie_Return_ListEmptyException()
        {
            service.deleteSousCategorie(1);
            List<SousCategorie> sousCategories = service.getAllSousCategories();
        }
        [TestMethod]
        [TestCategory("SousCategorie")]
        [TestProperty("Test SousCategorie", "GetAllByCategorie")]
        public void GetAllByCategorieSousCategorie_Sportif_Return_Count_Equals1()
        {
            List<SousCategorie> sousCategories = service.getAllSousCategoriesbyCategorie("Sportif");
            Assert.AreEqual(1, sousCategories.Count);
        }

        [TestMethod]
        [TestCategory("SousCategorie")]
        [TestProperty("Test SousCategorie", "GetAllByCategorie")]
        [ExpectedException(typeof(ListEmptyException))]
        public void GetAllByCategorieSousCategorie_Culturel_Return_ListEmptyException()
        {
            List<SousCategorie> sousCategories = service.getAllSousCategoriesbyCategorie("Culturel");
        }


    }
}
