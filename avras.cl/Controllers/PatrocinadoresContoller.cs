using avras.cl.Models;
using avras.cl.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace avras.cl.Controllers
{
    public class PatrocinadoresContoller
    {
        public int Gravar(PatrocinadoresViewModel p)
        {
            int result;

            Patrocinadores patrocinadores = new Patrocinadores()
            {
                Nome = p.Nome,
                DataVencimento = p.DataVencimento,
                Valor = p.Valor,
                DataCadastro = p.DataCadastro,
                Parcelas = p.Parcelas,
            };

            if (p.Id != 0)
            {
                patrocinadores.Id = p.Id;
                result = patrocinadores.Alterar();
            }
            else
            {
                result = patrocinadores.Gravar();
            }

            return result;
        }

        public int Alterar(PatrocinadoresViewModel p)
        {
            Patrocinadores patrocinadores = new Patrocinadores()
            {
                Id = p.Id,
                Nome = p.Nome,
                DataVencimento = p.DataVencimento,
                Valor = p.Valor,
                DataCadastro = p.DataCadastro,
                Parcelas = p.Parcelas,
            };

            return patrocinadores.Alterar();
        }

        public PatrocinadoresViewModel BuscarPatrocinadoresPorId(int id)
        {
            Patrocinadores p = new Patrocinadores().BuscarPatrocinadoresPorId(id);
            PatrocinadoresViewModel patrocinadores = new PatrocinadoresViewModel()
            {
                Id = p.Id,
                Nome = p.Nome,
                DataVencimento = p.DataVencimento,
                Valor = p.Valor,
                DataCadastro = p.DataCadastro,
                Parcelas = p.Parcelas,
            };
            return patrocinadores;

        }
        public List<PatrocinadoresViewModel> BuscarPatrocinadoresPorNome(string nome)
        {
            var patrocinadores = new Patrocinadores().BuscarPatrocinadoresPorNome(nome);
            if (patrocinadores != null && patrocinadores.Count > 0)

                return (from Patrocinadores in patrocinadores
                        select new PatrocinadoresViewModel()
                        {
                            Id = Patrocinadores.Id,
                            Nome = Patrocinadores.Nome,
                            DataVencimento = Patrocinadores.DataVencimento,
                            Valor = Patrocinadores.Valor,
                            DataCadastro = Patrocinadores.DataCadastro,
                            Parcelas = Patrocinadores.Parcelas,
                        }).ToList();
            else
                return null;

        }
        public int Excluir(int id)
        {
            return new Patrocinadores().Excluir(id);
        }

        public List<PatrocinadoresViewModel> BuscarPatrocinadores()
        {
            var patrocinadores = new Patrocinadores().BuscarPatrocinadores();
            if (patrocinadores != null && patrocinadores.Count > 0)

                return (from patrocinador in patrocinadores
                        select new PatrocinadoresViewModel()
                        {
                            Id = patrocinador.Id,
                            Nome = patrocinador.Nome,
                            DataVencimento = patrocinador.DataVencimento,
                            Valor = patrocinador.Valor,
                            DataCadastro = patrocinador.DataCadastro,
                            Parcelas = patrocinador.Parcelas,
                        }).ToList();
            else
                return null;
        }
    }
}
