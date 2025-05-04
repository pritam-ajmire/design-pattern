using System;
using ObserverPattern.UseCases.WeatherMonitoring;
using ObserverPattern.UseCases.StockMarket;

namespace ObserverPattern;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Observer Pattern Demonstrations");
        Console.WriteLine("==============================");
        
        // Run the Weather Monitoring demo
        WeatherMonitoringDemo.Run();
        
        Console.WriteLine("\nPress any key to continue to the next demo...");
        Console.ReadKey(true);
        
        // Run the Stock Market demo
        StockMarketDemo.Run();
        
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey(true);
    }
}