using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyPlace.Negocios;

namespace MyPlace.Data
{
     public class FornecedorMapping : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.HasKey(f => f.id);
            
            builder.Property(f => f.nome)
              .IsRequired()
              .HasColumnType("varchar(200)");

            builder.Property(f => f.documento)
              .IsRequired()
              .HasColumnType("varchar(14)");

            // 1:1 => fornecedor : endereco
            builder.HasOne(f => f.endereco)
              .WithOne(e => e.fornecedor)
              .OnDelete(DeleteBehavior.Cascade);

            // 1 : N => fornecedor : produtos
            builder.HasMany(f => f.produtos)
              .WithOne(p => p.fornecedor)
              .HasForeignKey(p => p.fornecedorId)
              .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("fornecedores");
        }
    }
}