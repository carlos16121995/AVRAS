﻿using System;
using System.Collections.Generic;

namespace avras.cl.Models
{
    internal partial class TipoAluguel
    {
        public TipoAluguel()
        {
            Aluguel = new HashSet<Aluguel>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }

        public virtual ICollection<Aluguel> Aluguel { get; set; }
    }
}