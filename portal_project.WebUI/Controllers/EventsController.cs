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

        public EventsController()
        {
            catDao = new CategorieImpl();
            catService = new CategorieService(catDao);
            sousCatDao = new SousCategorieImpl();
            souCatService = new SousCategorieService(sousCatDao);
        }
        // GET: Events
        public ActionResult Index()
        {
            
            List<CategoryViewModel> vm = new List<CategoryViewModel>();
            foreach (Categorie category in catDao.getAllCategories())
            {
                List<SousCategorie> souscats = new List<SousCategorie>();
                foreach (SousCategorie souscat in sousCatDao.getAllSousCategoriesbyCategorie(category.Libelle))
                    {
                    souscats.Add(souscat);
                    }
                vm.Add(new CategoryViewModel { Categorie = category, LstSousCategories = souscats });

            }
            
            //List<SousCategorie> sousCatsLst = souCatService.getAllSousCategories().ToList();
            //List<SelectListItem> sousCats = new List<SelectListItem>() { };
            return View(vm);
        }
    }
}