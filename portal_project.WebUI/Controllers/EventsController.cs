using portal_project.Dao;
using portal_project.Models;
using portal_project.Service;
using portal_project.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
        public ActionResult Index(string SousCategorie = null, string searchField = null)
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
            try
            {
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
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }

            ViewData["events"] = events;

            if (String.IsNullOrEmpty(searchField))
            {
                ViewData["events"] = events;
            }
            else
            {
                ViewData["events"] = events.Where(e => e.Titre.ToLower().Contains(searchField.ToLower()));
            }
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

                    string fileName = ev.Titre + extension;
                    string path = Server.MapPath("~/Images/" + fileName);  //Personaliser le nom de la photo
                    ev.PhotosEvent = new List<Photo>();
                    ev.PhotosEvent.Add(new Photo { PhotoLocation = path, PhotoTitle = fileName, PhotoDescription = "Photo de " + ev.Titre, PhotoEvent = ev, DateUpload = DateTime.Now });  //Je met à jour ma propriété Photo de la classe Employe avec le nom personalisé
                                                                                                                                                                                           // /Content/Photos/user1.jpg

                    photo.SaveAs(path);
                }
                else
                {
                    return Content("L'extension de la photo doit être : .png, .jpg ou .jpeg");
                }

                adresseService.createAdress(ev.EventAdresse);

                evService.createEvent(ev);

                return RedirectToAction("Index");
            }
            else
            {

                return View("Index");
            }
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventAdresseViewModel model = new EventAdresseViewModel();
            model.Event = evService.findOneById((int)id);
            model.Adresse = adresseService.findOneById((int)model.Event.EventAdresseId);
            model.Photos = new List<Photo>();
            model.Event.PhotosEvent = photoService.getAllEventPhoto(model.Event);
            model.Photos.Add(photoService.findOneById(model.Event.PhotosEvent[0].Id));
            ViewData["sousCats"] = souCatService.getAllSousCategories().ToList();
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EventAdresseViewModel model, int id, HttpPostedFileBase photo)
        {
            if (ModelState.IsValid)
            {

                if (photo != null)
                {
                    model.Event.PhotosEvent = photoService.getAllEventPhoto(model.Event);
                    model.Photos = new List<Photo>();
                    model.Photos.Add(photoService.findOneById(model.Event.PhotosEvent[0].Id));
                    model.Photos[0].Id = model.Event.PhotosEvent[0].Id;
                    model.Photos[0].PhotoTitle = model.Event.Titre + Path.GetExtension(photo.FileName);
                    string path = Server.MapPath("~/Images/" + model.Photos[0].PhotoTitle);
                    model.Photos[0].PhotoLocation = path;
                    model.Photos[0].PhotoDescription = "Photo de " + model.Event.Titre;
                    model.Photos[0].DateUpload = DateTime.Now;

                    photo.SaveAs(path);
                }
                else
                {
                    return Content("L'extension de la photo doit être : .png, .jpg ou .jpeg");
                }
                model.Event.PhotosEvent[0] = model.Photos[0];
                model.Event.Id = id;
                model.Event.EventAdresseId = model.Adresse.Id;

                List<Photo> lstPhotosToEdit = new List<Photo>();
                lstPhotosToEdit = photoService.getAllEventPhoto(model.Event);
                model.Event.PhotosEvent = lstPhotosToEdit;
                adresseService.editAdress(model.Adresse);
                evService.editEvent(model.Event);
                photoService.editPhoto(model.Photos[0]);

                return RedirectToAction("Index");
            }
            else
            {
                return View("Index");
            }
        }
        public ActionResult Delete(int id)
        {
            Event e = evService.findOneById(id);
            if (e == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            Event eventToDelete = evService.findOneById(id);

            if (eventToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                photoService.deletePhoto(eventToDelete.PhotosEvent[0].Id);
                evService.deleteEvent(id);
                return RedirectToAction("Index");
            }
        }
    }
}