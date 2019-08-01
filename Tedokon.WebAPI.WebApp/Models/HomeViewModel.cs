using Tedokon.ListaLivraria.Modelos;
using System.Collections.Generic;

namespace Tedokon.ListaLivraria.WebApp.Models
{
    public class HomeViewModel
    {
        public IEnumerable<LivroApi> Tecnologia { get; set; }
        public IEnumerable<LivroApi> Motivacional { get; set; }
        public IEnumerable<LivroApi> Cientifico { get; set; }
    }
}
