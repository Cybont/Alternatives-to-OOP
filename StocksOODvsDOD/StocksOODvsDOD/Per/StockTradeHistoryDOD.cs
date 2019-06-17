namespace StocksOODvsDOD
{
    public class StockTradeHistoryDOD : StockTradeHistoryBase
    {
        private int _noOfTrades;
        private string[] _tradesId;
        private double[] _tradesPrice;
        private int[] _tradesAmount;

        public StockTradeHistoryDOD(int noOfTrades) : base(noOfTrades)
        {
            _noOfTrades = noOfTrades;
        }

        protected override void InitDataStructures(int noOfTrades)
        {
            _tradesId = new string[noOfTrades];
            _tradesPrice = new double[noOfTrades];
            _tradesAmount = new int[noOfTrades];
        }

        protected override void GenerateTrade(int index)
        {
            _tradesId[index] = GenerateCompany().ID;
            _tradesPrice[index] = GeneratePrice();
            _tradesAmount[index] = GenerateAmount();
        }

        protected override void CalcAverages()
        {
            string[] ids = new string[5];
            int[] tradeCount = new int[5];
            double[] averages = new double[5];

            ids[0] = "NOVO";
            ids[1] = "COLO";
            ids[2] = "DSV";
            ids[3] = "DABA";
            ids[4] = "GENM";

            for (int i = 0; i < _noOfTrades; i++)
            {
                int index = 0;
                while (_tradesId[i] != ids[index]) index++;

                averages[index] += _tradesAmount[i] * _tradesPrice[i];
                tradeCount[index] += _tradesAmount[i];
            }

            for (int i = 0; i < ids.Length; i++)
            {
                _averages[ids[i]] = averages[i] / tradeCount[i];
            }
        }
    }
}