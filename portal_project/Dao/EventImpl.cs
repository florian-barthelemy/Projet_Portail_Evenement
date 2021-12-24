using portal_project.Metier;
using portal_project.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portal_project.Dao
{
    public class EventImpl : IEvent
    {
        MyContext context = new MyContext();
        public void createEvent(Event ev)
        {
            context.Events.Add(ev);
            context.SaveChanges();
        }

        public void deleteEvent(int id_event)
        {
            Event dbEvent = context.Events.SingleOrDefault(e => e.Id == id_event);
            context.Events.Remove(dbEvent);
            context.SaveChanges();
        }

        public void editEvent(Event ev)
        {
            
                context.Events.Attach(ev);
                context.Entry(ev).State = EntityState.Modified;
                context.SaveChanges();
            
        }


        public List<Event> findAllEventsByCategorie(string titre)
        {
            return context.Events.AsNoTracking().Where(evnt => evnt.EventSousCat.EventCategorie.Libelle.Equals(titre)).ToList();
        }

        public List<Event> findAllEventsByDateDebut(DateTime date_debut)
        {
            return context.Events.AsNoTracking().Where(e => e.DateDebut == date_debut).ToList();
        }

        public List<Event> findAllEventsByDateFin(DateTime date_fin)
        {
            List<Event> dbEvent = context.Events.AsNoTracking().Where(e => e.DateFin == date_fin).ToList();
            return dbEvent;
        }

        public List<Event> findAllEventsByDateInterval(DateTime date_debut, DateTime date_fin)
        {
            List<Event> dbEvent = context.Events.AsNoTracking().Where(e => e.DateDebut >= date_debut && e.DateFin <= date_fin).ToList();
            return dbEvent;
        }

        public List<Event> findAllEventsBySousCategorie(string titre)
        {
            List<Event> dbEvent = context.Events.AsNoTracking().Where(evnt => evnt.EventSousCat.Libelle.Equals(titre)).ToList();
            return dbEvent;
        }

        public List<Event> findAllEventsByTitre(string titre)
        {
            return context.Events.AsNoTracking().Where(e => e.Titre.Contains(titre)).ToList();
        }

        public List<Event> findAllEventsByVille(string ville)
        {
            return context.Events.AsNoTracking().Where(e => e.EventAdresse.Ville.Equals(ville)).ToList();
        }

        public Event findOneById(int id)
        {
            return context.Events.AsNoTracking().SingleOrDefault(e => e.Id == id);
        }

        public List<Event> getAllEvents()
        {
            return context.Events.AsNoTracking().ToList();
        }
    }
}
