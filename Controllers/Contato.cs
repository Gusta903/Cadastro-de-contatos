using Cadastro_de_contatos.Models;
using Cadastro_de_contatos.Repositório;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Cadastro_de_contatos.Controllers
{
    public class Contato : Controller
    {
        private readonly IContatorepositorio _contatorepositorio;
        public Contato(IContatorepositorio contatorepositorio)
        {
            _contatorepositorio = contatorepositorio;
        }
        public IActionResult Index()
        {
            List<ContatoModel> contatos = _contatorepositorio.Todos();
            return View(contatos);
        }
        public IActionResult criar()
        {

            return View();
        }public IActionResult editar(int Id)
        {
            ContatoModel contato = _contatorepositorio.ListaPorId(Id);
            return View(contato);
        }public IActionResult ApagarConfirmacao(int Id)
        {
            ContatoModel contato = _contatorepositorio.ListaPorId(Id);
            return View(contato);
        }

        public IActionResult Remover(int Id)
        {
            try
            {
				bool apagado = _contatorepositorio.Remover(Id);
                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Contato apagado com sucesso!";
                }
                else
                {
                    TempData["MensagemErro"] = "Ocorreu um erro ao apagar o contato";
                }
				return RedirectToAction("Index");
			}
            catch (Exception)
            {
				TempData["MensagemErro"] = "Ocorreu um erro ao apagar o contato";
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
					_contatorepositorio.Adicionar(contato);
					TempData["MensagemSucesso"] = "Contato cadastrado com sucesso!";
					return RedirectToAction("Index");
				}
				return View(contato);
			}
            catch (System.Exception)
            {
                TempData["MensagemErro"]="Um erro ocorreu a cadastrar o contato :(";
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
					_contatorepositorio.Atualizar(contato);
					TempData["MensagemSucesso"] = "Contato alterado com sucesso!";
					return RedirectToAction("Index");
				}
				return View("editar", contato);
			}
            catch (System.Exception)
            {
                TempData["MensagemErro"] = "Ocorreu um erro na alteração do contato";
                return RedirectToAction("Index");
            }
        }
        
        
    }
}
