namespace CurrencyApp.Domain
{
    public record Edge
    {
        public string Source { get; init; }
        public string Destination { get; init; }
        public double Weight { get; init; }
        
        // public Edge()
        // {

        // }
        public Edge(string source, string destination, double weight)
        {
            Source = source;
            Destination = destination;
            Weight = weight;
        }
    }
}