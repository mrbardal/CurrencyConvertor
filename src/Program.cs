using CurrencyApp.Service;
var rates = new List<Tuple<string, string, double>>
{
    new Tuple<string, string, double>("USD", "CAD", 1.34),
    new Tuple<string, string, double>("CAD", "GBP", 0.58),
    new Tuple<string, string, double>("USD", "EUR", 0.86),
};

CurrencyConverter.Instance.UpdateConfiguration(rates);

try
{
    var result = CurrencyConverter.Instance.Convert("USD", "GBP", 200);
    Console.WriteLine(result);
}
catch (System.Exception exp)
{
    System.Console.WriteLine(exp.Message);
}

Console.ReadLine();