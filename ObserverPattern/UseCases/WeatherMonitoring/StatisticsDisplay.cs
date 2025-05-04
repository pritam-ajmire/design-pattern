using System;
using System.Collections.Generic;
using System.Linq;
using ObserverPattern.Core;

namespace ObserverPattern.UseCases.WeatherMonitoring;

/// <summary>
/// Displays statistics about the weather data.
/// </summary>
public class StatisticsDisplay : ISubjectObserver<WeatherData>, IDisplayElement
{
    private readonly List<float> _temperatures = new();
    private readonly List<float> _humidities = new();
    private readonly List<float> _pressures = new();

    public void Update(WeatherData weatherData)
    {
        _temperatures.Add(weatherData.Temperature);
        _humidities.Add(weatherData.Humidity);
        _pressures.Add(weatherData.Pressure);
        Display();
    }

    public void Display()
    {
        if (_temperatures.Count == 0) return;
        
        Console.WriteLine("Weather Statistics:");
        Console.WriteLine($"Avg/Max/Min temperature: {_temperatures.Average():F1}°F / {_temperatures.Max():F1}°F / {_temperatures.Min():F1}°F");
        Console.WriteLine($"Avg/Max/Min humidity: {_humidities.Average():F1}% / {_humidities.Max():F1}% / {_humidities.Min():F1}%");
        Console.WriteLine($"Avg/Max/Min pressure: {_pressures.Average():F1} / {_pressures.Max():F1} / {_pressures.Min():F1}");
    }
}
