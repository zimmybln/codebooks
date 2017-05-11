using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StorageIntoSqlLite.Storage
{
    public class ObjectItem
    {
        [Key]
        public int ItemId { get; set; }

        [Required]
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{Name} ({ItemId})";
        }
    }

    public class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
        }
    }

    public class DataContext : DbContext
    {
        private static bool _created = false;


        public DataContext()
        {
            if (!_created)
            {
                _created = true;
                Database.EnsureCreated();
                Database.Migrate();

                
                
            }
            
        }

        public DbSet<ObjectItem> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<ObjectItem>().HasKey(o => o.ItemId);

            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionStringBuilder = new SqliteConnectionStringBuilder()
            {
                DataSource = "sample.db"
            }
            .ToString();

            var connection = new SqliteConnection(connectionStringBuilder);

            optionsBuilder.UseSqlite(connection);
        }


    }
}
