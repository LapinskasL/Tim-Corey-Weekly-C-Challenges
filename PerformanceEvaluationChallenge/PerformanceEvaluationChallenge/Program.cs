// Summary: Tests the performance difference between 
//          concatenating strings and using StringBuilder.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceEvaluationChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplayAppendTextSpeed(500);
            DisplayAppendTextSpeed(5000);
            DisplayAppendTextSpeed(50000);

            DisplayStringBuilderSpeed(500);
            DisplayStringBuilderSpeed(5000);
            DisplayStringBuilderSpeed(50000);

            Console.ReadKey();
        }


        /// <summary>
        /// Displays the the number of milliseconds it took to 
        /// concatenate a string to a test variable.
        /// </summary>
        /// <param name="iterations">Number of times to add "abc" to a test variable.</param>
        static public void DisplayAppendTextSpeed(int iterations)
        {
            string someString = "abc";
            Stopwatch sw = new Stopwatch();

            sw.Start();
            for (int i = 0; i < iterations; i++)
            {
                someString += "abc";
            }
            sw.Stop();

            Console.WriteLine("Append Text {0} reps: {1} ms", iterations, sw.ElapsedMilliseconds);
        }


        /// <summary>
        /// Displays the number of milliseconds it took to Append a 
        /// string to a test variable using StringBuilder.
        /// </summary>
        /// <param name="iterations">Number of times to Append "abc" to a test variable.</param>
        static public void DisplayStringBuilderSpeed(int iterations)
        {
            StringBuilder stringBld = new StringBuilder("abc");
            Stopwatch sw = new Stopwatch();

            sw.Start();
            for (int i = 0; i < iterations; i++)
            {
                stringBld.Append("abc");
            }
            sw.Stop();

            Console.WriteLine("String Builder {0} reps: {1} ms", iterations, sw.ElapsedMilliseconds);
        }
    }
}
