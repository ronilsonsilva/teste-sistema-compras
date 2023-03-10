using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SistemaCompra.Domain.Core;
using SistemaCompra.Domain.ProdutoAggregate;
using SistemaCompra.Infra.Data.Produto;
using SistemaCompra.Infra.Data.SolicitacaoCompra;
using System;
using ProdutoAgg = SistemaCompra.Domain.ProdutoAggregate;

namespace SistemaCompra.Infra.Data
{
    public class SistemaCompraContext : DbContext
    {
        public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });

        public SistemaCompraContext(DbContextOptions options) : base(options) { }
        public DbSet<ProdutoAgg.Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var produtoSeed = new { Id = Guid.NewGuid(), Nome = "Produto01", Descricao = "Descricao01", Categoria = Categoria.Madeira, Situacao = Situacao.Ativo };
            modelBuilder.Entity<ProdutoAgg.Produto>()
                .HasData(
                    produtoSeed
                );
            modelBuilder.Entity<ProdutoAgg.Produto>()
                .OwnsOne(p => p.Preco)
                .HasData(
                    new { ProdutoId =  produtoSeed.Id, Value = 100m }
                );

            modelBuilder.Ignore<Event>();

            modelBuilder.ApplyConfiguration(new ProdutoConfiguration());
            modelBuilder.ApplyConfiguration(new SolicitacaoCompraConfiguration());
            modelBuilder.ApplyConfiguration(new ProdutoConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(loggerFactory)  
                .EnableSensitiveDataLogging()
                .UseSqlServer(@"Server=localhost,1433;Database=SistemaCompraDb;User Id=sa;Password=Sig@2023;");
        }
    }
}
