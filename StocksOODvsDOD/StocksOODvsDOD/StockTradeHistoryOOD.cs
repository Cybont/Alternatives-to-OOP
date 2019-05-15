using System.Collections.Generic;
using System.Linq;
// ReSharper disable ForCanBeConvertedToForeach

namespace StocksOODvsDOD
{
    public class StockTradeHistoryOOD : StockTradeHistoryBase
    {
        private List<StockTrade> _trades;

        public StockTradeHistoryOOD(int noOfTrades) : base(noOfTrades)
        {
        }

        protected override void InitDataStructures(int noOfTrades)
        {
            _trades = new List<StockTrade>();
        }

        protected override void GenerateTrade(int index)
        {
            _trades.Add(new StockTrade(GenerateCompany(), GeneratePrice(), GenerateAmount()));
        }

        protected override void CalcAverages()
        {
            foreach (StockTrade trade in _trades)
            {
                _tradeCount[trade.CompanyTraded.ID] += trade.Amount;
                _averages[trade.CompanyTraded.ID] += trade.Price * trade.Amount;
            }

            List<string> ids = _averages.Keys.ToList();
            for (int i = 0; i < ids.Count; i++)
            {
                _averages[ids[i]] = _averages[ids[i]] / _tradeCount[ids[i]];
            }
        }
    }
}