using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControlWorkbenchListBox
{
    public class Person
    {
        private ValueCollection mv_objPersonValues = new ValueCollection();

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public uint Age { get; set; }
        public string City { get; set; }
        
        public ValueCollection Values
        {
            get { return mv_objPersonValues; }
        }
        
        public static List<Person> CommonPersons
        {
            get
            {
                var lstPersons = new List<Person>();

                lstPersons.Add(new Person() {Age = 42, FirstName = "Torsten", LastName = "Zimmermann", City = "Berlin"});
                lstPersons.Add(new Person() {Age = 56, FirstName = "John", LastName = "Lennon", City = "Liverpool"});
                lstPersons.Add(new Person() {Age = 68, FirstName = "Paul", LastName = "McCartney", City = "Liverpool"});
                lstPersons.Add(new Person() {Age = 50, FirstName = "George", LastName = "Harrison", City = "Liverpool"});
                lstPersons.Add(new Person() {Age = 68, FirstName = "Ringo", LastName = "Starr", City = "Liverpool"});
                lstPersons.Add(new Person() {Age = 39, FirstName = "Hansi", LastName = "Zappel", City = "Bern"});
                lstPersons.Add(new Person()
                                   {
                                       Age = 48,
                                       FirstName = "Roger",
                                       LastName = "Zimmermann",
                                       City = "Friedrichsrode"
                                   });
                lstPersons.Add(new Person() {Age = 55, FirstName = "Theodor", LastName = "Fontane", City = "Potsdam"});

                return lstPersons;
            }
        }

    }

    public class ValueCollection : NameObjectCollectionBase
    {

        /*
         *      Anforderungen an die Wertesammlung
         *      - Wird ein Wert angefragt und ist er nicht vorhanden, wird nichts zurückgeliefert
         * 
         * 
         */

        public string this[string Description]
        {
            get { return String.Format("Wert: {0}", Description); }
        }

    }
}
