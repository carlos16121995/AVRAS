using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using avras.cl.ViewModels;
using avras.cl.Controllers;
using Microsoft.AspNetCore.Http;

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
        [Route("Estoque/Index/{id}")]
        public IActionResult AdicionarProduto(string id)
        {
            
            ViewBag.Id = id;
            return View();
        }
        public JsonResult BuscarTipos()
        {
            var tipo = new
            {
                prod = new ProdutoController().Listar()
            };
            return Json(tipo);
        }
        private int ValidaId(string id)
        {

            int resultado = 0;
            if (String.IsNullOrEmpty(id.Trim()))
            {
                return resultado;
            }
            else
            {
                if (int.TryParse(id.Trim(), out resultado))
                {
                    return resultado;
                }
            }
            return resultado;
        }
        public bool Valida(IFormCollection form, out int id, out decimal compra, out decimal venda, out int quantidade, out int minimo)
        {
            id = ValidaId(form["Id"]);
            compra = 0;
            venda = 0;
            quantidade = 0;
            minimo = 0;

           

            if (form["Nome"] == "")
            {
                return false;
            }
            if (!decimal.TryParse(form["Compra"], out compra))
            {
                return false;
            }
            if (!int.TryParse(form["Quantidade"], out quantidade))
            {
                return false;
            }
            if (!int.TryParse(form["Minimo"], out minimo))
            {
                return false;
            }

            if (!decimal.TryParse(form["Venda"], out venda))
            {
                return false;
            }

            return true;
        }
        [HttpPost]
        public JsonResult Gravar(IFormCollection form)
        {
            bool valido = Valida(form, out int id, out decimal compra, out decimal venda, out int quantidade, out int minimo);
            if ((valido == true))
            {
                int ret = 0;
                ProdutoViewModel produto = new ProdutoViewModel()
                {
                    Id = id,
                    Nome=form["Nome"],
                    ValorCompra = compra,
                    ValorVenda = venda,
                    Quantidade = quantidade,
                    QuantidadeMinima = minimo,
                    CategoriaId = Convert.ToInt32(form["CategoriaId"]),
                    Disponível = Convert.ToByte(form["Disponivel"]),
                };
                if (id == 0)
                {
                    ret = new ProdutoController().Gravar(produto);
                }
                else
                {
                    ret = new cl.Controllers.ProdutoController().Alterar(produto);
                }
                var retorno = new
                {
                    retorno = ret,
                };
                return Json(retorno);
            }
            return Json("");
        }
        public JsonResult BuscarProdutos()
        {
            List<ProdutoViewModel> produto = new cl.Controllers.ProdutoController().BuscarProdutos(true); /*váriavel boolean traz ou não a Categoria produto*/

            return Json(produto);
        }
        public JsonResult BuscarProdutoPorNome( string nome)
        {
            List<ProdutoViewModel> produto = new ProdutoController().BuscarProdutoPorNome(nome, true); /*váriavel boolean traz ou não a Categoria produto*/
        
            return Json(produto);
        }
        public JsonResult BuscarProdutoPorId(string id)
        {

            ProdutoViewModel produto = new ProdutoController().BuscarProdutosPorId(Convert.ToInt32(id));
            return Json(produto);
        }
        public JsonResult Excluir(int id)
        {
            var ret = new ProdutoController().Excluir(id);
            return Json(ret);
        }
    }
}