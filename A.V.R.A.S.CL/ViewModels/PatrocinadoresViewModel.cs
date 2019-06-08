using System;
using System.Collections.Generic;
using System.Text;

namespace A.V.R.A.S.CL.ViewModels
{
    public class PatrocinadoresViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataCadastro { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataVencimento { get; set; }
        public int Parcelas { get; set; }

        public virtual ICollection<ReceberViewModel> Receber { get; set; }
    }
}
