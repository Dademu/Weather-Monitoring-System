// Models/WeatherData.cs
using System;
using System.Collections.Generic;
using WeatherMonitoringSystem.Observer;

namespace WeatherMonitoring.Models;
{
    public class WeatherData
{
    private static WeatherData _instance;
    private readonly List<IObserver> _observers;
    private double _temperature; // Simulated weather data

    private WeatherData()
    {
        _observers = new List<IObserver>();
    }

    public static WeatherData GetInstance()
    {
        return _instance ??= new WeatherData();
    }

    public void AddObserver(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void SetTemperature(double temperature)
    {
        _temperature = temperature;
        NotifyObservers();
    }

    private void NotifyObservers()
    {
        foreach (var observer in _observers)
        {
            observer.Update(_temperature);
        }
    }

    public double Temperature => _temperature;
}
}