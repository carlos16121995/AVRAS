using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace avras.web.Controllers
{
    public class VendasController : Controller
    {
        public IActionResult Venda()
        {
            return View();
        }
        public IActionResult Historico_Vendas()
        {
            return View();
        }
    }
}