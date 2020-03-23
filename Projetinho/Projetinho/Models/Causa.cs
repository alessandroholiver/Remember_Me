using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projetinho.Models
{
    public class Causa
    {
        public int CausaID { get; set; }
        public int RegraID { get; set; }
        public string Nome { get; set; }
        public string Pergunta { get; set; }
        public string Resposta { get; set; }


        public virtual Regra Regra { get; set; }
    }
}