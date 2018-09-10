using DesafioCast.Context.Maps;
using DesafioCast.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioCast.Context
{
    public class BibliotecaContexto : DbContext
    {
        public BibliotecaContexto(DbContextOptions<BibliotecaContexto> options) : base(options)
        {
        }

        public DbSet<Livro> Livros { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Emprestimo> Emprestimos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new LivroMaps());
            modelBuilder.ApplyConfiguration(new ClientesMaps());
            modelBuilder.ApplyConfiguration(new EmprestimosMaps());

            base.OnModelCreating(modelBuilder);
        }
    }
}
