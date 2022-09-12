using AutoMapper;
using Moq;
using StockApplication.Data.Entities;
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
    public class GetAllStocksNotificationHandlerTests
    {
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<IStockRepository> _mockStockRepository;

        public GetAllStocksNotificationHandlerTests()
        {

            _mockMapper = new Mock<IMapper>();
            _mockStockRepository = new Mock<IStockRepository>();
        }

        [Fact]
        public async Task CanGetAllStocksNotificationHandlers()
        {
            //Arrange
            IEnumerable<StockSymbolResponse> stockResponse = new List<StockSymbolResponse>()
            {
                new StockSymbolResponse()
                {
                    StockDate = DateTime.Now,
                    BrokerId = 101,
                    StockPrice = 13,
                    StockShares = 21,
                    StockSymbol = "ABB"
                },
                new StockSymbolResponse()
                {
                    StockDate = DateTime.Now,
                    BrokerId = 101,
                    StockPrice = 13,
                    StockShares = 21,
                    StockSymbol = "AAA"
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
                    StockSymbol = "AAA"
                }

            };

            _mockStockRepository.Setup(x => x.GetAllStocks()).Returns(Task.FromResult(stockEntity));
            _mockMapper.Setup(x => x.Map<IEnumerable<StockSymbolResponse>>(stockEntity)).Returns(stockResponse);

            var handler = new GetAllStocksNotificationHandler(_mockStockRepository.Object, _mockMapper.Object);
            var result = await handler.Handle(It.IsAny<AllRequest>(), CancellationToken.None);

            Assert.NotNull(result);
            Assert.Equal(stockResponse, result);
        }

    }
}
