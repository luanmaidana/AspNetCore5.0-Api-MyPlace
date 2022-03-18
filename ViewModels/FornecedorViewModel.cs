using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using MyPlace.Negocios;
using Newtonsoft.Json;

namespace MyPlace.ViewModels
{
    [JsonObject(IsReference = true)] 
    public class FornecedorViewModel
    {
        [Key]
        public Guid id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string nome { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(14, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 11)]
        public string documento { get; set; }
        [DisplayName("Tipo")]
        public int tipoFornecedor { get; set; }
        public EnderecoViewModel endereco { get; set; }
         [DisplayName("Ativo?")]
        public bool ativo { get; set; }
        public IEnumerable<Produto> produtos { get; set; }

    }
}