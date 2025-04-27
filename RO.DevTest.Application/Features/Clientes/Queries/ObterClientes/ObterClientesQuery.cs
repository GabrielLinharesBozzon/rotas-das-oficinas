using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RO.DevTest.Application.Contracts.DTOs;
using RO.DevTest.Application.Features.Common;
using RO.DevTest.Domain.Abstract;

namespace RO.DevTest.Application.Features.Clientes.Queries.ObterClientes
{
    public class ObterClientesQuery : BaseQuery<ListaPaginada<ClienteDto>>
    {
        public int NumeroPagina { get; set; } = 1;
        public int TamanhoPagina { get; set; } = 10;
        public string TermoBusca { get; set; }
        public string OrdenarPor { get; set; }
        public bool OrdemDecrescente { get; set; }
    }

    public class ObterClientesQueryHandler : IRequestHandler<ObterClientesQuery, ListaPaginada<ClienteDto>>
    {
        private readonly IRepositorioCliente _repositorioCliente;

        public ObterClientesQueryHandler(IRepositorioCliente repositorioCliente)
        {
            _repositorioCliente = repositorioCliente;
        }

        public async Task<ListaPaginada<ClienteDto>> Handle(ObterClientesQuery request, CancellationToken cancellationToken)
        {
            var clientes = await _repositorioCliente.ObterTodosAsync();

            // Aplicar filtro de busca
            if (!string.IsNullOrWhiteSpace(request.TermoBusca))
            {
                clientes = clientes.Where(c =>
                    c.Nome.Contains(request.TermoBusca, StringComparison.OrdinalIgnoreCase) ||
                    c.Email.Contains(request.TermoBusca, StringComparison.OrdinalIgnoreCase) ||
                    c.Telefone.Contains(request.TermoBusca, StringComparison.OrdinalIgnoreCase) ||
                    c.Endereco.Contains(request.TermoBusca, StringComparison.OrdinalIgnoreCase));
            }

            // Aplicar ordenação
            if (!string.IsNullOrWhiteSpace(request.OrdenarPor))
            {
                clientes = request.OrdenarPor.ToLower() switch
                {
                    "nome" => request.OrdemDecrescente
                        ? clientes.OrderByDescending(c => c.Nome)
                        : clientes.OrderBy(c => c.Nome),
                    "email" => request.OrdemDecrescente
                        ? clientes.OrderByDescending(c => c.Email)
                        : clientes.OrderBy(c => c.Email),
                    "telefone" => request.OrdemDecrescente
                        ? clientes.OrderByDescending(c => c.Telefone)
                        : clientes.OrderBy(c => c.Telefone),
                    "endereco" => request.OrdemDecrescente
                        ? clientes.OrderByDescending(c => c.Endereco)
                        : clientes.OrderBy(c => c.Endereco),
                    _ => clientes
                };
            }

            // Converter para DTOs
            var clienteDtos = clientes.Select(c => new ClienteDto
            {
                Id = c.Id,
                Nome = c.Nome,
                Email = c.Email,
                Telefone = c.Telefone,
                Endereco = c.Endereco,
                Ativo = c.Ativo
            });

            // Aplicar paginação
            return await ListaPaginada<ClienteDto>.CreateAsync(
                clienteDtos,
                request.NumeroPagina,
                request.TamanhoPagina);
        }
    }
}