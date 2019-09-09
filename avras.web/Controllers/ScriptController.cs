using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using avras.web.Models;
using Microsoft.AspNetCore.Mvc;

namespace avras.web.Controllers
{
    public class ScriptController : Controller
    {
        [Route("Script/Mensalidade/Jogador")]
        public void MensalidadeJogador()
        {
            new Script().ExecutarProcedure("criar_mensalidade_jogador");
        }
        [Route("Script/Mensalidade/Socio")]
        public void MensalidadeSocio()
        {
            new Script().ExecutarProcedure("criar_mensalidade_socio");
        }
    }
}