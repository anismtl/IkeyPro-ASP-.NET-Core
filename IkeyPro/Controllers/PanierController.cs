using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IkeyPro.DAO;
using IkeyPro.Helpers;
using IkeyPro.Models;
using Microsoft.AspNetCore.Mvc;

namespace IkeyPro.Controllers
{
   
    public class PanierController : Controller
    {
        [Route("index")]
        public IActionResult Index()
        {
            var cart = SessionHelper.GetObjectFromJson<List<Panier>>(HttpContext.Session, "cart");
            ViewBag.nombre =cart.Count();
            ViewBag.cart = cart;
            ViewBag.total = cart.Sum(item => item.Produit.Prix * item.Quantity);
       
            return View();          
        }


      //  [Route("buy/{id}")]
        public IActionResult Buy(string id, string quantity_input)
        {
            
            if (SessionHelper.GetObjectFromJson<List<Panier>>(HttpContext.Session, "cart") == null)
            {
                List<Panier> cart = new List<Panier>();
                cart.Add(new Panier { Produit = ProduitDAO.GetProduit(id), Quantity = int.Parse(quantity_input) });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
                
            }
            else
            {
                List<Panier> cart = SessionHelper.GetObjectFromJson<List<Panier>>(HttpContext.Session, "cart");
                int index = isExist(id);
                if (index != -1)
                {
                    cart[index].Quantity= cart[index].Quantity+int.Parse(quantity_input);
                }
                else
                {
                    cart.Add(new Panier { Produit = ProduitDAO.GetProduit(id), Quantity = int.Parse(quantity_input) });
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToAction("Index");
        }



        [Route("remove/{id}")]
        public IActionResult Remove(string id)
        {
            List<Panier> cart = SessionHelper.GetObjectFromJson<List<Panier>>(HttpContext.Session, "cart");
            int index = isExist(id);
            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
        }


        [Route("removeall")]
        public IActionResult Removeall()
        {
            List<Panier> cart = SessionHelper.GetObjectFromJson<List<Panier>>(HttpContext.Session, "cart");
            cart.Clear();
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("index","home");
        }


        private int isExist(string id)
        {
            List<Panier> cart = SessionHelper.GetObjectFromJson<List<Panier>>(HttpContext.Session, "cart");
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Produit.CodeProduit.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }


    }
}