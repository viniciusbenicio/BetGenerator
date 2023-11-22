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
            builder.Property(x => x.TotalNumbers)
                   .IsRequired()
                   .HasColumnName("TotalNumbers")
                   .HasColumnType("INTEGER");

            builder.Property(x => x.NumberOfGames)
                  .IsRequired()
                  .HasColumnName("NumberOfGames")
                  .HasColumnType("INTEGER");

            builder.Property(x => x.Error)
                .IsRequired()
                .HasColumnName("Error")
                .HasColumnType("bit");

        }

    }
}
