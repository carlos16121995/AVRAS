using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace avras.web.Controllers
{
    public class FinancasController : Controller
    {
        public IActionResult Financas()
        {
            return View();
        }
        public IActionResult Adicionar_Contas()
        {
            return View();
        }
        public IActionResult Caixa()
        {
            return View();
        }
        public IActionResult QuitaContaPagar()
        {
            return View();
        }
        public IActionResult Relatorio()
        {
            return View();
        }
        public IActionResult RetiradaCaixa()
        {
            return View();
        }
    }
}