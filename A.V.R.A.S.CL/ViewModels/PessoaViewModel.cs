using System;
using System.Collections.Generic;
using System.Text;

namespace A.V.R.A.S.CL.ViewModels
{
    public class PessoaViewModel
    {
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

        public virtual PendenciaViewModel Pendencia { get; set; }
        public virtual EnderecoViewModel Endereco { get; set; }
        public virtual ICollection<AluguelViewModel> Aluguel { get; set; }
        public virtual ICollection<CargoViewModel> Cargo { get; set; }
        public virtual ICollection<ControleCaixaViewModel> ControleCaixa{ get; set; }
        public virtual ICollection<ReceberViewModel> Receber { get; set; }
        public virtual ICollection<RetiradaCaixaViewModel> RetiradaCaixa { get; set; }
        public virtual ICollection<SociedadeTempoViewModel> SociedadeTempo { get; set; }
        public virtual ICollection<VendaViewModel> Venda { get; set; }
    }
}
