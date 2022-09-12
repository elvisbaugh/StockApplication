using AutoMapper;
using MediatR;
using StockApplication.Data.Entities;
using StockApplication.Data.Respository.interfaces;
using StockApplication.Domain.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StockApplication.Domain.Notifications
{
    public class AddStockDataNotificationHandler : IRequestHandler<StockTickData>
    {
        private readonly IStockRepository _stockRepository;
        private readonly IMapper _mapper;
        public AddStockDataNotificationHandler(IStockRepository stockRepository, IMapper mapper)
        {
            _stockRepository = stockRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(StockTickData request, CancellationToken cancellationToken)
        { 
            var data = _mapper.Map<StockEntity>(request);

            await _stockRepository.AddNewData(data);

            return Unit.Value;
        }
    }
}
