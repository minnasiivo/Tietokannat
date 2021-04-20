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

        public List<Person> ReadAll()
        {
            var people = _personRepository.ReadAllPeople();
            return people;
        }
    }
}
