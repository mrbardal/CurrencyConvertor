namespace CurrencyApp.Domain
{
    public class Builder
    {
        private IEnumerable<Tuple<string, string, double>> _rates;
        
        public void SetRates(IEnumerable<Tuple<string, string, double>> rates)
        {
            _rates = rates;
        }

        public Graph Buid()
        {
            var graph = new Graph();

            _rates.ToList().ForEach(rate =>
            {
                graph.Addvertice(rate.Item1, rate.Item2, Math.Log10(rate.Item3));
            });

            return graph;
        }
    }
}