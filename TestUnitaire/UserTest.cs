using Microsoft.VisualStudio.TestTools.UnitTesting;
using portal_project.Models;
using System;
using System.Collections.Generic;
using TestUnitaire.Mock;

namespace TestUnitaire
{
    [TestClass]
    public class UserTest
    {
        UserMockDao dao;
        [TestInitialize] //Setup: s'execute avant chaque méthode de test
        public void Setup()
        {
            dao = new UserMockDao();
            dao.Users.Add(new User() { Id = 1, Nom = "Jehann", Prenom = "Lille", Email = "jehan@lille.com", IsAdmin =true });
            DateTime dateNaissance = new DateTime(2018, 10, 1);
            Adresse adresse = new Adresse(1, 3.062618, 50.637243, "1 rue esquermoise", "59800", "Lille");
            dao.Users[0].DateNais = dateNaissance;
            dao.Users[0].MainAdresse = adresse;

        }

        [TestCleanup] //Clean: s'execute après chaque méthode de test
        public void Clean()
        {
            dao.Users.Clear();
        }
        [TestMethod]
        [TestCategory("User")]
        [TestProperty("Test User", "Create")]
        public void CreateUser_DifferentId_DifferentEmail_Return_Count_Equals2()
        {
            User user1 = new User()
            {
                Id = 2,
                Nom = "Jehann",
                Prenom = "Lille",
                Email = "jehan2@lille.com"
            };
            dao.createUser(user1);
            Assert.AreEqual(2, dao.Users.Count);
        }

        [TestMethod]
        [TestCategory("User")]
        [TestProperty("Test User", "Create")]
        public void CreateUser_DifferentId_SameEmail_Return_Count_Equals1()
        {
            User user1 = new User()
            {
                Id = 2,
                Nom = "Jehann",
                Prenom = "Lille",
                Email = "jehan@lille.com"
            };
            dao.createUser(user1);
            Assert.AreEqual(1, dao.Users.Count);
        }

        [TestMethod]
        [TestCategory("User")]
        [TestProperty("Test User", "Create")]
        public void CreateUser_SameId_DifferentEmail_Return_Count_Equals1()
        {
            User user1 = new User()
            {
                Id = 1,
                Nom = "Jehann",
                Prenom = "Lille",
                Email = "jehan2@lille.com"
            };
            dao.createUser(user1);
            Assert.AreEqual(1, dao.Users.Count);
        }

        [TestMethod]
        [TestCategory("User")]
        [TestProperty("Test User", "Delete")]
        public void DeleteUser_Id_Known_Return_Count_Equals0()
        {
            dao.deleteUser(1);
            Assert.AreEqual(0, dao.Users.Count);
        }

        [TestMethod]
        [TestCategory("User")]
        [TestProperty("Test User", "Delete")]
        public void DeleteUser_Id_UnKnown_Return_Count_Equals1()
        {
            dao.deleteUser(2);
            Assert.AreEqual(1, dao.Users.Count);
        }

        [TestMethod]
        [TestCategory("User")]
        [TestProperty("Test User", "Edit")]
        public void EditUser_Id_Known_Return_Item_Edited()
        {
            User user1 = new User()
            {
                Id = 1,
                Nom = "Dawan",
                Prenom = "Paris",
                Email = "jehan2@lille.com"
            };
            dao.editUser(user1);
            Assert.AreEqual(user1.Nom, dao.findOneById(1).Nom);
        }
        [TestMethod]
        [TestCategory("User")]
        [TestProperty("Test User", "Edit")]
        public void EditUser_Id_Unknown_Return_Item_NotEdited()
        {
            User user1 = new User()
            {
                Id = 2,
                Nom = "Dawan",
                Prenom = "Paris",
                Email = "jehan2@lille.com"
            };
            dao.editUser(user1);
            Assert.AreEqual("Jehann", dao.findOneById(1).Nom);
        }

        [TestMethod]
        [TestCategory("User")]
        [TestProperty("Test User", "FindByFirstName")]
        public void FindByFirstName_Li_Return_Count_Equals1()
        {

            List<User> users = dao.findByFirstName("Li");
            Assert.AreEqual(1, users.Count);
        }

        [TestMethod]
        [TestCategory("User")]
        [TestProperty("Test User", "FindByFirstName")]
        public void FindByFirstName_Pa_Return_Count_Equals_0()
        {

            List<User> users = dao.findByFirstName("Pa");
            Assert.AreEqual(0, users.Count);
        }

        [TestMethod]
        [TestCategory("User")]
        [TestProperty("Test User", "FindByFullName")]
        public void FindByFullName_JehannLille_Return_Count_Equals_1()
        {

            List<User> users = dao.findByFullName("Jehann", "Lille");
            Assert.AreEqual(1, users.Count);
        }

        [TestMethod]
        [TestCategory("User")]
        [TestProperty("Test User", "FindByFullName")]
        public void FindByFullName_DawanParis_Return_Count_Equals_0()
        {

            List<User> users = dao.findByFullName("Dawan", "Paris");
            Assert.AreEqual(0, users.Count);
        }

        [TestMethod]
        [TestCategory("User")]
        [TestProperty("Test User", "FindByLastName")]
        public void FindByLastName_Je_Return_Count_Equals_1()
        {

            List<User> users = dao.findByLastName("Je");
            Assert.AreEqual(1, users.Count);
        }

