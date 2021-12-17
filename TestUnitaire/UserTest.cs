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
    public class UserTest
    {
        UserMockDao dao;
        UserService service;
        [TestInitialize] //Setup: s'execute avant chaque méthode de test
        public void Setup()
        {
            dao = new UserMockDao();
            service = new UserService(dao);
            User u = new User { Id = 1, Nom = "Jehann", Prenom = "Lille", Email = "jehan@lille.com", IsAdmin = true };
            DateTime dateNaissance = DateTime.Now;
            dateNaissance = dateNaissance.AddYears(-3);
            Adresse adresse = new Adresse(1, 3.062618, 50.637243, "1 rue esquermoise", "59800", "Lille");
            u.DateNais = dateNaissance;
            u.MainAdresse = adresse;
            u.UserGenre = User.Genre.Homme;
            dao.Users.Add(u);

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
            service.createUser(user1);
            Assert.AreEqual(2, dao.Users.Count);
        }

        [TestMethod]
        [TestCategory("User")]
        [TestProperty("Test User", "Create")]
        [ExpectedException(typeof(AlreadyCreatedException))]
        public void CreateUser_DifferentId_SameEmail_Return_AlreadyCreatedException()
        {
            User user1 = new User()
            {
                Id = 2,
                Nom = "Jehann",
                Prenom = "Lille",
                Email = "jehan@lille.com"
            };
            service.createUser(user1);
        }

        [TestMethod]
        [TestCategory("User")]
        [TestProperty("Test User", "Create")]
        [ExpectedException(typeof(AlreadyCreatedException))]
        public void CreateUser_SameId_DifferentEmail_Return_AlreadyCreatedException()
        {
            User user1 = new User()
            {
                Id = 1,
                Nom = "Jehann",
                Prenom = "Lille",
                Email = "jehan2@lille.com"
            };
            service.createUser(user1);
        }

        [TestMethod]
        [TestCategory("User")]
        [TestProperty("Test User", "Delete")]
        public void DeleteUser_Id_Known_Return_Count_Equals0()
        {
            service.deleteUser(1);
            Assert.AreEqual(0, dao.Users.Count);
        }

        [TestMethod]
        [TestCategory("User")]
        [TestProperty("Test User", "Delete")]
        [ExpectedException(typeof(NullReferenceException))]
        public void DeleteUser_Id_UnKnown_Return_NullReferencException()
        {
            service.deleteUser(2);
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
            service.editUser(user1);
            Assert.AreEqual(user1.Nom, service.findOneById(1).Nom);
        }
        [TestMethod]
        [TestCategory("User")]
        [TestProperty("Test User", "Edit")]
        [ExpectedException(typeof(NullReferenceException))]
        public void EditUser_Id_Unknown_Return_NullReferenceException()
        {
            User user1 = new User()
            {
                Id = 2,
                Nom = "Dawan",
                Prenom = "Paris",
                Email = "jehan2@lille.com"
            };
            service.editUser(user1);
        }

        [TestMethod]
        [TestCategory("User")]
        [TestProperty("Test User", "FindByFirstName")]
        public void FindByFirstName_Li_Return_Count_Equals1()
        {

            List<User> users = service.findByFirstName("Li");
            Assert.AreEqual(1, users.Count);
        }

        [TestMethod]
        [TestCategory("User")]
        [TestProperty("Test User", "FindByFirstName")]
        [ExpectedException(typeof(ListEmptyException))]
        public void FindByFirstName_Pa_Return_ListEmptyException()
        {

            List<User> users = service.findByFirstName("Pa");
        }

        [TestMethod]
        [TestCategory("User")]
        [TestProperty("Test User", "FindByFullName")]
        public void FindByFullName_JehannLille_Return_Count_Equals_1()
        {
            List<User> users = service.findByFullName("Jehann", "Lille");
            Assert.AreEqual(1, users.Count);
        }

        [TestMethod]
        [TestCategory("User")]
        [TestProperty("Test User", "FindByFullName")]
        [ExpectedException(typeof(ListEmptyException))]
        public void FindByFullName_DawanParis_Return_ListEmptyException()
        {
            List<User> users = service.findByFullName("Dawan", "Paris");
        }

        [TestMethod]
        [TestCategory("User")]
        [TestProperty("Test User", "FindByLastName")]
        public void FindByLastName_Je_Return_Count_Equals_1()
        {

            List<User> users = service.findByLastName("Je");
            Assert.AreEqual(1, users.Count);
        }

        [TestMethod]
        [TestCategory("User")]
        [TestProperty("Test User", "FindByLastName")]
        [ExpectedException(typeof(ListEmptyException))]
        public void FindByLastName_Da_Return_ListEmptyException()
        {
            List<User> users = service.findByLastName("Da");
        }

        [TestMethod]
        [TestCategory("User")]
        [TestProperty("Test User", "FindOneById")]
        public void FindById_Id_Known_Return_Nom_EqualsJehann()
        {
            User u1 = service.findOneById(1);
            Assert.AreEqual("Jehann", u1.Nom);
        }

        [TestMethod]
        [TestCategory("User")]
        [TestProperty("Test User", "FindOneById")]
        [ExpectedException(typeof(NullReferenceException))]
        public void FindById_Id_Unknown_Return_NullReferenceException()
        {
            User u1 = service.findOneById(2);
        }

        [TestMethod]
        [TestCategory("User")]
        [TestProperty("Test User", "FindAll")]
        public void FindAll_Users_Return_Count_Equals1()
        {
            List<User> users = service.getAllUsers();
            Assert.AreEqual(1, users.Count);
        }

        [TestMethod]
        [TestCategory("User")]
        [TestProperty("Test User", "FindAll")]
        [ExpectedException(typeof(ListEmptyException))]
        public void FindAll_Users_Return_ListEmptyException()
        {
            service.deleteUser(1);
            List<User> users = service.getAllUsers();
        }


        [TestMethod]
        [TestCategory("User")]
        [TestProperty("Test User", "FindByCp")]
        public void FindByCp_59800_Return_Count_Equals1()
        {
            List<User> users = service.findAllUsersByCP("59800");
            Assert.AreEqual(1, users.Count);
        }

        [TestMethod]
        [TestCategory("User")]
        [TestProperty("Test User", "FindByCp")]
        [ExpectedException(typeof(ListEmptyException))]
        public void FindByCp_75015_Return_ListEmptyException()
        {
            List<User> users = service.findAllUsersByCP("75015");
        }

        [TestMethod]
        [TestCategory("User")]
        [TestProperty("Test User", "FindByVille")]
        public void FindByVille_Lille_Return_Count_Equals1()
        {
            List<User> users = service.findAllUsersByVille("Lille");
            Assert.AreEqual(1, users.Count);
        }

        [TestMethod]
        [TestCategory("User")]
        [TestProperty("Test User", "FindByVille")]
        [ExpectedException(typeof(ListEmptyException))]
        public void FindByVille_Paris_Return_ListEmptyException()
        {
            List<User> users = service.findAllUsersByVille("Paris");
            Assert.AreEqual(0, users.Count);
        }

        [TestMethod]
        [TestCategory("User")]
        [TestProperty("Test User", "FindByAge")]
        public void FindByAge_1_Comparatif_PlusVieux_Return_Count_Equals1()
        {
            List<User> users = service.findByAge(1, ">=");
            Assert.AreEqual(1, users.Count);
        }

        [TestMethod]
        [TestCategory("User")]
        [TestProperty("Test User", "FindByAge")]
        [ExpectedException(typeof(ListEmptyException))]
        public void FindByAge_10_Comparatif_PlusVieux_Return_ListEmptyException()
        {
            List<User> users = service.findByAge(10, ">=");
        }

        [TestMethod]
        [TestCategory("User")]
        [TestProperty("Test User", "FindByAge")]
        public void FindByAge_10_Comparatif_PlusJeune_Return_Count_Equals1()
        {
            List<User> users = service.findByAge(10, "<=");
            Assert.AreEqual(1, users.Count);
        }

        [TestMethod]
        [TestCategory("User")]
        [TestProperty("Test User", "FindByAge")]
        [ExpectedException(typeof(ListEmptyException))]
        public void FindByAge_1_Comparatif_PlusJeune_Return_ListEmptyException()
        {
            List<User> users = service.findByAge(1, "<=");
        }

        [TestMethod]
        [TestCategory("User")]
        [TestProperty("Test User", "FindByAge")]
        public void FindByAge_3_Comparatif_Exact_DateSuperieur_DateDuJour_Return_Count_Equals1()
        {
            List<User> users = service.findByAge(3, "=");
            Assert.AreEqual(1, users.Count);
        }

        [TestMethod]
        [TestCategory("User")]
        [TestProperty("Test User", "FindByAge")]
        [ExpectedException(typeof(ListEmptyException))]
        public void FindByAge_3_Comparatif_Exact_DateInferieur_DateDuJour_Return_ListEmptyException()
        {
            dao.Users[0].DateNais = dao.Users[0].DateNais.AddDays(-1);
            List<User> users = service.findByAge(3, "=");
        }

        [TestMethod]
        [TestCategory("User")]
        [TestProperty("Test User", "FindByAge")]
        [ExpectedException(typeof(ListEmptyException))]
        public void FindByAge_4_Comparatif_Exact_Return_ListEmptyException()
        {
            List<User> users = service.findByAge(4, "=");
        }
        [TestMethod]
        [TestCategory("User")]
        [TestProperty("Test User", "FindByAge")]
        [ExpectedException(typeof(ArgumentException))]
        public void FindByAge_4_BadComparatif_Return_ArgumentException()
        {
            List<User> users = service.findByAge(4, "!");
        }


        [TestMethod]
        [TestCategory("User")]
        [TestProperty("Test User", "FindAllAdmins")]
        public void FindAdmins_Return_Count_Equals1()
        {
            List<User> users = service.getAllAdmins();
            Assert.AreEqual(1, users.Count);
        }

        [TestMethod]
        [TestCategory("User")]
        [TestProperty("Test User", "FindAllAdmins")]
        [ExpectedException(typeof(ListEmptyException))]
        public void FindAdmins_AjoutUtilisateurNonAdmin_Return_ListEmptyException()
        {
            service.deleteUser(1);
            List<User> users = service.getAllAdmins();
        }

        [TestMethod]
        [TestCategory("User")]
        [TestProperty("Test User", "FindByGenre")]
        public void FindByGenre_h_Return_Count_Equals1()
        {
            List<User> users = service.findByGenre('h');
            Assert.AreEqual(1, users.Count);
        }
        [TestMethod]
        [TestCategory("User")]
        [TestProperty("Test User", "FindByGenre")]
        public void FindByGenre_f_Return_Count_Equals1()
        {
            service.createUser(new User { Id = 2, UserGenre = User.Genre.Femme });
            List<User> users = service.findByGenre('f');
            Assert.AreEqual(1, users.Count);
        }
        [TestMethod]
        [TestCategory("User")]
        [TestProperty("Test User", "FindByGenre")]
        [ExpectedException(typeof(ListEmptyException))]
        public void FindByGenre_h_Return_ListEmptyException()
        {
            service.deleteUser(1);
            List<User> users = service.findByGenre('h');
            Assert.AreEqual(1, users.Count);
        }

        [TestMethod]
        [TestCategory("User")]
        [TestProperty("Test User", "FindByGenre")]
        [ExpectedException(typeof(ListEmptyException))]
        public void FindByGenre_f_Return_ListEmptyException()
        {
            List<User> users = service.findByGenre('f');
            Assert.AreEqual(1, users.Count);
        }

        [TestMethod]
        [TestCategory("User")]
        [TestProperty("Test User", "FindByGenre")]
        [ExpectedException(typeof(ArgumentException))]
        public void FindByGenre_g_Return_ArgumentException()
        {
            List<User> users = service.findByGenre('g');
            Assert.AreEqual(1, users.Count);
        }

    }
}
