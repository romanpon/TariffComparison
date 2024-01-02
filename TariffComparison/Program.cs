// See https://aka.ms/new-console-template for more information
using TariffComparison.Tariff;

var tariffHandler = new TariffComparisionHandler();
Console.OutputEncoding = System.Text.Encoding.Unicode;

while (true)
{
    Console.WriteLine("Input annual consuption:");

    var input = Console.ReadLine();
    if (double.TryParse(input, out var inputNumber))
    {
        try
        {
            var tariffs = tariffHandler.GetAnualCost(inputNumber);
            foreach (var tariff in tariffs)
                Console.WriteLine($"{tariff.Name}. {tariff.Desription}");
            Console.WriteLine();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    else
    {
        Console.WriteLine("Invalid format. Input should be double and positive value");
    }
}