using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TesteAPI.DAL.Mapeamento
{
    public class AlunoMAP : IEntityTypeConfiguration<MLL.Aluno>
    {
        public void Configure(EntityTypeBuilder<MLL.Aluno> builder)
        {
            builder.ToTable("TB_ALUNO");

            //Primary Key
            builder.HasKey(x => x.Codigo);

            builder.Property(x => x.Codigo).HasColumnName("ALU_CODIGO");
            builder.Property(x => x.Nome).HasColumnName("ALU_NOME");
            builder.Property(x => x.Registro_Academico).HasColumnName("ALU_REGISTRO_ACADEMICO");
            builder.Property(x => x.Periodo).HasColumnName("ALU_PERIODO");
            builder.Property(x => x.CursoCodigo).HasColumnName("ALU_CURCODIGO");
            builder.Property(x => x.Status).HasColumnName("ALU_STATUS");
            builder.Property(x => x.Foto).HasColumnName("ALU_FOTO");
            //builder.Property(x => x.UsuarioCriacaoCodigo).HasColumnName("ALU_USUCODIGO_CRIACAO");
            //builder.Property(x => x.Data_Criacao).HasColumnName("ALU_DATA_CRIACAO");
            //builder.Property(x => x.UsuarioEdicaoCodigo).HasColumnName("ALU_USUCODIGO_EDICAO");
            //builder.Property(x => x.Data_Edicao).HasColumnName("ALU_DATA_EDICAO");

            //Foreign Keys

            //builder.HasOne(x => x.Usuario_Criacao)
            //    .WithMany()
            //    .HasForeignKey(x => x.UsuarioCriacaoCodigo);

            //builder.HasOne(x => x.Usuario_Edicao)
            //    .WithMany()
            //    .HasForeignKey(x => x.UsuarioEdicaoCodigo);

            builder.HasOne(x => x.Curso)
                .WithMany()
                .HasForeignKey(x => x.CursoCodigo);

        }
    }
}
