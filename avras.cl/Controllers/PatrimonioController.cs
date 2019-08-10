using System;
using System.Collections.Generic;
using System.Text;
using avras.cl.ViewModels;
using avras.cl.Models;
using System.Linq;

namespace avras.cl.Controllers
{
    class PatrimonioController
    {
        public PatrimonioViewModel BuscarPatrimonioPorId(int id, bool includeTipo = false)
        {
            var p = new Patrimonio().BuscarPatrimoniosPorId(id);
            return new PatrimonioViewModel()
            {
                Id = p.Id,
                Nome = p.Nome,
                Descicao = p.Descicao,
                Quantidade = p.Quantidade,
                ValorCompra = p.ValorCompra,
                ValorPerda = p.ValorPerda,
                Disponibilidade = p.Disponibilidade,
                Anotacao = p.Anotacao,
                DataAquisicao = p.DataAquisicao,
                DataPerda = p.DataPerda,
                TipoPatrimonioId = p.TipoPatrimonioId,
                TipoPatrimonio = (includeTipo == true ? BuscarTipoPorId(p.TipoPatrimonioId) : null),
            };
        }
        public List<PatrimonioViewModel> BuscarPatrimoniosPorNome(string nome, bool includeTipo = false)
        {
            var patrimonios = new Patrimonio().BuscarPatrimoniosPorNome(nome);
            if (patrimonios != null && patrimonios.Count > 0)

                return (from p in patrimonios
                        select new PatrimonioViewModel()
                        {
                            Id = p.Id,
                            Nome = p.Nome,
                            Descicao = p.Descicao,
                            Quantidade = p.Quantidade,
                            ValorCompra = p.ValorCompra,
                            ValorPerda = p.ValorPerda,
                            Disponibilidade = p.Disponibilidade,
                            Anotacao = p.Anotacao,
                            DataAquisicao = p.DataAquisicao,
                            DataPerda = p.DataPerda,
                            TipoPatrimonioId = p.TipoPatrimonioId,
                            TipoPatrimonio = (includeTipo == true ? BuscarTipoPorId(p.TipoPatrimonioId) : null),
                        }).ToList();
            else
                return null;
        }
        public List<PatrimonioViewModel> BuscarPatrimonios(bool includeTipo = false)
        {
            var patrimonios = new Patrimonio().BuscarPatrimonios();
            if (patrimonios != null && patrimonios.Count > 0)

                return (from p in patrimonios
                        select new PatrimonioViewModel()
                        {
                            Id = p.Id,
                            Nome = p.Nome,
                            Descicao = p.Descicao,
                            Quantidade = p.Quantidade,
                            ValorCompra = p.ValorCompra,
                            ValorPerda = p.ValorPerda,
                            Disponibilidade = p.Disponibilidade,
                            Anotacao = p.Anotacao,
                            DataAquisicao = p.DataAquisicao,
                            DataPerda = p.DataPerda,
                            TipoPatrimonioId = p.TipoPatrimonioId,
                            TipoPatrimonio = (includeTipo == true ? BuscarTipoPorId(p.TipoPatrimonioId) : null),
                        }).ToList();
            else
                return null;
        }
        public int Gravar(PatrimonioViewModel p)
        {
            int result;

            Patrimonio patrimonio = new Patrimonio()
            {
                Nome = p.Nome,
                Descicao = p.Descicao,
                Quantidade = p.Quantidade,
                ValorCompra = p.ValorCompra,
                ValorPerda = p.ValorPerda,
                Disponibilidade = p.Disponibilidade,
                Anotacao = p.Anotacao,
                DataAquisicao = p.DataAquisicao,
                DataPerda = p.DataPerda,
                TipoPatrimonioId = p.TipoPatrimonioId,
            };

            if (p.Id != 0)
            {
                patrimonio.Id = p.Id;
                result = patrimonio.Alterar();
            }
            else
            {
                result = patrimonio.Gravar();
            }

            return result;
        }
        public int Alterar(PatrimonioViewModel p)
        {
            Patrimonio patrimonio = new Patrimonio()
            {
                Id = p.Id,
                Nome = p.Nome,
                Descicao = p.Descicao,
                Quantidade = p.Quantidade,
                ValorCompra = p.ValorCompra,
                ValorPerda = p.ValorPerda,
                Disponibilidade = p.Disponibilidade,
                Anotacao = p.Anotacao,
                DataAquisicao = p.DataAquisicao,
                DataPerda = p.DataPerda,
                TipoPatrimonioId = p.TipoPatrimonioId,
            };
            return patrimonio.Alterar();
        }
        public int Excluir(int id)
        {
            return new Patrimonio().Excluir(id);
        }

        // Buscar por tipo ou categoria
        private TipoPatrimonioViewModel BuscarTipoPorId(int id)
        {
            var tipo = new TipoPatrimonio().BuscarTipoPatrimonioPorId(id);
            return new TipoPatrimonioViewModel()
            {
                Id = tipo.Id,
                Nome = tipo.Nome,
                Descricao = tipo.Descricao,
            };
        }
        public List<TipoPatrimonioViewModel> BuscarTipoPatrimonios()
        {
            var tipoPatrimonios = new TipoPatrimonio().BuscarTipoPatrimonio();
            if (tipoPatrimonios != null && tipoPatrimonios.Count > 0)

                return (from p in tipoPatrimonios
                        select new TipoPatrimonioViewModel()
                        {
                            Id = p.Id,
                            Nome = p.Nome,
                            Descricao = p.Descricao,
                        }).ToList();
            else
                return null;
        }
        public int Gravar(TipoPatrimonioViewModel p)
        {
            int result;

            TipoPatrimonio tipoPatrimonio = new TipoPatrimonio()
            {
                Nome = p.Nome,
                Descricao = p.Descricao,
            };

            if (p.Id != 0)
            {
                tipoPatrimonio.Id = p.Id;
                result = tipoPatrimonio.Alterar();
            }
            else
            {
                result = tipoPatrimonio.Gravar();
            }

            return result;
        }
        public int Alterar(TipoPatrimonioViewModel p)
        {
            TipoPatrimonio tipoPatrimonio = new TipoPatrimonio()
            {
                Id = p.Id,
                Nome = p.Nome,
                Descricao = p.Descricao,
                
            };
            return tipoPatrimonio.Alterar();
        }
        public int ExcluirTipoPatrimonio(int id)
        {
            return new TipoPatrimonio().Excluir(id);
        }


    }
}
