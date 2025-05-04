using ObserverPattern.Core;
using ObserverPattern.Core.NotificationStrategies;

namespace ObserverPattern.UseCases.WeatherMonitoring;

/// <summary>
/// The WeatherData class represents a weather station that tracks temperature, humidity, and pressure.
/// It serves as the concrete subject in the Observer pattern.
/// </summary>
public class WeatherData : BaseSubject<WeatherData>
{
    private float _temperature;
    private float _humidity;
    private float _pressure;

    public WeatherData(INotificationStrategy<WeatherData> strategy) : base(strategy)
    {
    }

    public float Temperature => _temperature;
    public float Humidity => _humidity;
    public float Pressure => _pressure;

    /// <summary>
    /// Sets new measurements and notifies all observers.
    /// </summary>
    public void SetMeasurements(float temperature, float humidity, float pressure)
    {
        _temperature = temperature;
        _humidity = humidity;
        _pressure = pressure;
        
        // Notify observers that the state has changed
        Notify();
    }
}
