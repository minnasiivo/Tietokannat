using System;
using System.Linq;
using Sql_PersonDBApp;
using Sql_PersonDBApp.Models;
using Sql_PersonDBApp.views;

namespace Sql_PersonDBApp
{
    class Program
    {
        static private readonly IPersonview _personView = new Personview();
        static void Main(string[] args)
        {
           // _personView.PrintAllPeople();
            string choice = null;
            do
            {
                choice = UserInterface();
                switch(choice.ToUpper())
                {
                    case "C":
                        _personView.CreatePerson();
                        break;
                    case "R":
                        _personView.PrintAllPeople();
                        break;
                }
                Console.WriteLine("Paina enteriä jatkaaksesi...");
                Console.ReadLine();
            }
            while (choice.ToUpper() != "X");
        }
    
        static string UserInterface()
        {
            Console.WriteLine("Tietokannan käsittelyesimerkki");
            Console.WriteLine("[C] - Lisää uusi henkilö");
            Console.WriteLine("[R] - Tulosta kaikki henkilöt");
            Console.WriteLine("[U] - Päivitä henkilön tietoja");
            Console.WriteLine("[D] - Poista henkilön tiedot");
            Console.WriteLine("[X] - Lopeta ohjelma suoritus");

            return Console.ReadLine();
        }
        
    }
}
