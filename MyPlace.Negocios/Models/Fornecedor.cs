using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MyPlace.Negocios
{
    [JsonObject(IsReference = true)] 
    public class Fornecedor : Entity{
        public string nome { get; set; }
        public string documento { get; set; }
        public TipoFornecedor tipoFornecedor { get; set; }
        public Endereco endereco { get; set; }
        public bool ativo { get; set; }

        /*EF Relacionamento*/

        public IEnumerable<Produto> produtos { get; set; }
    }
}