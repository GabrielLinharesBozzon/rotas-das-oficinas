using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RO.DevTest.Domain.Abstract;
using RO.DevTest.Domain.Entities;
using RO.DevTest.Persistence.Context;

namespace RO.DevTest.Persistence.Repositories
{
    public class ClienteRepository : BaseRepository<Cliente>, IRepositorioCliente
    {
        public ClienteRepository(DefaultContext context) : base(context)
        {
        }

        public async Task<Cliente> ObterPorIdAsync(Guid id)
        {
            return await _context.Set<Cliente>().FindAsync(id);
        }

        public async Task<IEnumerable<Cliente>> ObterTodosAsync()
        {
            return await _context.Set<Cliente>().ToListAsync();
        }

        public async Task<IEnumerable<Cliente>> ObterAtivosAsync()
        {
            return await _context.Set<Cliente>()
                .Where(c => c.Ativo)
                .ToListAsync();
        }

        public async Task AdicionarAsync(Cliente cliente)
        {
            await _context.Set<Cliente>().AddAsync(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Cliente cliente)
        {
            _context.Entry(cliente).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task ExcluirAsync(Guid id)
        {
            var cliente = await ObterPorIdAsync(id);
            if (cliente != null)
            {
                _context.Set<Cliente>().Remove(cliente);
                await _context.SaveChangesAsync();
            }
        }
    }
}