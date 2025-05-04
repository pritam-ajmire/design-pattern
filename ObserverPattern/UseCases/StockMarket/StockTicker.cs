using System;
using System.Collections.Generic;
using ObserverPattern.Core;
using ObserverPattern.Core.NotificationStrategies;

namespace ObserverPattern.UseCases.StockMarket;

/// <summary>
/// Represents a stock ticker that provides real-time stock price updates.
/// </summary>
public class StockTicker : BaseSubject<StockTicker>
{
    private readonly Dictionary<string, StockData> _stocks = new();

    public StockTicker(INotificationStrategy<StockTicker> strategy) : base(strategy)
    {
    }

    public IReadOnlyDictionary<string, StockData> Stocks => _stocks;

    /// <summary>
    /// Updates the price of a stock and notifies observers.
    /// </summary>
    public void UpdateStock(string symbol, decimal price, decimal change)
    {
        if (_stocks.TryGetValue(symbol, out var stockData))
        {
            stockData.Price = price;
            stockData.Change = change;
            stockData.LastUpdate = DateTime.Now;
        }
        else
        {
            _stocks[symbol] = new StockData
            {
                Symbol = symbol,
                Price = price,
                Change = change,
                LastUpdate = DateTime.Now
            };
        }
        
        // Notify observers of the price change
        Notify();
    }
}

/// <summary>
/// Represents data for a single stock.
/// </summary>
public class StockData
{
    public string Symbol { get; set; }
    public decimal Price { get; set; }
    public decimal Change { get; set; }
    public DateTime LastUpdate { get; set; }
}
