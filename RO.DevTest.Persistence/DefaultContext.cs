using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RO.DevTest.Domain.Entities;
using RO.DevTest.Persistence.Configurations;

namespace RO.DevTest.Persistence;

public class DefaultContext : IdentityDbContext<Usuario>
{

    public DefaultContext() { }

    public DefaultContext(DbContextOptions<DefaultContext> options) : base(options) { }

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Venda> Vendas { get; set; }
    public DbSet<ItemVenda> ItensVenda { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.HasPostgresExtension("uuid-ossp");
        builder.ApplyConfigurationsFromAssembly(typeof(DefaultContext).Assembly);

        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new ClienteConfiguration());
        builder.ApplyConfiguration(new ProdutoConfiguration());
        builder.ApplyConfiguration(new VendaConfiguration());
        builder.ApplyConfiguration(new ItemVendaConfiguration());
    }
}