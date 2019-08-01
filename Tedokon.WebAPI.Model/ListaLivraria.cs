using System.Collections.Generic;
using System.Linq;

namespace Tedokon.ListaLivraria.Modelos
{
    public static class TipoGeneroExtensions
    {
        private static Dictionary<string, TipoGenero> mapa =
            new Dictionary<string, TipoGenero>
            {
                { "Tecnologia", TipoGenero.Tecnologia },
                { "Motivacional", TipoGenero.Motivacional },
                { "Cientifico", TipoGenero.Cientifico }
            };

        public static string ParaString(this TipoGenero tipo)
        {
            return mapa.First(s => s.Value == tipo).Key;
        }

        public static TipoGenero ParaTipo(this string texto)
        {
            return mapa.First(t => t.Key == texto).Value;
        }
    }

    public enum TipoGenero
    {
        Tecnologia,
        Motivacional,
        Cientifico
    }

    public class ListaLivraria
    {
        public string Tipo { get; set; }
        public IEnumerable<LivroApi> Livros { get; set; }
    }
}
