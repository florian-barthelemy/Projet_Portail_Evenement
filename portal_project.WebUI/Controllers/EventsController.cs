﻿using portal_project.Dao;
using portal_project.Models;
using portal_project.Service;
using portal_project.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;

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
        private AdresseService adresseService;
        private AdresseImpl adresseDao;

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
            adresseDao = new AdresseImpl();
            adresseService = new AdresseService(adresseDao);
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
        public ActionResult Create()
        {
            ViewData["sousCats"] = souCatService.getAllSousCategories().ToList();

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Event ev, HttpPostedFileBase photo)
        {

            if (ModelState.IsValid)
            {
                string extension = Path.GetExtension(photo.FileName);
                if (extension.Equals(".png") || extension.Equals(".jpeg") || extension.Equals(".jpg"))
                {

                    string fileName = ev.Titre + extension;  //Personaliser le nom de la photo
                    ev.PhotosEvent = new List<Photo>();
                    ev.PhotosEvent.Add(new Photo { PhotoTitle = fileName, PhotoEvent = ev });  //Je met à jour ma propriété Photo de la classe Employe avec le nom personalisé
                    string path = Server.MapPath("~/Images/" + fileName); // /Content/Photos/user1.jpg
                    photo.SaveAs(path);
                }
                else
                {
                    return Content("L'extension de la photo doit être : .png, .jpg ou .jpeg");
                }

                //adresseService.createAdress(ev.EventAdresse);
                evService.createEvent(ev);

                return RedirectToAction("Index");
            }
            else
            {

                return View("Index");
            }
        }
    }
}