using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealDODSpace
{
    //public struct Company
    //{
    //    public string Id;
    //    public string Name;
    //    public int StockIsIssued;
    //}

    //public struct Companies
    //{
    //    public Company[] CompanyList;
    //    public Averages[] averages;
    //}

    public struct StockTradeData
    {
        public string[] TradesId;
        public double[] TradesPrice;
        public int[] TradesAmount;
    }

    public struct Averages
    {
        public string Id;
        public double Average;
    }

    public struct StockFunctions
    {
        private static Random _rng;

        public void StockTradeInit(int noOfTrades, StockTradeData stockTradeData)
        {
            stockTradeData.TradesId = new string[noOfTrades];
            stockTradeData.TradesPrice = new double[noOfTrades];
            stockTradeData.TradesAmount = new int[noOfTrades];
        }

        public void GenerateTrades(int noOfTrades, StockTradeData stockTradeData)
        {
            _rng = new Random(noOfTrades);
            for (int i = 0; i < noOfTrades; i++)
            {
                stockTradeData.TradesId[i] = GenerateCompany().ID;
                stockTradeData.TradesPrice[i] = GeneratePrice();
                stockTradeData.TradesAmount[i] = GenerateAmount();
            }
        }

        public double GeneratePrice(double min = 0, double max = 1000)
        {
            return min + ((max - min) * _rng.NextDouble());
        }

        public int GenerateAmount(int min = 0, int max = 100)
        {
            return _rng.Next(min, max);
        }

        public Averages[] CalcAverages(int noOfTrades, StockTradeData stockTradeData)
        {
            string[] ids = new string[5];
            int[] tradeCount = new int[5];
            double[] averages = new double[5];

            ids[0] = "NOVO";
            ids[1] = "COLO";
            ids[2] = "DSV";
            ids[3] = "DABA";
            ids[4] = "GENM";

            for (int i = 0; i < noOfTrades; i++)
            {
                int index = 0;
                while (stockTradeData.TradesId[i] != ids[index]) index++;

                averages[index] += stockTradeData.TradesAmount[i] * stockTradeData.TradesPrice[i];
                tradeCount[index] += stockTradeData.TradesAmount[i];
            }

            Averages[] Averages = new Averages[5];

            for (int i = 0; i < ids.Length; i++)
            {
                Averages[i].Id = ids[i];
                Averages[i].Average = averages[i] / tradeCount[i];
            }

            return Averages;
        }
    }
}

