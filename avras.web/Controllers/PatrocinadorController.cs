using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using static System.Net.Mime.MediaTypeNames;
using cl = avras.cl.Controllers;
using avras.cl.ViewModels;
using avras.web.Filters;

namespace avras.web.Controllers
{
    [ValidarAcesso(Order = 1)]
    public class PatrocinadorController : Controller
    {
        public IActionResult Lista()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
        [Route("Patrocinador/Cadastro/{id}")]
        public IActionResult Cadastro(string id)
        {
            int.TryParse(id, out int patrocinador);

            PatrocinadoresViewModel pat = new PatrocinadoresViewModel();
            pat = new cl.Controllers.PatrocinadoresContoller().BuscarPatrocinadoresPorId(patrocinador);
            ViewBag.Id = pat.Id;
            ViewBag.Nome = pat.Nome;
            string dia = pat.DataVencimento.Day.ToString("D2");
            string mes = pat.DataVencimento.Month.ToString("D2");
            string ano = Convert.ToString(pat.DataVencimento.Year);
            ViewBag.DataVencimento = ano + "-" + mes + "-" + dia;
            string vl = pat.Valor.ToString("N2");
            ViewBag.Valor = vl;
            ViewBag.Parcelas = pat.Parcelas;
            return View();
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
        public bool Valida(IFormCollection form, out int id, out decimal valor, out DateTime data_vencimento, out int parcelas)
        {
            id = ValidaId(form["Id"]);
            valor = 0;
            data_vencimento = Convert.ToDateTime(form["DataVencimento"]);
            parcelas = 0;

            if (form.Count != 5)
            {
                return false;
            }
          
            if (form["Nome"] == "")
            {
                return false;
            }
            if(!decimal.TryParse(form["Valor"],out valor))
            {
                return false;
            }
            
            if(!int.TryParse(form["Parcelas"], out parcelas))
            {
                return false;
            }

            return true;
        }
        public IActionResult Cadastro()
        {
            return View();
        }
        public JsonResult Gravar(IFormCollection form)
        {
            bool valido = Valida(form, out int id, out decimal valor, out DateTime data_vencimento, out int parcelas);
            if ((valido == true) && (data_vencimento.Month > DateTime.Now.Month && data_vencimento.Day >= DateTime.Now.Day) && (form["nome"] != ""))
            {
                int ret = 0;
                PatrocinadoresViewModel patrocinador = new PatrocinadoresViewModel()
                {
                    Id = id,
                    Nome = form["Nome"],
                    Valor = valor,
                    DataVencimento = data_vencimento,
                    Parcelas = parcelas,
                };
                if (id == 0)
                {
                    patrocinador.DataCadastro = DateTime.Now;
                    ret = new cl.Controllers.PatrocinadoresContoller().Gravar(patrocinador);
                }
                else
                {
                    ret = new cl.Controllers.PatrocinadoresContoller().Alterar(patrocinador);
                }
                var retorno = new
                {
                    retorno = ret,
                };
                return Json(retorno);
            }
            if(data_vencimento.Month < DateTime.Now.Month || data_vencimento.Day <= DateTime.Now.Day)
            {
                return Json("99");
            }
            return Json("");
        }
        public int Excluir(int id)
        {
            return new cl.Controllers.PatrocinadoresContoller().Excluir(id);
        }
        public JsonResult BuscarPatrocinadores()
        {
            List<PatrocinadoresViewModel> patrocinador = new cl.Controllers.PatrocinadoresContoller().BuscarPatrocinadores(); /*váriavel boolean traz ou não o endereço*/

            return Json(patrocinador);
        }
        public JsonResult BuscarPorNome(string nome)
        {
           return Json(new cl.Controllers.PatrocinadoresContoller().BuscarPatrocinadoresPorNome(nome));
                  
        }
    }
}