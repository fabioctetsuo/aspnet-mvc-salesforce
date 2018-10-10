using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SalesforceProject.Models;
using SalesforceProject.ViewModels;
using SalesforceProject.Services;
using SalesforceProject.Filters;

namespace SalesforceProject.Controllers
{
    [AcessoFilter]
    public class LojaController : Controller
    {
        // GET: Loja
        [HttpGet]
        public ActionResult Index()
        {
            LojaViewModel viewModel = new LojaViewModel
            {
                Lojas = new LojaService().GetLojas(),
                Loja = new Loja()
            };
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Editar(string id)
        {
            LojaViewModel _lojaViewModel = new LojaViewModel()
            {
                Loja = new LojaService().GetLojaById(id)
            };
            return View(_lojaViewModel);
        }

        [HttpPost]
        public ActionResult Editar(LojaViewModel _lojaViewModel)
        {
            if (ModelState.IsValid)
            {
                LojaService lojaService = new LojaService();
                try
                {
                    lojaService.EditarLoja(_lojaViewModel.Loja);
                    TempData["mensagem"] = "Editado com sucesso";
                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    TempData["mensagem"] = e.Message;
                    return View(_lojaViewModel);
                }
            }
            return View(_lojaViewModel);
        }

        [HttpGet]
        public ActionResult Consultar(string id)
        {
            Loja Loja = new LojaService().GetLojaById(id);
            return View(Loja);
        }

        [HttpGet]
        public ActionResult Excluir(string id)
        {
            LojaService lojaService = new LojaService();
            try
            {
                lojaService.ExcluirLoja(id);
                TempData["mensagem"] = "Excluido com sucesso";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["mensagem"] = e.Message;
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult Inserir()
        {
            ModelState.Clear();
            LojaViewModel _viewModel = new LojaViewModel
            {
                Loja = new Loja()
            };
            return View(_viewModel);
        }

        [HttpPost]
        public ActionResult Inserir (LojaViewModel _lojaViewModel)
        {
            if (ModelState.IsValid)
            {
                LojaService lojaService = new LojaService();
                try
                {
                    lojaService.InserirLoja(_lojaViewModel.Loja);
                    TempData["mensagem"] = "Inserido com sucesso";
                    return RedirectToAction("Index");
                } catch (Exception e)
                {
                    TempData["mensagem"] = e.Message;
                    return View(_lojaViewModel);
                }
            } else
            {
                return View(_lojaViewModel);
            }
        }

        [HttpPost]
        public ActionResult BuscarLoja (LojaViewModel _lojaViewModel)
        {
            Loja SearchParams = _lojaViewModel.Loja;
            if (String.IsNullOrWhiteSpace(SearchParams.Endereco) && String.IsNullOrWhiteSpace(SearchParams.Cidade) && String.IsNullOrWhiteSpace(SearchParams.Estado))
            {
                return RedirectToAction("Index");
            }
            else
            {
                LojaService lojaService = new LojaService();
                try
                {
                    IList<Loja> ListaLojas = lojaService.FilterLojas(_lojaViewModel.Loja);
                    _lojaViewModel.Lojas = ListaLojas;
                    return View(_lojaViewModel);
                } catch (Exception e)
                {
                    return RedirectToAction("Index");
                }
            }
        }
    }
}