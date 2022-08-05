using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TesteAPI.DAL.Mapeamento
{
    public class CursoMAP : IEntityTypeConfiguration<MLL.Curso>
    {
        public void Configure(EntityTypeBuilder<MLL.Curso> builder)
        {
            builder.ToTable("TB_CURSO");

            //Primary Key
            builder.HasKey(x => x.Codigo);

            builder.Property(x => x.Codigo).HasColumnName("CUR_CODIGO");
            builder.Property(x => x.Nome).HasColumnName("CUR_NOME");           
            //builder.Property(x => x.UsuarioCriacaoCodigo).HasColumnName("CUR_USUCODIGO_CRIACAO");
            //builder.Property(x => x.Data_Criacao).HasColumnName("CUR_DATA_CRIACAO");
            //builder.Property(x => x.UsuarioEdicaoCodigo).HasColumnName("CUR_USUCODIGO_EDICAO");
            //builder.Property(x => x.Data_Edicao).HasColumnName("CUR_DATA_EDICAO");


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
