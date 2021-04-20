using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sql_PersonDBApp.Data1;
using Sql_PersonDBApp.Models;

namespace Sql_PersonDBApp.Repositories
{
    class PersonRepository : IPersonRepository
    {
        private readonly PersonTestDBContext _context;

        public PersonRepository()
        {
            _context = new PersonTestDBContext();
        }
        public Person CreatePerson(Person person)
        {
            try
            {
                _context.People.Add(person);
                _context.SaveChanges();
                return person;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public void DeletePerson(Person person)
        {
            throw new NotImplementedException();
        }

        public List<Person> ReadAllPeople()
        {
            var people = _context.People.ToList();
            return people;
        }

        public Person UpdatePerson(Person person)
        {
            throw new NotImplementedException();
        }
    }
}
