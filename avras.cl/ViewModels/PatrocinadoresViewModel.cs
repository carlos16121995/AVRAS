using System;
using System.Collections.Generic;
using System.Text;
using avras.cl.ViewModels;

namespace avras.cl.ViewModels
{
    public class PatrocinadoresViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataCadastro { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataVencimento { get; set; }
        public int Parcelas { get; set; }
        public byte[] Imagem { get; set; }
        public string Descricao { get; set; }
        public string Alt { get; set; }

        public virtual ICollection<ReceberViewModel> Receber { get; set; }
    }
}
