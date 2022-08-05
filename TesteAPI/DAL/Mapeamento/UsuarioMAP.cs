using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TesteAPI.DAL.Mapeamento
{
    public class UsuarioMAP : IEntityTypeConfiguration<MLL.Usuario>
    {
        public void Configure(EntityTypeBuilder<MLL.Usuario> builder)
        {

            builder.ToTable("TB_USUARIO");
            builder.HasKey(x => x.Codigo);

            builder.Property(x => x.Codigo).HasColumnName("USU_CODIGO");
            builder.Property(x => x.Login).HasColumnName("USU_LOGIN");
            builder.Property(x => x.Senha).HasColumnName("USU_SENHA");
            builder.Property(x => x.Data_Criacao).HasColumnName("USU_DATA_CRIACAO");
        }

    }
}
