using portal_project.Dao;
using portal_project.Models;
using portal_project.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace portal_project.WebUI.Controllers
{
    public class EventsController : Controller
    {
        private CategorieService service;
        private CategorieImpl dao;

        public EventsController()
        {
            dao = new CategorieImpl();
            service = new CategorieService(dao);
        }
        // GET: Events
        public ActionResult Index()
        {
            List<Categorie> cats = service.getAllCategories().ToList();
            return View(cats);
        }
    }
}