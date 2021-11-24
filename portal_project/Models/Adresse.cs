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
        public double Axe_X { get; set; }
        [Required]
        public double Axe_Y { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Voie { get; set; }
        [Required]
        [DataType(DataType.PostalCode)]
        public string CodePostal { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Ville { get; set; }
        public virtual User User { get; set; }

        public Adresse()
        {
        }
        public Adresse(int id, double axe_x, double axe_y, string voie, string codePostal, string ville)
        {
            Id = id;
            Axe_X = axe_x;
            Axe_Y = axe_y;
            Voie = voie;
            CodePostal = codePostal;
            Ville = ville;
        }
        public Adresse(double axe_x, double axe_y, string voie, string codePostal, string ville)
        {
            Axe_X = axe_x;
            Axe_Y = axe_y;
            Voie = voie;
            CodePostal = codePostal;
            Ville = ville;
        }
    }
}
