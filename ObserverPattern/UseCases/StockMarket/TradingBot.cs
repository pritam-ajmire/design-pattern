using System;
using System.Collections.Generic;
using System.Threading;
using ObserverPattern.Core;

namespace ObserverPattern.UseCases.StockMarket;

/// <summary>
/// A simulated trading bot that makes trading decisions based on stock price movements.
/// </summary>
public class TradingBot : ISubjectObserver<StockTicker>
{
    private readonly Dictionary<string, decimal> _lastPrices = new();
    private readonly Dictionary<string, int> _holdings = new();
    private readonly Random _random = new();
    private decimal _cash = 10000m; // Starting with $10,000

    public void Update(StockTicker subject)
    {
        // Simulate some processing time
        Thread.Sleep(50);
        
        foreach (var stock in subject.Stocks.Values)
        {
            // If we've seen this stock before, consider trading
            if (_lastPrices.TryGetValue(stock.Symbol, out var lastPrice))
            {
                // Simple trading strategy: buy if price dropped, sell if price increased
                if (stock.Price < lastPrice && _cash >= stock.Price)
                {
                    int sharesToBuy = (int)Math.Min(5, _cash / stock.Price);
                    if (sharesToBuy > 0)
                    {
                        Buy(stock.Symbol, sharesToBuy, stock.Price);
                    }
                }
                else if (stock.Price > lastPrice && _holdings.TryGetValue(stock.Symbol, out var shares) && shares > 0)
                {
                    int sharesToSell = _random.Next(1, shares + 1);
                    Sell(stock.Symbol, sharesToSell, stock.Price);
                }
            }
            else
            {
                // First time seeing this stock, initialize holdings
                _holdings[stock.Symbol] = 0;
            }
            
            // Update our last known price
            _lastPrices[stock.Symbol] = stock.Price;
        }
    }

    private void Buy(string symbol, int shares, decimal price)
    {
        decimal cost = shares * price;
        _cash -= cost;
        
        if (!_holdings.ContainsKey(symbol))
        {
            _holdings[symbol] = 0;
        }
        
        _holdings[symbol] += shares;
        
        Console.WriteLine($"TradingBot: Bought {shares} shares of {symbol} at ${price:F2} (Total: ${cost:F2})");
        PrintPortfolio();
    }

    private void Sell(string symbol, int shares, decimal price)
    {
        decimal revenue = shares * price;
        _cash += revenue;
        _holdings[symbol] -= shares;
        
        Console.WriteLine($"TradingBot: Sold {shares} shares of {symbol} at ${price:F2} (Total: ${revenue:F2})");
        PrintPortfolio();
    }

    private void PrintPortfolio()
    {
        Console.WriteLine($"TradingBot Portfolio - Cash: ${_cash:F2}, Holdings: {string.Join(", ", GetHoldingsString())}");
    }

    private IEnumerable<string> GetHoldingsString()
    {
        foreach (var holding in _holdings)
        {
            if (holding.Value > 0)
            {
                yield return $"{holding.Key}: {holding.Value}";
            }
        }
    }
}
