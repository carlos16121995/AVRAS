using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using avras.web.Models;

namespace avras.web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Contato()
        {
            return View();
        }
        public IActionResult Aniversariantes()
        {
            return View();
        }
        public IActionResult Inicio()
        {
            return View();
        }
        public IActionResult PerguntasFrequentes()
        {
            return View();
        }
        public IActionResult Sobre()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Home()
        {
            return View("Home");
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
