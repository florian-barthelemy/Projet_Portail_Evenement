using portal_project.Dao;
using portal_project.Models;
using portal_project.Service;
using portal_project.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace portal_project.WebUI.Controllers
{
    public class AccueilController : Controller
    {
        private CategorieService catService;
        private SousCategorieService souCatService;
        private SousCategorieImpl sousCatDao;
        private CategorieImpl catDao;
        private EventService evService;
        private EventImpl evDao;
        private PhotoService photoService;
        private PhotoImpl photoDao;
        private AdresseService adresseService;
        private AdresseImpl adresseDao;


        public AccueilController()
        {
            catDao = new CategorieImpl();
            catService = new CategorieService(catDao);
            sousCatDao = new SousCategorieImpl();
            souCatService = new SousCategorieService(sousCatDao);
            evDao = new EventImpl();
            evService = new EventService(evDao);
            photoDao = new PhotoImpl();
            photoService = new PhotoService(photoDao);
            adresseDao = new AdresseImpl();
            adresseService = new AdresseService(adresseDao);
        }
        // GET: Accueil
        public ActionResult Index()
        {
            List<EventViewModel> vm = new List<EventViewModel>();

            List<Event> events = new List<Event>();

            foreach (Event ev in evService.getAllEvents())
            {

                events.Add(ev);
            }
            ViewData["events"] = events;

            return View(vm);
        }
    }
}