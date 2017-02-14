using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace SelfhostingWebAPI
{
    public class CustomController : ApiController
    {
        // http://localhost:8080/api/TestTZ/Custom/GetFirstMethod?param1=Hallo Welt
        [HttpGet]
        public string FirstMethod(string configuration, string param1)
        {
            return $"{MethodBase.GetCurrentMethod().Name}:{configuration}, Param1: {param1}";
        }

        // http://localhost:8080/api/TestTZ/Custom/GetSecondMethod?param1=Hallo Welt&value=10
        public string GetSecondMethod(string configuration, string param1, int value)
        {
            return $"{MethodBase.GetCurrentMethod().Name}:{configuration}, Param1: {param1}, Value: {value}";
        }



    }
}
