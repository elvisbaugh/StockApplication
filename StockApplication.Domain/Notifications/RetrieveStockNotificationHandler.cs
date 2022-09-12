using AutoMapper;
using MediatR;
using StockApplication.Data.Respository.interfaces;
using StockApplication.Domain.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StockApplication.Domain.Notifications
{
    public class RetrieveStockNotificationHandler : IRequestHandler<StockSymbol, StockSymbolResponse>
    {
        private readonly IStockRepository _stockRepository;
        private readonly IMapper _mapper;

        public RetrieveStockNotificationHandler(IStockRepository stockRepository, IMapper mapper)
        {
            _stockRepository = stockRepository;
            _mapper = mapper;
        }

        public async Task<StockSymbolResponse> Handle(StockSymbol request, CancellationToken cancellationToken)
        {
            var data = await _stockRepository.GetStock(request.TickerName);

            if (data == null)
            {
                return null;
            }
            var stockData = _mapper.Map<StockSymbolResponse>(data);

            return stockData;
        }
    }
}
