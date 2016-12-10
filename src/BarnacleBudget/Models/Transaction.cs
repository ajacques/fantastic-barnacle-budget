using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarnacleBudget.Models
{
    public class Transaction
    {
        private static IDictionary<string, string> tickerLookup;

        static Transaction()
        {
            tickerLookup = new Dictionary<string, string>();
            tickerLookup.Add("Shake Shack", "SHAK");
            tickerLookup.Add("Whole Foods", "WFC");
            tickerLookup.Add("Amazon", "AMZN");
        }

        public Transaction(string name, DateTime date, decimal amount)
        {
            Name = name;
            Date = date;
            Amount = amount;
        }

        public string Name
        {
            get;
            private set;
        }
        public decimal Amount
        {
            get;
            private set;
        }

        public DateTime Date
        {
            get;
            private set;
        }

        public string ProbableStockTicket()
        {
            if (!tickerLookup.ContainsKey(Name))
            {
                return null;
            }

            return tickerLookup[Name];
        }
    }
}
