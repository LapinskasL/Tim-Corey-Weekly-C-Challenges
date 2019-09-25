using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceEvaluationChallenge
{
    static class MeasureStringBuild
    {
        static public void DisplaySpeed(this StringBuilder stringBld, int iterations)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            for (int i = 0; i < iterations; i++)
            {
                stringBld.Append("string");
            }
            sw.Stop();
            Console.WriteLine("String Builder {0} reps: {1} ms", iterations, sw.ElapsedMilliseconds);
        }
    }
}
