using Microsoft.VisualStudio.TestTools.UnitTesting;
using portal_project.Models;
using System;
using System.Collections.Generic;
using TestUnitaire.Mock;

namespace TestUnitaire
{
    [TestClass]
    public class CategorieTest
    {
        CategorieMockDao dao;
        [TestInitialize] //Setup: s'execute avant chaque méthode de test
        public void Setup()
        {
            dao = new CategorieMockDao();
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
            dao.createCategorie(new Categorie(2, "Culturel"));
            Assert.AreEqual(2, dao.Categories.Count);
        }

        [TestMethod]
        [TestCategory("Categorie")]
        [TestProperty("Test Categorie", "Create")]
        public void CreateCategorie_SameId_Return_Count_Equals1()
        {
            dao.createCategorie(new Categorie(1, "Culturel"));
            Assert.AreEqual(1, dao.Categories.Count);
        }

        [TestMethod]
        [TestCategory("Categorie")]
        [TestProperty("Test Categorie", "Delete")]
        public void DeleteCategorie_Id_Known_Return_Count_Equals0()
        {
            dao.deleteCategorie(1);
            Assert.AreEqual(0, dao.Categories.Count);
        }

        [TestMethod]
        [TestCategory("Categorie")]
        [TestProperty("Test Categorie", "Delete")]
        public void DeleteCategorie_Id_Unknown_Return_Count_Equals1()
        {
            dao.deleteCategorie(2);
            Assert.AreEqual(1, dao.Categories.Count);
        }

        [TestMethod]
        [TestCategory("Categorie")]
        [TestProperty("Test Categorie", "Edit")]
        public void EditCategorie_Id_Known_Return_Item_Edited()
        {
            Categorie cat = new Categorie(1, "Culturel");
            dao.editCategorie(cat);
            Assert.AreEqual(cat.Libelle, dao.findOneById(1).Libelle);
        }

        [TestMethod]
        [TestCategory("Categorie")]
        [TestProperty("Test Categorie", "Edit")]
        public void EditCategorie_Id_Unknown_Return_Item_NotEdited()
        {
            Categorie cat = new Categorie(2, "Culturel");
            dao.editCategorie(cat);
            Assert.AreEqual("Sportif", dao.findOneById(1).Libelle);
        }

        [TestMethod]
        [TestCategory("Categorie")]
        [TestProperty("Test Categorie", "FindById")]
        public void FindById_UnknowId_Return_Object_Null()
        {
            Categorie cat = dao.findOneById(2);
            Assert.AreEqual(null, cat);
        }

        [TestMethod]
        [TestCategory("Categorie")]
        [TestProperty("Test Categorie", "FindById")]
        public void FindById_knowId_Return_Libelle_EqualsSportif()
        {
            Categorie cat = dao.findOneById(1);
            Assert.AreEqual("Sportif", cat.Libelle);
        }


        [TestMethod]
        [TestCategory("Categorie")]
        [TestProperty("Test Categorie", "FindAll")]
        public void FindAll_Categorie_Return_Count_Equals1()
        {
            List<Categorie> categories = dao.getAllCategories();
            Assert.AreEqual(1, categories.Count);
        }


    }
}
