using avras.cl.Models;
using avras.cl.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace avras.cl.Controllers
{
    class CaixaController
    {
        public List<CaixaViewModel> Listar()
        {
            var caixas = new Caixa().BuscarCaixa();
            if (caixas != null && caixas.Count > 0)

                return (from caixa in caixas
                        select new CaixaViewModel()
                        {
                            Id = caixa.Id,
                            Valor = caixa.Valor,
                        }).ToList();
            else
                return null;
        }


        private CaixaViewModel BuscarCaixaPorId(int id)
        {
            var caixa = new Caixa().BuscarCaixaPorId(id);
            return new CaixaViewModel()
            {
                Id = caixa.Id,
                Valor = caixa.Valor,
            };
        }
        public int Gravar(CaixaViewModel p)
        {
            int result;

            Caixa caixa = new Caixa()
            {
                Valor = p.Valor,
            };

            if (p.Id != 0)
            {
                caixa.Id = p.Id;
                result = caixa.Alterar();
            }
            else
            {
                result = caixa.Gravar();
            }

            return result;
        }
        public int Alterar(CaixaViewModel p)
        {
            Caixa caixa = new Caixa()
            {
                Id = p.Id,
                Valor = p.Valor,
            };
            return caixa.Alterar();
        }
        public int ExcluirCaixa(int id)
        {
            return new Caixa().Excluir(id);
        }
    }
}
