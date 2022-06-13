using CSharpFunctionalExtensions;

namespace CurrencyApp.Domain
{
    public class BellmanFord
    {
        private Graph _graph;
        private Dictionary<string, double> _distances;

        public BellmanFord(Graph graph)
        {
            _graph = graph;
            _distances = new Dictionary<string, double>();
        }

        public Result Compute(string source)
        {
            //? Step 1: Initialize distances array from src vertex to all other vertices as INFINITE 
            _graph.Vertices.ForEach(v => _distances.Add(v, double.MaxValue));

            //? mark the source vertex
            _distances[source] = 0;

            //? Step 2: relax edges |V| - 1 times
            _graph.Vertices.Where(v => v != source).ToList().ForEach(v =>
            {
                _graph.Edges.ToList().ForEach(edge =>
                {
                    string u = edge.Source;
                    string v = edge.Destination;
                    double weight = edge.Weight;

                    if (_distances[u] != int.MaxValue && _distances[u] + weight < _distances[v])
                        _distances[v] = _distances[u] + weight;

                });
            });

            //? step 3: detect negative cycle if value changes then we have a negative cycle in the graph and we cannot find the shortest distances
            try
            {
                _graph.Edges.ToList().ForEach(edge =>
                {
                    string u = edge.Source;
                    string v = edge.Destination;
                    double weight = edge.Weight;

                    if (_distances[u] != int.MaxValue && _distances[u] + weight < _distances[v])
                    {
                        throw new Exception("Graph contains negative weight cycle.");
                    }
                });

                return Result.Success();
            }
            catch (System.Exception exp)
            {
                return Result.Failure(exp.Message);
            }


        }

        public Result<double> GetDistance(string destination)
        {
            var result = _distances[destination];

            if (result == int.MaxValue)
            {
                return Result.Failure<double>("Path not found!");
            }
            else
            {
                return Result.Success(result);
            }
        }
    }
}