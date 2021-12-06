using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyPlace.Negocios
{
    public interface IEnderecoRepository : IRepository<Endereco>{

        Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId);

    }
}