using System;
using System.Data.Common;
using System.Data.Entity;

namespace PHRMS.Data
{
    public class PhexonDb : DbContext
    {
        static PhexonDb()
        {
            Database.SetInitializer<PhexonDb>(null);
        }

        public PhexonDb() : base(CreateConnection(), true)
        {
        }

        public PhexonDb(string connectionString) : base(connectionString)
        {
        }

        public PhexonDb(DbConnection connection) : base(connection, true)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Leave> Leaves { get; set; }
        public DbSet<Absence> Absences { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<Holiday> Holidays { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Warning> Warnings { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<DatabaseVersion> Version { get; set; }


        private static DbConnection CreateConnection()
        {
            PhexonConfigurationManager.Initialize();
            var connection = DbProviderFactories.GetFactory("MySql.Data.MySqlClient").CreateConnection();
            connection.ConnectionString = string.Format("Server={0};Database={1};Uid={2};Pwd={3};Port={4}",
                PhexonConfigurationManager.Configuration.Host, PhexonConfigurationManager.Configuration.Database,
                PhexonConfigurationManager.Configuration.User, PhexonConfigurationManager.Configuration.Password,
                PhexonConfigurationManager.Configuration.Port);
            return connection;
        }
    }

    public class DatabaseVersion : DatabaseObject
    {
        public DateTime Date { get; set; }
    }
}