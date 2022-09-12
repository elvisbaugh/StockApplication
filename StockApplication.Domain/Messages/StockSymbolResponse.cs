using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApplication.Domain.Messages
{
    public class StockSymbolResponse
    {
        public string StockSymbol { get; set; }
        public decimal StockPrice { get; set; }
        public decimal StockShares { get; set; }
        public int BrokerId { get; set; }
        public DateTime StockDate { get; set; }
    }
}
