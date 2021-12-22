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
        [ForeignKey("EventAdresseId")]
        public  Adresse EventAdresse { get; set; }
        public int? EventAdresseId { get; set; }
        [DataType(DataType.DateTime)]
        [Column(TypeName = "datetime2")]
        public virtual DateTime DateDebut { get; set; }
        [DataType(DataType.DateTime)]
        [Column(TypeName = "datetime2")]
        public virtual DateTime DateFin { get; set; }
        public List<User> Participants { get; set; }
        public List<User> Intervenants { get; set; }
        
        public virtual User Creator{ get; set; }
        
        public double Tarif { get; set; }
        [Range(0,18)]
        public int MinAge { get; set; }
        public virtual List<Photo> PhotosEvent { get; set; }
        [ForeignKey("EventSousCatId")]
        public SousCategorie EventSousCat { get; set; }
        public int? EventSousCatId { get; set; }
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

        public Event()
        {

        }
    }
}
