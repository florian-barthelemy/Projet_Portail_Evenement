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
    public class SousCategorieController : Controller
    {
        SousCategorieService sousCategorieService;
        CategorieService CategorieService;

        public SousCategorieController()
        {
            sousCategorieService = new SousCategorieService(new SousCategorieImpl());
            CategorieService = new CategorieService(new CategorieImpl());

        }

        // GET: SousCategory
        public ActionResult Index()
        {
            try
            {
                List<SousCategorie> sousCategories = sousCategorieService.getAllSousCategories();
                foreach (SousCategorie sousCategorie in sousCategories)
                {
                    sousCategorie.EventCategorie = CategorieService.findOneById(Convert.ToInt32(sousCategorie.EventCategorieId));
                }
                return View(sousCategories);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        public ActionResult Create()
        {
            try
            {
                SousCategorie sousCategorie = new SousCategorie();
                ViewData["cats"] = CategorieService.getAllCategories();
                return View(sousCategorie);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SousCategorie sousCategorie)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    sousCategorieService.createSousCategorie(sousCategorie);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ViewBag.Error = ex.Message;
                    return View(sousCategorie);
                }
            }
            else
            {
                return View(sousCategorie);
            }
        }

        public ActionResult Details(int? id)
        {
            try
            {
                SousCategorie sousCategorie = sousCategorieService.findOneById(Convert.ToInt32(id));
                sousCategorie.EventCategorie = CategorieService.findOneById(Convert.ToInt32(sousCategorie.EventCategorieId));
                return View(sousCategorie);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        public ActionResult Edit(int? id)
        {
            try
            {
                SousCategorie sousCategorie = sousCategorieService.findOneById(Convert.ToInt32(id));
                ViewData["cats"] = CategorieService.getAllCategories();
                return View(sousCategorie);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SousCategorie sousCategorie, int? id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    sousCategorie.Id = Convert.ToInt32(id);
                    sousCategorieService.editSousCategorie(sousCategorie);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ViewBag.Error = ex.Message;
                    return View(sousCategorie);
                }
            }
            else
            {
                return View(sousCategorie);
            }
            }

        public ActionResult Delete(int? id)
        {
            try
            {
                SousCategorie sousCategorie = sousCategorieService.findOneById(Convert.ToInt32(id));
                sousCategorie.EventCategorie = CategorieService.findOneById(Convert.ToInt32(sousCategorie.EventCategorieId));
                return View(sousCategorie);
            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
    }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int? id)
        {
            try
            {
                sousCategorieService.deleteSousCategorie(Convert.ToInt32(id));
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