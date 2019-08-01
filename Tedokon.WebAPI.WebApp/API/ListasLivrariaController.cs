using Tedokon.ListaLivraria.Modelos;
using Tedokon.ListaLivraria.Persistencia;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Lista = Tedokon.ListaLivraria.Modelos;

namespace Alura.WebAPI.WebApp.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class ListasLivrariaController: ControllerBase
    {
        private readonly IRepository<Livro> _repo;

        public ListasLivrariaController(IRepository<Livro> repository)
        {
            _repo = repository;
        }

        private ListaLivraria CriaLista(TipoGenero tipo)
        {
            return new ListaLivraria
            {
                Tipo = tipo.ParaString(),
                Livros = _repo.All
                    .Where(l => l.Genero == tipo)
                    .Select(l => l.ToApi())
                    .ToList()
            };
        }

        [HttpGet]
        public IActionResult TodasListas()
        {
            ListaLivraria tecnologia = CriaLista(TipoGenero.Tecnologia);
            ListaLivraria motivacional = CriaLista(TipoGenero.Motivacional);
            ListaLivraria cientifico = CriaLista(TipoGenero.Cientifico);
            var colecao = new List<ListaLivraria> { tecnologia, motivacional, cientifico };
            return Ok(colecao);
        }

        [HttpGet("{tipo}")]
        public IActionResult Recuperar(TipoGenero tipo)
        {
            var lista = CriaLista(tipo);
            return Ok(lista);
        }
    }
}
