using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IkeyPro.Models;
using IkeyPro.ADO;
using Microsoft.AspNetCore.Http;

namespace IkeyPro.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var cats = CategorieADO.GetListCategorie();

            ViewData["Categorie"] = cats;


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
