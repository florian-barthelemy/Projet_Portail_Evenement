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
    public class EventsController : Controller
    {
        private CategorieService catService;
        private SousCategorieService souCatService;
        private SousCategorieImpl sousCatDao;
        private CategorieImpl catDao;
        private EventService evService;
        private EventImpl evDao;

        public EventsController()
        {
            catDao = new CategorieImpl();
            catService = new CategorieService(catDao);
            sousCatDao = new SousCategorieImpl();
            souCatService = new SousCategorieService(sousCatDao);
            evDao = new EventImpl();
            evService = new EventService(evDao);
        }
        // GET: Events
        public ActionResult Index()
        {

            List<EventViewModel> vm = new List<EventViewModel>();
            List<Event> events = new List<Event>();
            foreach (Event evenement in evDao.getAllEvents())
            {
                events.Add(evenement);
            }
            foreach (Categorie category in catDao.getAllCategories())
            {
                List<SousCategorie> souscats = new List<SousCategorie>();
                foreach (SousCategorie souscat in sousCatDao.getAllSousCategoriesbyCategorie(category.Libelle))
                {
                    souscats.Add(souscat);
                }

                vm.Add(new EventViewModel { Categorie = category, LstSousCategories = souscats});

            }
            ViewData["events"] = events;
            //List<SousCategorie> sousCatsLst = souCatService.getAllSousCategories().ToList();
            //List<SelectListItem> sousCats = new List<SelectListItem>() { };
            return View(vm);
        }
    }
}