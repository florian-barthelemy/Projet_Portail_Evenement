using portal_project.Exceptions;
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
            Event e = dao.findOneById(ev.Id);
            if (e == null)
            {
                dao.createEvent(ev);
            }
            else
            {
                throw new AlreadyCreatedException("L'évènement avec l'id " + ev.Id + " existe déjà");
            }
        }

        public void deleteEvent(int id_event)
        {
            Event e = dao.findOneById(id_event);
            if (e != null)
            {
                dao.deleteEvent(id_event);
            }
            else
            {
                throw new NotFoundException("L'évènement avec l'id "
                    + id_event + " n'existe pas");
            }
        }

        public void editEvent(Event ev)
        {
            Event e = dao.findOneById(ev.Id);
            if (e != null)
            {
                dao.editEvent(ev);
            }
            else
            {
                throw new NotFoundException("L'évènement avec l'id " + ev.Id +
                     " n'existe pas");
            }
        }

        public List<Event> findAllEventsByCategorie(string titre)
        {

            List<Event> events = dao.findAllEventsByCategorie(titre);
            if (events.Count > 0)
            {
                return events;
            }
            else
            {
                throw new ListEmptyException("Aucun évènement ne correspond avec le titre " + titre);
            }
        }

        public List<Event> findAllEventsByDateDebut(DateTime date_debut)
        {
            List<Event> events = dao.findAllEventsByDateDebut(date_debut);
            if (events.Count > 0)
            {
                return events;
            }
            else
            {
                throw new ListEmptyException("Aucun évènement ne commence à la date " + date_debut.Date);
            }
        }

        public List<Event> findAllEventsByDateFin(DateTime date_fin)
        {
            List<Event> events = dao.findAllEventsByDateFin(date_fin);
            if (events.Count > 0)
            {
                return events;
            }
            else
            {
                throw new ListEmptyException("Aucun évènement ne finit à la date " + date_fin.Date);
            }
        }

        public List<Event> findAllEventsByDateInterval(DateTime date_debut, DateTime date_fin)
        {
            List<Event> events = dao.findAllEventsByDateInterval(date_debut, date_fin);
            if (events.Count > 0)
            {
                return events;
            }
            else
            {
                throw new ListEmptyException("Aucun évènement ne commence après la date " + date_debut.Date
                    + " et ne finit avant la date " + date_fin.Date);
            }
        }

        public List<Event> findAllEventsBySousCategorie(string titre)
        {
            List<Event> events = dao.findAllEventsBySousCategorie(titre);
            if (events.Count > 0)
            {
                return events;
            }
            else
            {
                throw new ListEmptyException("Aucun évènement ne correspond à la sous catégorie " + titre);
            }
        }

        public List<Event> findAllEventsByTitre(string titre)
        {
            List<Event> events = dao.findAllEventsByTitre(titre);
            if (events.Count > 0)
            {
                return events;
            }
            else
            {
                throw new ListEmptyException("Aucun évènement ne contient le titre " + titre);
            }
        }

        public List<Event> findAllEventsByVille(string ville)
        {
            List<Event> events = dao.findAllEventsByVille(ville);
            if (events.Count > 0)
            {
                return events;
            }
            else
            {
                throw new ListEmptyException("Aucun évènement ne se déroule dans la ville" + ville);
            }
        }

        public Event findOneById(int id)
        {
            Event e = dao.findOneById(id);
            if (e != null)
            {
                return e;
            }
            else
            {
                throw new NotFoundException("L'évènement avec l'id " + id + " n'existe pas");
            }
        }

        public List<Event> getAllEvents()
        {
            List<Event> events = dao.getAllEvents();
            if (events.Count > 0)
            {
                return events;
            }
            else
            {
                throw new ListEmptyException("Aucun évènement n'est enregistré");
            }
        }

        public List<Event> getAllEventsCreatedByUser(User u)
        {
            List<Event> events = dao.getAllEvents().Where(e => e.Creator.Id == u.Id).ToList();
            if (events.Count > 0)
            {
                return events;
            }
            else
            {
                throw new ListEmptyException("Aucun évènement créé par l'utilisataur " + u);
            }
        }

        public List<Event> getAllEventsParticipatedByUser(User u)
        {
            List<Event> eventParticipated = new List<Event>();
            List<Event> allEvents = dao.getAllEvents();
            foreach (var eve in allEvents)
            {
                foreach (var participant in eve.Participants)
                {
                    if (participant.Id == u.Id)
                    {
                        eventParticipated.Add(eve);
                    }
                }
            }
            if (eventParticipated.Count > 0)
            {
                return eventParticipated;
            }
            else
            {
                throw new ListEmptyException("L'utilisateur " + u + " ne participe à aucun évènement");
            }
        }
    }
}
