using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace avras.web.Controllers
{
    public class EstoqueController : Controller
    {
        public IActionResult Estoque()
        {
            return View();
        }
        public IActionResult AdicionarProduto()
        {
            return View();
        }
        public IActionResult ListarProdutos()
        {
            return View();
        }
        public IActionResult AdicionarTipo()
        {
            return View();
        }
    }
}