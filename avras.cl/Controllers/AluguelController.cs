using avras.cl.Models;
using avras.cl.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace avras.cl.Controllers
{
    public class AluguelController
    {
        public List<TipoAluguelViewModel> Listar()
        {
            var tipoAlugueis = new TipoAluguel().BuscarTipoAluguel();
            if (tipoAlugueis != null && tipoAlugueis.Count > 0)

                return (from tipoAluguel in tipoAlugueis
                        select new avras.cl.ViewModels.TipoAluguelViewModel()
                        {
                            Id = tipoAluguel.Id,
                            Nome = tipoAluguel.Nome,
                            Valor = tipoAluguel.Valor,
                        }).ToList();
            else
                return null;
        }


        private TipoAluguelViewModel BuscarTipoAluguelPorId(int id)
        {
            var tipoAluguel = new TipoAluguel().BuscarTipoAluguelPorId(id);
            return new TipoAluguelViewModel()
            {
                Id = tipoAluguel.Id,
                Nome = tipoAluguel.Nome,
                Valor = tipoAluguel.Valor,
            };
        }
        public int Gravar(TipoAluguelViewModel p)
        {
            int result;

            TipoAluguel tipoAluguel = new TipoAluguel()
            {
                Nome = p.Nome,
                Valor = p.Valor,
            };

            if (p.Id != 0)
            {
                tipoAluguel.Id = p.Id;
                result = tipoAluguel.Alterar();
            }
            else
            {
                result = tipoAluguel.Gravar();
            }

            return result;
        }
        public int Alterar(TipoAluguelViewModel p)
        {
            TipoAluguel tipoAluguel = new TipoAluguel()
            {
                Id = p.Id,
                Nome = p.Nome,
                Valor = p.Valor,
            };
            return tipoAluguel.Alterar();
        }
        public int ExcluirTipoAluguel(int id)
        {
            return new TipoAluguel().Excluir(id);
        }
    }
}
