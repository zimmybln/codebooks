using System; 
using System.Collections.Generic;
using System.Reflection;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using SelfhostingWebAPI.Types;
 
namespace SelfhostingWebAPI.Controllers
{
    [RoutePrefix("api/customers")]
     public class CustomersController : ApiController
    {
        [HttpGet]
        [Route("")]
        public IEnumerable<Customer> GetCustomers()
        { 
            return new List<Customer>(new Customer[]
            {
                new Customer() {Id = 1, FirstName = "John", LastName = "Lennon"},
                new Customer() {Id = 2, FirstName = "Paul", LastName = "McCartney"}
            });
        }


        [HttpGet]
        [Route("{id:int}")]
        public Customer GetCustomer(int id)
        {
            return new Customer() { Id = id, FirstName = "George", LastName = "Harrison" };
        }

        [HttpGet]
        [Route("{id:int}/invoices/{year:int=0}/{month:int=0}/{day:int=0}")]
        public IEnumerable<Invoice> GetInvoicesByDateTime(int id, int? year, int month, int day, string page = null, string sortorder = null)
        {
            Console.WriteLine($"Rechnungen werden ermittelt {MethodBase.GetCurrentMethod().Name} {year}/{month}/{day} {sortorder},{page}");

            return new List<Invoice>();
        }

        [HttpGet]
        [Route("{id:int}/invoices/{city}/{year:int=0}/{month:int=0}/{day:int=0}")]
        public IEnumerable<Invoice> GetInvoicesByCity(int id, string city, int? year, int month, int day, [FromUri] string sortorder = null, [FromUri] string page = null)
        {
            Console.WriteLine($"Rechnungen werden ermittelt {MethodBase.GetCurrentMethod().Name} {city} {year}/{month}/{day} {sortorder},{page}");

            return new List<Invoice>();
        }

        [HttpPost]
        [Route("{id:int}")]
        public int SaveCustomer(int id, Customer customer)
        {
            // Datensatz wird gespeichert ...

            return 4;
        }

        [HttpPatch]
        [Route("{id:int}")]
        public int SaveCustomerPartial(int id, [FromBody] Customer customer)
        {
            return id;
        }

        [HttpPut]
        [Route("")]
        public int CreateCustomer([FromBody] Customer customer)
        {
            return 100;
        }

        [HttpDelete]
        [Route("{id:int}")]
        public void DeleteCustomer(int id)
        {
            // Datensatz wird gelöscht
        }
        
        [AcceptVerbs("TRANSFER")]
        [Route("{id}/transfers")]
        public int Transfer(int id)
        {
            return id + id;
        }

        // https://docs.microsoft.com/en-us/aspnet/web-api/overview/web-api-routing-and-actions/create-a-rest-api-with-attribute-routing

             
        [HttpGet]
        [Route("{filter}")]
        public IEnumerable<Customer> Filter(string filter, [FromUri] int pagecount = 0)
        {
            Console.WriteLine(filter);

            return new List<Customer>(new Customer[]
            {
                new Customer() {Id = 1, FirstName = "John", LastName = "Lennon"},
                new Customer() {Id = 2, FirstName = "Paul", LastName = "McCartney"}
            });
        }
    }
}
