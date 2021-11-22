using ConvertMetricUnits.Data.Models;
using Microsoft.EntityFrameworkCore;


namespace ConvertMetricUnits.Data
{
    public class ConvertMetricDbContext : DbContext
    {
        public ConvertMetricDbContext(DbContextOptions<ConvertMetricDbContext> options) : base(options)
        {

        }
        public DbSet<Formula> Formuae { get; set; }
        public DbSet<Length> Length { get; set; }
        public DbSet<Weight> Weight { get; set; }
        public DbSet<Temparature> Temparature { get; set; }
    }
}
