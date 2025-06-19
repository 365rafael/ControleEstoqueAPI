using ControleEstoqueAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleEstoqueAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<EntradaEstoque> EntradasEstoque { get; set; }
        public DbSet<SaidaEstoque> SaidasEstoque { get; set; }
    }
}
