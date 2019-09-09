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
    public class DiretoriaController : Controller
    {
        public IActionResult Diretoria()
        {
            return View();
        }
        public IActionResult Mandatos()
        {
            return View();
        }
        public IActionResult Novo_Mandato()
        {
            return View();
        }
        public IActionResult TipoCargo()
        {
            return View();
        }
        public JsonResult BuscarTipos()
        {
            var tipo = new
            {
                cargo = new MandadoController().Listar()
            };
            return Json(tipo);
        }
        public JsonResult BuscarCategoria(string id)
        {
            int idx;
            int.TryParse(id, out idx);
            if (idx > 0)
            {
                return Json(new MandadoController().BuscarTipoCargoPorId(idx));
            }
            else
                return Json("");
        }
        public IActionResult GravarTipoCargo(IFormCollection form)
        {
            int id = Convert.ToInt32(form["id"]);
            int permissao = Convert.ToInt32(form["permissao"]);
            string descricao = form["descricao"];
            string nome = form["nome"];

            if ((nome.Length > 4) && ((permissao > 0) && (permissao < 7)))
            {
                TipoCargoViewModel tipoCargo = new TipoCargoViewModel()
                {
                    Nome = nome,
                    Permissao = permissao,
                    Descricao = descricao,
                };
                if (id == 0)
                {
                    return Json(new MandadoController().Gravar(tipoCargo));
                }
                else
                {
                    tipoCargo.Id = id;
                    return Json(new MandadoController().Alterar(tipoCargo));
                }
            }
            else
            {
                return Json("0");
            }
        }
        public JsonResult ExcluirTipoCargo(int id)
        {
            if (id > 5)
            {
                var ret = new MandadoController().ExcluirTipoCargo(id);
                return Json(ret);
            }
            return Json("-55");
        }
        public JsonResult Gravar(IFormCollection form)
        {
            //var tentativa = form.Keys;
            //foreach(var aux in form.Keys)
            //{
            //    var aux2 = aux[$"mandato[{0}][idCargo]"];

            //}
            return Json("1");
        }
    }
}