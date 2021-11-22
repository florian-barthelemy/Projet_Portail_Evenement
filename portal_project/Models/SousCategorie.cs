using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portal_project.Models
{
    [Table("SousCategorie")]
    public class SousCategorie
    {
        [Key]
        public int Id { get; set; }
        public string Libelle { get; set; }
        public virtual Categorie Categorie { get; set; }

        public SousCategorie()
        {
        }

        public SousCategorie(int id, string libelle, Categorie categorie)
        {
            Id = id;
            Libelle = libelle;
            Categorie = categorie;
        }

        public SousCategorie(string libelle, Categorie categorie)
        {
            Libelle = libelle;
            Categorie = categorie;
        }
    }
}
