using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using IDEIBiblio.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace IDEIBiblio.Dal
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection") { }
        public DbSet<Produto> produtos { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();


            modelBuilder.Entity<Produto>().ToTable("Produto");
            modelBuilder.Entity<Livro>().ToTable("Livro");
            modelBuilder.Entity<Revista>().ToTable("Revista");
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Cat_Livro> Categorias_Livros { get; set; }
        public DbSet<Cat_Revista> Categorias_Revistas { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<Fatura> Faturas { get; set; }
        public DbSet<Gestor_P> Gestores { get; set; }
        public DbSet<Linha_Doc> Linhas_Faturas { get; set; }
        public DbSet<Morada> Moradas { get; set; }
        public DbSet<Tipo_Pub> Tipos_Publicacao { get; set; }

        public DbSet<Livro> Livroes { get; set; }

        public DbSet<Revista> Revistas { get; set; }

        //public DbSet<Encomenda> Encomendas { get; set; }
        public DbSet<Carrinho> carrinhos { get; set; }

        public DbSet<Item_Carrinho> items_carrinho { get; set; }
               
        
    }
}