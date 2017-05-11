using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json;
using SelfhostingWebAPI.Types;

namespace SelfhostingWebAPI.Controllers
{
    public class PocoController : ApiController
    {

        public Person GetPerson(string configuration, int id)
        {
            return new Person() {FirstName = "John", LastName = "Lennon", Id = id};
        }

        public async Task<Person> GetPersonAsync(string configuration, int id)
        {
            var person = await Task.Run(() => new Person() {FirstName = "Paul", LastName = "McCartney", Id = id});

            return person;
        }
    }
}
