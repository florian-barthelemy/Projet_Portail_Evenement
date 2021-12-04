﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using portal_project.Models;
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
        [TestInitialize] //Setup: s'execute avant chaque méthode de test
        public void Setup()
        {
            dao = new SousCategorieMockDao();
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
            dao.createSousCategorie(sousCategorie);
            Assert.AreEqual(2, dao.SousCategories.Count);
        }

        [TestMethod]
        [TestCategory("SousCategorie")]
        [TestProperty("Test SousCategorie", "Create")]
        public void CreateSousCategorie_SameId_Return_Count_Equals1()
        {
            SousCategorie sousCategorie = new SousCategorie { Id = 1, Libelle = "Rugby" };
            dao.createSousCategorie(sousCategorie);
            Assert.AreEqual(1, dao.SousCategories.Count);
        }

        [TestMethod]
        [TestCategory("SousCategorie")]
        [TestProperty("Test SousCategorie", "Delete")]
        public void DeleteSousCategorie_Id_Known_Return_Count_Equals0()
        {

            dao.deleteSousCategorie(1);
            Assert.AreEqual(0, dao.SousCategories.Count);
        }
        [TestMethod]
        [TestCategory("SousCategorie")]
        [TestProperty("Test SousCategorie", "Delete")]
        public void DeleteSousCategorie_Id_Unknown_Return_Count_Equals1()
        {

            dao.deleteSousCategorie(2);
            Assert.AreEqual(1, dao.SousCategories.Count);
        }

        [TestMethod]
        [TestCategory("SousCategorie")]
        [TestProperty("Test SousCategorie", "Edit")]
        public void EditSousCategorie_Id_Known_Return_Item_Edited()
        {
            SousCategorie sousCategorie = new SousCategorie { Id = 1, Libelle = "Rugby" };
            dao.editSousCategorie(sousCategorie);
            Assert.AreEqual(sousCategorie.Libelle, dao.findOneById(1).Libelle);
        }

        [TestMethod]
        [TestCategory("SousCategorie")]
        [TestProperty("Test SousCategorie", "Edit")]
        public void EditSousCategorie_Id_Unknown_Return_Item_Edited()
        {
            SousCategorie sousCategorie = new SousCategorie { Id = 2, Libelle = "Rugby" };
            dao.editSousCategorie(sousCategorie);
            Assert.AreEqual("Foot", dao.findOneById(1).Libelle);
        }

        [TestMethod]
        [TestCategory("SousCategorie")]
        [TestProperty("Test SousCategorie", "FindOneById")]
        public void FindByIdSousCategorie_Id_Known_Return_()
        {
            SousCategorie sousCategorie = dao.findOneById(1);
            Assert.AreEqual("Foot", sousCategorie.Libelle);
        }

        [TestMethod]
        [TestCategory("SousCategorie")]
        [TestProperty("Test SousCategorie", "FindOneById")]
        public void FindByIdSousCategorie_Id_Unknown_Return_()
        {
            SousCategorie sousCategorie = dao.findOneById(2);
            Assert.AreEqual(null, sousCategorie);
        }

        [TestMethod]
        [TestCategory("SousCategorie")]
        [TestProperty("Test SousCategorie", "GetAll")]
        public void GetAllSousCategorie_Return_Count_Equals1()
        {
            List<SousCategorie> sousCategories = dao.getAllSousCategories();
            Assert.AreEqual(1, sousCategories.Count);
        }

        [TestMethod]
        [TestCategory("SousCategorie")]
        [TestProperty("Test SousCategorie", "GetAllByCategorie")]
        public void GetAllByCategorieSousCategorie_Sportif_Return_Count_Equals1()
        {
            List<SousCategorie> sousCategories = dao.getAllSousCategoriesbyCategorie("Sportif");
            Assert.AreEqual(1, sousCategories.Count);
        }

        [TestMethod]
        [TestCategory("SousCategorie")]
        [TestProperty("Test SousCategorie", "GetAllByCategorie")]
        public void GetAllByCategorieSousCategorie_Culturel_Return_Count_Equals0()
        {
            List<SousCategorie> sousCategories = dao.getAllSousCategoriesbyCategorie("Culturel");
            Assert.AreEqual(0, sousCategories.Count);
        }


    }
}
