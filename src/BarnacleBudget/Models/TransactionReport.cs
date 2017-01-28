using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using System.Net.Http;
using CsvHelper;

namespace BarnacleBudget.Models
{
    public class TransactionReport
    {
        private List<Transaction> transactions;

        public TransactionReport()
        {
            transactions = new List<Transaction>();
        }

        public IEnumerable<StockLot> ComputePortfolio()
        {
            // For each unique stock ticker, group into daily buckets
            var campaign = from t in transactions
                           where t.ProbableStockTicket() != null
                           group t by t.ProbableStockTicket() into ticker
                           select new
                           {
                               Ticker = ticker.Key,
                               MinDate = ticker.Min(f => f.Date),
                               Dates = from date in ticker
                                       group date by date.Date into dates
                                       select new
                                       {
                                           Date = dates.Key,
                                           TotalDailyValue = dates.Sum(f => f.Amount)
                                       }
                           };

            IList<StockLot> lots = new List<StockLot>();
            using (HttpClient client = new HttpClient())
            {
                foreach (var stock in campaign)
                {
                    string domain = "http://ichart.finance.yahoo.com/table.csv";
                    Uri uri = new Uri($"{domain}?s={stock.Ticker}&a={stock.MinDate.Month - 1}&b={stock.MinDate.Day}&c={stock.MinDate.Year}&d={DateTime.Now.Month - 1}&e={DateTime.Now.Day}&={DateTime.Now.Year}&g=d");
                    Stream stream = client.GetAsync(uri).Result.Content.ReadAsStreamAsync().Result;
                    CsvParser parser = new CsvParser(new StreamReader(stream));
                    parser.Read();
                    decimal lastPrice = 0;
                    IDictionary<DateTime, decimal> closePrices = new Dictionary<DateTime, decimal>();
                    while (true)
                    {
                        string[] parts = parser.Read();
                        if (parts == null)
                        {
                            break;
                        }

                        DateTime date = DateTime.ParseExact(parts[0], "yyyy-MM-dd", CultureInfo.CurrentCulture);
                        decimal close = Decimal.Parse(parts[4]);
                        closePrices.Add(date, close);
                        if (lastPrice == 0)
                        {
                            lastPrice = close;
                        }
                    }
                    foreach (var date in stock.Dates)
                    {
                        int walk = 1;
                        DateTime newDate = date.Date;
                        while (!closePrices.ContainsKey(newDate))
                        {
                            newDate = newDate.AddDays(walk);
                            walk = (walk + Math.Sign(walk)) * -1;
                        }
                        decimal todayValue = Math.Round(((lastPrice / closePrices[newDate]) * date.TotalDailyValue),2);
                        lots.Add(new StockLot(stock.Ticker, date.Date, date.TotalDailyValue, todayValue));
                    }
                }
            }

            return lots;
        }

        public static TransactionReport FromCsvStream(Stream stream)
        {
            TransactionReport report = new TransactionReport();
            CsvParser reader = new CsvParser(new StreamReader(stream));
            reader.Read();
            while (true)
            {
                string[] parts = reader.Read();
                if (parts == null)
                {
                    break;
                }
                DateTime date = DateTime.ParseExact(parts[0], "M/dd/yyyy", CultureInfo.CurrentCulture);
                string name = parts[1];
                decimal amount = Decimal.Parse(parts[3]) * (parts[4] == "debit" ? 1 : -1);
                report.transactions.Add(new Transaction(name, date, amount));
            }
            return report;
        }
    }
}
