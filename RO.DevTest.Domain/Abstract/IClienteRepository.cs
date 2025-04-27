using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using RO.DevTest.Domain.Entities;

namespace RO.DevTest.Domain.Abstract
{
    public interface IClienteRepository
    {
        Task<Cliente> GetByIdAsync(int id);
        Task<IEnumerable<Cliente>> GetAllAsync();
        Task<IEnumerable<Cliente>> GetAsync(Expression<Func<Cliente, bool>> predicate);
        Task<Cliente> AddAsync(Cliente entity);
        Task UpdateAsync(Cliente entity);
        Task DeleteAsync(Cliente entity);
    }
}