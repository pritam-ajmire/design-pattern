using System;
using ObserverPattern.Core;

namespace ObserverPattern.UseCases.WeatherMonitoring;

/// <summary>
/// Displays the current weather conditions.
/// </summary>
public class CurrentConditionsDisplay : ISubjectObserver<WeatherData>, IDisplayElement
{
    private float _temperature;
    private float _humidity;

    public void Update(WeatherData weatherData)
    {
        _temperature = weatherData.Temperature;
        _humidity = weatherData.Humidity;
        Display();
    }

    public void Display()
    {
        Console.WriteLine($"Current conditions: {_temperature}°F and {_humidity}% humidity");
    }
}

/// <summary>
/// Interface for display elements.
/// </summary>
public interface IDisplayElement
{
    void Display();
}
