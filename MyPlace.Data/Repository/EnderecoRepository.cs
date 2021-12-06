using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Myplace.Data;
using MyPlace.Negocios;

namespace MyPlace.Data
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(MyPlaceDbContext db) : base(db)
        {
        }

        public async Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId)
        {
            return await db.enderecos.AsNoTracking()
            .FirstOrDefaultAsync(f => f.fornecedorId == fornecedorId);
        }
    }
}