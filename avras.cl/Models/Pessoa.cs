using System;
using System.Collections.Generic;

namespace avras.cl.Models
{
    internal partial class Pessoa
    {
        internal Pessoa()
        {
            Aluguel = new HashSet<Aluguel>();
            Cargo = new HashSet<Cargo>();
            ControleCaixa = new HashSet<ControleCaixa>();
            Receber = new HashSet<Receber>();
            SociedadeTempo = new HashSet<SociedadeTempo>();
            Venda = new HashSet<Venda>();
        }

        internal int Id { get; set; }
        internal string Nome { get; set; }
        internal string Cpf { get; set; }
        internal DateTime DataNascimento { get; set; }
        internal string Telefone { get; set; }
        internal string Email { get; set; }
        internal string Senha { get; set; }
        internal byte Socio { get; set; }
        internal byte Jogador { get; set; }
        internal byte Isento { get; set; }
        internal string Observacoes { get; set; }
        internal int? PendenciaId { get; set; }

        internal virtual Pendencia Pendencia { get; set; }
        internal virtual Endereco Endereco { get; set; }
        internal virtual ICollection<Aluguel> Aluguel { get; set; }
        internal virtual ICollection<Cargo> Cargo { get; set; }
        internal virtual ICollection<ControleCaixa> ControleCaixa { get; set; }
        internal virtual ICollection<Receber> Receber { get; set; }
        internal virtual ICollection<SociedadeTempo> SociedadeTempo { get; set; }
        internal virtual ICollection<Venda> Venda { get; set; }
    }
}
