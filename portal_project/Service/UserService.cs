using portal_project.Exceptions;
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
            User u = dao.findOneById(user.Id);
            User u2 = dao.getAllUsers().SingleOrDefault(u3 => u3.Email == user.Email);
            if (u == null)
            {
                if (u2 == null)
                {
                    dao.createUser(user);
                }
                else
                {
                    throw new AlreadyCreatedException("L'adresse email " + user.Email + " est déjà " +
                        "associé à un autre utilisateur");
                }
            }
            else
            {
                throw new AlreadyCreatedException("L'utilisateur avec l'id " + user.Id + " existe déjà");
            }
        }

        public void deleteUser(int id_user)
        {
            User u = dao.findOneById(id_user);
            if (u != null)
            {
                dao.deleteUser(id_user);
            }
            else
            {
                throw new NotFoundException("L'utilisateur avec l'id " + id_user + " n'existe pas");
            }
        }

        public void editUser(User user)
        {
            User u = dao.findOneById(user.Id);
            if (u != null)
            {
                dao.editUser(user);
            }
            else
            {
                throw new NotFoundException("L'utilisateur avec l'id " + user.Id + " n'existe pas");
            }
        }

        public List<User> findAllUsersByCP(string code_postal)
        {
            List<User> users = dao.findAllUsersByCP(code_postal);
            if (users.Count > 0)
            {
                return users;
            }
            else
            {
                throw new ListEmptyException("Aucun utilisateur n'habite au code postal " + code_postal);
            }
        }

        public List<User> findAllUsersByVille(string ville)
        {
            List<User> users = dao.findAllUsersByVille(ville);
            if (users.Count > 0)
            {
                return users;
            }
            else
            {
                throw new ListEmptyException("Aucun utilisateur n'habite dans la ville " + ville);
            }
        }

        public User CheckLogin(string email, string password)
        {

            try
            {
            User u = findByMail(email);
                if (!u.Password.Equals(password))
                {
                    throw new ArgumentException("Le mot de passe ne correspond pas avec l'email");
                }
                else
                {
                    return u;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<User> findByAge(int age, string filter)
        {
            if (filter == ">=" || filter == "<=" || filter == "=")
            {
                List<User> users = dao.findByAge(age, filter);
                if (users.Count > 0)
                {
                    return users;
                }
                else
                {
                    throw new ListEmptyException("Aucun utilisateur ne correpond aux restrictions de l'age "
                        + filter + " " + age);
                }
            }
            else
            {
                throw new ArgumentException("Le filtre " + filter + " ne correpond pas pour le filtre sur l'âge");
            }
        }

        public List<User> findByFirstName(string prenom)
        {
            List<User> users = dao.findByFirstName(prenom);
            if (users.Count > 0)
            {
                return users;
            }
            else
            {
                throw new ListEmptyException("Aucun utilisateur ne contient " + prenom + " dans son prenom");
            }
        }

        public List<User> findByFullName(string nom, string prenom)
        {
            List<User> users = dao.findByFullName(nom, prenom);
            if (users.Count > 0)
            {
                return users;
            }
            else
            {
                throw new ListEmptyException("Aucun utilisateur ne contient " + prenom + " dans son prenom et " +
                    nom + " dans son nom");
            }
        }

        public List<User> findByLastName(string nom)
        {
            List<User> users = dao.findByLastName(nom);
            if (users.Count > 0)
            {
                return users;
            }
            else
            {
                throw new ListEmptyException("Aucun utilisateur ne contient " + nom + " dans son nom");
            }
        }

        public User findOneById(int id)
        {
            User u = dao.findOneById(id);
            if (u != null)
            {
                return u;
            }
            else
            {
                throw new NotFoundException("L'utilisateur avec l'id " + id + " n'existe pas");
            }
        }

        public List<User> getAllAdmins()
        {
            List<User> users = dao.getAllAdmins();
            if (users.Count > 0)
            {
                return users;
            }
            else
            {
                throw new ListEmptyException("Aucun utilisateur n'est administrateur");
            }
        }
        public List<User> getAllUsers()
        {
            List<User> users = dao.getAllUsers();
            if (users.Count > 0)
            {
                return users;
            }
            else
            {
                throw new ListEmptyException("Aucun utilisateur enregistré");
            }
        }
        public List<User> findByGenre(char genVal)
        {
            if (genVal.ToString().ToLower() == "h" || genVal.ToString().ToLower() == "f")
            {
                List<User> users = dao.findByGenre(genVal);
                if (users.Count > 0)
                {
                    return users;
                }
                else
                {
                    string message;
                    if (genVal.ToString().ToLower() == "h")
                    {
                        message = "Aucun homme trouvé";
                    }
                    else
                    {
                        message = "Aucune femme trouvée";
                    }
                    throw new ListEmptyException(message);
                }
            }
            else
            {
                throw new ArgumentException("Le genre " + genVal + " rentré n'est pas compatible pour cette recherche ");
            }
        }

        public User findByMail(string email)
        {
            User u = dao.getAllUsers().SingleOrDefault(user => user.Email.Equals(email));
            if (u != null)
            {
                return u;
            }
            else
            {
                throw new NotFoundException("L'utilisateur avec l'email " + email + " n'existe pas");
            }
        }
    }
}
