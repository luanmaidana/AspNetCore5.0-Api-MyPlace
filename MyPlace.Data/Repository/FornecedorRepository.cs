using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Myplace.Data;
using MyPlace.Negocios;

namespace MyPlace.Data
{
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(MyPlaceDbContext db) : base(db)
        {
        }

        public async Task<Fornecedor> ObterFornecedorEndereco(Guid id)
        {
            return await db.fornecedores.AsNoTracking()
                        .Include(c => c.endereco)
                        .FirstOrDefaultAsync(c => c.id == id);
        }

        public async Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid id)
        {
            return await db.fornecedores.AsNoTracking()
                .Include(c => c.produtos)
                .Include(c => c.endereco)
                .FirstOrDefaultAsync( c => c.id == id);
        }
    }
}