        [TestMethod]
        [TestCategory("User")]
        [TestProperty("Test User", "FindByLastName")]
        public void FindByLastName_Da_Return_Count_Equals_0()
        {

            List<User> users = dao.findByLastName("Da");
            Assert.AreEqual(0, users.Count);
        }

        [TestMethod]
        [TestCategory("User")]
        [TestProperty("Test User", "FindOneById")]
        public void FindById_Id_Known_Return_Nom_EqualsJehann()
        {
            User u1 = dao.findOneById(1);
            Assert.AreEqual("Jehann", u1.Nom);
        }

        [TestMethod]
        [TestCategory("User")]
        [TestProperty("Test User", "FindOneById")]
        public void FindById_Id_Unknown_Return_Object_Null()
        {
            User u1 = dao.findOneById(2);
            Assert.AreEqual(null, u1);
        }

        [TestMethod]
        [TestCategory("User")]
        [TestProperty("Test User", "FindAll")]
        public void FindAll_Users_Return_Count_Equals1()
        {
            List<User> users = dao.getAllUsers();
            Assert.AreEqual(1, users.Count);
        }


        [TestMethod]
        [TestCategory("User")]
        [TestProperty("Test User", "FindByCp")]
        public void FindByCp_59800_Return_Count_Equals1()
        {
            List<User> users = dao.findAllUsersByCP("59800");
            Assert.AreEqual(1, users.Count);
        }

        [TestMethod]
        [TestCategory("User")]
        [TestProperty("Test User", "FindByCp")]
        public void FindByCp_75015_Return_Count_Equals0()
        {
            List<User> users = dao.findAllUsersByCP("75015");
            Assert.AreEqual(0, users.Count);
        }

        [TestMethod]
        [TestCategory("User")]
        [TestProperty("Test User", "FindByVille")]
        public void FindByVille_Lille_Return_Count_Equals1()
        {
            List<User> users = dao.findAllUsersByVille("Lille");
            Assert.AreEqual(1, users.Count);
        }

        [TestMethod]
        [TestCategory("User")]
        [TestProperty("Test User", "FindByVille")]
        public void FindByVille_Paris_Return_Count_Equals0()
        {
            List<User> users = dao.findAllUsersByVille("Paris");
            Assert.AreEqual(0, users.Count);
        }

        [TestMethod]
        [TestCategory("User")]
        [TestProperty("Test User", "FindByAge")]
        public void FindByAge_1_Comparatif_PlusVieux_Return_Count_Equals1()
        {
            List<User> users = dao.findByAge(1,">=");
            Assert.AreEqual(1, users.Count);
        }

        [TestMethod]
        [TestCategory("User")]
        [TestProperty("Test User", "FindByAge")]
        public void FindByAge_10_Comparatif_PlusVieux_Return_Count_Equals0()
        {
            List<User> users = dao.findByAge(10, ">=");
            Assert.AreEqual(0, users.Count);
        }

        [TestMethod]
        [TestCategory("User")]
        [TestProperty("Test User", "FindByAge")]
        public void FindByAge_10_Comparatif_PlusJeune_Return_Count_Equals1()
        {
            List<User> users = dao.findByAge(10, "<=");
            Assert.AreEqual(1, users.Count);
        }

        [TestMethod]
        [TestCategory("User")]
        [TestProperty("Test User", "FindByAge")]
        public void FindByAge_1_Comparatif_PlusJeune_Return_Count_Equals0()
        {
            List<User> users = dao.findByAge(1, "<=");
            Assert.AreEqual(0, users.Count);
        }

        [TestMethod]
        [TestCategory("User")]
        [TestProperty("Test User", "FindByAge")]
        public void FindByAge_3_Comparatif_Exact_Return_Count_Equals1()
        {
            List<User> users = dao.findByAge(3, "=");
            Assert.AreEqual(1, users.Count);
        }

        [TestMethod]
        [TestCategory("User")]
        [TestProperty("Test User", "FindByAge")]
        public void FindByAge_4_Comparatif_Exact_Return_Count_Equals0()
        {
            List<User> users = dao.findByAge(4, "=");
            Assert.AreEqual(0, users.Count);
        }
        [TestMethod]
        [TestCategory("User")]
        [TestProperty("Test User", "FindByAge")]
        public void FindByAge_2_Comparatif_Exact_Return_Count_Equals0()
        {
            List<User> users = dao.findByAge(2, "=");
            Assert.AreEqual(0, users.Count);
        }

        [TestMethod]
        [TestCategory("User")]
        [TestProperty("Test User", "FindAllAdmins")]
        public void FindAdmins_Return_Count_Equals1()
        {
            List<User> users = dao.getAllAdmins();
            Assert.AreEqual(1, users.Count);
        }

        [TestMethod]
        [TestCategory("User")]
        [TestProperty("Test User", "FindAllAdmins")]
        public void FindAdmins_AjoutUtilisateurNonAdmin_Return_Count_Equals1()
        {
            User u2 = new User() { Id = 2, Email = "Dawan@paris.com", IsAdmin = false };
            dao.createUser(u2);
            List<User> users = dao.getAllAdmins();
            Assert.AreEqual(1, users.Count);
        }
    }
}
