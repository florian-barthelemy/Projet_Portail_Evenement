﻿using portal_project.Metier;
using portal_project.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portal_project.Dao
{
    class UserImpl : IUser
    {
        MyContext context = new MyContext();
        public void createUser(User user)
        {
            User dbUser = context.Users.FirstOrDefault(u => u.Id == user.Id || u.Email == user.Email);
            if(dbUser == null)
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        public void deleteUser(int id_user)
        {
            User dbUser = context.Users.SingleOrDefault(u => u.Id == id_user);
            if(dbUser != null)
            {
                context.Users.Remove(dbUser);
            }
        }

        public void editUser(User user)
        {
            User dbUser = context.Users.SingleOrDefault(u => u.Id == user.Id);
            if (dbUser != null)
            {
                context.Users.Attach(user);
                context.Entry(user).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public List<User> findAllUsersByCP(string code_postal)
        {
            List<User> dbUser = context.Users.AsNoTracking().Where(u => u.MainAdresse.CodePostal.Equals(code_postal)).ToList();
            return dbUser;
        }

        public List<User> findAllUsersByVille(string ville)
        {
            List<User> dbUser = context.Users.AsNoTracking().Where(u => u.MainAdresse.Ville.Equals(ville)).ToList();
            return dbUser;
        }

        // filter ">=,<=,="
        public List<User> findByAge(int age, string filter)
        {
            DateTime filterDate = new DateTime();
            filterDate.AddYears(-age);
            List<User> dbUser = null;
            switch (filter)
            {
                case ">=": // plus vieux que
                    dbUser = context.Users.AsNoTracking().Where(u => u.DateNais <= filterDate).ToList();
                    break;
                case "<=": // plus jeune que
                    dbUser = context.Users.AsNoTracking().Where(u => u.DateNais >= filterDate).ToList();
                    break;
                case "=": // age exact
                    dbUser = context.Users.AsNoTracking().Where(u => u.DateNais == filterDate).ToList();
                    break;
            }
            return dbUser;
        }

        public List<User> findByFirstName(string prenom)
        {
            return context.Users.AsNoTracking().Where(u => u.Prenom.Contains(prenom)).ToList();
        }

        public List<User> findByFullName(string nom, string prenom)
        {
            return context.Users.AsNoTracking().Where(u => u.Prenom.Contains(prenom) || u.Nom.Contains(nom)).ToList();
        }

        public List<User> findByLastName(string nom)
        {
            return context.Users.AsNoTracking().Where(u => u.Nom.Contains(nom)).ToList();

        }

        public User findOneById(int id)
        {
            return context.Users.SingleOrDefault(u => u.Id == id);
        }

        public List<User> getAllAdmins()
        {
            return context.Users.AsNoTracking().Where(u => u.IsAdmin == true).ToList();
        }

        public List<User> getAllUsers()
        {
            return context.Users.ToList();
        }
    }
}
