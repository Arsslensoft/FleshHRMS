using DevExpress.Internal;
using System;
using System.Data.Common;
using System.Data.Entity;
using System.IO;

namespace FHRMS.Data {
    public class PhexonDb : DbContext {
        public PhexonDb() : base(CreateConnection(), true) { }
        public PhexonDb(string connectionString) : base(connectionString) { }
        public PhexonDb(DbConnection connection) : base(connection, true) { }

        static PhexonDb() {
       
            Database.SetInitializer<PhexonDb>(null);
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




        static DbConnection CreateConnection() {
      
            var connection = DbProviderFactories.GetFactory("MySql.Data.MySqlClient").CreateConnection();
            connection.ConnectionString = "Server=localhost;Database=fhrms;Uid=root;Pwd=;";
            return connection;
        }
    }
    public class DatabaseVersion : DatabaseObject {
        public DateTime Date { get; set; }
    }
}
