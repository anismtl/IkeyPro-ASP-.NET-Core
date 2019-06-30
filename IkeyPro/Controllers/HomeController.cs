using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IkeyPro.Models;
using IkeyPro.ADO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;

using Newtonsoft.Json;
using IkeyPro.Helpers;
using IkeyPro.DAO;

namespace IkeyPro.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            // var cats = SessionHelper.GetObjectFromJson<List<Categorie>>(HttpContext.Session, "SessionListCategorie");
            // ViewBag.cart = cats;
            List<Categorie> ListeCategories = CategorieDAO.GetListCategorie();
            SessionHelper.SetObjectAsJson(HttpContext.Session, "SessionListCategorie", ListeCategories);

            List<Editeur> ListeEditeurs1 = EditeurDAO.GetListeEditeur();
            SessionHelper.SetObjectAsJson(HttpContext.Session, "ListeEditeurs", ListeEditeurs1);

            List<Produit> ListMostViwedProduit = ProduitDAO.GetListeMostViwedProduit();
            SessionHelper.SetObjectAsJson(HttpContext.Session, "ListMostViwedProduit", ListMostViwedProduit);

            // List<Produit> ListMostViwedProduit = ProduitDAO.GetListeMostViwedProduit();


            //TempDataHelper.Put<List<Categorie>>(TempData, "ListCategorie", cats);
            // var caty = SessionHelper.GetObjectFromJson<List<Categorie>>(HttpContext.Session, "SessionListCategorie");
            // ViewBag.caty = caty;

            //  ViewData["Categorie"] = cats;
            //  TempData["ListCategorie"] = JsonConvert.SerializeObject(cats);
            // TempData.Add("ListCat", JsonConvert.SerializeObject(cats));

            // HttpContext.Session.SetString("ListCats", JsonConvert.SerializeObject(cats));
            // HttpContext.Items.Add("ListCat", cats);




            return View();
        }

        public IActionResult Cat()
        {
            List<Categorie> ListeCategories = SessionHelper.GetObjectFromJson<List<Categorie>>(HttpContext.Session, "SessionListCategorie");
            return new JsonResult(ListeCategories);
        }

        public IActionResult MostViewed()
        {
            List<Produit> ListMostViwedProduit = SessionHelper.GetObjectFromJson<List<Produit>>(HttpContext.Session, "ListMostViwedProduit");
            return new JsonResult(ListMostViwedProduit);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
