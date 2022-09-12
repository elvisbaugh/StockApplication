using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApplication.Domain.Messages
{
    public class StockSymbolRequest: IRequest<IEnumerable<StockSymbolResponse>>
    {
        public IEnumerable<StockSymbol> SymbolName { get; set; }
    }
}
