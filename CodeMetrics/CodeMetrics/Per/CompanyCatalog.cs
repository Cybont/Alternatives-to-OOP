using System;
using System.Collections.Generic;
using System.Linq;

namespace StocksOODvsDOD
{
    public class CompanyCatalog
    {
        private List<Company> _companies;

        public CompanyCatalog()
        {
            _companies = new List<Company>();
            _companies.Add(new Company("NOVO", "Novo Nordisk", 400000000));
            _companies.Add(new Company("COLO", "Coloplast", 75000000));
            _companies.Add(new Company("DSV", "DSV A/S", 200000000));
            _companies.Add(new Company("DABA", "Danske Bank", 500000000));
            _companies.Add(new Company("GENM", "GenMab", 50000000));
        }

        public int Count
        {
            get { return _companies.Count; }
        }

        public List<string> Ids
        {
            get { return _companies.Select(c => c.ID).ToList(); }
        }

        public Company Lookup(int index)
        {
            if (index < 0 || index >= _companies.Count) throw new ArgumentException($"Illegal index {index}");
            return _companies[index];
        }
    }
}