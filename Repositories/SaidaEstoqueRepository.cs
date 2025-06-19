using ControleEstoqueAPI.Data;
using ControleEstoqueAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleEstoqueAPI.Repositories
{
    public class SaidaEstoqueRepository : ISaidaEstoqueRepository
    {
        private readonly AppDbContext _context;

        public SaidaEstoqueRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SaidaEstoque>> GetAllAsync()
        {
            return await _context.SaidasEstoque
                .Include(s => s.Produto)
                .ToListAsync();
        }

        public async Task<SaidaEstoque?> GetByIdAsync(int id)
        {
            return await _context.SaidasEstoque
                .Include(s => s.Produto)
                .FirstOrDefaultAsync(s => s.SaidaEstoqueId == id);
        }

        public async Task AddAsync(SaidaEstoque saida)
        {
            _context.SaidasEstoque.Add(saida);
            await _context.SaveChangesAsync();
        }
    }
}
