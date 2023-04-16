using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SabidoMagroAcademia.Application.DTOs
{
    public class UserDTO
    {
        [DisplayName("Nome")]
        [Required(ErrorMessage = "O campo nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo nome deve ter no máximo 100 caracteres.")]
        public string Name { get; set; }

        [DisplayName("E-mail")]
        [Required(ErrorMessage = "O campo email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O email informado é inválido.")]
        public string Email { get; set; }

        [DisplayName("Telefone")]
        [Phone(ErrorMessage = "O campo telefone deve ser um número de telefone válido.")]
        public string Fone { get; set; }

        [DisplayName("Gênero")]
        [Required(ErrorMessage = "O campo gênero é obrigatório.")]
        public string Gender { get; set; }

        [DisplayName("Data de nascimento")]
        [Required(ErrorMessage = "O campo data de nascimento é obrigatório.")]
        [DataType(DataType.Date)]
        public DateTime Born { get; set; }

        [DisplayName("Imagem")]
        [Url(ErrorMessage = "O campo imagem deve ser uma URL válida.")]
        public string Image { get; set; }
    }
}
