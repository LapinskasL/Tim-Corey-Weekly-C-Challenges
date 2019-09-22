using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoLibrary;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            PaymentProcessor paymentProcessor = new PaymentProcessor();
            for (int i = 0; i <= 10; i++)
            {
                try
                {
                    var result = paymentProcessor.MakePayment($"Demo{ i }", i);
                    Console.WriteLine(result.TransactionAmount);
                }
                catch (Exception ex)
                {
                    if (ex is IndexOutOfRangeException)
                    {
                        Console.Write("Skipped invalid record");
                    }
                    else if (ex is FormatException && i != 5)
                    {
                            Console.Write("Formatting Issue");
                    }
                    else if (ex is NullReferenceException)
                    {
                        Console.Write("Null value for item " + i);
                    }
                    else
                    {
                        Console.Write("Payment skipped for payment with " + i + " items");
                    }

                    // write InnerException message, if exists
                    if (ex.InnerException != null)
                    {
                        Console.Write(" " + ex.InnerException.Message);
                    }

                    Console.Write("\n"); // new line
                }
            }
            Console.ReadLine();
        }
    }
}
