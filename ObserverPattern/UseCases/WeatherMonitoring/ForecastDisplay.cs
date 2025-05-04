using System;
using ObserverPattern.Core;
using ObserverPattern.Core.NotificationStrategies;

namespace ObserverPattern.UseCases.WeatherMonitoring;

/// <summary>
/// Displays a weather forecast based on the barometric pressure.
/// This observer also demonstrates the event-based notification approach.
/// </summary>
public class ForecastDisplay : IEventObserver<WeatherData>, IDisplayElement
{
    private float _currentPressure = 29.92f;
    private float _lastPressure;

    public void Update(WeatherData weatherData)
    {
        _lastPressure = _currentPressure;
        _currentPressure = weatherData.Pressure;
        Display();
    }

    public void Subscribe(EventBasedStrategy<WeatherData> strategy)
    {
        strategy.StateChanged += OnWeatherDataChanged;
    }

    public void Unsubscribe(EventBasedStrategy<WeatherData> strategy)
    {
        strategy.StateChanged -= OnWeatherDataChanged;
    }

    private void OnWeatherDataChanged(object sender, SubjectEventArgs<WeatherData> e)
    {
        Update(e.Subject);
    }

    public void Display()
    {
        Console.Write("Forecast: ");
        
        if (_currentPressure > _lastPressure)
        {
            Console.WriteLine("Improving weather on the way!");
        }
        else if (_currentPressure == _lastPressure)
        {
            Console.WriteLine("More of the same");
        }
        else
        {
            Console.WriteLine("Watch out for cooler, rainy weather");
        }
    }
}
