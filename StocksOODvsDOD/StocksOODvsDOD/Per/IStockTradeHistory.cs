using System.Collections.Generic;

namespace StocksOODvsDOD
{
    public interface IStockTradeHistory
    {
        Dictionary<string, double> GetAverages();
    }
}