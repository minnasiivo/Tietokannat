using System;
using System.Collections.Generic;
using System.Text;

namespace Sql_PersonDBApp.views
{
    public interface IPersonview
    {
        void CreatePerson();
        void PrintAllPeople();
        void PrintSinglePerson();
        void PrintByCIty();
        void UpdatePerson();
        void DeletePerson();
    }
}
