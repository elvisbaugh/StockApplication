using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApplication.Domain.Messages
{
    public class AllRequest : IRequest<IEnumerable<StockSymbolResponse>>
    {
        public string All { get; set; }
    }
}
