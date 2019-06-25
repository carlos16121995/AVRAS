using System;
using System.Collections.Generic;

namespace avras.cl.Models
{
    internal partial class Imagens
    {
        public int Id { get; set; }
        public byte[] Imagem { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Alt { get; set; }
    }
}
