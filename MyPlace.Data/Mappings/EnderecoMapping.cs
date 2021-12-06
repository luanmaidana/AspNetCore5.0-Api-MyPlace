using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyPlace.Negocios;

namespace MyPlace.Data
{
    public class EnderecoMapping : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(e => e.id);
            
            builder.Property(e => e.logradouro)
              .IsRequired()
              .HasColumnType("varchar(200)");

            builder.Property(e => e.numero)
              .IsRequired()
              .HasColumnType("varchar(50)");

            builder.Property(e => e.cep)
              .IsRequired()
              .HasColumnType("varchar(8)");

            builder.Property(e => e.complemento)
              .IsRequired()
              .HasColumnType("varchar(250)");

            builder.Property(e => e.bairro)
              .IsRequired()
              .HasColumnType("varchar(100)");
            
            builder.Property(e => e.cidade)
              .IsRequired()
              .HasColumnType("varchar(100)");
            
            builder.Property(e => e.estado)
              .IsRequired()
              .HasColumnType("varchar(50)");

            builder.ToTable("enderecos");
        }
    }
}