using CL.Core.Domain;
using CL.Core.Shared.ModelViews.Cliente;
using CL.Core.Shared.ModelViews.Usuario;
using CL.Manager.Implementation;
using CL.Manager.Interfaces.Managers;
using CL.WebApi.Controllers;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CL.WebApp.Services
{
    public class Api
    {
        private readonly string baseUrl = "https://localhost:44319/";
        private readonly string routeUsuarios = "/api/Usuarios";
        private readonly string routeClientes = "/api/Clientes";
        private readonly ClientesController clientesController;

        public HttpClient HttpUtil()
        {
            HttpClient client = new HttpClient()
            {
                BaseAddress = new Uri(baseUrl)
            };
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            return client;
        }

        public HttpResponseMessage GetUtil(string token, string route)
        {
            HttpClient client = HttpUtil();
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            HttpResponseMessage response = client.GetAsync(route).Result;
            return response;
        }

        // MÉTODOS USUÁRIO
        public UsuarioLogado LoginUtil(Usuario usuario)
        {
            HttpClient client = HttpUtil();
            string stringData = JsonConvert.SerializeObject(usuario);
            var contentData = new StringContent
                (stringData, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync
                ("/api/Usuarios/Login", contentData).Result;
            string stringUser = response.Content.ReadAsStringAsync().Result;
            UsuarioLogado usuarioLogado = JsonConvert.DeserializeObject<UsuarioLogado>(stringUser);
            return usuarioLogado;
        }


        public HttpResponseMessage InsertUser(string token, Usuario usuario)
        {
            HttpClient client = HttpUtil();
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            
            string stringData = JsonConvert.SerializeObject(usuario);
            var contentData = new StringContent
                (stringData, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage responseUser = client.PostAsync(routeUsuarios, contentData).Result;
            return responseUser;
        }

        // MÉTODOS CLIENTE
        public Task Get(string token)
        {
            HttpClient client = HttpUtil();
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            var listaClientes = clientesController.Get();
            return listaClientes;
        }
        public HttpResponseMessage InsertClient(string token, NovoCliente novoCliente)
        {
            HttpClient client = HttpUtil();
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);


            string stringData = JsonConvert.SerializeObject(novoCliente);
            var contentData = new StringContent
                (stringData, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage responseClient = client.PostAsync(routeClientes, contentData).Result;
            return responseClient;

        }

        //public HttpRequestMessage UpdateClient(string token, AlteraCliente alteraCliente)
        //{
        //    HttpClient client = HttpUtil();
        //    client.DefaultRequestHeaders.Authorization =
        //        new AuthenticationHeaderValue("Bearer", token);

        //    string stringData = JsonConvert.SerializeObject(alteraCliente);
        //    var contentData = new StringContent
        //        (stringData, System.Text.Encoding.UTF8, "application/json")
        //}


        public string ExceptionUtil(HttpResponseMessage response)
        {
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                return "Acesso não autorizado";
            }

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                return "Erro desconhecido no servidor";
            }
            return "";
        }
    }
}
