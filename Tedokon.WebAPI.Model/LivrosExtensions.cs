using System.IO;
using Microsoft.AspNetCore.Http;

namespace Tedokon.ListaLivraria.Modelos
{
    public static class LivrosExtensions
    {
        public static byte[] ConvertToBytes(this IFormFile image)
        {
            if (image == null)
            {
                return null;
            }
            using (var inputStream = image.OpenReadStream())
            using (var stream = new MemoryStream())
            {
                inputStream.CopyTo(stream);
                return stream.ToArray();
            }
        }

        public static Livro ToLivro(this LivroUpload model)
        {
            return new Livro
            {
                Id = model.Id,
                Titulo = model.Titulo,
                Descricao = model.Descricao,
                Autor = model.Autor,
                ISBN = model.ISBN,
                Preco = model.Preco,
                DataPublicacao = model.Data,
                ImagemCapa = model.Capa.ConvertToBytes(),
                Genero = model.Genero
            };
        }



        public static LivroApi ToApi(this Livro livro)
        {
            return new LivroApi
            {
                Id = livro.Id,
                Titulo = livro.Titulo,
                Descricao = livro.Descricao,
                Autor = livro.Autor,
                ISBN = livro.ISBN,
                Preco = livro.Preco,
                Data = livro.DataPublicacao,
                Capa = $"/api/livros/{livro.Id}/capa",
                Genero = livro.Genero.ParaString()
            };
        }

        public static LivroUpload ToModel(this Livro livro)
        {
            return new LivroUpload
            {
                Id = livro.Id,
                Titulo = livro.Titulo,
                Descricao = livro.Descricao,
                Autor = livro.Autor,
                ISBN = livro.ISBN,
                Preco = livro.Preco,
                Data = livro.DataPublicacao,
                Genero = livro.Genero
            };
        }
    }
}
