using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockApplication.Domain.Messages
{
    public class StockTickData : IRequest
    {
        public string Symbol { get; set; }
        public decimal Price { get; set; }
        public decimal Shares { get; set; }
        public int BrokerId { get; set; }
        public DateTime Created { get; set; }

    }
}
