using System;
using System.Collections.Generic;
using System.Text;
using Sql_PersonDBApp.Models;
using Sql_PersonDBApp.Services;

namespace Sql_PersonDBApp.views
{
    class Personview : IPersonview
    {
        private readonly IPersonService _personService;

        public Personview()
        {
            _personService = new PersonService();
        }
        public void CreatePerson()
        {
            Person newPerson = new Person();
            Console.WriteLine("Lisätään henkilö, syötä henkilön tiedot");
          
            Console.WriteLine("Anna etunimi ja paina enter");  
            newPerson.FirstName = Console.ReadLine();
            Console.WriteLine("Anna sukunimi ja paina enter");
            newPerson.LastName = Console.ReadLine();
            Console.WriteLine("Anna kaupunki ja paina enter");
            newPerson.City = Console.ReadLine();
            Console.WriteLine("Anna syntymäpäivä muodossa (yyyy-mm-dd)");
             newPerson.DateOfBirth = DateTime.Parse(Console.ReadLine());
             Console.WriteLine("Anna sukupuoli (male/female/other)");
             newPerson.Sex = Console.ReadLine();
             Console.WriteLine("Silmien väri?");
             newPerson.EyeColor = Console.ReadLine();
             Console.WriteLine("Silmien väri?");
             newPerson.ShoeSize =int.Parse(Console.ReadLine());
            Console.WriteLine("Pituus[cm]?");
            newPerson.Height = int.Parse(Console.ReadLine()); 

            newPerson = _personService.Create(newPerson);
            if (newPerson != null)
            { Console.WriteLine("Henkilön lisääminen onnistui"); }
            else
            {
                Console.WriteLine("Henkilön lisääminen epäonnistui");
            }
            
        }

        public void DeletePerson()
        {
            Console.Write("Anna poistettavan henkilön Id");
            long id =Convert.ToInt64(Console.ReadLine());
            _personService.DeletePerson(id);
        }

        public void PrintAllPeople()
        {
            var people = _personService.Read();
            PrintPeople(people);
        }

        public void PrintByCIty()
        {
            Console.Write("Syötä kaupungin nimi");
            string city = Console.ReadLine();
            var people = _personService.Read(city);
        }

        public void PrintSinglePerson()
        {
            Console.Write("Syötä henkilön id");
            long id = Convert.ToInt64(Console.ReadLine());
                var person = _personService.Read(id);
            PrintPerson(person);
        }

        public void UpdatePerson()
        {
            Console.Write("Syötä henkilön id");
            long id = Convert.ToInt64(Console.ReadLine());
            var person = _personService.Read(id);
            //kysy uudet arvot
            Console.WriteLine("Anna henkilön uusi etunimi");
           person.FirstName = Console.ReadLine();
            Console.WriteLine("Anna henkilön uusi sukunimi");
            person.LastName = Console.ReadLine();
            Console.WriteLine("Anna  henkilön uusi kaupunki");
            person.City = Console.ReadLine();
            Console.WriteLine("Anna syntymäpäivä muodossa (yyyy-mm-dd)");
            person.DateOfBirth = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Anna sukupuoli (male/female/other)");
            person.Sex = Console.ReadLine();
            Console.WriteLine("Silmien väri?");
            person.EyeColor = Console.ReadLine();
            Console.WriteLine("Silmien väri?");
            person.ShoeSize = int.Parse(Console.ReadLine());
            Console.WriteLine("Pituus[cm]?");
            person.Height = int.Parse(Console.ReadLine());

            _personService.Update(id, person);
        }
        private void PrintPeople(List<Person>people)
        {
            Console.WriteLine("Id\tEtunimi\tSukunimi\tSukupuoli\tKaupunki");
            foreach (var p in people)
            {
                Console.WriteLine($"{p.Id}\t{p.FirstName}\t{p.LastName}\t{p.Sex}\t{p.City}");
            }
        }
        private void PrintPerson(Person person)
        { 
            
                Console.WriteLine($"{person.Id}\t{person.FirstName}\t{person.LastName}\t{person.Sex}\t{person.City}");
        }
        
    }
}
