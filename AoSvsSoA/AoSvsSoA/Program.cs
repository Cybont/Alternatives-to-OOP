using System;
using System.Diagnostics;

namespace AoSvsSoA
{
    class Program
    {
        private static int iterations = 10000 + 1;

        private static Random random = new Random();

        public struct Entity
        {
            public double a;
            public double b;
            public double c;
            public double h;
            public double w;
            public double d;
            public double sum;
        }

        public struct Entities
        {
            public double[] a;
            public double[] b;
            public double[] c;
            public double[] h;
            public double[] w;
            public double[] d;
            public double[] sum;
        }

        static void Main(string[] args)
        {
            Entities entities = new Entities();
            entities.h = new double[iterations];
            entities.w = new double[iterations];
            //entities.d = new double[iterations];
            entities.sum = new double[iterations];

            Entity[] enArr = new Entity[iterations];

            AoSTest(10000, enArr);

            Console.ReadKey();

            Stopwatch aosStopwatch = new Stopwatch();
            aosStopwatch.Start();
            Console.WriteLine("Aos Test");
            Console.WriteLine("");

            AoSTest(iterations, enArr);
            
            aosStopwatch.Stop();
            Console.WriteLine($"AoS test time elapsed in milliseconds: {aosStopwatch.ElapsedMilliseconds}");

            Console.ReadKey();
            
            Stopwatch soaStopwatch = new Stopwatch();
            soaStopwatch.Start();
            Console.WriteLine("SoA Test");
            Console.WriteLine("");

            SoATest(iterations, entities);

            soaStopwatch.Stop();
            Console.WriteLine($"SoA test time elapsed in milliseconds: {soaStopwatch.ElapsedMilliseconds}");

            if (soaStopwatch.ElapsedMilliseconds > aosStopwatch.ElapsedMilliseconds)
            {
                Console.WriteLine("SoA was: " + (aosStopwatch.ElapsedMilliseconds / soaStopwatch.ElapsedMilliseconds) + " times faster");
            }
            

            Console.ReadKey();
        }

        public static void AoSTest(int iterations, Entity[] enArr)
        {
            //for (int i = 0; i < iterations; i++)
            //{
            //    enArr[i].h = new Random().Next(0, 1000);
            //    enArr[i].w = new Random().Next(0, 1000);
            //    enArr[i].d = new Random().Next(0, 1000);

            //    enArr[i].sum = Math.Sqrt(enArr[i].h) 
            //        + Math.Sqrt(enArr[i].w) + Math.Sqrt(enArr[i].d);

            //    Console.WriteLine($"AoS Sqr[{i}]: {enArr[i].sum}");
            //}

            for (int i = 0; i < iterations; i++)
            {
                enArr[i].h = random.Next(0, 1000);
                enArr[i].w = random.Next(0, 1000);

                Console.WriteLine(enArr[i].h + enArr[i].w);

                //enArr[i].sum = Math.Sqrt(enArr[i].h)
                //    + Math.Sqrt(enArr[i].w);

                //Console.WriteLine($"AoS Sqr[{i}]: {enArr[i].sum}");
            }
        }

        public static void SoATest(int iterations, Entities entities)
        {
            //for (int i = 0; i < iterations; i++)
            //{
            //    entities.h[i] = new Random().Next(0, 1000);
            //    entities.w[i] = new Random().Next(0, 1000);
            //    entities.d[i] = new Random().Next(0, 1000);

            //    entities.sum[i] = Math.Sqrt(entities.h[i]) 
            //        + Math.Sqrt(entities.w[i]) + Math.Sqrt(entities.d[i]);
            //    Console.WriteLine($"SoA Sqr[{i}]: {entities.sum[i]}");
            //}

            for (int i = 0; i < iterations; i++)
            {
                entities.h[i] = random.Next(0, 1000);
                entities.w[i] = random.Next(0, 1000);

                Console.WriteLine(entities.h[i] + entities.w[i]);

                //entities.sum[i] = Math.Sqrt(entities.h[i])
                //    + Math.Sqrt(entities.w[i]);
                //Console.WriteLine($"SoA Sqr[{i}]: {entities.sum[i]}");
            }
        }
    }
}
