using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyPlace.Negocios;

namespace MyPlace.Data
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p => p.id);

            builder.Property(p => p.nome)
              .IsRequired()
              .HasColumnType("varchar(200)");

            builder.Property(p => p.descricao)
              .IsRequired()
              .HasColumnType("varchar(1000)");
              
              builder.Property(p => p.img)
              .IsRequired()
              .HasColumnType("varchar(100)");

              builder.ToTable("produtos");
        }
    }
}