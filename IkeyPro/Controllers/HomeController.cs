using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using IkeyPro.Models;
using IkeyPro.ADO;
using Microsoft.AspNetCore.Http;
using IkeyPro.Helpers;
using IkeyPro.DAO;
using System.Threading;
using System;
using System.Globalization;
using Microsoft.AspNetCore.Localization;

namespace IkeyPro.Controllers
{
    public class HomeController : Controller
    {
 

        public IActionResult Index()
        {
        
            List<Categorie> ListeCategories = CategorieDAO.GetListCategorie();
            SessionHelper.SetObjectAsJson(HttpContext.Session, "SessionListCategorie", ListeCategories);

            List<Editeur> ListeEditeurs1 = EditeurDAO.GetListeEditeur();
            SessionHelper.SetObjectAsJson(HttpContext.Session, "ListeEditeurs", ListeEditeurs1);

            List<Edition> ListeEditions = EditionDAO.GetListeEditeur();
            SessionHelper.SetObjectAsJson(HttpContext.Session, "ListeEditions", ListeEditions);

            List<Produit> ListMostViwedProduit = ProduitDAO.GetListeMostViewedProduit();
            SessionHelper.SetObjectAsJson(HttpContext.Session, "ListMostViwedProduit", ListMostViwedProduit);

            List<Produit> ListeLastDispo = ProduitDAO.GetListeFullProduitByDispo();
            SessionHelper.SetObjectAsJson(HttpContext.Session, "ListeLastDispo", ListeLastDispo);

            Produit ProduitVedette = ProduitDAO.GetProduitVedette();
            SessionHelper.SetObjectAsJson(HttpContext.Session, "ProduitVedette", ProduitVedette);

            List<Produit> ListeProduitByPub = ProduitDAO.GetListeFullProduitByPublicite();
            SessionHelper.SetObjectAsJson(HttpContext.Session, "ListeProduitByPub", ListeProduitByPub);

            List<Produit> ListeAllProduits = ProduitDAO.GetListeDesProduits();
            SessionHelper.SetObjectAsJson(HttpContext.Session, "ListeAllProduits", ListeAllProduits);
            string langue = SessionHelper.GetObjectFromJson<string>(HttpContext.Session, "langue");
            if (langue==null)
            {
                SessionHelper.SetObjectAsJson(HttpContext.Session, "langue", "fr-CA");
            }
          
            return View();
        }


        public IActionResult langue(string culture)
        {
         
                Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires=DateTimeOffset.UtcNow.AddYears(1)}
                
                );
            SessionHelper.SetObjectAsJson(HttpContext.Session, "langue", culture);
            return new JsonResult("ok");
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

        public IActionResult produit(string codeProduit)
        {
            Produit produit = ProduitDAO.GetProduit(codeProduit);
            ViewData["Product"] = produit;
            return View();
        }


        public IActionResult shop(string categorie)
        {
            string cat = CategorieDAO.GetCategorie(categorie);
            List<Produit> ListeProduits = ProduitDAO.GetListeFullProduitByCategorie(categorie);
            ViewData["ListeProduitsShop"] = ListeProduits;
            ViewData["ShopTitre"] = cat;
            return View();
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