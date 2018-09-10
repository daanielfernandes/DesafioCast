using DesafioCast.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioCast.Context.Maps
{
    public class LivroMaps : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.ToTable("livro", "dbo");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("cd_livro");

            builder.Property(x => x.Titulo).HasColumnName("tt_livro");

            builder.Property(x => x.Ano).HasColumnName("an_livro");

            builder.Property(x => x.Status).HasColumnName("st_livro");


        }
    }
}
