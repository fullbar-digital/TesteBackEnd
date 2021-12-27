using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Mapping
{
    public class DisciplinaMap : IEntityTypeConfiguration<Disciplina>
    {
        public void Configure(EntityTypeBuilder<Disciplina> builder)
        {
            builder.ToTable("TB_DISCIPLINA");

            builder.HasKey(x => x.Codigo);

            builder.Property(x => x.Codigo)
                .HasColumnName("DIS_CODIGO");

            builder.Property(x => x.Nome)
                .HasColumnName("DIS_NOME");

            builder.Property(x => x.MinAprovacao)
                .HasColumnName("DIS_MIN_APROVADO");

            builder.Property(x => x.DataCriacao)
                .HasColumnName("DIS_DATA_CRIACAO");

        }
    }
}
