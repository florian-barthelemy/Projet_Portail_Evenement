using portal_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portal_project.Metier
{
    public interface IEvent
    {
        void createEvent(Event ev);
        void editEvent(Event ev);
        void deleteEvent(int id_event);
        List<Event> getAllEvents();
        Event findOneById(int id);
        List<Event> findAllEventsByVille(string ville);
        List<Event> findAllEventsByDateDebut(DateTime date_debut);
        List<Event> findAllEventsByDateFin(DateTime date_fin);
        List<Event> findAllEventsByDateInterval(DateTime date_debut, DateTime date_fin);
        List<Event> findAllEventsByTitre(string titre);
        List<Event> findAllEventsByCategorie(string titre);
        List<Event> findAllEventsBySousCategorie(string titre);


    }
}
