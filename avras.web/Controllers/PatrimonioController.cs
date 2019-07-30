using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace avras.web.Controllers
{
    public class PatrimonioController : Controller
    {
        public IActionResult Patrimonio()
        {
            return View();
        }
        public IActionResult Listar_Patrimonio()
        {
            return View();
        }
        
        
    }
}