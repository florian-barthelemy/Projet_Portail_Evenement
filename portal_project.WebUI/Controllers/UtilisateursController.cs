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
            try
            {
                List<User> users = userService.getAllUsers();
                return View(users);
            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
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

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                if (Session["User"] != null)
                {
                    id = (Session["User"] as UserLogViewModel).Id;
                }
                else
                {
                    ViewBag.Error="Aucun n'utilisateur connecté vous n'êtes pas censé vous trouver ici";
                    return View();
                }
            }
            try
            {
                User u = userService.findOneById(Convert.ToInt32(id));
                return View(u);
            }
            catch (Exception ex)
            {

                ViewBag.Error = ex.Message;
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            try
            {
                User user = userService.findOneById(id);
                UserAdresseViewModel u = new UserAdresseViewModel { Adresse = user.MainAdresse, User = user };
                return View(u);
            }catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserAdresseViewModel u,int id,string ConfirmPassword )
        {
            if (ModelState.IsValid)
            {
                if ( u.User.Password.Equals(ConfirmPassword))
                {
                    try
                    {
                        User user = userService.findOneById(id);
                        
                        userService.editUser(user);
                        return RedirectToAction("Details", new { id = id });
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Error = ex.Message;
                        return View(u);
                    }
                }
                else
                {
                    ViewBag.errorPassword = "Les 2 mots de passes ne correspondent pas";
                    return View(u);
                }
            }
            else
            {
                return View(u);
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