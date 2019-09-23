using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateTimeChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a date: ");
            string dateInput = Console.ReadLine();
            Console.Write("Enter date format: ");
            string dateformat = Console.ReadLine();

            DateTime pastDate = DateTime.ParseExact(dateInput, dateformat,
                                             CultureInfo.InvariantCulture);

            DateTime currentDate = DateTime.Now;

            var daysAgo = (currentDate - pastDate).TotalDays;

            Console.WriteLine("It has been " + Math.Floor(daysAgo) + " days since " + dateInput + ".");
            Console.Write(Environment.NewLine);





            Console.Write("Enter a time: ");
            string timeInput = Console.ReadLine();
            Console.Write("Enter time format: ");
            string timeFormat = Console.ReadLine();

            DateTime pastTime = DateTime.ParseExact(timeInput, timeFormat,
                                             CultureInfo.InvariantCulture);

            DateTime currentTime = DateTime.Now;

            if (pastTime > currentTime)
            {
               pastTime = pastTime.AddDays(-1);
            }

            var hoursAgo = (currentTime - pastTime);
            var minutesAgo = (hoursAgo.TotalHours - Math.Floor(hoursAgo.TotalHours)) * 60;

            Console.WriteLine(timeInput + " was " +
                Math.Floor(hoursAgo.TotalHours) + " hours and " + Math.Floor(minutesAgo) + " minutes ago.");



            Console.ReadKey();
        }
    }
}
