using CurrencyApp.Domain;

namespace CurrencyApp.Service
{
    public class CurrencyConverter : ICurrencyConverter
    {
        //? Dingleton Pattern and Thread Safe Class
        private static readonly object locker;
        private static readonly Lazy<CurrencyConverter> _lazy;
        //Data racing
        public static CurrencyConverter Instance
        {
            get
            {
                lock (locker)
                {
                    return _lazy.Value;
                }
            }
        }

        static CurrencyConverter()
        {
            locker = new object();
            _lazy = new Lazy<CurrencyConverter>(() => new CurrencyConverter());
        }


        private Builder _builder;
        private Graph _graph;
        // private Dijkstra _dijkstra;
        private BellmanFord _bellmanFord;

        protected CurrencyConverter()
        {
            _builder = new Builder();
        }

        public void ClearConfiguration()
        {
            _graph = null;
            _bellmanFord = null;
        }

        public double Convert(string source, string destination, double amount)
        {
            _bellmanFord.Compute(source);
            var result = _bellmanFord.GetDistance(destination);

            if (result.IsSuccess)
            {
                return Math.Pow(10, result.Value) * 200;
            }
            else
            {
                throw new Exception(result.Error);
            }
        }

        public void UpdateConfiguration(IEnumerable<Tuple<string, string, double>> conversionRates)
        {
            _builder.SetRates(conversionRates);
            _graph = _builder.Buid();
            _bellmanFord = new BellmanFord(_graph);
        }
    }
}