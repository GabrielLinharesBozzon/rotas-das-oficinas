using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RO.DevTest.Domain.Entities;

namespace RO.DevTest.Persistence.Configurations
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produtos");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Descricao)
                .HasMaxLength(500);

            builder.Property(p => p.Preco)
                .IsRequired()
                .HasPrecision(10, 2);

            builder.Property(p => p.QuantidadeEstoque)
                .IsRequired();

            builder.Property(p => p.Codigo)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasIndex(p => p.Codigo)
                .IsUnique();
        }
    }
}