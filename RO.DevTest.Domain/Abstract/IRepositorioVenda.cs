using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RO.DevTest.Domain.Entities;

namespace RO.DevTest.Domain.Abstract
{
    public interface IRepositorioVenda
    {
        Task<Venda> ObterPorIdAsync(Guid id);
        Task<IEnumerable<Venda>> ObterTodasAsync();
        Task<IEnumerable<Venda>> ObterPorClienteAsync(Guid clienteId);
        Task<IEnumerable<Venda>> ObterPorPeriodoAsync(DateTime dataInicio, DateTime dataFim);
        Task<IEnumerable<Venda>> ObterPorStatusAsync(string status);
        Task AdicionarAsync(Venda venda);
        Task AtualizarAsync(Venda venda);
        Task ExcluirAsync(Guid id);
    }
}