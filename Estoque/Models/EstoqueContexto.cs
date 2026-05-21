using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Estoque.Models
{
    public class EstoqueContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }

        public DbSet<Movimentacao> Movimentacoes { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");

            modelBuilder.Entity<Produto>().ToTable("Produtoes", "public");
            modelBuilder.Entity<Produto>().HasKey(p => p.Id);
            modelBuilder.Entity<Produto>().Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Produto>().Property(p => p.Nome).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Produto>().Property(p => p.Descricao).HasMaxLength(300);
            modelBuilder.Entity<Produto>().Property(p => p.Preco).HasPrecision(18, 2);
            modelBuilder.Entity<Produto>().Property(p => p.ImagemUrl).HasMaxLength(500);
            modelBuilder.Entity<Produto>().Property(p => p.Quantidade).IsRequired();

            modelBuilder.Entity<Movimentacao>().ToTable("Movimentacaos", "public");
            modelBuilder.Entity<Movimentacao>().HasKey(m => m.Id);
            modelBuilder.Entity<Movimentacao>().Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Movimentacao>().Property(m => m.ProdutoId).IsRequired();
            modelBuilder.Entity<Movimentacao>().Property(m => m.Quantidade).IsRequired();
            modelBuilder.Entity<Movimentacao>().Property(m => m.Data).IsRequired();

            modelBuilder.Entity<Usuario>().ToTable("Usuarios", "public");
            modelBuilder.Entity<Usuario>().HasKey(u => u.Id);
            modelBuilder.Entity<Usuario>().Property(u => u.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Usuario>().Property(u => u.Nome).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Usuario>().Property(u => u.Email).HasMaxLength(150).IsRequired();
            modelBuilder.Entity<Usuario>().Property(u => u.SenhaHash).HasMaxLength(64).IsRequired();
            modelBuilder.Entity<Usuario>().Property(u => u.PodeAcessarAdmin).IsRequired();
            modelBuilder.Entity<Usuario>().Property(u => u.DataCadastro).IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }
}
