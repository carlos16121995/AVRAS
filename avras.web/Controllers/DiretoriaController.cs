using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace avras.web.Controllers
{
    public class DiretoriaController : Controller
    {
        public IActionResult Diretoria()
        {
            return View();
        }
        public IActionResult Mandados()
        {
            return View();
        }
        public IActionResult Novo_Mandado()
        {
            return View();
        }
    }
}