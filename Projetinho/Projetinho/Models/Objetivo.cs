using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Projetinho.Models
{
    public class Objetivo
    {
        
        public int ObjetivoID { get; set; }
        public string Nome { get; set; }
        public string Dica { get; set; }

        public virtual ICollection<Regra> Regras { get; set; }
    }
}