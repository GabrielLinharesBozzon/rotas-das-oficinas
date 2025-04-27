using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RO.DevTest.Domain.Entities;

namespace RO.DevTest.Domain.Abstract
{
    public interface IRepositorioCliente
    {
        Task<Cliente> ObterPorIdAsync(Guid id);
        Task<IEnumerable<Cliente>> ObterTodosAsync();
        Task<IEnumerable<Cliente>> ObterAtivosAsync();
        Task AdicionarAsync(Cliente cliente);
        Task AtualizarAsync(Cliente cliente);
        Task ExcluirAsync(Guid id);
    }
}