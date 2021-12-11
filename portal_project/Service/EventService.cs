using portal_project.Metier;
using portal_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portal_project.Service
{
   public class EventService
    {
        private IEvent dao;

        public EventService(IEvent dao)
        {
            this.dao = dao;
        }

        public void createEvent(Event ev)
        {
            dao.createEvent(ev);
        }

        public void deleteEvent(int id_event)
        {
            dao.deleteEvent(id_event);
        }

        public void editEvent(Event ev)
        {
            dao.editEvent(ev);
        }

        public List<Event> findAllEventsByCategorie(string titre)
        {
            return dao.findAllEventsByCategorie(titre);
        }

        public List<Event> findAllEventsByDateDebut(DateTime date_debut)
        {
            return dao.findAllEventsByDateDebut(date_debut);
        }

        public List<Event> findAllEventsByDateFin(DateTime date_fin)
        {
            return dao.findAllEventsByDateFin(date_fin);
        }

        public List<Event> findAllEventsByDateInterval(DateTime date_debut, DateTime date_fin)
        {
            return dao.findAllEventsByDateInterval(date_debut, date_fin);
        }

        public List<Event> findAllEventsBySousCategorie(string titre)
        {
            return dao.findAllEventsBySousCategorie(titre);
        }

        public List<Event> findAllEventsByTitre(string titre)
        {
            return dao.findAllEventsByTitre(titre);
        }

        public List<Event> findAllEventsByVille(string ville)
        {
            return dao.findAllEventsByVille(ville);
        }

        public Event findOneById(int id)
        {
            return dao.findOneById(id);
        }

        public List<Event> getAllEvents()
        {
            return dao.getAllEvents();        }
    }
}
