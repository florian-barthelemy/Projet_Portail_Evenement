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
        public virtual Adresse Event_Adresse { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public List<User> Participants { get; set; }
        public List<User> Intervenants { get; set; }
        [Required]
        public virtual User Creator{ get; set; }
        public double Tarif { get; set; }

        public Event()
        {
        }
        public Event(int id, string titre, string description,
                    Adresse event_Adresse, DateTime dateDebut, DateTime dateFin, 
                    List<User> participants, List<User> intervenants, User creator, double tarif)
        {
            Id = id;
            Titre = titre;
            Description = description;
            Event_Adresse = event_Adresse;
            DateDebut = dateDebut;
            DateFin = dateFin;
            Participants = participants;
            Intervenants = intervenants;
            Creator = creator;
            this.Tarif = tarif;
        }

        public Event(string titre, string description, Adresse event_Adresse, DateTime dateDebut, DateTime dateFin, List<User> participants, List<User> intervenants, User creator, double tarif)
        {
            Titre = titre;
            Description = description;
            Event_Adresse = event_Adresse;
            DateDebut = dateDebut;
            DateFin = dateFin;
            Participants = participants;
            Intervenants = intervenants;
            Creator = creator;
            Tarif = tarif;
        }
    }
}
