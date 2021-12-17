using portal_project.Metier;
using portal_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestUnitaire.Mock
{
    public class EventMockDao : IEvent
    {
        public List<Event> Events;

        public EventMockDao()
        {
            Events = new List<Event>();
        }

        public void createEvent(Event ev)
        {
            Event ev1 = Events.Find(c => c.Id == ev.Id);
                Events.Add(ev);
        }

        public void deleteEvent(int id_event)
        {
            Event event1 = Events.Find(c => c.Id == id_event);
                Events.Remove(event1);
        }

        public void editEvent(Event ev)
        {
            Event event1 = Events.Find(c => c.Id == ev.Id);
                Events.Remove(event1);
                Events.Add(ev);
        }

        public List<Event> findAllEventsByCategorie(string titre)
        {
            return Events.FindAll(e => e.EventSousCat.EventCategorie.Libelle.Equals(titre));
        }

        public List<Event> findAllEventsByDateDebut(DateTime date_debut)
        {
            return Events.FindAll(e=>e.DateDebut== date_debut);
        }

        public List<Event> findAllEventsByDateFin(DateTime date_fin)
        {
            return Events.FindAll(e => e.DateFin == date_fin);
        }

        public List<Event> findAllEventsByDateInterval(DateTime date_debut, DateTime date_fin)
        {
            return Events.FindAll(e => e.DateDebut >= date_debut && e.DateFin <= date_fin);
        }

        public List<Event> findAllEventsBySousCategorie(string titre)
        {
            return Events.FindAll(e => e.EventSousCat.Libelle.Equals(titre));
        }

        public List<Event> findAllEventsByTitre(string titre)
        {
            return Events.FindAll(e => e.Titre.Contains(titre));
        }

        public List<Event> findAllEventsByVille(string ville)
        {
            return Events.FindAll(e=> e.EventAdresse.Ville.Equals(ville));
        }

        public Event findOneById(int id)
        {
            return Events.Find(c => c.Id == id);
        }

        public List<Event> getAllEvents()
        {
            return Events;
        }
    }
}
