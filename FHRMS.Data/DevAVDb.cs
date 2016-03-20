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

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Leave> Tasks { get; set; }
        public DbSet<Crest> Crests { get; set; }
        public DbSet<CustomerCommunication> Communications { get; set; }
        public DbSet<CustomerStore> CustomerStores { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Probation> Probations { get; set; }
        public DbSet<ProductCatalog> ProductCatalogs { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<QuoteItem> QuoteItems { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<CustomerEmployee> CustomerEmployees { get; set; }
        public DbSet<Absence> Evaluations { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<DatabaseVersion> Version { get; set; }

        static string filePath;

        static DbConnection CreateConnection() {
            if(filePath == null)
                filePath = DataDirectoryHelper.GetFile("devav.sqlite3", DataDirectoryHelper.DataFolderName);
            File.SetAttributes(filePath, File.GetAttributes(filePath) & ~FileAttributes.ReadOnly);
            var connection = DbProviderFactories.GetFactory("MySql.Data.MySqlClient").CreateConnection();
            connection.ConnectionString = "Server=localhost;Database=test;Uid=root;Pwd=;";
            return connection;
        }
    }
    public class DatabaseVersion : DatabaseObject {
        public DateTime Date { get; set; }
    }
}
