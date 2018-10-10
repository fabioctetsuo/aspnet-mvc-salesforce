using SalesforceProject.Models;
using SalesforceProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SalesforceProject.Filters;
using SalesforceProject.ViewModels;

namespace SalesforceProject.Controllers
{
    [AcessoFilter]
    public class ContatoController : Controller
    {
        // GET: Contato
        [HttpGet]
        public ActionResult Index()
        {
            ContatoViewModel _contatoViewModel = new ContatoViewModel()
            {
                Newsletters = new NewsletterService().GetNewsletters(),
                Newsletter = new Newsletter()
            };
            return View(_contatoViewModel);
        }

        [HttpPost]
        public ActionResult BuscaContato(ContatoViewModel _contatoViewModel)
        {
            Newsletter SearchParams = _contatoViewModel.Newsletter;
            if (String.IsNullOrWhiteSpace(SearchParams.Nome) && String.IsNullOrWhiteSpace(SearchParams.Email))
            {
                return RedirectToAction("Index");
            }
            else
            {
                NewsletterService _newsletterService = new NewsletterService();
                try
                {
                    IList<Newsletter> ListaContatos = _newsletterService.FilterContato(_contatoViewModel.Newsletter);
                    _contatoViewModel.Newsletters = ListaContatos;
                    return View(_contatoViewModel);
                }
                catch (Exception e)
                {
                    return RedirectToAction("Index");
                }
            }
        }

        [HttpGet]
        public ActionResult Excluir(string id)
        {
            NewsletterService _newsletterService = new NewsletterService();
            try
            {
                _newsletterService.ExcluirContato(id);
                TempData["mensagem"] = "Excluido com sucesso";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["mensagem"] = e.Message;
                return RedirectToAction("Index");
            }
        }
    }
}