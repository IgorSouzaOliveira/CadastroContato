using System.ComponentModel.DataAnnotations;

namespace CadastroDeContatos.Models;

public class ContatoModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Digite o nome do contato.")]
    public String? Nome { get; set; }
    [Required(ErrorMessage = "Digite o email do contato.")]
    [EmailAddress(ErrorMessage = "Digite um e-mail válido!")]
    public String? Email { get; set; }

    [Required(ErrorMessage = "Digite o celular do contato.")]
    [Phone(ErrorMessage = "Digite um número de telefone válido!")]
    public String? Celular { get; set; }
}
