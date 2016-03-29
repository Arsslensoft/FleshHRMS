using DevExpress.Internal;
using System;
using System.Data.Common;
using System.Data.Entity;
using System.IO;

namespace FHRMS.Data {
    public class DevAVDb : DbContext {
        public DevAVDb() : base(CreateConnection(), true) { }
        public DevAVDb(string connectionString) : base(connectionString) { }
        public DevAVDb(DbConnection connection) : base(connection, true) { }

        static DevAVDb() {
       
            Database.SetInitializer<DevAVDb>(null);
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Leave> Tasks { get; set; }
        public DbSet<Absence> Evaluations { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<Holiday> Holidays { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Warning> Warnings { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<DatabaseVersion> Version { get; set; }




        static DbConnection CreateConnection() {
            //if(filePath == null)
            //    filePath = DataDirectoryHelper.GetFile("devav.sqlite3", DataDirectoryHelper.DataFolderName);
            //File.SetAttributes(filePath, File.GetAttributes(filePath) & ~FileAttributes.ReadOnly);
            var connection = DbProviderFactories.GetFactory("MySql.Data.MySqlClient").CreateConnection();
            connection.ConnectionString = "Server=localhost;Database=fhrms;Uid=root;Pwd=;";
            return connection;
        }
    }
    public class DatabaseVersion : DatabaseObject {
        public DateTime Date { get; set; }
    }
}
