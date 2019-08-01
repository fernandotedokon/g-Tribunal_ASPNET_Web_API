using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tedokon.ListaLivraria.Modelos;

namespace Tedokon.WebAPI.WebApp.Formatters
{
    public class LivroCsvFormatter : TextOutputFormatter
    {

        public LivroCsvFormatter()
        {
            var textCsvMediaType = MediaTypeHeaderValue.Parse("text/csv");
            var appCsvMediaType = MediaTypeHeaderValue.Parse("application/csv");
            SupportedMediaTypes.Add(textCsvMediaType);
            SupportedMediaTypes.Add(appCsvMediaType);
            SupportedEncodings.Add(Encoding.UTF8);
        }

        protected override bool CanWriteType(Type type)
        {
            return type == typeof(LivroApi);
        }

        public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            var livroEmCsv = "";

            if (context.Object is LivroApi)
            {
                var livro = context.Object as LivroApi;
                livroEmCsv = $"{livro.Titulo};{livro.Descricao};{livro.Autor};{livro.ISBN};{livro.Preco};{livro.Genero}";
            }

            using (var escritor = context.WriterFactory(context.HttpContext.Response.Body, selectedEncoding))
            {
                return escritor.WriteAsync(livroEmCsv);
            }

        }
    }
}
