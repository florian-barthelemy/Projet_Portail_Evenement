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
        UserService userService;
        // AdresseService adresseService;

        public UtilisateursController()
        {
            userService = new UserService(new UserImpl());
            // adresseService = new AdresseService(new AdresseImpl());
        }

        // GET: Utilisateur
        public ActionResult Index()
        {
            List<User> users = userService.getAllUsers();
            return View(users);
        }

        public ActionResult Create()
        {
            UserAdresseViewModel u = new UserAdresseViewModel();
            return View(u);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserAdresseViewModel u, string ConfirmPassword)
        {
            if (!ModelState.IsValid)
            {
                return View(u);
            }
            else
            {
                if (ConfirmPassword.Equals(u.User.Password))
                {
                    try
                    {
                        User uSave = u.User;
                        uSave.MainAdresse = u.Adresse;
                        userService.createUser(uSave);
                        return RedirectToAction("Index");
                    }
                    catch (Exception e)
                    {
                        ViewBag.error = e.Message;
                        return View(u);
                    }
                }
                else
                {
                    ViewBag.errorPassword = "Les 2 mots de passes ne correspondent pas";
                    return View(u);
                }
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string password)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    User u = userService.CheckLogin(email, password);
                    Session["User"] = new UserLogViewModel { Id = u.Id, IsAdmin = u.IsAdmin, FullName = u.Prenom + " " + u.Nom };
                    return RedirectToAction("Index", "Accueil");

                }
                catch(Exception ex)
                {
                    ModelState.Clear();
                    ViewBag.ErrorLog = ex.Message;
                    return View();
                }
            }
            else
            {
                ViewBag.ErrorLog = "Le pseudo ou le mot de passe ne sont pas renseignés";
                return View();
            }
        }

        public ActionResult Logout()
        {
            Session.Remove("User");
            return RedirectToAction("Index","Accueil");
        }
    }
}