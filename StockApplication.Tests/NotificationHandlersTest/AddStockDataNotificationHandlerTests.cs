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
    public class AddStockDataNotificationHandlerTests
    {
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<IStockRepository> _mockStockRepository;

        public AddStockDataNotificationHandlerTests()
        {
            _mockMapper = new Mock<IMapper>();
            _mockStockRepository = new Mock<IStockRepository>();
        }

        [Fact]
        public async Task ShouldAddStockDataNewStock()
        {
            //Arrange
            var stockRequest = new StockTickData()
            {
                Created = DateTime.Now,
                BrokerId = 101,
                Price = 13,
                Shares = 21,
                Symbol = "ABB"
            };

            var stockEntity = new StockEntity()
            {
                StockDate = DateTime.Now,
                BrokerId = 101,
                StockPrice = 13,
                StockShares = 21,
                StockSymbol = "ABB"
            };

            _mockMapper.Setup(x => x.Map<StockEntity>(stockRequest)).Returns(stockEntity);
            _mockStockRepository.Setup(x => x.AddNewData(stockEntity));

            //Arrange
            var handler = new AddStockDataNotificationHandler(_mockStockRepository.Object, _mockMapper.Object);
            var _ = await handler.Handle(stockRequest, CancellationToken.None);

            //Assert
            _mockStockRepository.Verify(x => x.AddNewData(It.IsAny<StockEntity>()), Times.Once);
        }
    }
}
