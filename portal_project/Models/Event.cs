using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portal_project.Models
{
    [Table("Event")]
    public class Event
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Titre { get; set; }
        public string Description { get; set; }
        public string Adresse { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public List<User> Participants { get; set; }
        public List<User> Intervenants { get; set; }
        public int Creator_Id{ get; set; }
        public double Tarif { get; set; }

        public Event(int id, string titre, string description,
                    string adresse, DateTime dateDebut, DateTime dateFin, 
                    List<User> participants, List<User> intervenants, int id_createur, double tarif)
        {
            Id = id;
            Titre = titre;
            Description = description;
            Adresse = adresse;
            DateDebut = dateDebut;
            DateFin = dateFin;
            Participants = participants;
            Intervenants = intervenants;
            this.Creator_Id = id_createur;
            this.Tarif = tarif;
        }

        public Event()
        {
        }
    }
}
