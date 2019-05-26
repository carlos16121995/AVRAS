using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using A.V.R.A.S.Models;
using System.Security.Cryptography;
using System.Text;
using System.Net.Mail;
using System.Net;
namespace A.V.R.A.S.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Cadastro()
        {
            return View();
        }
        public IActionResult Lista()
        {
            return View();
        }
        public bool Valida(Pessoa usuario)
        {
            var valido = true;
            if ((String.IsNullOrEmpty(usuario.Nome)) || (usuario.Nome.Length < 4))
            {
                valido = false;
            }
            if (!IsCpf(usuario.Cpf))
            {
                valido = false;
            }
            if (usuario.DataNascimento > DateTime.Now)
            {
                valido = false;
            }
            if ((usuario.Telefone.Length < 14) || (String.IsNullOrEmpty(usuario.Telefone)))
            {
                valido = false;
            }
            if ((usuario.Endereco.PessoaId != usuario.Id))
            {
                valido = false;
            }
            if (String.IsNullOrEmpty(usuario.Endereco.Cidade))
            {
                valido = false;
            }
            if (String.IsNullOrEmpty(usuario.Endereco.Rua))
            {
                valido = false;
            }
            if (String.IsNullOrEmpty(usuario.Endereco.Bairro))
            {
                valido = false;
            }
            if (usuario.Endereco.Numero <= 0)
            {
                valido = false;
            }
            return valido;

        }
        private string EnviarEmail(string nomeFrom, List<string> emailPara, string assunto, string texto)
        {
            string emailFrom = "avrasteste@gmail.com";
            //Gerando o objeto da mensagem
            MailMessage msg = new MailMessage();
            //Remetente
            msg.From = new MailAddress(emailFrom, nomeFrom);
            //Destinatários
            foreach (string email in emailPara)
                msg.To.Add(email);
            //Assunto
            msg.Subject = assunto;
            //Texto a ser enviado
            msg.Body = texto;
            msg.IsBodyHtml = true;

            //Gerando o objeto para envio da mensagem (Exemplo pelo Gmail)
            SmtpClient client = new SmtpClient();
            client.UseDefaultCredentials = true;
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Credentials = new NetworkCredential(emailFrom, "avras2019");
            try
            {
                client.Send(msg);
                return "OK";
            }
            catch (Exception ex)
            {
                return "Falha: " + ex.Message;
            }
            finally
            {
                msg.Dispose();
            }
        }
        public string CalculateMD5Hash(string input)
        {
            // Calcular o Hash
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // Converter byte array para string hexadecimal
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
        public string CriarSenha(string nome, string email)
        {
            int tamanho = 8;
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, tamanho)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());

            //enviando senha para email
            List<string> emails = new List<string>();
            emails.Add(email);
            string assunto = "Sua senha para acesso ao sistema da A.V.R.A.S";
            string texto = " Agora você pode acessar o sistema da A.V.R.A.S de qualquer lugar. Verifique suas mensalidades, compras no bar e fique por sabendo dos aniversariantes do mês para não se esquecer de lhes dar o parabéns. Sua senha para acesso é: " + result;
            EnviarEmail(nome, emails, assunto, texto);

            // criando rash para salvar no banco
            result = CalculateMD5Hash(result);
            return result;
        }
        public JsonResult Gravar(IFormCollection form)
        {
            int id = 0;
            int resultado = 0;
            if (form["id"] == "")
            {
                id = 0;
            }
            else
                id = Convert.ToInt32(form["id"]);
            int numero = int.Parse((form["numero"]), 0);
            Endereco endereco = new Endereco()
            {
                PessoaId = id,
                Cep = form["cep"],
                Cidade = form["cidade"],
                Bairro = form["bairro"],
                Rua = form["rua"],
                Numero = numero,
                Complemento = form["complemento"],
            };
            Pessoa pessoa = new Pessoa()
            {
                Id = id,
                Nome = form["nome"],
                Cpf = form["cpf"],
                DataNascimento = Convert.ToDateTime(form["dataNascimento"]),
                Telefone = form["telefone"],
                Email = form["email"],
                Senha = CriarSenha(form["nome"], form["email"]),
                Socio = Convert.ToByte((form["socio"] == "true" ? 1 : 0)),
                Jogador = Convert.ToByte((form["jogador"] == "true" ? 1 : 0)),
                Isento = Convert.ToByte((form["isento"] == "true" ? 1 : 0)),
                Endereco = endereco,
            };
            bool valido = Valida(pessoa);
            if (valido)
            {
                resultado = pessoa.Gravar();
                return Json("1");
            }
            return Json("");

        }
        public JsonResult BuscarUsuarios()
        {

            return Json("");
        }
       
        public JsonResult BuscarPorCpf(string cpf)
        {
            Pessoa pessoa = new Pessoa();
            bool valido = IsCpf(cpf);
            if (valido)
            {

                pessoa = pessoa.BuscarPorCpf(cpf);
                Pessoa pessoa2 = new Pessoa()
                {
                    Id = pessoa.Id,
                    Cpf = pessoa.Cpf,
                    Nome = pessoa.Nome,
                    DataNascimento = pessoa.DataNascimento,
                    Telefone = pessoa.Telefone,
                    Email = pessoa.Email,
                    Senha = pessoa.Senha,
                    Socio = pessoa.Socio,
                    Jogador = pessoa.Jogador,
                    Isento = pessoa.Isento,
                    Observacoes = pessoa.Observacoes,
                    PendenciaId = pessoa.PendenciaId
                };
                Endereco endereco = new Endereco()
                {
                    PessoaId = Convert.ToInt32(pessoa.Endereco.PessoaId),
                    Cep = pessoa.Endereco.Cep,
                    Cidade = pessoa.Endereco.Cidade,
                    Bairro = pessoa.Endereco.Bairro,
                    Rua = pessoa.Endereco.Rua,
                    Numero = pessoa.Endereco.Numero,
                    Complemento = pessoa.Endereco.Complemento,
                };
                

                var retorno = new {
                    pessoa2,
                    endereco
                };


                return Json(retorno);
            }
            var ret2 = new
            {
                pessoa,
            };
            return Json("");
        }
        public JsonResult BuscarPorNome(string nome)
        {
            var dados = new
            {
                teste1 = "afasdf",
                teste2 = "sdgsdfg",
            };
            return Json(dados);
        }

        public bool IsCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)

                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }
    }
}