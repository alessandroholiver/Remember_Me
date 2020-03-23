using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projetinho.Models
{
    public class Regra
    {
        public int RegraID { get; set; }
        public int ObjetivoID { get; set; }
        public string Nome { get; set; }
        
        public virtual Objetivo Objetivo { get; set; }

        public virtual ICollection<Causa> Causas { get; set; }

    }
}