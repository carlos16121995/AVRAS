using System;
using System.Collections.Generic;

namespace avras.cl.Models
{
    internal partial class Receber
    {
        public int ContaId { get; set; }
        public DateTime DataRecebimento { get; set; }
        public decimal ValorRecebimento { get; set; }
        public byte Isento { get; set; }
        public int? AluguelId { get; set; }
        public int? VendaId { get; set; }
        public int? PatrocinioId { get; set; }
        public int? PessoaId { get; set; }

        public virtual Aluguel Aluguel { get; set; }
        public virtual Conta Conta { get; set; }
        public virtual Patrocinadores Patrocinio { get; set; }
        public virtual Pessoa Pessoa { get; set; }
        public virtual Venda Venda { get; set; }
    }
}
