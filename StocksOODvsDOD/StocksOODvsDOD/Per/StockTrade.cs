namespace StocksOODvsDOD
{
    public class StockTrade
    {
        public StockTrade(Company companyTraded, double price, int amount)
        {
            CompanyTraded = companyTraded;
            Price = price;
            Amount = amount;
        }

        public Company CompanyTraded { get; }
        public double Price { get; }
        public int Amount { get; }
    }
}