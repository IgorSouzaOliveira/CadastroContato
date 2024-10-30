using CadastroDeContatos.Models;
using CadastroDeContatos.Repositorios;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CadastroDeContatos.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio _contatoRepositorio;

        public ContatoController(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
        }
        public IActionResult Index()
        {
            List<ContatoModel> result = _contatoRepositorio.ListarTodos();
            return View(result);
        }
        public IActionResult Criar()
        {
            return View();
        }
        public IActionResult Editar(int id)
        {
            ContatoModel result = _contatoRepositorio.ListarPorId(id);
            return View(result);
        }
        public IActionResult ApagarConfirmacao(int id)
        {
            ContatoModel result = _contatoRepositorio.ListarPorId(id);
            return View(result);
        }
        public IActionResult Apagar(int id)
        {
            try
            {
                var result = _contatoRepositorio.Apagar(id);

                if (result.Equals(true))
                {
                    TempData["MensagemSucesso"] = "Contato apagado com sucesso.";
                }
                else
                {
                    TempData["MensagemErro"] = "Ops, não conseguimos apagar seu contato, tente novamente.";
                }

                return RedirectToAction("Index");

            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos apagar seu contato, tente novamente. Detalhes do erro: {erro.Message}.";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Adicionar(contato);
                    TempData["MensagemSucesso"] = "Contato cadastrado com sucesso.";
                    return RedirectToAction("Index");
                }

                return View(contato);

            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar seu contato, tente novamente. Detalhes do erro: {erro.Message}.";
                return RedirectToAction("Index");
            }


        }

        [HttpPost]
        public IActionResult Alterar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Atualizar(contato);
                    TempData["MensagemSucesso"] = "Contato atualizado com sucesso.";
                    return RedirectToAction("Index");
                }

                return View("Editar", contato);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos atualizar seu contato, tente novamente. Detalhes do erro: {erro.Message}.";
                return RedirectToAction("Index");
            }
        }


    }
}
