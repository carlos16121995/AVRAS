using avras.cl.Models;
using avras.cl.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace avras.cl.Controllers
{
    public class MandadoController
    {
        public List<TipoCargoViewModel> Listar()
        {
            var tipoCargos = new TipoCargo().BuscarTipoCargo();
            if (tipoCargos != null && tipoCargos.Count > 0)

                return (from tipoCargo in tipoCargos
                        select new TipoCargoViewModel()
                        {
                            Id = tipoCargo.Id,
                            Nome = tipoCargo.Nome,
                            Descricao = tipoCargo.Descricao,
                            Permissao = tipoCargo.Permissao,
                        }).ToList();
            else
                return null;
        }


        public TipoCargoViewModel BuscarTipoCargoPorId(int id)
        {
            
            var tipoCargo = new TipoCargo().BuscarTipoCargoPorId(id);
            return new TipoCargoViewModel()
            {
                Id = tipoCargo.Id,
                Nome = tipoCargo.Nome,
                Descricao = tipoCargo.Descricao,
                Permissao = tipoCargo.Permissao,
            };
        }
        public int Gravar(TipoCargoViewModel p)
        {
            int result;

            TipoCargo tipoCargo = new TipoCargo()
            {
                Nome = p.Nome,
                Descricao = p.Descricao,
                Permissao = p.Permissao,
            };

            if (p.Id != 0)
            {
                tipoCargo.Id = p.Id;
                result = tipoCargo.Alterar();
            }
            else
            {
                result = tipoCargo.Gravar();
            }

            return result;
        }
        public int Alterar(TipoCargoViewModel p)
        {
            TipoCargo tipoCargo = new TipoCargo()
            {
                Id = p.Id,
                Nome = p.Nome,
                Descricao = p.Descricao,
                Permissao = p.Permissao,
            };
            return tipoCargo.Alterar();
        }
        public int ExcluirTipoCargo(int id)
        {
            return new TipoCargo().Excluir(id);
        }
    }
}
