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

            var Cats = SessionHelper.GetObjectFromJson<List<Categorie>>(HttpContext.Session, "SessionListCategorie");
            if (Cats == null)
            {
                List<Categorie> ListeCategories = CategorieDAO.GetListCategorie();
                SessionHelper.SetObjectAsJson(HttpContext.Session, "SessionListCategorie", ListeCategories);
            }


            var ListeEditeurs = SessionHelper.GetObjectFromJson<List<Editeur>>(HttpContext.Session, "ListeEditeurs");
            if (ListeEditeurs == null)
            {
                List<Editeur> ListeEditeurs1 = EditeurDAO.GetListeEditeur();
                SessionHelper.SetObjectAsJson(HttpContext.Session, "ListeEditeurs", ListeEditeurs1);
            }


            var ListeEditionss = SessionHelper.GetObjectFromJson<List<Edition>>(HttpContext.Session, "ListeEditions");
            if (ListeEditionss == null)
            {
                List<Edition> ListeEditions = EditionDAO.GetListeEditeur();
                SessionHelper.SetObjectAsJson(HttpContext.Session, "ListeEditions", ListeEditions);
            }

            var ListMostViwedProduits = SessionHelper.GetObjectFromJson<List<Produit>>(HttpContext.Session, "ListMostViwedProduit");
            if (ListMostViwedProduits == null)
            {
                List<Produit> ListMostViwedProduit = ProduitDAO.GetListeMostViewedProduit();
                SessionHelper.SetObjectAsJson(HttpContext.Session, "ListMostViwedProduit", ListMostViwedProduit);
            }
             

            var ListeLastDispos = SessionHelper.GetObjectFromJson<List<Produit>>(HttpContext.Session, "ListeLastDispo");
            if (ListeLastDispos == null)
            {
                List<Produit> ListeLastDispo = ProduitDAO.GetListeFullProduitByDispo();
                SessionHelper.SetObjectAsJson(HttpContext.Session, "ListeLastDispo", ListeLastDispo);
            }

            var ProduitVedettes = SessionHelper.GetObjectFromJson<Produit>(HttpContext.Session, "ProduitVedette");
            if (ProduitVedettes == null)
            {
                Produit ProduitVedette = ProduitDAO.GetProduitVedette();
                SessionHelper.SetObjectAsJson(HttpContext.Session, "ProduitVedette", ProduitVedette);
            }

            var ListeProduitByPubs = SessionHelper.GetObjectFromJson<List<Produit>>(HttpContext.Session, "ListeProduitByPub");
            if (ListeProduitByPubs == null)
            {
                List<Produit> ListeProduitByPub = ProduitDAO.GetListeFullProduitByPublicite();
                SessionHelper.SetObjectAsJson(HttpContext.Session, "ListeProduitByPub", ListeProduitByPub);
            }

            var ListeAllProduitss = SessionHelper.GetObjectFromJson<List<Produit>>(HttpContext.Session, "ListeAllProduits");
            if (ListeAllProduitss == null)
            {
                List<Produit> ListeAllProduits = ProduitDAO.GetListeDesProduits();
                SessionHelper.SetObjectAsJson(HttpContext.Session, "ListeAllProduits", ListeAllProduits);
            }
            

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

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Blog()
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