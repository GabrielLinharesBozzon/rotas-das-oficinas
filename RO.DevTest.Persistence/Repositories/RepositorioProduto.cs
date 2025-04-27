using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RO.DevTest.Domain.Abstract;
using RO.DevTest.Domain.Entities;

namespace RO.DevTest.Persistence.Repositories
{
    public class RepositorioProduto : IRepositorioProduto
    {
        private readonly DefaultContext _context;

        public RepositorioProduto(DefaultContext context)
        {
            _context = context;
        }

        public async Task<Produto> ObterPorIdAsync(Guid id)
        {
            return await _context.Set<Produto>().FindAsync(id);
        }

        public async Task<IEnumerable<Produto>> ObterTodosAsync()
        {
            return await _context.Set<Produto>().ToListAsync();
        }

        public async Task<IEnumerable<Produto>> ObterAtivosAsync()
        {
            return await _context.Set<Produto>()
                .Where(p => p.Ativo)
                .ToListAsync();
        }

        public async Task<IEnumerable<Produto>> ObterPorNivelEstoqueAsync(int estoqueMinimo)
        {
            return await _context.Set<Produto>()
                .Where(p => p.QuantidadeEstoque <= estoqueMinimo)
                .ToListAsync();
        }

        public async Task AdicionarAsync(Produto produto)
        {
            await _context.Set<Produto>().AddAsync(produto);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Produto produto)
        {
            _context.Set<Produto>().Update(produto);
            await _context.SaveChangesAsync();
        }

        public async Task ExcluirAsync(Guid id)
        {
            var produto = await ObterPorIdAsync(id);
            if (produto != null)
            {
                _context.Set<Produto>().Remove(produto);
                await _context.SaveChangesAsync();
            }
        }
    }
}