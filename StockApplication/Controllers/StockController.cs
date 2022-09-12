using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockApplication.Domain.Messages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StockController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("stockData")]
        public async Task StockData([FromBody] StockTickData stockTickData)
        {
            await _mediator.Send(stockTickData);
        }

        [HttpGet("tickers")]
        public async Task<IActionResult>GetTickerSymbols(StockSymbolRequest symbols)
        {
            var response = await _mediator.Send(symbols);

            return Ok(response);
        }

        [HttpGet("symbol")]
        public async Task<IActionResult> GetSymbol(StockSymbol symbol)
        {
            var response = await _mediator.Send(symbol);

            return Ok(response);
        }

        [HttpGet("allstocks")]
        public async Task<IActionResult> GetAllSymbol([FromQueryAttribute] AllRequest request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }
    }
}
