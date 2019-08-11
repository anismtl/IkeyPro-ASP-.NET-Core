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

        public IActionResult shop(string categorie)
        {
            string cat = CategorieDAO.GetCategorie(categorie);
            List<Produit> ListeProduits = ProduitDAO.GetListeFullProduitByCategorie(categorie);
            ViewData["ListeProduitsShop"] = ListeProduits;
            ViewData["ShopTitre"] = cat;
            return View();
        }
    }
}