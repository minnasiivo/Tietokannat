using System;
using System.Collections.Generic;
using System.Text;
using Sql_PersonDBApp.Models;
using Sql_PersonDBApp.Repositories;

namespace Sql_PersonDBApp.Services
{
    class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService()
        {
            _personRepository = new PersonRepository();
        }

        public Person Create(Person person)
        {
            var createdPerson = _personRepository.CreatePerson(person);
            return createdPerson;
        }

        public void Delete(long id)
        {
            var person = _personRepository.Read(id);
            _personRepository.DeletePerson(person);
        }

        public List<Person> Read()
        {
            var people = _personRepository.Read();
            return people;
        }

        public Person Read(long id)
        {
            var person = _personRepository.Read(id);
            return person;
        }

        public List<Person> Read(string city)
        {
            var people = _personRepository.Read(city);
            return people;
        }

        public Person Update(long id, Person person)
        {
            var dbPerson = _personRepository.Read(id);
            if (dbPerson != null)
            {
                person.Id = id;
                var updatePerson=_personRepository.UpdatePerson(person);
                return updatePerson;
            }
            else
            {
                Console.WriteLine("Henkilöä ei löydy, päivitys ei onnistu");
                return null;
            }
        }
    }
}
