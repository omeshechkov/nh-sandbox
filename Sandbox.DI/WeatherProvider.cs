using GlavLib.Abstractions.DI;

namespace Sandbox.DI;


[SingleInstance<Lib.IWeatherProvider>]
public sealed class WeatherProvider : Lib.IWeatherProvider
{
    public int Get()
    {
        return Random.Shared.Next(40);
    }
}