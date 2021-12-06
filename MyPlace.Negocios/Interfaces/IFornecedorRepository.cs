using System;
using System.Threading.Tasks;

namespace MyPlace.Negocios
{
    public interface IFornecedorRepository : IRepository<Fornecedor>{

        Task<Fornecedor> ObterFornecedorEndereco(Guid id);
        Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid id);

    }
}