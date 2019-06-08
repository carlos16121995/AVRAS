using System;
using System.Collections.Generic;
using System.Text;
using A.V.R.A.S.CL.ViewModels;
using A.V.R.A.S.CL.Models;
using System.Linq;

namespace A.V.R.A.S.CL.Controllers
{
    public class PatrocinadoresController
    {
        public int Gravar(PatrocinadoresViewModel p)
        {
            int result;

            Patrocinadores pessoa = new Patrocinadores()
            {
                Nome = p.Nome,
                DataVencimento = p.DataVencimento,
                Valor = p.Valor,
                DataCadastro = p.DataCadastro,
                Parcelas = p.Parcelas,
            };
           
            if (p.Id != 0)
            {
                pessoa.Id = p.Id;
                result = pessoa.Alterar();
            }
            else
            {
                result = pessoa.Gravar();
            }

            return result;
        }
        
        public int Alterar(PatrocinadoresViewModel p)
        {
            Patrocinadores pessoa = new Patrocinadores()
            {
                Id = p.Id,
                Nome = p.Nome,
                DataVencimento = p.DataVencimento,
                Valor = p.Valor,
                DataCadastro = p.DataCadastro,
                Parcelas = p.Parcelas,
            };
            
            return pessoa.Alterar();
        }
       
       
        public List<PatrocinadoresViewModel> BuscarPatrocinadoresPorNome(string nome, bool includeEndereco = false)
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
     
        public List<PatrocinadoresViewModel> BuscarPatrocinadores(bool includeEndereco = false)
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
