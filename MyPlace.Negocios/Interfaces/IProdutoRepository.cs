using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyPlace.Negocios
{
    public interface IProdutoRepository : IRepository<Produto>{

        Task<IEnumerable<Produto>> ObterProdutosPorFornecedores(Guid fornecedorId);
        Task<IEnumerable<Produto>> ObterProdutosFornecedores();
        Task<Produto> ObterProdutoFornecedor(Guid id);

    }
}