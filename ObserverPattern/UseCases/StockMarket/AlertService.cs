using System;
using System.Collections.Generic;
using ObserverPattern.Core;

namespace ObserverPattern.UseCases.StockMarket;

/// <summary>
/// Alerts when stock prices change beyond a certain threshold.
/// </summary>
public class AlertService : ISubjectObserver<StockTicker>
{
    private readonly Dictionary<string, decimal> _lastPrices = new();
    private readonly decimal _alertThreshold;

    public AlertService(decimal alertThreshold = 5.0m)
    {
        _alertThreshold = alertThreshold;
    }

    public void Update(StockTicker subject)
    {
        foreach (var stock in subject.Stocks.Values)
        {
            // If we've seen this stock before, check for significant changes
            if (_lastPrices.TryGetValue(stock.Symbol, out var lastPrice))
            {
                decimal percentChange = Math.Abs((stock.Price - lastPrice) / lastPrice * 100);
                
                if (percentChange >= _alertThreshold)
                {
                    string direction = stock.Price > lastPrice ? "up" : "down";
                    Console.WriteLine($"ALERT: {stock.Symbol} has moved {direction} by {percentChange:F2}% (${Math.Abs(stock.Price - lastPrice):F2})");
                }
            }
            
            // Update our last known price
            _lastPrices[stock.Symbol] = stock.Price;
        }
    }
}
