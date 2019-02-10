using System.Linq;
using TrainsProblem.DataStructures.Graph;

namespace TrainsProblem.DataStructures.Builders
{
    public class DirectedGraphBuilder<T> : GraphBuilder<T>
    {
        public override void AddEdge(T source, T destination, int weight)
        {
            AddIfNew(source);
            AddIfNew(destination);

            AddEdgeIfNew(source, destination, weight);
        }

        private void AddIfNew(T value)
        {
            if (!graph.Vertices.Any(v => v.Value.Equals(value)))
                graph.Vertices.Add(new Vertex<T>(value));
        }

        private void AddEdgeIfNew(T sourceValue, T destinationValue, int weight)
        {
            var source = graph.GetVertex(sourceValue);
            var destination = graph.GetVertex(destinationValue);

            if (!source.Edges.Any(edge => edge.Destination.Value.Equals(destinationValue)))
                source.AddEdge(new Edge<T>(destination, weight));
        }
    }
}
