using System;
using System.Diagnostics;
using RealDODSpace;

namespace StocksOODvsDOD
{
    class Program
    {
        private static Stopwatch watch = new Stopwatch();

        static void Main(string[] args)
        {
            int noOfTrades = 1000000;

            StockTradeHistoryOOD sthOOD = new StockTradeHistoryOOD(noOfTrades);
            //StockTradeHistoryDOD sthDOD = new StockTradeHistoryDOD(noOfTrades);

            MeasureAverageCalc("(Per) Object-Oriented approach", sthOOD);
            //MeasureAverageCalc("(Per) Data-Oriented approach", sthDOD);
            DOD("(Kimon) Data-Oriented approach", noOfTrades);

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

        private static void DOD(string header, int noOfTrades)
        {
            StockTradeData stockTradeData = new StockTradeData();
            StockFunctions F = new StockFunctions();

            stockTradeData = F.StockTradeInit(noOfTrades);
            F.GenerateTrades(noOfTrades, stockTradeData);

            watch.Restart();

            F.CalcAverages(noOfTrades, stockTradeData);

            long mSecs = watch.ElapsedMilliseconds;

            Console.WriteLine($"{header} took {mSecs} msecs.");
        }
    }
}
