using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Mapping
{
    public class CursoMap : IEntityTypeConfiguration<Curso>
    {
        public void Configure(EntityTypeBuilder<Curso> builder)
        {
            builder.ToTable("TB_CURSO");

            builder.HasKey(x => x.Codigo);

            builder.Property(x => x.Codigo)
                .HasColumnName("CRS_CODIGO");

            builder.Property(x => x.Nome)
                .HasColumnName("CRS_NOME");

            builder.Property(x => x.DataCriacao)
                .HasColumnName("CRS_DATA_CRIACAO");

        }
    }
}
