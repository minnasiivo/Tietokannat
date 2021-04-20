using System;
using System.Collections.Generic;
using System.Text;
using Sql_PersonDBApp;
using Sql_PersonDBApp.Models;

namespace Sql_PersonDBApp.Repositories
{
    public interface IPersonRepository
    {
        //CRUD
        //Create, Read, Update, Delete
        Models.Person CreatePerson(Models.Person person);

       List<Models.Person> Read();

        Person Read(long id);

        List<Person> Read(String city);


        Models.Person UpdatePerson(Models.Person person);

        void DeletePerson(Models.Person person);
    }
}
