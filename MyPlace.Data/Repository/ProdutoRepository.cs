using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Myplace.Data;
using MyPlace.Negocios;

namespace MyPlace.Data
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(MyPlaceDbContext db) : base(db){}

        public async Task<Produto> ObterProdutoFornecedor(Guid id)
        {
            return await db.produtos.AsNoTracking().Include(f => f.fornecedor)
                .FirstOrDefaultAsync(p => p.id == id);
        }

        public async Task<IEnumerable<Produto>> ObterProdutosFornecedores()
        {
            return await db.produtos.AsNoTracking().Include(f => f.fornecedor)
                .OrderBy(p => p.nome).ToListAsync();
        }

        public async Task<IEnumerable<Produto>> ObterProdutosPorFornecedores(Guid fornecedorId)
        {
            return await Buscar(p=>p.fornecedorId == fornecedorId);
        }
    }
}