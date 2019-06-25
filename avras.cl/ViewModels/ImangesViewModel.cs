using System;
using System.Collections.Generic;
using System.Text;
using avras.cl.ViewModels;

namespace avras.cl.ViewModels
{
    public class ImangesViewModel
    {
        public int Id { get; set; }
        public byte[] Imagem { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Alt { get; set; }
    }
}
