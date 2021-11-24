using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portal_project.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Nom { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Prenom { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public bool IsAdmin { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateNais { get; set; }
        public virtual List<Adresse> Adresses { get; set; }
        public virtual Adresse MainAdresse { get; set; }


        public User()
        {
        }

        public User(int id, string nom, string prenom, string email, string password, bool isAdmin, List<Adresse> adresses, DateTime dateNais, Adresse mainAdresse)
        {
            Id = id;
            Nom = nom;
            Prenom = prenom;
            Email = email;
            Password = password;
            IsAdmin = isAdmin;
            Adresses = adresses;
            DateNais = dateNais;
            MainAdresse = mainAdresse;
        }

        public User(string nom, string prenom, string email, string password, bool isAdmin, List<Adresse> adresses, DateTime dateNais, Adresse mainAdresse)
        {
            Nom = nom;
            Prenom = prenom;
            Email = email;
            Password = password;
            IsAdmin = isAdmin;
            Adresses = adresses;
            DateNais = dateNais;
            MainAdresse = mainAdresse;
        }
    }
}
