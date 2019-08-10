using avras.cl.Models;
using avras.cl.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace avras.cl.Controllers
{
    class ContaController
    {
        public List<TipoContaViewModel> Listar()
        {
            var tipoContas = new TipoConta().BuscarTipoConta();
            if (tipoContas != null && tipoContas.Count > 0)

                return (from tipoConta in tipoContas
                        select new TipoContaViewModel()
                        {
                            Id = tipoConta.Id,
                            Nome = tipoConta.Nome,
                            Descricao = tipoConta.Descricao,
                        }).ToList();
            else
                return null;
        }


        private TipoContaViewModel BuscarTipoContaPorId(int id)
        {
            var tipoConta = new TipoConta().BuscarTipoContaPorId(id);
            return new TipoContaViewModel()
            {
                Id = tipoConta.Id,
                Nome = tipoConta.Nome,
                Descricao = tipoConta.Descricao,
            };
        }
        public int Gravar(TipoContaViewModel p)
        {
            int result;

            TipoConta tipoConta = new TipoConta()
            {
                Nome = p.Nome,
                Descricao = p.Descricao,
            };

            if (p.Id != 0)
            {
                tipoConta.Id = p.Id;
                result = tipoConta.Alterar();
            }
            else
            {
                result = tipoConta.Gravar();
            }

            return result;
        }
        public int Alterar(TipoContaViewModel p)
        {
            TipoConta tipoConta = new TipoConta()
            {
                Id = p.Id,
                Nome = p.Nome,
                Descricao = p.Descricao,
            };
            return tipoConta.Alterar();
        }
        public int ExcluirTipoConta(int id)
        {
            return new TipoConta().Excluir(id);
        }
    }
}
