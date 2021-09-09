using CL.Core.Domain;
using CL.WebApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Http;

namespace CL.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private Api api;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            api = new Api();
        }

        // RETORNA A VIEW LOGIN
        public IActionResult Index()
        {
            return View("Login");
        }

        // LOGAR USUÁRIO E REDIRECIONAR PARA A LISTAGEM DE CLIENTES
        [HttpPost]
        public IActionResult Login(Usuario usuario)
        {
            if (!string.IsNullOrEmpty(usuario.Login) && !string.IsNullOrEmpty(usuario.Senha))
            {
                var usuarioLogado = api.LoginUtil(usuario);
                HttpContext.Session.SetString("token", usuarioLogado.Token);
                return RedirectToAction("Index", "Clientes");
            }
            return View();
        }

        // SAIR E REDIRECIONAR PARA A VIEW DE LOGIN
        public IActionResult Logout()
        {
            HttpContext.Session.SetString("token", "");
            return View("Login");
        }

        // RETORNA A VIEW PARA CADASTRAR NOVO USUÁRIO
        public IActionResult Insert()
        {
            string token = HttpContext.Session.GetString("token");
            if (string.IsNullOrEmpty(token))
            {
                ViewBag.Title = "Erro";
                return View("Exception", "Acesso não autorizado");
            }
            return View();
        }

        // MÉTODO RESPONSÁVEL PELO CADASTRO DE NOVO USUÁRIO
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Insert(Usuario usuario)
        {
            var token = HttpContext.Session.GetString("token");
            HttpResponseMessage response = api.InsertUser(token, usuario);
            string exception = api.ExceptionUtil(response);

            if (!string.IsNullOrEmpty(exception))
            {
                ViewBag.Title = exception;
                return View(exception);
            }
            return RedirectToAction("Login");
        }
    }
}
