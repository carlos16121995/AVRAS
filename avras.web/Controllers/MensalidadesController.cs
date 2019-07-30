using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace avras.web.Controllers
{
    public class MensalidadesController : Controller
    {
        public IActionResult Mensalidades()
        {
            return View();
        }
        public IActionResult GerenciarMensalidade()
        {
            return View();
        }
    }
}