using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using avras.cl.Controllers;
using avras.cl.ViewModels;
using Microsoft.AspNetCore.Http;

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
        public IActionResult ContaCorrente()
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
        public IActionResult TipoConta()
        {
            return View();
        }
        public JsonResult BuscarTipos()
        {
            var tipo = new
            {
                cargo = new ContaController().Listar()
            };
            return Json(tipo);
        }
        public JsonResult BuscarCategoria(string id)
        {
            int idx;
            int.TryParse(id, out idx);
            if (idx > 0)
            {
                return Json(new ContaController().BuscarTipoContaPorId(idx));
            }
            else
                return Json("");
        }
        public IActionResult GravarTipoConta(IFormCollection form)
        {
            int id = Convert.ToInt32(form["id"]);
            string descricao = form["descricao"];
            string nome = form["nome"];

            if ((nome.Length > 4))
            {
                TipoContaViewModel tipoConta = new TipoContaViewModel()
                {
                    Nome = nome,
                    Descricao = descricao,
                };
                if (id == 0)
                {
                    return Json(new ContaController().Gravar(tipoConta));
                }
                else
                {
                    tipoConta.Id = id;
                    return Json(new ContaController().Alterar(tipoConta));
                }
            }
            else
            {
                return Json("0");
            }
        }
        public int ExcluirTipoConta(int id)
        {
            return new ContaController().ExcluirTipoConta(id);
        }
    }
}