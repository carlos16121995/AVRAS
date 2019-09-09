using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using avras.cl.ViewModels;
using avras.cl.Controllers;
using Microsoft.AspNetCore.Http;
using System.Drawing.Imaging;
using System.IO;
using System.Drawing;
using Microsoft.AspNetCore.Hosting;
using System.Text;

namespace avras.web.Controllers
{
    public class EstoqueController : Controller
    {

        private IHostingEnvironment _env;

        public EstoqueController(IHostingEnvironment env)
        {
            _env = env;
        }
        public IActionResult Estoque()
        {
            return View();
        }
        public IActionResult AdicionarProduto()
        {
            return View();
        }
        public IActionResult ListarProdutos()
        {
            return View();
        }
        public IActionResult TipoProdutoViewModel()
        {
            return View();
        }
        [Route("Estoque/Index/{id}")]
        public IActionResult AdicionarProduto(string id)
        {

            ViewBag.Id = id;
            return View();
        }
        public JsonResult BuscarCategoria(string id)
        {
            int idx;
            int.TryParse(id, out idx);
            cl.ViewModels.TipoProdutoViewModel prod = new cl.Controllers.ProdutoController().BuscarCategoriaPorId(idx);
            var ret = new
            {
                produto = prod,
                base64 = Ler(prod.SrcImagem),
            };
            return Json(ret);
        }
        public JsonResult BuscarTipos()
        {
            var tipo = new
            {
                prod = new ProdutoController().Listar()
            };
            return Json(tipo);
        }
        private ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }
        private void Resize(Stream img, int novaLargura, string nomeArquivo, out string base64)
        {
            // Cria um objeto de imagem baseado no stream do arquivo enviado
            Bitmap originalBMP = new Bitmap(img);

            // Calcula a nova dimensao da imagem
            int origWidth = originalBMP.Width;
            int origHeight = originalBMP.Height;
            double sngRatio = (double)novaLargura / origWidth;
            int newWidth = novaLargura;
            int newHeight = Convert.ToInt32(origHeight * sngRatio);

            // Cria uma nova imagem a partir da imagem original
            Bitmap newBMP = new Bitmap(originalBMP, newWidth, newHeight);

            //Diminuir a qualidade da imagem
            System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
            EncoderParameters myEncoderParameters = new EncoderParameters(1);
            EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 50L);
            myEncoderParameters.Param[0] = myEncoderParameter;
            ImageCodecInfo pngEncoder = GetEncoder(ImageFormat.Png);

            // Grava a nova imagem no servidor
            newBMP.Save(nomeArquivo, pngEncoder, myEncoderParameters);

            //Convertendo para base64
            MemoryStream ms = new MemoryStream();
            newBMP.Save(ms, ImageFormat.Png);
            byte[] imageBytes = ms.ToArray();
            base64 = Convert.ToBase64String(imageBytes);

