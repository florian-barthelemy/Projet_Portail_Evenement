using portal_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portal_project.Metier
{
    public interface IUser
    {
        void createUser(User user);
        void editUser(User user);
        void deleteUser(int id_user);
        List<User> getAllUsers();
        User findOneById(int id);
        List<User> findByFullName(string nom, string prenom);
        List<User> findByLastName(string nom);
        List<User> findByFirstName(string prenom);
        List<User> findByAge(int age);
        List<Adresse> findAllUsersByVille(string ville);
        List<Adresse> findAllUsersByCP(string code_postal);
    }
}
