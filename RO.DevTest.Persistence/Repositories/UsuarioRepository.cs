using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RO.DevTest.Domain.Abstract;
using RO.DevTest.Domain.Entities;
using RO.DevTest.Persistence.Context;

namespace RO.DevTest.Persistence.Repositories
{
    public class UsuarioRepository : IRepositorioUsuario
    {
        private readonly DefaultContext _context;

        public UsuarioRepository(DefaultContext context)
        {
            _context = context;
        }

        public async Task<Usuario> ObterPorIdAsync(Guid id)
        {
            return await _context.Set<Usuario>().FindAsync(id);
        }

        public async Task<Usuario> ObterPorNomeUsuarioAsync(string nomeUsuario)
        {
            return await _context.Set<Usuario>()
                .FirstOrDefaultAsync(u => u.UserName == nomeUsuario);
        }

        public async Task<Usuario> ObterPorEmailAsync(string email)
        {
            return await _context.Set<Usuario>()
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<IEnumerable<Usuario>> ObterTodosAsync()
        {
            return await _context.Set<Usuario>().ToListAsync();
        }

        public async Task<IEnumerable<Usuario>> ObterPorFuncaoAsync(string funcao)
        {
            return await _context.Set<Usuario>()
                .Where(u => u.Funcao == funcao)
                .ToListAsync();
        }

        public async Task AdicionarAsync(Usuario usuario)
        {
            await _context.Set<Usuario>().AddAsync(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Usuario usuario)
        {
            _context.Entry(usuario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task ExcluirAsync(Guid id)
        {
            var usuario = await ObterPorIdAsync(id);
            if (usuario != null)
            {
                _context.Set<Usuario>().Remove(usuario);
                await _context.SaveChangesAsync();
            }
        }
    }
}