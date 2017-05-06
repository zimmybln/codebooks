using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphQLTest.Types;

namespace GraphQLTest.Data
{
    public class DataSource
    {
        public List<Customer> Customers { get; } = new List<Customer>()
        {
            new Customer(){Id = 1, FirstName = "Hans", LastName = "Maier"},
            new Customer(){Id = 2, FirstName = "Simone", LastName = "Selmke"},
            new Customer(){Id = 3, FirstName = "Simone", LastName = "Schulze"},
        };

        public List<Invoice> Invoices { get; } = new List<Invoice>()
        {
            new Invoice() {Id = 1, CustomerId = 1, Date = new DateTime(2017, 1, 10), Price = 50},
            new Invoice() {Id = 1, CustomerId = 1, Date = new DateTime(2017, 5, 2), Price = 150},
            new Invoice() {Id = 1, CustomerId = 2, Date = new DateTime(2017, 3, 10), Price = 80}
        };
    }
}
