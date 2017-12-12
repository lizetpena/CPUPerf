using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Threading.Tasks;

namespace DebuggingDemo
{
    public class Customer
    {
        public string Name { get; set; }
    }
    class Program
    {
        static int recursionCouhnt = 10;

        static void Main(string[] args)
        {
            while (true)
            {
                var t = Task.Run(new Action(DoIt));
                var t2 = Task.Run(() => DoRecursion(recursionCouhnt));
                var t3 = Task.Run(() => DoRecursion(recursionCouhnt));
                var t4 = Task.Run(() => DoRecursion(recursionCouhnt));


                Task.WaitAll(t, t2, t3, t4);
            }
        }

        private static void DoIt()
        {
            DoRecursion(recursionCouhnt);
        }

        static int Sum(int x, int y)
        {
            return x + y;
        }

        static int Square(int x)
        {
            return x * x;
        }

        private static void FindFactors()
        {
            int i = 10;
            for ( i = -100; i < 100; i++)
            {

                //Console.WriteLine("it is now {0}", i);
                bool isFactor = 100 / i == 0;

                if (isFactor)
                {
                    Console.WriteLine("{0} is a factor of 100", i);
                }
            }
        }

        public static bool IsFactorOf100(int val)
        {
            if (100 / val == 0)
            {
                return true;
            }
            return false;
        }

        static string someXml;
        public static void DoRecursion(int recursionCount)
        {
            Worker w = new Worker();
            w.DoWork(1000);

            someXml = File.ReadAllText("Customers.xml");
            if (recursionCount <= 0)
            {
               // Debugger.Break();
                return;
            }

            Console.WriteLine("This is iteration {0}", recursionCount);
            DoRecursion(recursionCount - 1);
        }

        public static void VisualizerExample()
        {
            string someXml = File.ReadAllText("Customers.xml");
            throw new NotImplementedException("Havent built it yet!");
        }
    }
}
