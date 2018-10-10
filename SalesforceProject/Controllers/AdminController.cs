using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SalesforceProject.Models;

namespace SalesforceProject.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        [HttpGet]
        public ActionResult Index(Usuario UsuarioLogin)
        {
            return View(UsuarioLogin);
        }

        [HttpPost]
        public ActionResult Login(Usuario UsuarioLogin)
        {
            if (ModelState.IsValid)
            {
                if (isValidUsuario(UsuarioLogin))
                {
                    // Adicionando o usuário na Sessão
                    Session["UsuarioLogado"] = UsuarioLogin;
                    return View();
                }
                else
                {
                    TempData["Mensagem"] = "Usuário ou Senha inválida.";
                    return View("Index", UsuarioLogin);
                }
            }
            else
            {
                TempData["Mensagem"] = "Usuário ou Senha inválida.";
                return View("Index", UsuarioLogin);
            }
        }

        public ActionResult Logout()
        {
            Session["UsuarioLogado"] = null;
            return RedirectToAction("Index");
        }

        public bool isValidUsuario(Usuario UsuarioLogin)
        {
            return UsuarioLogin.EmailUsuario.Equals("admin@fiap.com.br") && UsuarioLogin.SenhaUsuario.Equals("123");
        }
    }
}