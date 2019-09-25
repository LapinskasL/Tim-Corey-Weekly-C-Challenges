using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceEvaluationChallenge
{
    static class MeasureAppend
    {
        static public void DisplaySpeed(this string someString, int iterations)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            for (int i = 0; i < iterations; i++)
            {
                someString += "string";
            }
            sw.Stop();

            Console.WriteLine("Append Text {0} reps: {1} ms", iterations, sw.ElapsedMilliseconds);
        }
    }
}
