using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TariffCompare.Services;
using TariffCompare.Services.IServices;
using TariffCompare.Utils;


var serviceProvider = new ServiceCollection().AddLogging(configure => configure.AddConsole())
            .Configure<LoggerFilterOptions>(options => options.MinLevel = LogLevel.Debug)
            .AddTransient<Program>()
            .AddSingleton<ITariffService, TariffService>()
            .BuildServiceProvider();

var tariffService = serviceProvider.GetService<ITariffService>();

Console.WriteLine("Please enter the consumption value");
var enteredValue = Console.ReadLine();

double consumption = tariffService.CheckValidConsumptionValue(enteredValue);

Console.WriteLine("For the consumption value: " + consumption + " kWh/year");
PrintTable.PrintLine();
PrintTable.PrintRow("Tariff Name", "Annual Cost(Euros/year)");
PrintTable.PrintLine();

using (var products = tariffService.GetProducts(consumption).GetEnumerator())
{
    while (products.MoveNext())
    {
        var product = products.Current;
        PrintTable.PrintRow(product.Name, product.AnnualCost.ToString());
    }
}

PrintTable.PrintLine();

Console.WriteLine("Press any key to exit...");
Console.ReadKey(true);
