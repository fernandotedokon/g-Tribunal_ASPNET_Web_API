using Tedokon.ListaLivraria.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Tedokon.ListaLivraria.Persistencia
{
    public class LivrariaContext : DbContext
    {
        public DbSet<Livro> Livros { get; set; }

        public LivrariaContext(DbContextOptions<LivrariaContext> options) 
            : base(options)
        {
            //irá criar o banco e a estrutura de tabelas necessárias
            this.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration<Livro>(new LivroConfiguration());
        }
    }
}
