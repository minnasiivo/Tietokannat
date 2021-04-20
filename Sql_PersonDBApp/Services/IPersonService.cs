using System;
using System.Collections.Generic;
using System.Text;
using Sql_PersonDBApp.Models;

namespace Sql_PersonDBApp.Services
{
    public interface IPersonService
    {
        Person Create(Person person);
        List<Person> ReadAll();

    }
}
