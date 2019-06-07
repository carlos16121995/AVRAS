using System;
using System.Collections.Generic;

namespace A.V.R.A.S.CL.Models
{
    internal partial class Pessoa
    {
        public Pessoa()
        {
            Aluguel = new HashSet<Aluguel>();
            Cargo = new HashSet<Cargo>();
            ControleCaixa = new HashSet<ControleCaixa>();
            Receber = new HashSet<Receber>();
            RetiradaCaixa = new HashSet<RetiradaCaixa>();
            SociedadeTempo = new HashSet<SociedadeTempo>();
            Venda = new HashSet<Venda>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public byte Socio { get; set; }
        public byte Jogador { get; set; }
        public byte Isento { get; set; }
        public string Observacoes { get; set; }
        public int? PendenciaId { get; set; }

        public virtual Pendencia Pendencia { get; set; }
        public virtual Endereco Endereco { get; set; }
        public virtual ICollection<Aluguel> Aluguel { get; set; }
        public virtual ICollection<Cargo> Cargo { get; set; }
        public virtual ICollection<ControleCaixa> ControleCaixa { get; set; }
        public virtual ICollection<Receber> Receber { get; set; }
        public virtual ICollection<RetiradaCaixa> RetiradaCaixa { get; set; }
        public virtual ICollection<SociedadeTempo> SociedadeTempo { get; set; }
        public virtual ICollection<Venda> Venda { get; set; }
    }
}
