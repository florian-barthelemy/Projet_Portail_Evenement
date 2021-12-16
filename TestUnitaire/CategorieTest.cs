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
    public class CategorieTest
    {
        CategorieDao dao;
        CategorieService service;
        [TestInitialize] //Setup: s'execute avant chaque méthode de test
        public void Setup()
        {
            dao = new CategorieDao();
            service = new CategorieService(dao);
            dao.Categories.Add(new Categorie(1, "Sportif"));
        }

        [TestCleanup] //Clean: s'execute après chaque méthode de test
        public void Clean()
        {
            dao.Categories.Clear();
        }

        [TestMethod]
        [TestCategory("Categorie")]
        [TestProperty("Test Categorie", "Create")]
        public void CreateCategorie_DifferentId_Return_Count_Equals2()
        {
            service.createCategorie(new Categorie(2, "Culturel"));
            Assert.AreEqual(2, dao.Categories.Count);
        }

        [TestMethod]
        [TestCategory("Categorie")]
        [TestProperty("Test Categorie", "Create")]
        [ExpectedException(typeof(AlreadyCreatedException))]
        public void CreateCategorie_SameId_Return_AlreadyCreatedException()
        {
            service.createCategorie(new Categorie(1, "Culturel"));
        }

        [TestMethod]
        [TestCategory("Categorie")]
        [TestProperty("Test Categorie", "Delete")]
        public void DeleteCategorie_Id_Known_Return_Count_Equals0()
        {
            service.deleteCategorie(1);
            Assert.AreEqual(0, dao.Categories.Count);
        }

        [TestMethod]
        [TestCategory("Categorie")]
        [TestProperty("Test Categorie", "Delete")]
        [ExpectedException(typeof(NullReferenceException))]
        public void DeleteCategorie_Id_Unknown_Return_NullReferenceException()
        {
            service.deleteCategorie(2);
        }

        [TestMethod]
        [TestCategory("Categorie")]
        [TestProperty("Test Categorie", "Edit")]
        public void EditCategorie_Id_Known_Return_Item_Edited()
        {
            Categorie cat = new Categorie(1, "Culturel");
            service.editCategorie(cat);
            Assert.AreEqual(cat.Libelle, service.findOneById(1).Libelle);
        }

        [TestMethod]
        [TestCategory("Categorie")]
        [TestProperty("Test Categorie", "Edit")]
        [ExpectedException(typeof(NullReferenceException))]
        public void EditCategorie_Id_Unknown_Return_NullReferenceException()
        {
            Categorie cat = new Categorie(2, "Culturel");
            service.editCategorie(cat);
        }

        [TestMethod]
        [TestCategory("Categorie")]
        [TestProperty("Test Categorie", "FindById")]
        [ExpectedException(typeof(NullReferenceException))]
        public void FindById_UnknowId_Return_NullReferenceException()
        {
            Categorie cat = service.findOneById(2);
        }

        [TestMethod]
        [TestCategory("Categorie")]
        [TestProperty("Test Categorie", "FindById")]
        public void FindById_knowId_Return_Libelle_EqualsSportif()
        {
            Categorie cat = service.findOneById(1);
            Assert.AreEqual("Sportif", cat.Libelle);
        }


        [TestMethod]
        [TestCategory("Categorie")]
        [TestProperty("Test Categorie", "FindAll")]
        public void FindAll_Categorie_Return_Count_Equals1()
        {
            List<Categorie> categories = service.getAllCategories();
            Assert.AreEqual(1, categories.Count);
        }

        [TestMethod]
        [TestCategory("Categorie")]
        [TestProperty("Test Categorie", "FindAll")]
        [ExpectedException(typeof(ListEmptyException))]
        public void FindAll_Categorie_Return_ListEmptyException()
        {
            service.deleteCategorie(1);
            List<Categorie> categories = service.getAllCategories();
        }

    }
}
