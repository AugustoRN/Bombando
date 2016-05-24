using Bombando.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Linq;
using System.Web;

namespace Bombando.DAO
{
    public class Contexto : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Postagem> Postagens { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
    .Entity<Usuario>()
    .Property(t => t.Nome)
    .HasColumnAnnotation("IX_UNICO", new IndexAnnotation(new IndexAttribute()));

   
            
        
            modelBuilder.Entity<Postagem>().HasRequired(m => m.Usuario);

        }
    }
}