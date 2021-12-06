using System;
using System.ComponentModel.DataAnnotations;

namespace MyPlace.Negocios
{
    public class Produto : Entity{

        public Guid fornecedorId { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public string img { get; set; }
        public DateTime dataCadastro { get; set; }
        public bool ativo { get; set; }
        public decimal valor { get; set; }

        /*EF Relacionamento*/

        public Fornecedor fornecedor { get; set; }

    }
}