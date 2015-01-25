using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Data.Objects;
using System.Linq;
using System.Text;
using LINQDB.Data;

namespace LINQDB
{
    public class SampleQueries
    {
        #region ObjectQuery

        // MSDN, Querying a Conceptual Model: http://msdn.microsoft.com/en-us/library/bb738642.aspx
        // Blog, Entity Framework v4 - Tips and Tricks: http://geekswithblogs.net/rgupta/archive/2010/06/23/entity-framework-v4-ndash-tips-and-tricks.aspx
        // MSDN, LINQ to SQL, .NET Language-Integrated Query for Relational Data: http://msdn.microsoft.com/en-us/library/bb425822.aspx#linqtosql_topic12
        // MSDN, Entity SQL Referenz: http://msdn.microsoft.com/de-de/library/bb387118.aspx

        [Description("LINQ mit Inner Join")]
        public void LoadPersonWithLinqQuery()
        {
            using (var svrUserManagement = new LINQDB.Data.dbLINQSamplesEntities())
            {
                var query = from p in svrUserManagement.Persons
                            join c in svrUserManagement.Cities on p.CityOfBirth equals c.CityId
                            where c.Name == "Liverpool"
                            select new
                            {
                                LastName = p.LastName,
                                FirstName = p.FirstName,
                                City = c.Name
                            };

                foreach (var p in query)
                {
                    Console.WriteLine(String.Format("Lastname: {0}, Firstname: {1}, City: {2}", p.FirstName, p.LastName, p.City));
                }
            }
        }

        [Description("Entity SQL mit Inner Join")]
        public void LoadPersonWithEntityQuery()
        {
            using (var svrUserManagement = new LINQDB.Data.dbLINQSamplesEntities())
            {
                string strQuery =
                    "SELECT p.FirstName as FirstName, p.LastName as LastName, c.Name As City " +
                    "From Persons As p inner join Cities As c on c.CityId = p.CityOfBirth" +
                    " Where c.Name = @ct";

                var query = new ObjectQuery<DbDataRecord>(strQuery, svrUserManagement);

                query.Parameters.Add(new ObjectParameter("ct", "Liverpool"));

                foreach (var p in query)
                {
                    Console.WriteLine(String.Format("Lastname: {0}, Firstname: {1}, City: {2}", p["FirstName"], p["LastName"], p["City"]));
                }
            }
        }

        //[Description("ESQL, Inner Join, Mehrfachkriterien")]
        public void LoadPersonByCitiesWithEntityQuery()
        {
            using (var svrUserManagement = new LINQDB.Data.dbLINQSamplesEntities())
            {
                string strQuery =
                    "SELECT p.FirstName as FirstName, p.LastName as LastName, c.Name As City " +
                    "From Persons As p LEFT OUTER JOIN Cities AS c ON p.CityOfBirth = c.CityId" +
                    " WHERE p.CityOfBirth is NULL OR c.Name NOT IN {'Liverpool'}";

                var query = new ObjectQuery<DbDataRecord>(strQuery, svrUserManagement);
                
                foreach (var p in query)
                {
                    Console.WriteLine(String.Format("Lastname: {0}, Firstname: {1}, City: {2}", p["FirstName"], p["LastName"], p["City"]));
                }
            }
        }

        #endregion



        #region Laden von verknüpften Informationen

        // MSDN, Laden von verknüpften Objekten: http://msdn.microsoft.com/de-de/library/bb896272.aspx
        // ADO.NET Team Blog: Using DbContext in EF 4.1: Loading Related Entities: http://blogs.msdn.com/b/adonet/archive/2011/01/31/using-dbcontext-in-ef-feature-ctp5-part-6-loading-related-entities.aspx
        // POCO in the EF Part 1 - The Experience: http://blogs.msdn.com/b/adonet/archive/2009/05/21/poco-in-the-entity-framework-part-1-the-experience.aspx
        // POCO in the EF Part 2 - Complex Types, Deferred Loading and Explicit Loading: http://blogs.msdn.com/b/adonet/archive/2009/05/28/poco-in-the-entity-framework-part-2-complex-types-deferred-loading-and-explicit-loading.aspx
        // POCO in the EF Part 3 - Change Tracking with POCO: http://blogs.msdn.com/b/adonet/archive/2009/06/10/poco-in-the-entity-framework-part-3-change-tracking-with-poco.aspx

        /// <summary>
        /// Lädt alle Personen. Alle relationale Daten werden in den Ladenvorgang 
        /// einbezogen.
        /// </summary>
        public void LoadPersonsWithLazyLoading()
        {
            // Erstellen der Datenverbindung
            using (var svrUserManagement = new LINQDB.Data.dbLINQSamplesEntities())
            {
                svrUserManagement.ContextOptions.LazyLoadingEnabled = true;

                foreach (Person p in from prs in svrUserManagement.Persons select prs)
                {
                    string strCity = p.City == null ? "keine Angabe" : p.City.Name;

                    Console.WriteLine(String.Format("Lastname: {0}, Firstname: {1}, City: {2}", p.LastName, p.FirstName,
                                                    strCity));
                }
            }
        }

        /// <summary>
        /// Lädt alle Personen. Relationale Daten werden nicht in den Ladevorgang
        /// einbezogen. Statt dessen wird eine Eigenschaft, die sich aus einer 1:n
        /// Beziehung ergibt, explizit geladen.
        /// </summary>
        public void LoadPersonsWithLoadProperty()
        {
            // Ausgabe aller Personen
            using (var svrUserManagement = new LINQDB.Data.dbLINQSamplesEntities())
            {
                foreach (Person p in from prs in svrUserManagement.Persons.ToList() where prs.FirstName == "John" select prs)
                {
                    // Explizites Laden einer verbundenen Information
                    svrUserManagement.LoadProperty(p, "City");

                    string strCity = p.City == null ? "keine Angabe" : p.City.Name;

                    Console.WriteLine(String.Format("Lastname: {0}, Firstname: {1}, City: {2}", p.LastName, p.FirstName,
                                                    strCity));
                }
            }
        }

        #endregion



    }
}
