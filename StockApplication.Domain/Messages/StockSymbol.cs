using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApplication.Domain.Messages
{
    public class StockSymbol: IRequest<StockSymbolResponse>
    {
        public string TickerName { get; set; }
    }
}
