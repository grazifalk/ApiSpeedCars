using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class ContextDb : DbContext
    {
        public ContextDb() { }

        public ContextDb(DbContextOptions<ContextDb> options) : base(options)
        {
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Model> Models { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //builder.ApplyConfigurationsFromAssembly(typeof(ContextDb).Assembly);
        }
    }
}
