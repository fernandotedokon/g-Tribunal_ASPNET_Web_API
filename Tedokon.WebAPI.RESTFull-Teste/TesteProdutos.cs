using System;
using Xunit;
using Tedokon.WebAPI.WebApp.Api;
using System.Net.Http;
using System.Net;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;
using Tedokon.ListaLivraria.WebApp;

namespace Tedokon.WebAPI.RESTFull_Teste
{
    public class TesteProdutos
    {


        private readonly HttpClient _cliente;

        public TesteProdutos()
        {

            var server = new TestServer(new WebHostBuilder()
                .UseEnvironment("Development")
                .UseStartup<Startup>());

            _cliente = server.CreateClient();

        }

        //[Fact]
        [Theory]
        [InlineData("GET")]
        public async Task RetornaProdutosAllAsync (string method)
        {
            var request = new HttpRequestMessage(new HttpMethod(method), $"/api/Livros");

            var response = await _cliente.SendAsync(request);

            // assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }


        [Theory]
        [InlineData("GET", 1003)]
        public async Task RetornaProdutoAsync(string method, int? id = null)
        {
            var request = new HttpRequestMessage(new HttpMethod(method), $"/api/Livros/{id}");

            var response = await _cliente.SendAsync(request);

            // assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }


        [Theory]
        [InlineData("GET", 1003)]
        public async Task RetornaProdutoCapaAsync(string method, int? id = null)
        {
            var request = new HttpRequestMessage(new HttpMethod(method), $"/api/Livros/{id}/Capa");

            var response = await _cliente.SendAsync(request);

            // assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }


    }
}
