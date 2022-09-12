using AutoMapper;
using MediatR;
using StockApplication.Data.Entities;
using StockApplication.Data.Models;
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
    public class GetStockSymbolsNotification : IRequestHandler<StockSymbolRequest, IEnumerable<StockSymbolResponse>>
    {
        private readonly IStockRepository _stockRepository;
        private readonly IMapper _mapper;
        public GetStockSymbolsNotification(IStockRepository stockRepository, IMapper mapper)
        {
            _stockRepository = stockRepository;
            _mapper = mapper;
        }       

        public async Task<IEnumerable<StockSymbolResponse>> Handle(StockSymbolRequest request, CancellationToken cancellationToken)
        {
            var symbols = _mapper.Map<IEnumerable<TickerSymbol>>(request.SymbolName);

            var rangeOfSymbols = await _stockRepository.GetSymbolsAysnc(symbols);

            var details = _mapper.Map<IEnumerable<StockSymbolResponse>>(rangeOfSymbols);

            return details;
        }
    }
}
