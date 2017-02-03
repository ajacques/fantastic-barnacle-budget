using System;

namespace BarnacleBudget.Models
{
    /// <summary>
    /// Represents a block of stock that could have been purchased.
    /// Correlates 1:M to a set of transactions for a given company in a given day.
    /// </summary>
    public class StockLot
    {
        public StockLot(string ticker, DateTime firstDate, decimal firstPrice, decimal lastLotValue)
        {
            Ticker = ticker;
            FirstDate = firstDate;
            FirstPrice = firstPrice;
            LastValue = lastLotValue;
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
        /// <summary>
        /// Gets the current value of the stock lot based on the last trade price.
        /// 
        /// </summary>
        public decimal LastValue
        {
            get;
            private set;
        }

        public decimal GrowthRatio
        {
            get
            {
                if (FirstPrice == 0)
                {
                    return 0;
                }
                return LastValue / FirstPrice;
            }
        }

        public decimal Growth
        {
            get
            {
                if (FirstPrice == 0)
                {
                    return 1;
                }
                return (LastValue - FirstPrice) / FirstPrice;
            }
        }
    }
}
