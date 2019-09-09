﻿using System;
using System.Collections.Generic;
using System.Text;

namespace avras.cl.ViewModels
{
    public class TipoCargoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Permissao { get; set; }


        public virtual ICollection<CargoViewModel> Cargo { get; set; }
    }
}
