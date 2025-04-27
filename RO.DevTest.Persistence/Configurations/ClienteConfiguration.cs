using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RO.DevTest.Domain.Entities;

namespace RO.DevTest.Persistence.Configurations
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Telefone)
                .HasMaxLength(20);

            builder.Property(c => c.Endereco)
                .HasMaxLength(200);

            builder.Property(c => c.CPF)
                .IsRequired()
                .HasMaxLength(11);

            builder.HasIndex(c => c.CPF)
                .IsUnique();

            builder.HasIndex(c => c.Email)
                .IsUnique();
        }
    }
}