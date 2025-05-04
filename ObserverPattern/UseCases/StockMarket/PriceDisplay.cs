using System;
using System.Linq;
using ObserverPattern.Core;

namespace ObserverPattern.UseCases.StockMarket;

/// <summary>
/// Displays current stock prices.
/// </summary>
public class PriceDisplay : ISubjectObserver<StockTicker>
{
    public void Update(StockTicker subject)
    {
        Console.WriteLine("\nCurrent Stock Prices:");
        Console.WriteLine("Symbol\tPrice\t\tChange");
        Console.WriteLine("------\t-----\t\t------");
        
        foreach (var stock in subject.Stocks.Values.OrderBy(s => s.Symbol))
        {
            string changeSymbol = stock.Change >= 0 ? "+" : "";
            Console.WriteLine($"{stock.Symbol}\t${stock.Price:F2}\t\t{changeSymbol}{stock.Change:F2}");
        }
    }
}
