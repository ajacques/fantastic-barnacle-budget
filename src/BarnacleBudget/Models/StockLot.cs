using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarnacleBudget.Models
{
    public class StockLot
    {
        public StockLot(string ticker, DateTime firstDate, decimal firstPrice, decimal nowPrice)
        {
            Ticker = ticker;
            FirstDate = firstDate;
            FirstPrice = firstPrice;
            LastPrice = nowPrice;
        }

        public string Ticker
        {
            get;
            private set;
        }
        public DateTime FirstDate
        {
            get;
            private set;
        }

        public decimal FirstPrice
        {
            get;
            private set;
        }
        public decimal LastPrice
        {
            get;
            private set;
        }

        public decimal Growth
        {
            get
            {
                if (FirstPrice == 0)
                {
                    return 1;
                }
                return (LastPrice - FirstPrice) / FirstPrice;
            }
        }
    }
}
