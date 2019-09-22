using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForEachChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            int COUNT = 4;
            string[] firstNamesArr = { "Linda", "Mike", "Charles", "Jason"};
            string[] lastNamesArr = { "Johnson", "Smith", "James", "Mandy"};

            List<Person> people = new List<Person>();

            for (int i = 0; i < COUNT; i++)
            {
                people.Add(new Person(firstNamesArr[i], lastNamesArr[i]));
            }

            foreach (var person in people)
            {
                Console.WriteLine($"Hello { person.FirstName } { person.LastName }!");
            }

            Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }
}