            // Retira os objetos da memória
            originalBMP.Dispose();
            newBMP.Dispose();
        }
        private string Ler(string nome)
        {
            string caminho = _env.WebRootPath + @"\images\categoriasProduto\" + nome;
            Bitmap image1 = new Bitmap(caminho, true);
            MemoryStream ms = new MemoryStream();
            image1.Save(ms, ImageFormat.Png);
            byte[] imageBytes = ms.ToArray();
            string base64 = Convert.ToBase64String(imageBytes);
            image1.Dispose();
            return base64;
        }
        public RetornoTipoCategoriaWEB Alterar(IFormCollection form)
        {
            RetornoTipoCategoriaWEB ret = new RetornoTipoCategoriaWEB();
            int id = 0;
            int.TryParse(form["Id"], out id);
            string nome = form["Nome"];
            if ((id > 0) && (nome != ""))
            {
                ret.NomeArquivo = form["nomeImg"];
                if (Convert.ToBoolean(form["arquivo"]) == true)
                {
                    try
                    {
                        ExcluirImagem(form["nomeImg"]);
                        ret = SalvarServidor(form);
                        if (ret.Err == 1)
                        {
                            ProdutoController prod = new ProdutoController();
                            TipoProdutoViewModel p = new TipoProdutoViewModel()
                            {
                                Id = id,
                                Nome = nome,
                                SrcImagem = ret.NomeArquivo,
                            };
                            ret.Err = prod.Alterar(p);
                            return ret;
                        }
                    }
                    catch (Exception ex)
                    {
                        ret.Err = -10;
                        ret.Msg = "Erro absurdo !!!";
                        return ret;
                    }

                }
                else
                {
                    ProdutoController prod = new ProdutoController();
                    TipoProdutoViewModel p = new TipoProdutoViewModel()
                    {
                        Id = id,
                        Nome = nome,
                        SrcImagem = ret.NomeArquivo,
                    };
                    ret.Err = prod.Alterar(p);
                }
            }
            ret.Err = -99;
            return ret;
        }
        private RetornoTipoCategoriaWEB SalvarServidor(IFormCollection form)
        {
            RetornoTipoCategoriaWEB ret = new RetornoTipoCategoriaWEB();
            List<object> retorno = new List<object>();
            if (Request.Form.Files.Count > 0)
            {
                var extensoesPermitidas = new[] { ".jpg", ".png" };

                for (int i = 0; i < Request.Form.Files.Count; i++)
                {
                    var arquivo = Request.Form.Files[i];
                    if (arquivo.Length <= 1048576) //1MB
                    {
                        string extensaoArquivo =
                        Path.GetExtension(arquivo.FileName).ToLower();
                        if (extensoesPermitidas.Contains(extensaoArquivo))
                        {
                            string dt = Convert.ToString(DateTime.Now);
                            dt = dt.Replace("/", "").Replace(" ", "").Replace(":", "");
                            var nomeArquivo = string.Format("{0}-{1}", dt, arquivo.FileName);
                            var caminho = _env.WebRootPath + @"\images\categoriasProduto\";
                            caminho = Path.Combine(caminho, nomeArquivo);
                            string base64 = "";
                            var img = new MemoryStream();
                            arquivo.CopyTo(img);
                            Resize(img, 800, caminho, out base64);
                            ret.Err = 1;
                            ret.Msg = base64;
                            ret.NomeArquivo = nomeArquivo;

                        }
                        else
                        {
                            ret.Err = -1;
                            ret.Msg = "Formato inválido. " + arquivo.FileName;
                            return ret;
                        }
                    }
                    else
                    {
                        ret.Err = -2;
                        ret.Msg = "Tamanho inválido. " + arquivo.FileName;
                        return ret;
                    }
                }
            }
            else
            {
                ret.Err = -3;
                ret.Msg = "Envie pelo menos 1 arquivo.";
                return ret;
            }
            return ret;
        }
        public RetornoTipoCategoriaWEB GravarCategoria(IFormCollection form)
        {
            RetornoTipoCategoriaWEB ret = new RetornoTipoCategoriaWEB();
            int id = 0;
            int.TryParse(form["Id"], out id);
            string nome = form["Nome"];
            if (nome != "")
            {
                try
                {
                    if (id == 0)
                    {
                        ret = SalvarServidor(form);
                        if (ret.Err == 1)
                        {

                            ProdutoController prod = new ProdutoController();
                            TipoProdutoViewModel p = new TipoProdutoViewModel()
                            {
                                Id = id,
                                Nome = nome,
                                SrcImagem = ret.NomeArquivo,
                            };
                            ret.Err = prod.Gravar(p);
                            return ret;
                        }
                    }
                }
                catch (Exception ex)
                {
                    ret.Err = -10;
                    ret.Msg = "Erro absurdo !!!";
                    return ret;
                }
            }
            ret.Err = -99;
            return ret;

        }
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
        public bool Valida(IFormCollection form, out int id, out decimal compra, out decimal venda, out int quantidade, out int minimo)
        {
            id = ValidaId(form["Id"]);
            compra = 0;
            venda = 0;
            quantidade = 0;
            minimo = 0;



            if (form["Nome"] == "")
            {
                return false;
            }
            if (!decimal.TryParse(form["Compra"], out compra))
            {
                return false;
            }
            if (!int.TryParse(form["Quantidade"], out quantidade))
            {
                return false;
            }
            if (!int.TryParse(form["Minimo"], out minimo))
            {
                return false;
            }

            if (!decimal.TryParse(form["Venda"], out venda))
            {
                return false;
            }

            return true;
        }
        [HttpPost]
        public JsonResult Gravar(IFormCollection form)
        {
            bool valido = Valida(form, out int id, out decimal compra, out decimal venda, out int quantidade, out int minimo);
            if ((valido == true))
            {
                int ret = 0;
                ProdutoViewModel produto = new ProdutoViewModel()
                {
                    Id = id,
                    Nome = form["Nome"],
                    Estoque = quantidade,
                    EstoqueMinimo = minimo,
                    CategoriaId = Convert.ToInt32(form["CategoriaId"]),
                    Disponível = Convert.ToByte(form["Disponivel"]),
                };
                if (id == 0)
                {
                    ret = new ProdutoController().Gravar(produto);
                }
                else
                {
                    ret = new cl.Controllers.ProdutoController().Alterar(produto);
                }
                var retorno = new
                {
                    retorno = ret,
                };
                return Json(retorno);
            }
            return Json("");
        }
        public JsonResult BuscarProdutos()
        {
            List<ProdutoViewModel> produto = new cl.Controllers.ProdutoController().BuscarProdutos(true); /*váriavel boolean traz ou não a Categoria produto*/

            return Json(produto);
        }
        public JsonResult BuscarProdutoPorNome(string nome)
        {
            List<ProdutoViewModel> produto = new ProdutoController().BuscarProdutoPorNome(nome, true); /*váriavel boolean traz ou não a Categoria produto*/

            return Json(produto);
        }
        public JsonResult BuscarProdutoPorId(string id)
        {

            ProdutoViewModel produto = new ProdutoController().BuscarProdutosPorId(Convert.ToInt32(id));
            return Json(produto);
        }
        public JsonResult Excluir(int id)
        {
            var ret = new ProdutoController().Excluir(id);
            return Json(ret);
        }
        private void ExcluirImagem(string nome)
        {
            string caminho = _env.WebRootPath + @"\images\categoriasProduto\" + nome;
            System.IO.File.Delete(caminho);
        }
        public JsonResult ExcluirTipoProdutoViewModel(int id, string nome)
        {
            try
            {
                ExcluirImagem(nome);
                var ret = new ProdutoController().ExcluirTipoProduto(id);
                return Json(ret);
            }
            catch
            {
                return Json("-1");
            }
        }
    }
}