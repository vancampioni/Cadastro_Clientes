using AutoMapper;
using CL.Core.Domain;
using CL.Core.Shared.ModelViews.Cliente;
using CL.Data.Repository;
using CL.Manager.Implementation;
using CL.Manager.Interfaces.Managers;
using CL.WebApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CL.WebApp.Controllers
{
    public class ClientesController : Controller
    {
        private Api _api;

        public ClientesController(Api api)
        {
            _api = api;
        }
        public IActionResult Index()
        {
            var token = HttpContext.Session.GetString("token");
            HttpResponseMessage response = _api.GetUtil(token, "/api/Clientes");
            string exception = _api.ExceptionUtil(response);
            if (!string.IsNullOrEmpty(exception))
            {
                ViewBag.Title = exception;
                return View();
            }

            var listaClientes = _api.Get(token);
            return View(listaClientes);
            //string stringData = response.Content.ReadAsStringAsync().Result;
            //IEnumerable<Cliente> cliente = JsonConvert.DeserializeObject
            //    <List<Cliente>>(stringData);
            //return View("listarClientes", cliente);
        }

        public IActionResult Insert()
        {
            var token = HttpContext.Session.GetString("token");
            if (string.IsNullOrEmpty(token))
            {
                return View("Usuarios/Login");
            }
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Insert(NovoCliente novoCliente)
        //{

        //}
    }
}
