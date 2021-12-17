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
    public class UtilisateursController : Controller
    {
        UserService service;

        public UtilisateursController()
        {
            service = new UserService(new UserImpl());
        }

        // GET: Utilisateur
        public ActionResult Index()
        {
            List<User> users = service.getAllUsers();
            return View(users);
        }

        public ActionResult Create()
        {
            UserAdresseViewModel u = new UserAdresseViewModel();
            return View(u);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserAdresseViewModel u)
        {
            if (!ModelState.IsValid)
            {
                return View(u);
            }
            else
            {
                try
                {
                    return RedirectToAction("Index");
                }
                catch(Exception e){
                    ViewBag.error = e.Message;
                    return View(u);
                }
            }
        }
    }
}