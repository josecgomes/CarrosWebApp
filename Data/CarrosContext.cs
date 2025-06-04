using Microsoft.EntityFrameworkCore;
using CarrosWebApp.Models;

namespace CarrosWebApp.Data
{
    public class CarrosContext : DbContext
    {
        public CarrosContext(DbContextOptions<CarrosContext> options)
            : base(options)
        {
        }

        public DbSet<ModeloCarro> ModelosCarros { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    if (!optionsBuilder.IsConfigured)
    {
        var connectionString = "server=4.221.123.186;port=3306;database=Carros;user=azure;password=Password1";
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 36)); // substitui pela tua versão real
        optionsBuilder.UseMySql(connectionString, serverVersion);
    }
}
    }
}



