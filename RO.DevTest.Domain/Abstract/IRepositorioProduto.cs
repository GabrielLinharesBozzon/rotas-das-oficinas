using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RO.DevTest.Domain.Entities;

namespace RO.DevTest.Domain.Abstract
{
    public interface IRepositorioProduto
    {
        Task<Produto> ObterPorIdAsync(Guid id);
        Task<IEnumerable<Produto>> ObterTodosAsync();
        Task<IEnumerable<Produto>> ObterAtivosAsync();
        Task<IEnumerable<Produto>> ObterPorNivelEstoqueAsync(int estoqueMinimo);
        Task AdicionarAsync(Produto produto);
        Task AtualizarAsync(Produto produto);
        Task ExcluirAsync(Guid id);
    }
}