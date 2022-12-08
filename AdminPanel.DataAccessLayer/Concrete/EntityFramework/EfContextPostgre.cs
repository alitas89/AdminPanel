using AdminPanel.AppSettings;
using AdminPanel.EntityLayer.Concrete.Other.TestPostgre;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AdminPanel.DataAccessLayer.Concrete.EntityFramework
{
    public class EfContextPostgre:DbContext
    {
        public EfContextPostgre():base()
        {

        }

        public EfContextPostgre(DbContextOptions options):base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(AppSettingsConfiguration.Create().Configuration
                .GetConnectionString(AppSettingsConfigurationNames.PostgreSQL));

            base.OnConfiguring(optionsBuilder);
        }

        DbSet<testpostgre> testpostgre { get; set; }
    }
}
