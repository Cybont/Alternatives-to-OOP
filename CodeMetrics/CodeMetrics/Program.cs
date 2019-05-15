using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace CodeMetrics
{
    class Program
    {
        private static int iterations = 10000;

        struct Entity
        {
            public double h;
            public double w;
            public double d;
            public double sum;
        }

        struct Entities
        {
            public double[] h;
            public double[] w;
            public double[] d;
            public double[] sum;
        }

        static void Main(string[] args)
        {
            Stopwatch aosStopwatch = new Stopwatch();
            aosStopwatch.Start();
            Console.WriteLine("Aos Test");
            Console.WriteLine("");

            AoSTest(iterations);

            aosStopwatch.Stop();
            Console.WriteLine($"AoS test time elapsed in milliseconds: {aosStopwatch.ElapsedMilliseconds}");

            Console.ReadKey();

            Stopwatch soaStopwatch = new Stopwatch();
            soaStopwatch.Start();
            Console.WriteLine("SoA Test");
            Console.WriteLine("");

            SoATest(iterations);

            soaStopwatch.Stop();
            Console.WriteLine($"SoA test time elapsed in milliseconds: {soaStopwatch.ElapsedMilliseconds}");
            Console.WriteLine("SoA was: " + aosStopwatch.ElapsedMilliseconds / soaStopwatch.ElapsedMilliseconds + " times faster");
            Console.ReadKey();
        }

        public static void AoSTest(int iterations)
        {
            Entity[] enArr = new Entity[iterations];

            for (int i = 0; i < iterations; i++)
            {
                enArr[i].h = new Random().NextDouble();
                enArr[i].w = new Random().NextDouble();
                enArr[i].d = new Random().NextDouble();

                enArr[i].sum = Math.Sqrt(enArr[i].h) + Math.Sqrt(enArr[i].w) + Math.Sqrt(enArr[i].d);

                Console.WriteLine($"AoS Sqr[{i}]: {enArr[i].sum}");
            }
        }

        public static void SoATest(int iterations)
        {
            Entities entities = new Entities();
            entities.h = new double[iterations];
            entities.w = new double[iterations];
            entities.d = new double[iterations];
            entities.sum = new double[iterations];

            for (int i = 0; i < iterations; i++)
            {
                entities.h[i] = new Random().NextDouble();
                entities.w[i] = new Random().NextDouble();
                entities.d[i] = new Random().NextDouble();

                entities.sum[i] = Math.Sqrt(entities.h[i]) + Math.Sqrt(entities.w[i]) + Math.Sqrt(entities.d[i]);
                Console.WriteLine($"SoA Sqr[{i}]: {entities.sum[i]}");
            }
        }
    }
}
