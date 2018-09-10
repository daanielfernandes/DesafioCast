using DesafioCast.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioCast.Context.Maps
{
    public class EmprestimosMaps : IEntityTypeConfiguration<Emprestimo>
    {
        public void Configure(EntityTypeBuilder<Emprestimo> builder)
        {
            builder.ToTable("emprestimo", "dbo");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("cd_emprestimo");

            builder.Property(x => x.DataEmprestimo).HasColumnName("dt_emprestimo");

            builder.Property(x => x.DataDevolucao).HasColumnName("dt_devolucao");

            builder.Property(x => x.IdLivro).HasColumnName("cd_livro");

            builder.Property(x => x.IdCliente).HasColumnName("cd_cliente");

            builder.HasOne(x => x.Livro).WithMany().HasForeignKey(x => x.IdLivro).IsRequired();

            builder.HasOne(x => x.Cliente).WithMany().HasForeignKey(x => x.IdCliente).IsRequired();

        }
    }
}
