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
        [DataType(DataType.Text)]
        public string Titre { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public virtual Adresse EventAdresse { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime DateDebut { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime DateFin { get; set; }
        public List<User> Participants { get; set; }
        public List<User> Intervenants { get; set; }
        [Required]
        public virtual User Creator{ get; set; }
        [Required]
        public double Tarif { get; set; }
        [Required]
        [Range(0,18)]
        public int MinAge { get; set; }
        public virtual List<Photo> PhotosEvent { get; set; }
        public Event()
        {
        }
        public Event(int id, string titre, string description,
                    Adresse eventAdresse, DateTime dateDebut, DateTime dateFin,
                    List<User> participants, List<User> intervenants, User creator, double tarif, int minAge, List<Photo> photosEvent)
        {
            Id = id;
            Titre = titre;
            Description = description;
            EventAdresse = eventAdresse;
            DateDebut = dateDebut;
            DateFin = dateFin;
            Participants = participants;
            Intervenants = intervenants;
            Creator = creator;
            Tarif = tarif;
            MinAge = minAge;
            PhotosEvent = photosEvent;
        }

        public Event(string titre, string description, Adresse eventAdresse, DateTime dateDebut, DateTime dateFin, List<User> participants, List<User> intervenants, User creator, double tarif, int minAge, List<Photo> photosEvent)
        {
            Titre = titre;
            Description = description;
            EventAdresse = eventAdresse;
            DateDebut = dateDebut;
            DateFin = dateFin;
            Participants = participants;
            Intervenants = intervenants;
            Creator = creator;
            Tarif = tarif;
            MinAge = minAge;
            PhotosEvent = photosEvent;
        }
    }
}
