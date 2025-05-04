using System;
using System.Threading;
using ObserverPattern.Core.NotificationStrategies;

namespace ObserverPattern.UseCases.StockMarket;

/// <summary>
/// Demonstrates the Stock Market use case with parallel notification strategy.
/// </summary>
public class StockMarketDemo
{
    public static void Run()
    {
        Console.WriteLine("\n=== Stock Market Demo (Parallel Notification) ===\n");
        
        // Create StockTicker with parallel notification strategy for better performance
        var stockTicker = new StockTicker(new ParallelStrategy<StockTicker>());
        
        // Create observers
        var priceDisplay = new PriceDisplay();
        var alertService = new AlertService(3.0m); // Alert on 3% change
        var tradingBot = new TradingBot();
        
        // Register observers
        stockTicker.Attach(priceDisplay);
        stockTicker.Attach(alertService);
        stockTicker.Attach(tradingBot);
        
        // Simulate stock updates
        SimulateStockUpdates(stockTicker);
        
        Console.WriteLine("\nChanging to Message Queue notification strategy...\n");
        
        // Switch to message queue strategy
        using (var queueStrategy = new MessageQueueStrategy<StockTicker>())
        {
            stockTicker.SetNotificationStrategy(queueStrategy);
            
            // Simulate more stock updates with the new strategy
            SimulateStockUpdates(stockTicker);
        }
    }

    private static void SimulateStockUpdates(StockTicker stockTicker)
    {
        // Initial stock prices
        stockTicker.UpdateStock("AAPL", 150.25m, 0.0m);
        stockTicker.UpdateStock("MSFT", 290.75m, 0.0m);
        stockTicker.UpdateStock("GOOG", 2750.10m, 0.0m);
        stockTicker.UpdateStock("AMZN", 3300.50m, 0.0m);
        
        Thread.Sleep(1000);
        
        // First update
        stockTicker.UpdateStock("AAPL", 152.50m, 2.25m);
        stockTicker.UpdateStock("MSFT", 288.30m, -2.45m);
        stockTicker.UpdateStock("GOOG", 2780.75m, 30.65m);
        stockTicker.UpdateStock("AMZN", 3275.25m, -25.25m);
        
        Thread.Sleep(1000);
        
        // Second update
        stockTicker.UpdateStock("AAPL", 149.75m, -2.75m);
        stockTicker.UpdateStock("MSFT", 292.40m, 4.10m);
        stockTicker.UpdateStock("GOOG", 2795.30m, 14.55m);
        stockTicker.UpdateStock("AMZN", 3350.00m, 74.75m);
        
        Thread.Sleep(1000);
        
        // Third update with significant changes to trigger alerts
        stockTicker.UpdateStock("AAPL", 158.25m, 8.50m);
        stockTicker.UpdateStock("MSFT", 280.15m, -12.25m);
        stockTicker.UpdateStock("GOOG", 2820.50m, 25.20m);
        stockTicker.UpdateStock("AMZN", 3290.75m, -59.25m);
    }
}
