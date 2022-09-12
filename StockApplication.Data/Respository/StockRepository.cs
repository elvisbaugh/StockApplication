using AutoMapper;
using StockApplication.Data.Context;
using StockApplication.Data.Entities;
using StockApplication.Data.Models;
using StockApplication.Data.Respository.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApplication.Data.Respository
{
    public class StockRepository: IStockRepository
    {
        private readonly StockDataContext _stockDataContext;

        public StockRepository(StockDataContext stockDataContext)
        {
            _stockDataContext = stockDataContext;
        }

        public async Task AddNewData(StockEntity stockEntity)
        {
           _stockDataContext.Stock.Add(stockEntity);
           await  _stockDataContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<StockEntity>> GetSymbolsAysnc(IEnumerable<TickerSymbol> tickerSymbols)
        {

            var symbols = from name in tickerSymbols
                          join symbol in _stockDataContext.Stock
                          on name.Name equals symbol.StockSymbol
                          select symbol;

            return await Task.FromResult(symbols);
        }

        public async Task<IEnumerable<StockEntity>> GetAllStocks()
        {
            return await Task.FromResult( _stockDataContext.Stock.ToList()); 
        }

        public async Task<StockEntity> GetStock(string stock)
        {
            var data  = _stockDataContext.Stock.Where(x => x.StockSymbol.Equals(stock)).FirstOrDefault();           

            return await Task.FromResult(data);
        }
    }
}
