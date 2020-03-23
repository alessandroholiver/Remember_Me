using Projetinho.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projetinho.DAL
{
    public class ProjetoInitializer: System.Data.Entity.DropCreateDatabaseIfModelChanges<AppDbContexto>
    {
        protected override void Seed(AppDbContexto context)
        {
            var objetivos = new List<Objetivo>
            {
                new Objetivo{ObjetivoID=1, Nome = "Gripe",Dica = "Repouso e beba muit agua" },
                new Objetivo{ObjetivoID=4,Nome = "COVID-19",Dica = "Procure urgentemente uma unidade de saúde" },
                new Objetivo{ObjetivoID=3,Nome = "Resfriado",Dica = "Fique de repouso" },
                new Objetivo{ObjetivoID=2,Nome = "Nada",Dica = "Vai trabalhar" },



            };
            objetivos.ForEach(s => context.Objetivos.Add(s));
            context.SaveChanges();

            var regra = new List<Regra>
            {
                new Regra{Nome = "Regra 1",ObjetivoID=1 },
                new Regra{Nome = "Regra 2",ObjetivoID=2 },
                new Regra{Nome = "Regra 3",ObjetivoID=3 },
                new Regra{Nome = "Regra 4",ObjetivoID=4 }




            };
            regra.ForEach(s => context.Regras.Add(s));
            context.SaveChanges();

            var causas = new List<Causa>
            {
                new Causa{Nome = "Dor de cabeça",Pergunta="Você esta com dor de cabeça?",Resposta="Não",RegraID=1 },
                new Causa{Nome = "Dor no corpo",Pergunta="Você esta com dor no corpo?",Resposta="Não",RegraID=1 },
                new Causa{Nome = "Febre",Pergunta="Você esta com febre?",Resposta="Não",RegraID=1 },
                new Causa{Nome = "Coriza",Pergunta="Você esta com coriza?",Resposta="Não",RegraID=1 },
                new Causa{Nome = "Dor nos olhos",Pergunta="Você esta com dor nos olhos?",Resposta="Não",RegraID=2 },
                new Causa{Nome = "Falta de ar",Pergunta="Você esta com dor nos olhos?",Resposta="Não",RegraID=2 },
                new Causa{Nome = "Cãimbra",Pergunta="Você esta com dor nos olhos?",Resposta="Não",RegraID=3 },
                new Causa{Nome = "Formigamento",Pergunta="Você esta com dor nos olhos?",Resposta="Não",RegraID=3 },
                new Causa{Nome = "Preguiça",Pergunta="Você esta com dor nos olhos?",Resposta="Não",RegraID=4 }



            };
            causas.ForEach(s => context.Causas.Add(s));
            context.SaveChanges();

           
        }

    }
}