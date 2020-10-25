
using SGE.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace SGE.Infrastructure.Repository.Context
{
    public class ProdutoDbContext : DbContext
    {
        
        public ProdutoDbContext(DbContextOptions<ProdutoDbContext> opts)
            : base(opts)
        {
            
        }

        public virtual DbSet<Produto> Produto { get; set; }

        protected override async void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Produto>().HasData(
                new Produto { Id = 1, NomeProduto = "café 3 <3", QtdeProduto = 100, ValorUnitario = 12.49 },
                new Produto { Id = 2, NomeProduto = "leite itambe", QtdeProduto = 100, ValorUnitario = 12.49 },
                new Produto { Id = 3, NomeProduto = "caneca", QtdeProduto = 100, ValorUnitario = 12.49 },
                new Produto { Id = 4, NomeProduto = "requeijão itambe", QtdeProduto = 100, ValorUnitario = 12.49 },
                new Produto { Id = 5, NomeProduto = "queijo itambe", QtdeProduto = 100, ValorUnitario = 12.49 },
                new Produto { Id = 6, NomeProduto = "manteiga itambe", QtdeProduto = 100, ValorUnitario = 12.49 }
                );
        }
    }
}
