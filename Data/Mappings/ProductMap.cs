using GeradorDeApostas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeradorDeApostas.Data.Mappings
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            //A Tabela
            builder.ToTable("Product");

            //Chave primaria
            builder.HasKey(x => x.Id);

            //Identity
            builder.Property(x => x.Id)
                   .ValueGeneratedOnAdd()
                   .UseIdentityColumn();

            //Propriedades
            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasColumnName("Name")
                   .HasColumnType("NVARCHAR")
                   .HasMaxLength(64);
        }

    }
}
