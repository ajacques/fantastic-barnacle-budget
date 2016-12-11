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
            tickerLookup.Add("Amazon.com", "AMZN");
            tickerLookup.Add("Target", "TGT");
            tickerLookup.Add("McDonald's", "MCD");
            tickerLookup.Add("Chipotle", "CMG");
            tickerLookup.Add("QFC", "KR");
            tickerLookup.Add("Netflix", "NFLX");
            tickerLookup.Add("GoDaddy.com", "GDDY");
            tickerLookup.Add("BP", "BP");
            tickerLookup.Add("Pizza Hut", "YUM");
            tickerLookup.Add("Delta", "DAL");
            tickerLookup.Add("American Tx", "AAL");
            tickerLookup.Add("Starbucks", "SBUX");
            tickerLookup.Add("Ea Origin Com", "EA");
            tickerLookup.Add("Nordstrom", "JWN");
            tickerLookup.Add("American Ai", "AAL");
            tickerLookup.Add("Courtyard", "MAR");
            tickerLookup.Add("Westin", "MAR");
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
