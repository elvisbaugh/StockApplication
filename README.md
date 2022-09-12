# StockApplication

 This project exposes an endpoint that will recieve data from a broker or several brokers to which this endpoint is expose to.
 Once data is received, by using Mediatr patter it will create a notification for the specific class to process the new data recieved
 and store into the in-memory database.
 
 This MVP project exposes four endpoints:
 
 Endpoint 1:
 Main endpoint to recieve tick data
 https://localhost:44386/api/stock/stockData
 [POST]
 
 body:
 ```json
 {
   "symbol": "BDOL" ,
   "price": 1.25,
   "shares": 1.25,
   "brokerId": 101,
   "created":"2017-09-08T19:01:55"

}
```
This endpoint would simulate live data from a broker who would send live tick data to the services.

Endpoint 2:
[GET]
https://localhost:44386/api/stock/symbol

body:
```json
{
   "symbolName":"BDOL"
}
```

This endpoint simulates getting data from DB via it's ticker symbol.

Endpoint 3:
[GET]
https://localhost:44386/api/stock/allstocks?all=all

This endpoint retrieves all stock details that are on the market
e.g of results
```json
[
    {
        "stockSymbol": "BDOL",
        "stockPrice": 1.25,
        "stockShares": 1.25,
        "brokerId": 101,
        "stockDate": "2017-09-08T19:01:55"
    },
    {
        "stockSymbol": "ADOL",
        "stockPrice": 1.25,
        "stockShares": 1.25,
        "brokerId": 101,
        "stockDate": "2017-09-08T19:01:55"
    },
    {
        "stockSymbol": "CDOL",
        "stockPrice": 1.25,
        "stockShares": 1.25,
        "brokerId": 101,
        "stockDate": "2017-09-08T19:01:55"
    }
]
```

Endpoint 4:
[GET]
https://localhost:44386/api/stock/tickers

body
```json
{
    "symbolName":[
        {
            "tickerName":"BDOL"
        },
        {
            "tickerName": "ADOL"
        }
    ]
}
```json

This endpoints returns stock tickers base on a spexified range of ticker symbols.

NOTE*: To play around with the other endpoints you will first have to make several request to the POST endpoint to populate the in-memory DB in order to use the 
other endpoints that will provide useful data.


