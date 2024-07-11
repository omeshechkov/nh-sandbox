using GlavLib.Abstractions.DI;

namespace Lib;

[SingleInstance]
public sealed class WeatherService(IWeatherProvider weatherProvider, Calculator calculator)
{
    public Calculator Calculator { get; } = calculator;

    public string GetWeather(TemperatureUnits temperatureUnits)
    {
        var temperature = weatherProvider.Get();

        return $"{temperatureUnits}: {temperature}";
    }
}