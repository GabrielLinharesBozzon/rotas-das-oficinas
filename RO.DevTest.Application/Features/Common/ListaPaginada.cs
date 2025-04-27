using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RO.DevTest.Application.Features.Common
{
    public class ListaPaginada<T>
    {
        public List<T> Itens { get; }
        public int NumeroPagina { get; }
        public int TotalPaginas { get; }
        public int TotalItens { get; }
        public bool TemPaginaAnterior => NumeroPagina > 1;
        public bool TemProximaPagina => NumeroPagina < TotalPaginas;

        public ListaPaginada(List<T> itens, int total, int numeroPagina, int tamanhoPagina)
        {
            NumeroPagina = numeroPagina;
            TotalPaginas = (int)Math.Ceiling(total / (double)tamanhoPagina);
            TotalItens = total;
            Itens = itens;
        }

        public static async Task<ListaPaginada<T>> CreateAsync(
            IQueryable<T> source, int numeroPagina, int tamanhoPagina)
        {
            var total = await source.CountAsync();
            var itens = await source.Skip((numeroPagina - 1) * tamanhoPagina)
                                  .Take(tamanhoPagina)
                                  .ToListAsync();

            return new ListaPaginada<T>(itens, total, numeroPagina, tamanhoPagina);
        }

        public static async Task<ListaPaginada<T>> CreateAsync(
            IEnumerable<T> source, int numeroPagina, int tamanhoPagina)
        {
            var total = source.Count();
            var itens = source.Skip((numeroPagina - 1) * tamanhoPagina)
                            .Take(tamanhoPagina)
                            .ToList();

            return new ListaPaginada<T>(itens, total, numeroPagina, tamanhoPagina);
        }
    }
}