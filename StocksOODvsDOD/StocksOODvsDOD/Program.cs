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

            //Console.ReadKey();

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




        #region Real DOD

        private static void DOD(int noOfTrades)
        {
            StockTradeData stockTradeData = new StockTradeData();
            StockFunctions F = new StockFunctions();
            F.StockTradeInit(noOfTrades, stockTradeData);
           
        }

        #endregion
    }
}
