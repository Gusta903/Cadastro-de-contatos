using System.ComponentModel.DataAnnotations;

namespace Cadastro_de_contatos.Models
{
    public class ContatoModel
    {
        public int Id { get; set; }
        [Required (ErrorMessage =("Digite o Nome do contato!"))]
        public string Nome { get; set; }
        [Required(ErrorMessage = ("Digite o Email do contato!"))]
        [EmailAddress(ErrorMessage =("Digite um Email Valido!"))]
        public string Email { get; set; }
        [Required(ErrorMessage = ("Digite o Numero do contato!"))]
        [Phone(ErrorMessage = ("Digite um numero valido!"))]
        public string Numero { get; set; }
    }
}
