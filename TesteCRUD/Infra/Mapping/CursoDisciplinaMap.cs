using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Mapping
{
    public class CursoDisciplinaMap : IEntityTypeConfiguration<CursoDisciplina>
    {
        public void Configure(EntityTypeBuilder<CursoDisciplina> builder)
        {
            builder.ToTable("TB_CURSO_DISCIPLINA");

            builder.HasKey(x => x.Codigo);

            builder.Property(x => x.Codigo)
                .HasColumnName("CDI_CODIGO");

            builder.Property(x => x.CursoCodigo)
                .HasColumnName("CDI_CRSCODIGO");

            builder.Property(x => x.DisciplinaCodigo)
                .HasColumnName("CDI_DISCODIGO");

            builder.Property(x => x.DataCriacao)
                .HasColumnName("CDI_DATA_CRIACAO");
        }
    }
}
