using System;
using System.Diagnostics;

namespace StocksOODvsDOD
{
    class Program
    {
        private static Stopwatch watch = new Stopwatch();

        static void Main(string[] args)
        {
            int noOfTrades = 1000000;

            StockTradeHistoryOOD sthOOD = new StockTradeHistoryOOD(noOfTrades);
            StockTradeHistoryDOD sthDOD = new StockTradeHistoryDOD(noOfTrades);

            MeasureAverageCalc("Object-Oriented approach", sthOOD);
            MeasureAverageCalc("Data-Oriented approach", sthDOD);

            Console.ReadKey();
        }

        private static void MeasureAverageCalc(string header, IStockTradeHistory sth)
        {          
            watch.Restart();
            sth.GetAverages();
            long mSecs = watch.ElapsedMilliseconds;

            Console.WriteLine($"{header} took {mSecs} msecs.");
        }

        private static void PrintAverages(string header, IStockTradeHistory sth)
        {
            Console.WriteLine(header);
            foreach (var average in sth.GetAverages())
            {
                Console.WriteLine($"{average.Key} @ {average.Value:F3}");
            }
            Console.WriteLine();
        }
    }
}
