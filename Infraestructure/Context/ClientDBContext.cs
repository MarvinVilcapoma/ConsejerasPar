using Common;
using Common.AspNetCore;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace Infraestructure.Context
{
    public class ClientDbContext : DbContext
    {

        /*private IConfigurationLib config;

        public ClientDbContext() : base() { }

        public ClientDbContext(DbContextOptions<ClientDbContext> options) : base(options) { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {        

            IConfigurationRoot configuration = ConfigManager.GetConfig();
            config = new ConfigurationLib(configuration);
            var connectionString = configuration.GetConnectionString("myconn");

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString, sqlServerOptions => sqlServerOptions.CommandTimeout(180));
                optionsBuilder.UseSqlServer(connectionString, sqlServerOptions =>
                {
                    sqlServerOptions.CommandTimeout(120)
                    .UseNetTopologySuite();
                });
            }
        }*/
        private IConfigurationLib config;

        public ClientDbContext() : base() { }

        public ClientDbContext(DbContextOptions<ClientDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactType> ContactTypes { get; set; }
        public DbSet<Counselor> Counselors { get; set; }
        public DbSet<Nutritionist> Nutritionists { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Referred> Referreds { get; set; }

        public DbSet<Assignment> Assignments { get; set; }


        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Data Source=10.0.10.13;Initial Catalog=ConsejerasParesDBDev;User ID=sa;Password=theDeveloper01*";

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString, sqlServerOptions => sqlServerOptions.CommandTimeout(180));
                optionsBuilder.UseSqlServer(connectionString, sqlServerOptions =>
                {
                    sqlServerOptions.CommandTimeout(120);
                });
            }
        }*/

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(connectionString);           

            IConfigurationRoot configuration = ConfigManager.GetConfig();
            config = new ConfigurationLib(configuration);
            var connectionString = configuration.GetConnectionString("myconn");

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString, sqlServerOptions => sqlServerOptions.CommandTimeout(180));
                optionsBuilder.UseSqlServer(connectionString, sqlServerOptions =>
                {
                    sqlServerOptions.CommandTimeout(120)
                    .UseNetTopologySuite();
                });
            }
        }
    }
}
