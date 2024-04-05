// Displays/CurrentConditionsDisplay.cs
using System;

namespace WeatherMonitoringSystem.Displays
{
    public class CurrentConditionsDisplay : IDisplay, IObserver
    {
        private readonly WeatherData _weatherData;

        public CurrentConditionsDisplay(WeatherData weatherData)
        {
            _weatherData = weatherData;
            _weatherData.AddObserver(this);
        }

        public void Display()
        {
            Console.WriteLine($"Current conditions: {_weatherData.Temperature}°C");
        }

        public void Update(double temperature)
        {
            // Update display when weather data changes
            Display();
        }
    }
}