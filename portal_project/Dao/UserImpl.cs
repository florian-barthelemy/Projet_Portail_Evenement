using portal_project.Metier;
using portal_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portal_project.Dao
{
    class UserImpl : IUser
    {
        public void createUser(User user)
        {
            throw new NotImplementedException();
        }

        public void deleteUser(int id_user)
        {
            throw new NotImplementedException();
        }

        public void editUser(User user)
        {
            throw new NotImplementedException();
        }

        public List<Adresse> findAllUsersByCP(string code_postal)
        {
            throw new NotImplementedException();
        }

        public List<Adresse> findAllUsersByVille(string ville)
        {
            throw new NotImplementedException();
        }

        public List<User> findByAge(int age)
        {
            throw new NotImplementedException();
        }

        public List<User> findByFirstName(string prenom)
        {
            throw new NotImplementedException();
        }

        public List<User> findByFullName(string nom, string prenom)
        {
            throw new NotImplementedException();
        }

        public List<User> findByLastName(string nom)
        {
            throw new NotImplementedException();
        }

        public User findOneById(int id)
        {
            throw new NotImplementedException();
        }

        public List<User> getAllUsers()
        {
            throw new NotImplementedException();
        }
    }
}
