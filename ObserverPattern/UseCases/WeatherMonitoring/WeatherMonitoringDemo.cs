using System;
using System.Threading;
using ObserverPattern.Core.NotificationStrategies;

namespace ObserverPattern.UseCases.WeatherMonitoring;

/// <summary>
/// Demonstrates the Weather Monitoring use case with different notification strategies.
/// </summary>
public class WeatherMonitoringDemo
{
    public static void Run()
    {
        Console.WriteLine("\n=== Weather Monitoring Demo ===\n");

        RunAsyncBasedDemo();
        
        // Sequential notification demo
        RunSequentialDemo();
        
        Console.WriteLine("\nPress any key to continue to the next demo...");
        Console.ReadKey(true);
        
        // Event-based notification demo
        RunEventBasedDemo();
    }

    private static void RunSequentialDemo()
    {
        Console.WriteLine("Sequential Notification Strategy Demo:");
        
        // Create WeatherData with sequential notification strategy
        var weatherData = new WeatherData(new SequentialStrategy<WeatherData>());
        
        // Create displays and register them as observers
        var currentDisplay = new CurrentConditionsDisplay();
        var statisticsDisplay = new StatisticsDisplay();
        
        weatherData.Attach(currentDisplay);
        weatherData.Attach(statisticsDisplay);
        
        // Simulate weather changes
        Console.WriteLine("\nWeather update 1:");
        weatherData.SetMeasurements(80, 65, 30.4f);
        
        Thread.Sleep(1000);
        
        Console.WriteLine("\nWeather update 2:");
        weatherData.SetMeasurements(82, 70, 29.2f);
        
        Thread.Sleep(1000);
        
        Console.WriteLine("\nWeather update 3:");
        weatherData.SetMeasurements(78, 90, 29.2f);
    }

    private static void RunEventBasedDemo()
    {
        Console.WriteLine("\nEvent-Based Notification Strategy Demo:");
        
        // Create WeatherData with event-based notification strategy
        var eventStrategy = new EventBasedStrategy<WeatherData>();
        var weatherData = new WeatherData(eventStrategy);
        
        // Create displays
        var currentDisplay = new CurrentConditionsDisplay();
        var forecastDisplay = new ForecastDisplay();
        
        // Register standard observer
        weatherData.Attach(currentDisplay);
        
        // Register event observer
        weatherData.Attach(forecastDisplay);
        forecastDisplay.Subscribe(eventStrategy);
        
        // Simulate weather changes
        Console.WriteLine("\nWeather update 1:");
        weatherData.SetMeasurements(80, 65, 30.4f);
        
        Thread.Sleep(1000);
        
        Console.WriteLine("\nWeather update 2:");
        weatherData.SetMeasurements(82, 70, 29.2f);
        
        Thread.Sleep(1000);
        
        Console.WriteLine("\nWeather update 3:");
        weatherData.SetMeasurements(78, 90, 29.2f);
        
        // Clean up
        forecastDisplay.Unsubscribe(eventStrategy);
    }
    
    private static void RunAsyncBasedDemo()
    {
        Console.WriteLine("\nAsync Notification Strategy Demo:");
        
        // Create WeatherData with Async notification strategy
        var asyncStrategy = new AsyncStrategy<WeatherData>();
        var weatherData = new WeatherData(asyncStrategy);
        
        // Create displays
        var currentDisplay = new CurrentConditionsDisplay();
        
        // Register standard observer
        weatherData.Attach(currentDisplay);
        
        // Simulate weather changes
        Console.WriteLine("\nWeather update 1:");
        weatherData.SetMeasurements(80, 65, 30.4f);
        
        Thread.Sleep(1000);
        
        Console.WriteLine("\nWeather update 2:");
        weatherData.SetMeasurements(82, 70, 29.2f);
        
        Thread.Sleep(1000);
        
        Console.WriteLine("\nWeather update 3:");
        weatherData.SetMeasurements(78, 90, 29.2f);
        
        // Clean up
        weatherData.Detach(currentDisplay);
    }
}
