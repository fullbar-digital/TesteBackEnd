using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TesteAPI.DAL.Mapeamento
{
    public class DisciplinaMAP : IEntityTypeConfiguration<MLL.Disciplina>
    {
        public void Configure(EntityTypeBuilder<MLL.Disciplina> builder)
        {
            builder.ToTable("TB_DISCIPLINA");

            //Primary Key
            builder.HasKey(x => x.Codigo);

            builder.Property(x => x.Codigo).HasColumnName("DIS_CODIGO");
            builder.Property(x => x.Nome).HasColumnName("DIS_NOME");
            builder.Property(x => x.Nota_Aprovacao).HasColumnName("DIS_NOTA_APROVACAO");
            builder.Property(x => x.CursoCodigo).HasColumnName("DIS_CURCODIGO");
            //builder.Property(x => x.UsuarioCriacaoCodigo).HasColumnName("DIS_USUCODIGO_CRIACAO");
            //builder.Property(x => x.Data_Criacao).HasColumnName("DIS_DATA_CRIACAO");
            //builder.Property(x => x.UsuarioEdicaoCodigo).HasColumnName("DIS_USUCODIGO_EDICAO");
            //builder.Property(x => x.Data_Edicao).HasColumnName("DIS_DATA_EDICAO");

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
