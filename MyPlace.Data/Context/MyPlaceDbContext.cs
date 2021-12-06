using System.Linq;
using Microsoft.EntityFrameworkCore;
using MyPlace.Negocios;

namespace Myplace.Data
{
    public class MyPlaceDbContext : DbContext{

        public MyPlaceDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Produto> produtos { get; set; }
        public DbSet<Fornecedor> fornecedores { get; set; }
        public DbSet<Endereco> enderecos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var propriedade in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
                        propriedade.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyPlaceDbContext).Assembly);

            foreach (var relacionamento in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relacionamento.DeleteBehavior = DeleteBehavior.Cascade;

            base.OnModelCreating(modelBuilder);
        }
    }
}