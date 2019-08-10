using avras.cl.Models;
using avras.cl.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace avras.cl.Controllers
{
    class ContaCorrenteController
    {
        public List<ContaCorrenteViewModel> Listar()
        {
            var contaCorrentes = new ContaCorrente().BuscarContaCorrente();
            if (contaCorrentes != null && contaCorrentes.Count > 0)

                return (from contaCorrente in contaCorrentes
                        select new ContaCorrenteViewModel()
                        {
                            Id = contaCorrente.Id,
                            Valor = contaCorrente.Valor,
                        }).ToList();
            else
                return null;
        }


        private ContaCorrenteViewModel BuscarTipoContaPorId(int id)
        {
            var contaCorrente = new ContaCorrente().BuscarTipoContaPorId(id);
            return new ContaCorrenteViewModel()
            {
                Id = contaCorrente.Id,
                Valor = contaCorrente.Valor,
            };
        }
        public int Gravar(ContaCorrenteViewModel p)
        {
            int result;

            ContaCorrente contaCorrente = new ContaCorrente()
            {
                Valor = p.Valor,
            };

            if (p.Id != 0)
            {
                contaCorrente.Id = p.Id;
                result = contaCorrente.Alterar();
            }
            else
            {
                result = contaCorrente.Gravar();
            }

            return result;
        }
        public int Alterar(ContaCorrenteViewModel p)
        {
            ContaCorrente tipoConta = new ContaCorrente()
            {
                Id = p.Id,
                Valor = p.Valor,
            };
            return tipoConta.Alterar();
        }
        public int ExcluirContaCorrente(int id)
        {
            return new ContaCorrente().Excluir(id);
        }
    }
}
