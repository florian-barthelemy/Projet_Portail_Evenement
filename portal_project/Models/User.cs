﻿using System;
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
        public string Nom { get; set; }
        [Required]
        public string Prenom { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public bool IsAdmin { get; set; }
        //public int Adresse_Id { get; set; }
        
        public virtual Adresse UserAdresse { get; set; }

        public User()
        {
        }

        public User(int id, string nom, string prenom, string email, string password, bool isAdmin, Adresse userAdresse)
        {
            Id = id;
            Nom = nom;
            Prenom = prenom;
            Email = email;
            Password = password;
            IsAdmin = isAdmin;
            UserAdresse = userAdresse;
        }
    }
}
