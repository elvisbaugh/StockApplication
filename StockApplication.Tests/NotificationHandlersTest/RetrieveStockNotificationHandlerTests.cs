using AutoMapper;
using Moq;
using StockApplication.Data.Entities;
using StockApplication.Data.Respository.interfaces;
using StockApplication.Domain.Messages;
using StockApplication.Domain.Notifications;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace StockApplication.Tests.NotificationHandlersTest
{
    public class RetrieveStockNotificationHandlerTests
    {
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<IStockRepository> _mockStockRepository;

        public RetrieveStockNotificationHandlerTests()
        {
            _mockMapper = new Mock<IMapper>();
            _mockStockRepository = new Mock<IStockRepository>();
        }

        [Fact]
        public async Task ShouldReturnAStockData_WhenTickerSymbolIsProvided()
        {
            //Arrange
            var stockResponse = new StockSymbolResponse() {
                StockDate = DateTime.Now,
                BrokerId = 101,
                StockPrice = 13,
                StockShares = 21,
                StockSymbol = "ABB"
            };
            var stock = new StockEntity()
            {
                StockDate = DateTime.Now,
                BrokerId = 101,
                StockPrice = 13,
                StockShares = 21,
                StockSymbol = "ABB"
            };

            var stockRequest = new StockSymbol()
            {
                TickerName = "ABB"
            };

            _mockStockRepository.Setup(x => x.GetStock("ABB")).Returns(Task.FromResult(stock));
            _mockMapper.Setup(x => x.Map<StockSymbolResponse>(stock)).Returns(stockResponse);

            //Act
            var handler = new RetrieveStockNotificationHandler(_mockStockRepository.Object, _mockMapper.Object);
            var response = await handler.Handle(stockRequest, CancellationToken.None);

            //Assert
            Assert.NotNull(response);
            Assert.Equal(stockResponse, response);
        }

    }
}
