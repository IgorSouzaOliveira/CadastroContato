using CadastroDeContatos.Data;
using CadastroDeContatos.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace CadastroDeContatos.Repositorios;

public class ContatoRepositorio : IContatoRepositorio
{
    private readonly BancoContext _bancoContext;
    public ContatoRepositorio(BancoContext bancoContext)
    {
        _bancoContext = bancoContext;
    }
    public List<ContatoModel> ListarTodos()
    {
        return _bancoContext.Contatos.ToList();
    }
    public ContatoModel Adicionar(ContatoModel contato)
    {
        //Adicionar no banco de dados

        _bancoContext.Contatos.Add(contato);
        _bancoContext.SaveChanges();
        return contato;
    }
    public ContatoModel ListarPorId(int id)
    {
        return _bancoContext.Contatos.FirstOrDefault(x => x.Id == id);
    }
    public ContatoModel Atualizar(ContatoModel contato)
    {
        ContatoModel contatoDB = ListarPorId(contato.Id);

        if (contatoDB is null)
            throw new Exception("Houve um erro na atualização do contato.");

        contatoDB.Nome = contato.Nome;
        contatoDB.Email = contato.Email;
        contatoDB.Celular = contato.Celular;

        _bancoContext.Contatos.Update(contatoDB);
        _bancoContext.SaveChanges();
        return contatoDB;
    }
    public bool Apagar(int id)
    {
        ContatoModel contatoDB = ListarPorId(id);

        if (contatoDB is null)
            throw new Exception("Houve um erro na deleção do contato.");

        _bancoContext.Contatos.Remove(contatoDB);
        _bancoContext.SaveChanges();
        return true;
    }
}
