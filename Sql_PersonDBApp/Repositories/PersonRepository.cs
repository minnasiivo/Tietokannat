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
                Console.WriteLine("Henkilön lisääminen epäonnistui" + ex.Message);
                return null;
            }
        }

        public void DeletePerson(Person person)
        {
            try
            {
                _context.People.Remove(person);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Henkilön tietoja ei voitu poistaa" + ex.Message);
            }
        }

        public List<Person> Read()
        {
            var people = _context.People.ToList();
            return people;
        }

        public Person Read(long id)
        {
            var person = _context.People.Find(id);
            return person;
        }

        public List<Person> Read(string city)
        {
            var people = _context.People.Where(p => p.City == city).ToList();
            return people;
        }

        public Person UpdatePerson(Person person)
        {
            try { 
           var updatePerson = _context.People.Update(person).Entity;
            _context.SaveChanges();
            return updatePerson;
        }
            catch(Exception ex)
            {
                Console.WriteLine("Henkilön tietojen päivittäminen ei onnistunut" + ex.Message);
                return null;
            }
}
    }
}
