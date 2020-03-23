using Projetinho.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Projetinho.DAL
{
    public class AppDbContexto: DbContext
    {
        public AppDbContexto() : base("AppContexto")
        {

        }

        public DbSet<Causa> Causas { get; set; }
        public DbSet<Regra> Regras { get; set; }
        public DbSet<Objetivo> Objetivos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}