using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cl = avras.cl.Controllers;
using Microsoft.AspNetCore.Mvc;
using avras.cl.ViewModels;
using Microsoft.AspNetCore.Http;

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
        public IActionResult TipoPatrimonio()
        {
            return View();
        }
        public IActionResult Cadastro()
        {
            return View();
        }
        public JsonResult BuscarTipos()
        {
            var tipo = new
            {
                cargo = new avras.cl.Controllers.PatrimonioController().BuscarTipoPatrimonios()
            };
            return Json(tipo);
        }
        public JsonResult BuscarCategoria(string id)
        {
            int idx;
            int.TryParse(id, out idx);
            if (idx > 0)
            {
                return Json(new avras.cl.Controllers.PatrimonioController().BuscarTipoPorId(idx));
            }
            else
                return Json("");
        }
        public IActionResult GravarTipo(IFormCollection form)
        {
            int id = Convert.ToInt32(form["id"]);
            string descricao = form["descricao"];
            string nome = form["nome"];

            if ((nome.Length > 4))
            {
                TipoPatrimonioViewModel tipoPatrimonio = new TipoPatrimonioViewModel()
                {
                    Nome = nome,
                    Descricao = descricao,
                };
                if (id == 0)
                {
                    return Json(new avras.cl.Controllers.PatrimonioController().Gravar(tipoPatrimonio));
                }
                else
                {
                    tipoPatrimonio.Id = id;
                    return Json(new avras.cl.Controllers.PatrimonioController().Alterar(tipoPatrimonio));
                }
            }
            else
            {
                return Json("0");
            }
        }
        public JsonResult BuscarPorNome(string nome)
        {
            int erros = 0;
            if (nome.Length > 3)
            {
                erros = -10;
            }
            if (erros == 0)
            {
                return Json(new cl.Controllers.PatrimonioController().BuscarPatrimoniosPorNome(nome));
            }
            return Json(erros);
        }
        [Route("Patrimonio/Index/{id}")]
        public IActionResult Cadastro(string id)
        {
            ViewBag.Id = id;
            return View();
        }
        public JsonResult Excluir(int id)
        {
            var ret = new avras.cl.Controllers.PatrimonioController().Excluir(id);
            return Json(ret);
        }
        public JsonResult BuscarPatrimonios()
        {
            List<PatrimonioViewModel> pessoa = new cl.Controllers.PatrimonioController().BuscarPatrimonios(true); /*váriavel boolean traz ou não o endereço*/

            return Json(pessoa);
        }
        public JsonResult ExcluirTipoPatrimonio(int id)
        {
            var ret = new avras.cl.Controllers.PatrimonioController().ExcluirTipoPatrimonio(id);
            return Json(ret);
        }
        public JsonResult BuscarPatrimonioPorId(string id)
        {

            PatrimonioViewModel produto = new cl.Controllers.PatrimonioController().BuscarPatrimonioPorId(Convert.ToInt32(id));
            return Json(produto);
        }
        public JsonResult Gravar(IFormCollection form)
        {
            bool valido = false;
            int id, quantidade, tipoPatrimonioId = 0;
            string nome, descicao, anotacao = "";
            decimal valorCompra, valorPerda = 0;
            id = Convert.ToInt32(form["id"]);
            nome = form["nome"];
            descicao = form["descicao"];
            quantidade = Convert.ToInt32(form["quantidade"]);
            valorCompra = Convert.ToDecimal(form["valorCompra"]);
            valorPerda = Convert.ToDecimal(form["valorPerda"]);
            byte disponibilidade = Convert.ToByte(form["disponibilidade"]);
            anotacao = form["anotacao"];
            DateTime dataAquisicao = Convert.ToDateTime(form["dataAquisicao"]);
            DateTime dataPerda = Convert.ToDateTime(form["dataPerda"]);
            tipoPatrimonioId = Convert.ToInt32(form["CategoriaId"]);

            if (nome.Length > 3)
            {
                int ret = 0;
                PatrimonioViewModel patrimonio = new PatrimonioViewModel()
                {
                    Id = id,
                    Nome = nome,
                    Descricao = descicao,
                    Quantidade = quantidade,
                    ValorCompra = valorCompra,
                    ValorPerda = valorPerda,
                    Disponibilidade = disponibilidade,
                    Anotacao = anotacao,
                    DataAquisicao = dataAquisicao,
                    DataPerda = dataPerda,
                    TipoPatrimonioId = tipoPatrimonioId,
                };
                if (id == 0)
                {
                    ret = new cl.Controllers.PatrimonioController().Gravar(patrimonio);
                }
                else
                {
                    ret = new cl.Controllers.PatrimonioController().Alterar(patrimonio);
                }
                var retorno = new
                {
                    retorno = ret,
                };
                return Json(retorno);
            }
            return Json("");
        }
    }
}