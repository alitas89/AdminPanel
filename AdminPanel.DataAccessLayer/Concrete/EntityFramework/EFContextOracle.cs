using AdminPanel.EntityLayer.Concrete.Other.Ybs_Filo;
using Microsoft.EntityFrameworkCore;
using AdminPanel.AppSettings;
using Microsoft.Extensions.Configuration;

namespace AdminPanel.DataAccessLayer.Concrete.EntityFramework
{
    public class EFContextOracle:DbContext
    {
        public EFContextOracle(): base()
        {

        }

        public EFContextOracle(DbContextOptions<EFContextOracle> options) : base(options)
        {
            
        }

       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseOracle(
                    AppSettingsConfiguration.Create()
                        .Configuration
                        .GetConnectionString(AppSettingsConfigurationNames.OracleDbString),
                    b => b.UseOracleSQLCompatibility(
                     AppSettingsConfiguration.Create()
                        .Configuration.GetSQLCompatibilityString(AppSettingsConfigurationNames.OracleSqlComponity)));

        }
        public DbSet<TEMP_SOSYALYARDIM3> TEMP_SOSYALYARDIM3 { get; set; }
    }
}
