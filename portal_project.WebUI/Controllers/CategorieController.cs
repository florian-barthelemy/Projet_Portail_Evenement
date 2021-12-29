using portal_project.Dao;
using portal_project.Models;
using portal_project.Service;
using portal_project.WebUI.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace portal_project.WebUI.Controllers
{
    [LoginFilter]
    [AdminFilter]
    public class CategorieController : Controller
    {
        CategorieService categoryService;

        public CategorieController()
        {
            categoryService = new CategorieService(new CategorieImpl());
        }

        // GET: Category
        public ActionResult Index()
        {
            try
            {
                List<Categorie> categories = categoryService.getAllCategories();
                return View(categories);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        public ActionResult Create()
        {
            Categorie categorie = new Categorie();
            return View(categorie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categorie categorie)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    categoryService.createCategorie(categorie);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ViewBag.Error = ex.Message;
                    return View(categorie);
                }
            }
            else
            {
                return View(categorie);
            }
        }

        public ActionResult Details(int? id)
        {
            try
            {
                Categorie categorie = categoryService.findOneById(Convert.ToInt32(id));
                return View(categorie);
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
                Categorie categorie = categoryService.findOneById(id);
                return View(categorie);
            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categorie categorie, int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    categorie.Id = id;
                    categoryService.editCategorie(categorie);
                    return RedirectToAction("Details", new { id = id });
                }
                catch(Exception ex)
                {
                    ViewBag.Error = ex.Message;
                    return View(categorie);
                }
            }
            else
            {
                return View(categorie);
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                Categorie categorie = categoryService.findOneById(id);
                return View(categorie);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            try
            {
                categoryService.deleteCategorie(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }
    }
}