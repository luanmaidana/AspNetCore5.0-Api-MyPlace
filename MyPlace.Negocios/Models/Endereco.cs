using System;
using System.ComponentModel.DataAnnotations;

namespace MyPlace.Negocios
{
    public class Endereco : Entity{

        public Guid fornecedorId { get; set; }
        public string numero { get; set; }
        public string logradouro { get; set; }
        public string complemento { get; set; }
        public string cep { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }

        /*EF relacionamento*/
        public Fornecedor fornecedor { get; set; }
    }
}