using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TesteAPI.DAL.Mapeamento
{
    public class AlunoNotaMAP: IEntityTypeConfiguration<MLL.AlunoNota>
    {
        public void Configure(EntityTypeBuilder<MLL.AlunoNota> builder)
        {

            builder.ToTable("TB_ALUNO_NOTA");

            //Primary Key
            builder.HasKey(x => x.Codigo);

            builder.Property(x => x.Codigo).HasColumnName("ALN_CODIGO");
            builder.Property(x => x.AlunoCodigo).HasColumnName("ALN_ALUCODIGO");
            builder.Property(x => x.DisciplinaCodigo).HasColumnName("ALN_DISCODIGO");      
            builder.Property(x => x.Nota).HasColumnName("ALN_NOTA");      
            //builder.Property(x => x.UsuarioCriacaoCodigo).HasColumnName("ALN_USUCODIGO_CRIACAO");
            //builder.Property(x => x.Data_Criacao).HasColumnName("ALN_DATA_CRIACAO");
            //builder.Property(x => x.UsuarioEdicaoCodigo).HasColumnName("ALN_USUCODIGO_EDICAO");
            //builder.Property(x => x.Data_Edicao).HasColumnName("ALN_DATA_EDICAO");




            //Foreign Keys

            //builder.HasOne(x => x.Usuario_Criacao)
            //   .WithMany()
            //   .HasForeignKey(x => x.UsuarioCriacaoCodigo);

            //builder.HasOne(x => x.Usuario_Edicao)
            //    .WithMany()
            //    .HasForeignKey(x => x.UsuarioEdicaoCodigo);
        }
    }
}
