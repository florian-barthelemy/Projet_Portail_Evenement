using portal_project.Metier;
using portal_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portal_project.Dao
{
    class EventImpl : IEvent
    {
        public void createEvent(Event ev)
        {
            throw new NotImplementedException();
        }

        public void deleteEvent(int id_event)
        {
            throw new NotImplementedException();
        }

        public void editEvent(Event ev)
        {
            throw new NotImplementedException();
        }

        public List<Event> findAllEventsByDateDebut(DateTime date_debut)
        {
            throw new NotImplementedException();
        }

        public List<Event> findAllEventsByDateFin(DateTime date_fin)
        {
            throw new NotImplementedException();
        }

        public List<Event> findAllEventsByDateInterval(DateTime date_debut, DateTime date_fin)
        {
            throw new NotImplementedException();
        }

        public List<Event> findAllEventsByTitre(string titre)
        {
            throw new NotImplementedException();
        }

        public List<Event> findAllEventsByVille(string ville)
        {
            throw new NotImplementedException();
        }

        public Adresse findOneById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Event> getAllEvents()
        {
            throw new NotImplementedException();
        }
    }
}
