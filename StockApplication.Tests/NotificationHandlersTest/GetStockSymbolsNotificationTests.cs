using AutoMapper;
using Moq;
using StockApplication.Data.Entities;
using StockApplication.Data.Models;
using StockApplication.Data.Respository.interfaces;
using StockApplication.Domain.Messages;
using StockApplication.Domain.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace StockApplication.Tests.NotificationHandlersTest
{
    public class GetStockSymbolsNotificationTests
    {

        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<IStockRepository> _mockStockRepository;

        public GetStockSymbolsNotificationTests()
        {

            _mockMapper = new Mock<IMapper>();
            _mockStockRepository = new Mock<IStockRepository>();
        }

        [Fact]
        public async Task GetStockSymbolsNotification_For_ARangeOfSymbols()
        {
            //Arrange
            IEnumerable<StockSymbol> stockSymbols = new List<StockSymbol>()
            {
                new StockSymbol()
                {
                    TickerName = "ABB"
                },
                new StockSymbol()
                {
                    TickerName = "BBB"
                }
            };

            IEnumerable<TickerSymbol> tickerSymbols = new List<TickerSymbol>()
            {
                new TickerSymbol()
                {
                    Name = "ABB"
                },
                 new TickerSymbol()
                {
                    Name = "BBB"
                }
            };

            IEnumerable<StockEntity> stockEntity = new List<StockEntity>()
            {
                new StockEntity()
                {
                    StockDate = DateTime.Now,
                    BrokerId = 101,
                    StockPrice = 13,
                    StockShares = 21,
                    StockSymbol = "ABB"
                },
                new StockEntity()
                {
                    StockDate = DateTime.Now,
                    BrokerId = 101,
                    StockPrice = 13,
                    StockShares = 21,
                    StockSymbol = "BBB"
                }

            };

            var request = new StockSymbolRequest();
            request.SymbolName = stockSymbols;

            _mockMapper.Setup(x => x.Map<IEnumerable<TickerSymbol>>(stockSymbols)).Returns(tickerSymbols);
            _mockStockRepository.Setup(x => x.GetSymbolsAysnc(tickerSymbols)).Returns(Task.FromResult(stockEntity));
            _mockMapper.Setup(x => x.Map<IEnumerable<StockSymbolResponse>>(stockEntity));

            var handler = new GetStockSymbolsNotification(_mockStockRepository.Object, _mockMapper.Object);
            var result =  await handler.Handle(request, CancellationToken.None);

            Assert.NotNull(result);
            Assert.IsType<StockSymbolResponse[]>(result);

        }
    }
}
