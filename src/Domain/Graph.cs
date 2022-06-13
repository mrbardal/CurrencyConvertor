namespace CurrencyApp.Domain
{
    public class Graph
    {
        private List<Edge> _edges;
        public IReadOnlyCollection<Edge> Edges => _edges.AsReadOnly();

        public Graph()
        {
            _edges = new List<Edge>();
        }

        public void Addvertice(string source, string destination, double weight)
        {
            var edge = new Edge(source, destination, weight);

            _edges.Add(edge);
        }

        public List<string> Vertices => _edges.Select(e => e.Source)
                                                .Union(_edges.Select(r => r.Destination))
                                                .Distinct()
                                                .OrderBy(r => r)
                                                .ToList();

    }
}