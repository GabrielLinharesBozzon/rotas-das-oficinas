using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RO.DevTest.Domain.Entities;

namespace RO.DevTest.Domain.Abstract
{
    public interface IRepositorioUsuario
    {
        Task<Usuario> ObterPorIdAsync(Guid id);
        Task<Usuario> ObterPorNomeUsuarioAsync(string nomeUsuario);
        Task<Usuario> ObterPorEmailAsync(string email);
        Task<IEnumerable<Usuario>> ObterTodosAsync();
        Task<IEnumerable<Usuario>> ObterPorFuncaoAsync(string funcao);
        Task AdicionarAsync(Usuario usuario);
        Task AtualizarAsync(Usuario usuario);
        Task ExcluirAsync(Guid id);
    }
}