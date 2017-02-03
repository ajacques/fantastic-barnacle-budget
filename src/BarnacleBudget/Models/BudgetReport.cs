using System.Collections.Generic;

namespace BarnacleBudget.Models
{
    /// <summary>
    /// Represents report generated from a user's input transaction set.
    /// </summary>
    public class BudgetReport
    {
        public BudgetReport(IEnumerable<StockLot> stockLots)
        {
            StockLots = stockLots;
        }

        /// <summary>
        /// Gets a list of all of the stock units the user could have purchased instead.
        /// </summary>
        public IEnumerable<StockLot> StockLots
        {
            get;
            private set;
        }
    }
}
