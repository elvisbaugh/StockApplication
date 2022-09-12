using StockApplication.Data.Entities;
using StockApplication.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StockApplication.Data.Respository.interfaces
{
    public interface IStockRepository
    {
        Task AddNewData(StockEntity stockEntity);
        Task<IEnumerable<StockEntity>> GetSymbolsAysnc(IEnumerable<TickerSymbol> tickerSymbols);
        Task<IEnumerable<StockEntity>> GetAllStocks();
        Task<StockEntity> GetStock(string stock);
    }
}
