using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Mapping
{
    public class AlunoDisciplinaMap : IEntityTypeConfiguration<AlunoDisciplina>
    {
        public void Configure(EntityTypeBuilder<AlunoDisciplina> builder)
        {
            builder.ToTable("TB_ALUNO_DISCIPLINA");

            builder.HasKey(x => x.Codigo);

            builder.Property(x => x.Codigo)
                .HasColumnName("ADI_CODIGO");

            builder.Property(x => x.AlunoCodigo)
                .HasColumnName("ADI_ALUCODIGO");

            builder.Property(x => x.DisciplinaCodigo)
                .HasColumnName("ADI_DISCODIGO");

            builder.Property(x => x.Nota)
                .HasColumnName("ADI_NOTA");

            builder.Property(x => x.Status)
                .HasColumnName("ADI_STATUS");


            builder.Property(x => x.DataCriacao)
                .HasColumnName("ADI_DATA_CRIACAO");
        }
    }
}
