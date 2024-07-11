using GlavLib.Abstractions.DataTypes;
using Lib;
using Microsoft.Extensions.DependencyInjection;
using Sandbox.DI;

var services = new ServiceCollection();
services.Add_Lib()
    .Add_Sandbox_DI();

services.AddScoped<DatabaseConnection>(sp => DatabaseConnection.Create());

// services.AddSingleton<IWeatherProvider, WeatherProvider>();
// services.AddSingleton<WeatherService>();

var serviceProvider = services.BuildServiceProvider();

var calc = serviceProvider.GetRequiredService<Calculator>();

var ws1 = serviceProvider.GetRequiredService<WeatherService>();
var ws2 = serviceProvider.GetRequiredService<WeatherService>();

DatabaseConnection temp;
using (var scope1 = serviceProvider.CreateScope())
{
    Console.WriteLine("Scope1");

    var conn11 = scope1.ServiceProvider.GetRequiredService<DatabaseConnection>();
    var conn12 = scope1.ServiceProvider.GetRequiredService<DatabaseConnection>();

    Console.WriteLine(ReferenceEquals(conn11, conn12));

    temp = conn11;
}

Console.WriteLine();

using (var scope2 = serviceProvider.CreateScope())
{
    Console.WriteLine("Scope2");

    var conn21 = scope2.ServiceProvider.GetRequiredService<DatabaseConnection>();
    var conn22 = scope2.ServiceProvider.GetRequiredService<DatabaseConnection>();

    Console.WriteLine(ReferenceEquals(conn21, conn22));
    Console.WriteLine(ReferenceEquals(conn21, temp));
}

// Console.WriteLine(ReferenceEquals(ws1, ws2));
// Console.WriteLine(ReferenceEquals(ws1.Calculator, ws2.Calculator));
//
// Console.WriteLine(ReferenceEquals(calc, ws2.Calculator));


// var weatherService = serviceProvider.GetRequiredService<WeatherService>();

// var result = weatherService.GetWeather(TemperatureUnits.Celsius);

// Console.WriteLine(result);

[EnumObjectItem("Option1", "OPT1", "Some Option1")]
[EnumObjectItem("Option2", "OPT2", "Some Option2")]
public sealed partial class TestEnum : EnumObject;