using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using A.V.R.A.S.Filters;
using A.V.R.A.S.CL.ViewModels;
using cl = A.V.R.A.S.CL.Controllers;
using Microsoft.AspNetCore.Http;

namespace A.V.R.A.S.Controllers
{
    [ValidarAcesso(Order = 1)]
    public class PatrocinadoresController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Cadastro()
        {
            ViewBag.Cpf = "";
            return View();
        }
        [Route("Patrocinadores/Index/{cpf}")]
        public IActionResult Cadastro(string cpf)
        {
            ViewBag.Cpf = cpf;
            return View();
        }
        public IActionResult Lista()
        {
            return View();
        }
        public JsonResult Excluir(int id)
        {
            return Json(id > 0 ? new cl.PatrocinadoresController().Excluir(id) : -10);
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
        private int ValidaParcelas(string Parcelas)
        {

            int resultado = 0;
            if (String.IsNullOrEmpty(Parcelas.Trim()))
            {
                return resultado;
            }
            else
            {
                if (int.TryParse(Parcelas.Trim(), out resultado))
                {
                    return resultado;
                }
            }
            return resultado;
        }
        private bool ValidaDataCadastro(string str, out DateTime dataDataCadastro)
        {
            if (DateTime.TryParse(str, out dataDataCadastro))
            {
                if ((dataDataCadastro < DateTime.Now) && (dataDataCadastro > Convert.ToDateTime("01/01/1990")))
                {
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }
        private bool ValidaValor(string str, out decimal valor)
        {
            if (decimal.TryParse(str.Trim(), out valor))
            {
                return true;
            }
            return false;
        }
        private bool ValidaDataVencimento(string str, out DateTime dataDataVencimento)
        {
            if (DateTime.TryParse(str, out dataDataVencimento))
            {
                if ((dataDataVencimento > DateTime.Now))
                {
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }
        public JsonResult Gravar(IFormCollection form)
        {
            string Nome;
            decimal Valor;
            int Parcelas;
            DateTime DataCadastro, DataVencimento;
            int Id;
            List<int> Erros = new List<int>();
            /*   
            *   Validações de campos de formulário
            *   Retorna True se for válido 
            */
            Id = ValidaId(form["Id"]);
            
            if (!ValidaNome(form["nome"], out Nome))
            {
                Erros.Add(-10);
            }
            if (!ValidaDataCadastro(form["DataCadastro"], out DataCadastro))
            {
                Erros.Add(-10);
            }
            if (!ValidaValor(form["Valor"], out Valor))
            {
                Erros.Add(-10);
            }
            if (!ValidaDataVencimento(form["DataVencimento"], out DataVencimento))
            {
                Erros.Add(-10);
            }
            Parcelas = ValidaParcelas(form["Parcelas"]);
            if ((Erros.Count == 0) || (Erros == null))
            {
                PatrocinadoresViewModel pessoa = new PatrocinadoresViewModel()
                {
                    Id = Id,
                    Nome = Nome,
                    Valor = Valor,
                    DataCadastro = DataCadastro,
                    DataVencimento = DataVencimento,
                    Parcelas = Parcelas,
                   
                };
                
                int res = new cl.PatrocinadoresController().Gravar(pessoa);
                if (res > 0)
                {
                    Erros.Add(100);
                }
                else
                    Erros.Add(res);
            }
            var retorno = new
            {
                Erros
            };
            return Json(retorno);

        } 
        public JsonResult BuscarUsuarios()
        {
            List<PatrocinadoresViewModel> patrocinadores = new cl.PatrocinadoresController().BuscarPatrocinadores();

            return Json(patrocinadores);
        }
        public JsonResult BuscarPorNome(string nome)
        {
            int erros = 0;
            if (!ValidaNome(nome, out string Nome))
            {
                erros = -10;
            }
            if (erros == 0)
            {
                return Json(new cl.PatrocinadoresController().BuscarPatrocinadoresPorNome(Nome));
            }
            return Json(erros);
        }
        private bool ValidaNome(string str, out string nome)
        {
            nome = str;
            if ((str.Trim().Length > 3) && (str.Trim().Length < 60))
            {
                nome = str.Trim();
                return true;
            }
            return false;
        }
    }
}