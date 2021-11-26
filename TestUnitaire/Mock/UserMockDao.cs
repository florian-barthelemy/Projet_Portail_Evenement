﻿using portal_project.Metier;
using portal_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestUnitaire.Mock
{
    public class UserMockDao : IUser
    {
        public List<User> Users;

        public UserMockDao()
        {
            Users = new List<User>();
        }

        public void createUser(User user)
        {
            User User1 =Users.Find(u => u.Id == user.Id || u.Email == user.Email);
            if (User1 == null)
            {
                Users.Add(user);
            }
        }

        public void deleteUser(int id_user)
        {
            User User1 = Users.Find(u => u.Id == id_user);
            if (User1 != null)
            {
                Users.Remove(User1);
            }
        }

        public void editUser(User user)
        {
            User User1 = Users.Find(u => u.Id == user.Id);
            if (User1 != null)
            {
                Users.Remove(User1);
                Users.Add(user);
            }
        }

        public List<User> findAllUsersByCP(string code_postal)
        {
            return Users.FindAll(u => u.MainAdresse.CodePostal.Equals(code_postal));
        }

        public List<User> findAllUsersByVille(string ville)
        {
            return Users.FindAll(u => u.MainAdresse.Ville.Equals(ville));
        }

        public List<User> findByAge(int age, string filter)
        {
            DateTime filterDate = DateTime.Now;
            filterDate=filterDate.AddYears(-age);
            List<User> dbUser = null;
            switch (filter)
            {
                case ">=": // plus vieux que
                    dbUser = Users.FindAll(u => u.DateNais.Year <= filterDate.Year);
                    break;
                case "<=": // plus jeune que
                    dbUser = Users.FindAll(u => u.DateNais.Year >= filterDate.Year);
                    break;
                case "=": // age exact
                    dbUser = Users.FindAll(u => u.DateNais.Year == filterDate.Year);
                    break;
            }
            return dbUser;
        }

        public List<User> findByFirstName(string prenom)
        {
            return Users.FindAll(u=> u.Prenom.Contains(prenom));
        }

        public List<User> findByFullName(string nom, string prenom)
        {
            return Users.FindAll(u=> u.Prenom.Contains(prenom) && u.Nom.Contains(nom));
        }

        public List<User> findByLastName(string nom)
        {
            return Users.FindAll(u => u.Nom.Contains(nom));
        }

        public User findOneById(int id)
        {
            return Users.Find(u => u.Id == id);
        }

        public List<User> getAllAdmins()
        {
            throw new NotImplementedException();
        }

        public List<User> getAllUsers()
        {
            return Users;
        }
    }
}
