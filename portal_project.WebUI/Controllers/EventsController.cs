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
        private PhotoService photoService;
        private PhotoImpl photoDao;

        public EventsController()
        {
            catDao = new CategorieImpl();
            catService = new CategorieService(catDao);
            sousCatDao = new SousCategorieImpl();
            souCatService = new SousCategorieService(sousCatDao);
            evDao = new EventImpl();
            evService = new EventService(evDao);
            photoDao = new PhotoImpl();
            photoService = new PhotoService(photoDao);
        }
        // GET: Events
        public ActionResult Index(string SousCategorie = null)
        {

            List<EventViewModel> vm = new List<EventViewModel>();
            List<Event> events = new List<Event>();
            foreach (Categorie category in catService.getAllCategories())
            {
                List<SousCategorie> souscats = new List<SousCategorie>();
                foreach (SousCategorie souscat in souCatService.getAllSousCategoriesbyCategorie(category.Libelle))
                {
                    souscats.Add(souscat);
                }

                vm.Add(new EventViewModel { Categorie = category, LstSousCategories = souscats });

            }
            if (SousCategorie == null)
            {
                foreach (Event evenement in evService.getAllEvents())
                {
                    events.Add(evenement);
                }
                
            }
            else
            {
                foreach (Event evenement in evService.findAllEventsBySousCategorie(SousCategorie))
                {
                    events.Add(evenement);
                }
            }

            ViewData["events"] = events;
            //List<SousCategorie> sousCatsLst = souCatService.getAllSousCategories().ToList();
            //List<SelectListItem> sousCats = new List<SelectListItem>() { };
            return View(vm);
        }
        public ActionResult Details(int id)
        {

            Event evenement = evService.findOneById(id);
            List<Photo> photo = photoService.getAllEventPhoto(evenement);
            evenement.PhotosEvent = photo;
            if (evenement == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(evenement);
            }


        }
    }
}