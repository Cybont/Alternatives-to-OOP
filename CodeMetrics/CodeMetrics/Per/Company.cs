namespace StocksOODvsDOD
{
    public class Company
    {
        public Company(string id, string name, int stocksIssued)
        {
            ID = id;
            Name = name;
            StocksIssued = stocksIssued;
        }

        public string ID { get; }
        public string Name { get; }
        public int StocksIssued { get; }
    }
}