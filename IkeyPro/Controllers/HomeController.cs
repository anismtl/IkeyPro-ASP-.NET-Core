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

namespace IkeyPro.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            // var cats = SessionHelper.GetObjectFromJson<List<Categorie>>(HttpContext.Session, "SessionListCategorie");
            // ViewBag.cart = cats;
            List<Categorie> cats = CategorieADO.GetListCategorie();
            TempDataHelper.Put<List<Categorie>>(TempData, "ListCategorie", cats);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "SessionListCategorie", cats);
            // var caty = SessionHelper.GetObjectFromJson<List<Categorie>>(HttpContext.Session, "SessionListCategorie");
            // ViewBag.caty = caty;

            //  ViewData["Categorie"] = cats;
            //  TempData["ListCategorie"] = JsonConvert.SerializeObject(cats);
            // TempData.Add("ListCat", JsonConvert.SerializeObject(cats));

            // HttpContext.Session.SetString("ListCats", JsonConvert.SerializeObject(cats));
            // HttpContext.Items.Add("ListCat", cats);




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
