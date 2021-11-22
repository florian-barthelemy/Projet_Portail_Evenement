using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portal_project.Models
{
    [Table("Adresse")]
    public class Adresse
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int[] Coordinates { get; set; }
        public string Voie { get; set; }
        public string CodePostal { get; set; }
        public string Ville { get; set; }
        public virtual User User { get; set; }

        public Adresse()
        {
        }
        public Adresse(int id, int[] coordinates, string voie, string codePostal, string ville)
        {
            Id = id;
            Coordinates[0] = coordinates[0];
            Coordinates[1] = coordinates[1];
            Voie = voie;
            CodePostal = codePostal;
            Ville = ville;
        }
        public Adresse(int[] coordinates, string voie, string codePostal, string ville)
        {
            Coordinates[0] = coordinates[0];
            Coordinates[1] = coordinates[1];
            Voie = voie;
            CodePostal = codePostal;
            Ville = ville;
        }
    }
}
