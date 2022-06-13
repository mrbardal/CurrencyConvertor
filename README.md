# Currency Convertor

## Simple Console Application

Graph theory has been used in the implementation of this program. The most well-known is the diskette algorithm, which is used to find the shortest path, but if the weight of the edges is negative, there is also the possibility of a negative cycle, which is corrected by the Belman Ford algorithm.

**Domain Class**
- In `Edge` To describe the edges of a graph
- In `Graph` To describe and model graphs
- In `Builder` To convert input information to a graph
- In `Dijkstra` Implementation of the Dijkstra algorithm
- In `BellmanFord` Implementation of the BellmanFord algorithm

**Service Contract**
- In `ICurrencyConverter` Define a converter service contract

**Service Class**
- In `CurrencyConverter` Implement a currency converter

<img src="https://github.com/mrbardal/SocialNetwork/blob/main/img/Currency.png" width="100%"/>

```javascript

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

```