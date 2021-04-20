using System;
using System.Collections.Generic;
using System.Text;
using Sql_PersonDBApp;


namespace Sql_PersonDBApp.Repositories
{
    public interface IPersonRepository
    {
        //CRUD
        //Create, Read, Update, Delete
        Models.Person CreatePerson(Models.Person person);

       List<Models.Person> ReadAllPeople();

        Models.Person UpdatePerson(Models.Person person);

        void DeletePerson(Models.Person person);
    }
}
