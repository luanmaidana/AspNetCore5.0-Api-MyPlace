using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace MyPlace.ViewModels
{    
    public class ProdutoViewModel{

        [Key]
        public Guid id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string nome { get; set; }
        [DisplayName("Descrição")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(1000, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string descricao { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string imgUpload { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string img { get; set; }
        public DateTime dataCadastro { get; set; }
        [DisplayName("Ativo?")]
        public bool ativo { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal valor { get; set; }    
        public Guid fornecedorId { get; set; }

        public string nomeFornecedor { get; set; }

    }   
}