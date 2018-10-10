using System;
using System.Collections.Generic;
using System.Web.Mvc;
using SalesforceProject.Models;
using SalesforceProject.Services;

namespace SalesforceProject.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            IList<Loja> ListaLojas = new LojaService().GetLojas();
            ViewBag.ListaLojas = ListaLojas;
            return View();
        }

        [HttpGet]
        public ActionResult Sobre() 
        {
            return View();
        }

        [HttpGet]
        public ActionResult Contato(Newsletter Newsletter)
        {
            return View(Newsletter);
        }

        [HttpPost]
        public ActionResult CadastrarNewsletter(Newsletter Newsletter)
        {
            NewsletterService newsletterService = new NewsletterService();
            try
            {
                newsletterService.CadastrarNewsletter(Newsletter);
                TempData["mensagem"] = "Cadastro realizado com sucesso";
                return RedirectToAction("Contato");
            } catch (Exception e)
            {
                TempData["mensagem"] = e.Message;
                return RedirectToAction("Contato");
            }
        }
    }
}