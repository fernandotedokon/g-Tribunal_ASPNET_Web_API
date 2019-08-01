using Tedokon.ListaLivraria.Persistencia;
using Tedokon.ListaLivraria.Modelos;
using Tedokon.ListaLivraria.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Tedokon.ListaGenero.WebApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IRepository<Livro> _repo;

        public HomeController(IRepository<Livro> repository)
        {
            _repo = repository;
        }

        private IEnumerable<LivroApi> ListaDoTipo(TipoGenero tipo)
        {
            return _repo.All
                .Where(l => l.Genero == tipo)
                .Select(l => l.ToApi())
                .ToList();
        }

        public IActionResult Index()
        {
            var model = new HomeViewModel
            {
                Tecnologia = ListaDoTipo(TipoGenero.Tecnologia),
                Motivacional = ListaDoTipo(TipoGenero.Motivacional),
                Cientifico = ListaDoTipo(TipoGenero.Cientifico)
            };
            return View(model);
        }
    }
}