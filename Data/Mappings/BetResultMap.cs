using GeradorDeApostas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeradorDeApostas.Data.Mappings
{
    public class BetResultMap : IEntityTypeConfiguration<BetResult>
    {
        public void Configure(EntityTypeBuilder<BetResult> builder)
        {
            //A Tabela
            builder.ToTable("BetResult");

            //Chave primaria
            builder.HasKey(x => x.Id);

            //Identity
            builder.Property(x => x.Id)
                   .ValueGeneratedOnAdd()
                   .UseIdentityColumn();

            //Propriedades
            builder.Property(x => x.Result)
                   .IsRequired()
                   .HasColumnName("Result")
                   .HasColumnType("VARCHAR")
                   .HasMaxLength(100);

            builder.HasOne(x => x.Bet)
                   .WithMany(x => x.BetResults)
                   .HasConstraintName("FK_Bet_Results")
                   .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
