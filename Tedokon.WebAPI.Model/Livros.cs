using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using System;

namespace Tedokon.ListaLivraria.Modelos
{

    public class Livro
    {
        public int Id { get; set; }

        [MinLength(5, ErrorMessage = "Nome deve ter no mínimo 5 caracteres")]
        [MaxLength(100, ErrorMessage = "Nome deve ter no máximo 100 caracteres")]
        [Required(ErrorMessage = "Titulo é obrigatório")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Descrição é obrigatório")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Autor é obrigatório")]
        public string Autor { get; set; }

        [MaxLength(13, ErrorMessage = "ISBN deve ter no máximo 13 digitos")]
        [Required(ErrorMessage = "ISBN é obrigatório")]
        public long ISBN { get; set; }

        public decimal Preco { get; set; }

        [Display(Name = "Data de Publicação")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime  DataPublicacao { get; set; }

        public byte[] ImagemCapa { get; set; }

        public TipoGenero Genero { get; set; }
    }

    [XmlType("Livro")]
    public class LivroApi
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Autor { get; set; }
        public long ISBN { get; set; }
        public decimal Preco { get; set; }
        public DateTime Data { get; set; }
        public string Capa { get; set; }
        public string Genero { get; set; }

    }

    public class LivroUpload
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Autor { get; set; }
        public long ISBN { get; set; }
        public decimal Preco { get; set; }
        public DateTime Data { get; set; }
        public IFormFile Capa { get; set; }
        public TipoGenero Genero { get; set; }
    }
}
