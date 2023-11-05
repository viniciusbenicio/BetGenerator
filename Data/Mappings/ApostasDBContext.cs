using Microsoft.EntityFrameworkCore;

namespace GeradorDeApostas.Mappings
{
    public class ApostasDBContext : DbContext
    {
        public ApostasDBContext(DbContextOptions<ApostasDBContext> options) : base(options){ }

        //public DbSet<Category> Categories { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.ApplyConfiguration(new CategoryMap());
        }
    }
}
