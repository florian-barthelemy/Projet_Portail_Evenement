using portal_project.Metier;
using portal_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portal_project.Service
{
   public class UserService
    {
        private IUser dao;

        public UserService(IUser dao)
        {
            this.dao = dao;
        }

        public void createUser(User user)
        {
            dao.createUser(user);
        }

        public void deleteUser(int id_user)
        {
            dao.deleteUser(id_user);
        }

        public void editUser(User user)
        {
            dao.editUser(user);
        }

        public List<User> findAllUsersByCP(string code_postal)
        {
            return dao.findAllUsersByCP(code_postal);
        }

        public List<User> findAllUsersByVille(string ville)
        {
            return dao.findAllUsersByVille(ville);
        }

        public List<User> findByAge(int age, string filter)
        {
            return dao.findByAge(age, filter);
        }

        public List<User> findByFirstName(string prenom)
        {
            return dao.findByFirstName(prenom);
        }

        public List<User> findByFullName(string nom, string prenom)
        {
            return dao.findByFullName(nom, prenom);
        }

        public List<User> findByLastName(string nom)
        {
            return dao.findByLastName(nom);
        }

        public User findOneById(int id)
        {
            return dao.findOneById(id);
        }

        public List<User> getAllAdmins()
        {
            return dao.getAllAdmins();
        }
        public List<User> getAllUsers()
        {
            return dao.getAllUsers();
        }
    }
}
