using CadastroDeContatos.Models;

namespace CadastroDeContatos.Repositorios;

public interface IContatoRepositorio
{
    
    ContatoModel Adicionar(ContatoModel contato);
    ContatoModel ListarPorId(int id);
    List<ContatoModel> ListarTodos();
    ContatoModel Atualizar(ContatoModel contato);
    Boolean Apagar(int id);

}
