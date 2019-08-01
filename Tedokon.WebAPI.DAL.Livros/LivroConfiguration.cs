using Tedokon.ListaLivraria.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Tedokon.ListaLivraria.Persistencia
{
    internal class LivroConfiguration : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder
                .Property(l => l.Titulo)
                .HasColumnType("nvarchar(100)")
                .IsRequired();

            builder
                .Property(l => l.Descricao)
                .HasColumnType("nvarchar(250)");

            builder
                .Property(l => l.Autor)
                .HasColumnType("nvarchar(100)");

            builder
                .Property(l => l.ISBN)
                .HasColumnType("bigint");

            builder
                .Property(l => l.Preco)
                .HasColumnType("decimal(5,2)");

            builder
                .Property(l => l.ImagemCapa);

            builder
                .Property(l => l.Genero)
                .HasColumnType("nvarchar(20)")
                .IsRequired()
                .HasConversion<string>(
                    tipo => tipo.ParaString(),
                    texto => texto.ParaTipo()
                );
        }
    }
}