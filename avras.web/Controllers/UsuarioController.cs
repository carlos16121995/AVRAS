using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using avras.cl.ViewModels;
using System.Security.Cryptography;
using System.Text;
using System.Net.Mail;
using System.Net;
using cl = avras.cl.Controllers;
using avras.web.Filters;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace avras.web.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Alugueis()
        {
            return View();
        }
        public IActionResult Aluguel()
        {
            return View();
        }
        public IActionResult Cadastro_Usuario()
        {
            return View();
        }
        public IActionResult Minhas_Mensalidades()
        {
            return View();
        }
        public IActionResult Perfil()
        {
            return View();
        }
        public IActionResult Relatorios()
        {
            return View();
        }
        public IActionResult Pendencias()
        {
            return View();
        }
        public IActionResult Alterar_Senha()
        {
            return View();
        }
        public IActionResult Usuario()
        {
            return View("Usuario");
        }
        public IActionResult Index()
        {
            if (Request.Cookies["email"] != null && Request.Cookies["senha"] != null)
            {
                var dados = new
                {
                    Codigo = Request.Cookies["email"].ToString(),
                    Senha = Request.Cookies["senha"].ToString(),
                };
                ViewData.Add("login", dados);
            }
            return View();
        }
        public IActionResult Autenticar(IFormCollection form)
        {
            
            cl.Controllers.PessoaController pessoa = new cl.Controllers.PessoaController();
            var u = pessoa.Autenticar(form["Email"], CalculateMD5Hash(form["Senha"]));

            if (u != null)
            {
                CookieOptions ckOptions = new CookieOptions();
                ckOptions.Expires = DateTime.Now.AddDays(30);
                Response.Cookies.Append("id", u.Id.ToString(), ckOptions);
                Response.Cookies.Append("email", form["Email"], ckOptions);
                Response.Cookies.Append("senha", form["Senha"], ckOptions);

                return Json(u);
            }
            else
                return Json("");
        }
        public IActionResult Logout()
        {
            Response.Cookies.Delete("email");
            Response.Cookies.Delete("senha");
            Response.Cookies.Delete("id");


            return RedirectToAction("Index", "Usuario");
        }
        [Route("Usuario/Index/{cpf}")]
        public IActionResult Cadastro(string cpf)
        {
            ViewBag.Cpf = cpf;
            return View();
        }
        [ValidarAcesso(Order = 1)]
        public IActionResult Cadastro()
        {
            ViewBag.Cpf = "";
            return View();
        }
        
        public IActionResult Lista()
        {
            return View();
        }
       
        public JsonResult Excluir(int id)
        {
            return Json(id > 0 ? new cl.Controllers.PessoaController().Excluir(id) : -10);
        }
        
        public JsonResult Gravar(IFormCollection form)
        {
            string Cpf, Nome, Telefone, Email, Senha, Observacoes, Cep, Cidade, Rua, Bairro, Complemento;
            byte Socio, Jogador, Isento;
            int PendenciaId, Id, Numero;
            DateTime DataNascimento;
            int resultado;
            List<int> Erros = new List<int>();
            /*   
            *   Validações de campos de formulário
            *   Retorna True se for válido 
            */
            Id = ValidaId(form["Id"]);
            if (!ValidaCpf(form["Cpf"], out Cpf))
            {
                Erros.Add(-10);
            }
            if (!ValidaNome(form["nome"], out Nome))
            {
                Erros.Add(-10);
            }
            if (!ValidaDataNascimento(form["DataNascimento"], out DataNascimento))
            {
                Erros.Add(-10);
            }
            if (!ValidaTelefone(form["Telefone"], out Telefone))
            {
                Erros.Add(-10);
            }
            if (!ValidaEmail(form["Email"], out Email))
            {
                Erros.Add(-10);
            }
            ValidaSocio(form["Socio"], out Socio);
            ValidaJogador(form["Jogador"], out Jogador);
            ValidaIsento(form["Isento"], out Isento);
            if (!ValidaObservacoes(form["Observacoes"], out Observacoes))
            {
                Erros.Add(-10);
            }
            if (!ValidaPendencia(form["PendenciaId"], out PendenciaId))
            {
                Erros.Add(-10);
            }
            if (!ValidaCep(form["Cep"], out Cep))
            {
                Erros.Add(-10);
            }
            if (!ValidaCidade(form["Cidade"], out Cidade))
            {
                Erros.Add(-10);
            }
            if (!ValidaBairro(form["Bairro"], out Bairro))
            {
                Erros.Add(-10);
            }
            if (!ValidaRua(form["Rua"], out Rua))
            {
                Erros.Add(-10);
            }
            if (!ValidaNumero(form["Numero"], out Numero))
            {
                Erros.Add(-10);
            }
            if (!ValidaComplemento(form["Complemento"], out Complemento))
            {
                Erros.Add(-10);
            }
            if ((Erros.Count == 0) || (Erros == null))
            {


                EnderecoViewModel endereco = new EnderecoViewModel()
                {
                    PessoaId = Id,
                    Cep = Cep,
                    Cidade = Cidade,
                    Bairro = Bairro,
                    Rua = Rua,
                    Numero = Numero,
                    Complemento = Complemento,
                };
                PessoaViewModel pessoa = new PessoaViewModel()
                {
                    Id = Id,
                    Nome = Nome,
                    Cpf = Cpf,
                    DataNascimento = DataNascimento,
                    Telefone = Telefone,
                    Email = Email,
                    Socio = Socio,
                    Jogador = Jogador,
                    Isento = Isento,
                    PendenciaId = PendenciaId,
                    Endereco = endereco,
                };
                if (Id == 0)
                {
                    Senha = CriarSenha(Nome, Email); // Envia o email para o usuario depois de criar a Senha;
                    pessoa.Senha = Senha;
                }
                int res = new cl.Controllers.PessoaController().Gravar(pessoa);
                if (res > 0)
                {
                    Erros.Add(100);
                }
                else
                    Erros.Add(res);
            }
            var retorno = new
            {
                Erros
            };
            return Json(retorno);

        }
        
        public JsonResult BuscarPorCpf(string str)
        {
            if (ValidaCpf(str, out string cpf))
            {
                PessoaViewModel pessoa = new PessoaViewModel();
                var retorno = new
                {
                    pessoa = new cl.Controllers.PessoaController().BuscarPorCPF(cpf, true), //váriavel boolean traz ou não o endereço
                };
                return Json(retorno);
            }
            return Json(null);
        }
        
        public JsonResult BuscarUsuarios()
        {
            List<PessoaViewModel> pessoa = new cl.Controllers.PessoaController().BuscarUsuarios(true); /*váriavel boolean traz ou não o endereço*/

            return Json(pessoa);
        }
        
        public JsonResult BuscarPorNome(string nome)
        {
            int erros = 0;
            if (!ValidaNome(nome, out string Nome))
            {
                erros = -10;
            }
            if (erros == 0)
            {
                return Json(new cl.Controllers.PessoaController().BuscarUsuarioPorNome(Nome));
            }
            return Json(erros);
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
        
        /*   Validações de campos de formulário
         * 
         * 
         * 
         *  Retorna True se for válido
         * 
         */
        private int ValidaId(string id)
        {

            int resultado = 0;
            if (String.IsNullOrEmpty(id.Trim()))
            {
                return resultado;
            }
            else
            {
                if (int.TryParse(id.Trim(), out resultado))
                {
                    return resultado;
                }
            }
            return resultado;
        }
        
        private bool ValidaCpf(string cpf, out string str)
        {
            str = cpf;
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
        private bool ValidaNome(string str, out string nome)
        {
            nome = str;
            if ((str.Trim().Length > 3) && (str.Trim().Length < 60))
            {
                nome = str.Trim();
                return true;
            }
            return false;
        }
        private bool ValidaDataNascimento(string str, out DateTime dataNascimento)
        {
            if (DateTime.TryParse(str, out dataNascimento))
            {
                if ((dataNascimento < DateTime.Now) && (dataNascimento > Convert.ToDateTime("01/01/1920")))
                {
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }
        private bool ValidaTelefone(string str, out string telefone)
        {
            telefone = str;
            if ((str.Trim().Length == 14))
            {
                telefone = str.Trim();
                return true;
            }
            return false;
        }
        private bool ValidaEmail(string str, out string email)
        {
            email = str;
            if ((email.Trim().Length > 7) && email.Trim().Length < 45)
            {
                return System.Text.RegularExpressions.Regex.IsMatch(email, ("(?<user>[^@]+)@(?<host>.+)"));
            }
            return false;
        }
        private bool ValidaSocio(string str, out byte socio)
        {
            if (byte.TryParse(str, out socio))
            {
                return true;
            }
            return false;
        }
        private bool ValidaJogador(string str, out byte jogador)
        {
            if (byte.TryParse(str, out jogador))
            {
                return true;
            }
            return false;
        }
        private bool ValidaIsento(string str, out byte isento)
        {
            if (byte.TryParse(str, out isento))
            {
                return true;
            }
            return false;
        }
        private bool ValidaObservacoes(string str, out string observacoes)
        {
            observacoes = str;
            if ((str.Trim().Length < 240))
            {
                observacoes = str.Trim();
                return true;
            }
            return false;
        }
        private bool ValidaPendencia(string str, out int id)
        {
            id = 0;
            if (int.TryParse(str.Trim(), out id))
            {
                if (id >= 0)
                {
                    if (id == 0)
                        id = 1;
                    return true;
                }
            }
            return false;
        }
        private bool ValidaCep(string str, out string cep)
        {
            cep = str;
            if ((cep.Trim().Length < 14) || (cep.Trim().Length < 14))
            {
                return System.Text.RegularExpressions.Regex.IsMatch(cep, ("[0-9]{2}.[0-9]{3}-[0-9]{3}"));
            }
            return false;
        }
        private bool ValidaCidade(string str, out string cidade)
        {
            cidade = str;
            if ((str.Trim().Length > 2) && (str.Trim().Length < 30))
            {
                cidade = str.Trim();
                return true;
            }
            return false;
        }
        private bool ValidaBairro(string str, out string bairro)
        {
            bairro = str;
            if ((str.Trim().Length > 4) && (str.Trim().Length < 45))
            {
                bairro = str.Trim();
                return true;
            }
            return false;
        }
        private bool ValidaRua(string str, out string rua)
        {
            rua = str;
            if ((str.Trim().Length > 1) && (str.Trim().Length < 45))
            {
                rua = str.Trim();
                return true;
            }
            return false;
        }
        private bool ValidaNumero(string str, out int numero)
        {
            numero = 0;
            if (int.TryParse(str.Trim(), out numero))
            {
                if (numero > 0)
                {
                    return true;
                }
            }
            return false;
        }
        private bool ValidaComplemento(string str, out string complemento)
        {
            complemento = str;
            if ((str.Trim().Length < 45))
            {
                complemento = str.Trim();
                return true;
            }
            return false;
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
        /// <summary>
        /// Cria uma senha Random com tamanho 8 e envia por email
        /// </summary>
        /// <param nome="Antonio"></param>
        /// <param name="tonho@mail.com"></param>
        /// <returns>Senha Hash</returns>
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
    }
}