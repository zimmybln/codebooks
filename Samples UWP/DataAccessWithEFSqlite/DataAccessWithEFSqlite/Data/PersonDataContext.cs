using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace DataAccessWithEFSqlite.Data
{
    public class PersonDataContext : DbContext  
    {
        private static bool _created = false;

        public DbSet<Person> Persons { get; set; } 


        public PersonDataContext()
        {
            if (!_created)
            {
                _created = true;
                Database.EnsureCreated();
                Database.Migrate();
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionStringBuilder = new SqliteConnectionStringBuilder()
            {
                DataSource = "persons.db"
            }
            .ToString();

            var connection = new SqliteConnection(connectionStringBuilder);

            optionsBuilder.UseSqlite(connection);
        }
    }
}
