using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealDODSpace
{
    public struct StockTradeData
    {
        public string[] TradesId;
        public double[] TradesPrice;
        public int[] TradesAmount;
        public Companies[] CompanyList;
    }

    public struct Companies
    {
        public Company Company;
        public double Average;
    }

    public struct Company
    {
        public string Id;
        public string Name;
        public int StockIsIssued;
    }

    public struct StockFunctions
    {
        private static Random _rng = new Random();

        public StockTradeData StockTradeInit(int noOfTrades)
        {
            StockTradeData stockTradeData = new StockTradeData();
            stockTradeData.TradesId = new string[noOfTrades];
            stockTradeData.TradesPrice = new double[noOfTrades];
            stockTradeData.TradesAmount = new int[noOfTrades];
            stockTradeData.CompanyList = new Companies[5];

            Company NOVO = new Company {Id = "NOVO" };
            stockTradeData.CompanyList[0].Company = NOVO;
            Company COLO = new Company { Id = "COLO" };
            stockTradeData.CompanyList[1].Company = COLO;
            Company DSV = new Company { Id = "DSV" };
            stockTradeData.CompanyList[2].Company = DSV;
            Company DABA = new Company { Id = "DABA" };
            stockTradeData.CompanyList[3].Company = DABA;
            Company GENM = new Company { Id = "GENM" };
            stockTradeData.CompanyList[4].Company = GENM;

            return stockTradeData;
        }

        public void GenerateTrades(int noOfTrades, StockTradeData stockTradeData)
        {
            _rng = new Random(noOfTrades);

            for (int i = 0; i < noOfTrades; i++)
            {
                stockTradeData.TradesId[i] = GenerateCompany(stockTradeData).Id;
                stockTradeData.TradesPrice[i] = GeneratePrice();
                stockTradeData.TradesAmount[i] = GenerateAmount();
            }
        }

        public Company GenerateCompany(StockTradeData stockTradeData)
        {
            return stockTradeData.CompanyList[_rng.Next(stockTradeData.CompanyList.Length)].Company;
        }

        private double GeneratePrice(double min = 0, double max = 1000)
        {
            return min + ((max - min) * _rng.NextDouble());
        }

        private int GenerateAmount(int min = 0, int max = 100)
        {
            return _rng.Next(min, max);
        }

        public Companies[] CalcAverages(int noOfTrades, StockTradeData stockTradeData)
        {
            Companies[] ids = new Companies[5];

            int[] tradeCount = new int[5];
            double[] averages = new double[5];

            ids[0].Company.Id = "NOVO";
            ids[1].Company.Id = "COLO";
            ids[2].Company.Id = "DSV";
            ids[3].Company.Id = "DABA";
            ids[4].Company.Id = "GENM";

            for (int i = 0; i < noOfTrades; i++)
            {
                int index = 0;
                while (stockTradeData.TradesId[i] != ids[index].Company.Id) index++;

                averages[index] += stockTradeData.TradesAmount[i] * stockTradeData.TradesPrice[i];
                tradeCount[index] += stockTradeData.TradesAmount[i];
            }

            Companies[] Averages = new Companies[5];

            for (int i = 0; i < ids.Length; i++)
            {
                Averages[i].Company.Id = ids[i].Company.Id;
                Averages[i].Average = averages[i] / tradeCount[i];
            }

            return Averages;
        }
    }
}

