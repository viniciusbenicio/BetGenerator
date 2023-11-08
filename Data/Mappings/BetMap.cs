using GeradorDeApostas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeradorDeApostas.Data.Mappings
{
    public class BetMap : IEntityTypeConfiguration<Bet>
    {
        public void Configure(EntityTypeBuilder<Bet> builder)
        {
            //A Tabela
            builder.ToTable("Bet");

            //Chave primaria
            builder.HasKey(x => x.Id);

            //Identity
            builder.Property(x => x.Id)
                   .ValueGeneratedOnAdd()
                   .UseIdentityColumn();

            //Propriedades
            builder.Property(x => x.qtGames)
                   .IsRequired()
                   .HasColumnName("qtGames")
                   .HasColumnType("INTEGER");

            builder.Property(x => x.numberGames)
                  .IsRequired()
                  .HasColumnName("numberGames")
                  .HasColumnType("INTEGER");

            builder.Property(x => x.resultGames)
             .IsRequired()
             .HasColumnName("resultGames")
             .HasColumnType("NVARCHAR")
             .HasMaxLength(100);

            builder.Property(x => x.error)
                .IsRequired()
                .HasColumnName("error")
                .HasColumnType("bit");

        }

    }
}
