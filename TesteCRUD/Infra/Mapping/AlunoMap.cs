using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Mapping
{
    public class AlunoMap : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.ToTable("TB_ALUNO");

            builder.HasKey(x => x.Codigo);

            builder.Property(x => x.Codigo)
                .HasColumnName("ALU_CODIGO");

            builder.Property(x => x.Nome)
                .HasColumnName("ALU_NOME");

            builder.Property(x => x.RA)
                .HasColumnName("ALU_RA");

            builder.Property(x => x.Periodo)
                .HasColumnName("ALU_PERIODO");

            builder.Property(x => x.Foto)
                .HasColumnName("ALU_FOTO");

            builder.Property(x => x.CursoCodigo)
                .HasColumnName("ALU_CRSCODIGO");

            builder.Property(x => x.DataCriacao)
                .HasColumnName("ALU_DATA_CRIACAO");

        }
    }
}
