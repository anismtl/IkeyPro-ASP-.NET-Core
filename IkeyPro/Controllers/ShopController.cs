using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IkeyPro.DAO;
using IkeyPro.ADO;
using IkeyPro.Models;
using Microsoft.AspNetCore.Mvc;

namespace IkeyPro.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult shopping(string categorie)
        {
            string cat = CategorieDAO.GetCategorie(categorie);
            List<Produit> ListeProduits = ProduitDAO.GetListeFullProduitByCategorie(categorie);
            ViewData["ListeProduitsShop"] = ListeProduits;
            ViewData["ShopTitre"] = cat;
            return View("shop");
        }
        public IActionResult Recherche(string rechecheStr)
        {
            List<Produit> ListeProduits = ProduitDAO.GetListeDesProduitsByName(rechecheStr);
            ViewData["ListeProduitsShop"] = ListeProduits;
            ViewData["ShopTitre"] = "Recherche";
            return View("shop");
        }


                public IActionResult Edition(string edition)
        {
            List<Produit> ListeProduits = ProduitDAO.GetListeFullProduitByEdition(edition);
            ViewData["ListeProduitsShop"] = ListeProduits;
            ViewData["ShopTitre"] = "edition";
            return View("shop");
        }


        public IActionResult Editeur(string editeur)
        {
            List<Produit> ListeProduits = ProduitDAO.GetListeFullProduitByEditeur(editeur);
            ViewData["ListeProduitsShop"] = ListeProduits;
            ViewData["ShopTitre"] = EditeurDAO.GetEditeur(editeur);
            return View("shop");
        }

        public IActionResult RechEditeur(string cat)
        {
            List<Editeur> ListeEditeur = ProduitDAO.GetListeDistinctEditeurByCat(cat);
           // List<Categorie> ListeCategories = SessionHelper.GetObjectFromJson<List<Categorie>>(HttpContext.Session, "SessionListCategorie");
            return new JsonResult(ListeEditeur);

        }


        public IActionResult RechEdition(string cat, string editeur)
        {
            List<Edition> ListeEdition = ProduitDAO.GetListeDistinctEditionByCat(cat, editeur);
      
            return new JsonResult(ListeEdition);

        }

    }
}