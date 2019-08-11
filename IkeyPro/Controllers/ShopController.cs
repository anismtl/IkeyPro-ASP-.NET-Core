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

        public IActionResult Shop()
        {
            List<Produit> ListeProduits = ProduitDAO.GetListeMostViewedProduit();
            ViewData["ListMostViwedProduit"] = ListeProduits;
            ViewData["ShopTitre"] = "Shop";
            return View();
        }
        public IActionResult Recherche(string rechecheStr)
        {
            List<Produit> ListeProduits = ProduitDAO.GetListeDesProduitsByName(rechecheStr);
            ViewData["ListeProduitsShop"] = ListeProduits;
            return View("shop");
        }
    }
}