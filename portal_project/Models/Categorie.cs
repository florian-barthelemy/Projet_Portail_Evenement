using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portal_project.Models
{
    [Table("Categorie")]
    public class Categorie
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Libelle { get; set; }
        public Categorie()
        {
        }

        public Categorie(int id, string libelle)
        {
            Id = id;
            Libelle = libelle;
        }

        public Categorie(string libelle)
        {
            Libelle = libelle;
        }
    }
}
