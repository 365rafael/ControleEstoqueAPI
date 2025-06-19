using ControleEstoqueAPI.Data;
using ControleEstoqueAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleEstoqueAPI.Repositories
{
    public class EntradaEstoqueRepository : IEntradaEstoqueRepository
    {
        private readonly AppDbContext _context;

        public EntradaEstoqueRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EntradaEstoque>> GetAllAsync()
        {
            return await _context.EntradasEstoque
                .Include(e => e.Produto)
                .ToListAsync();
        }

        public async Task<EntradaEstoque?> GetByIdAsync(int id)
        {
            return await _context.EntradasEstoque
                .Include(e => e.Produto)
                .FirstOrDefaultAsync(e => e.EntradaEstoqueId == id);
        }

        public async Task<EntradaEstoque?> GetByNumeroSerieAsync(string numeroSerie)
        {
            return await _context.EntradasEstoque
                .Include(e => e.Produto)
                .FirstOrDefaultAsync(e => e.NumeroSerie == numeroSerie);
        }

        public async Task AddAsync(EntradaEstoque entrada)
        {
            _context.EntradasEstoque.Add(entrada);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(EntradaEstoque entrada)
        {
            _context.EntradasEstoque.Remove(entrada);
            await _context.SaveChangesAsync();
        }
    }
}
