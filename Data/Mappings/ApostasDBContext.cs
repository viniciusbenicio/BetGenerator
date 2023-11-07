using GeradorDeApostas.Models;
using Microsoft.EntityFrameworkCore;

namespace GeradorDeApostas.Data.Mappings
{
    public class ApostasDBContext : DbContext
    {
        public ApostasDBContext(DbContextOptions<ApostasDBContext> options) : base(options) { }

        public DbSet<Product> products { get; set; }
        public DbSet<Bet> bets { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProductMap());
            builder.ApplyConfiguration(new BetMap());
        }
    }
}
