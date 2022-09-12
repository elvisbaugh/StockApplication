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
    public class GetAllStocksNotificationHandler : IRequestHandler<AllRequest, IEnumerable<StockSymbolResponse>>
    {
        private readonly IStockRepository _stockRepository;
        private readonly IMapper _mapper;

        public GetAllStocksNotificationHandler(IStockRepository stockRepository, IMapper mapper)
        {
            _stockRepository = stockRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StockSymbolResponse>> Handle(AllRequest request, CancellationToken cancellationToken)
        {
            var allStock = await _stockRepository.GetAllStocks();
            var stocks = _mapper.Map<IEnumerable<StockSymbolResponse>>(allStock);

            return stocks;
        }
    }
}
