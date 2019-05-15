using System;
using System.Collections.Generic;

namespace StocksOODvsDOD
{
    public abstract class StockTradeHistoryBase : IStockTradeHistory
    {
        protected static Random _rng;
        protected CompanyCatalog _companies;
        protected Dictionary<string, double> _averages;
        protected Dictionary<string, int> _tradeCount;

        protected StockTradeHistoryBase(int noOfTrades)
        {
            _companies = new CompanyCatalog();
            _averages = new Dictionary<string, double>();
            _tradeCount = new Dictionary<string, int>();

            InitDataStructures(noOfTrades);
            GenerateTrades(noOfTrades);
        }

        public Dictionary<string, double> GetAverages()
        {
            InitAverages();
            InitTradeCount();
            CalcAverages();

            return _averages;
        }

        protected abstract void InitDataStructures(int noOfTrades);

        protected abstract void GenerateTrade(int index);

        protected abstract void CalcAverages();

        private void GenerateTrades(int noOfTrades)
        {
            _rng = new Random(noOfTrades);
            for (int i = 0; i < noOfTrades; i++)
            {
                GenerateTrade(i);
            }
        }

        protected void InitAverages()
        {
            _averages.Clear();
            foreach (string id in _companies.Ids)
            {
                _averages.Add(id, 0.0);
            }
        }

        protected void InitTradeCount()
        {
            _tradeCount.Clear();
            foreach (string id in _companies.Ids)
            {
                _tradeCount.Add(id, 0);
            }
        }

        protected Company GenerateCompany()
        {
            return _companies.Lookup(_rng.Next(_companies.Count));
        }

        protected double GeneratePrice(double min = 0, double max = 1000)
        {
            return min + ((max - min) * _rng.NextDouble());
        }

        protected int GenerateAmount(int min = 0, int max = 100)
        {
            return _rng.Next(min, max);
        }
    }
}