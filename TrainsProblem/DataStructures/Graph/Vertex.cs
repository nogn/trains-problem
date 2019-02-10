using System.Collections.Generic;
using System.Linq;

namespace TrainsProblem.DataStructures.Graph
{
    public class Vertex<T>
    {
        public Vertex(T value, IEnumerable<Edge<T>> edges = null)
        {
            Value = value;
            Edges = edges?.ToList() ?? new List<Edge<T>>();
        }

        public T Value { get; }

        public List<Edge<T>> Edges { get; }

        public int EdgesCount => Edges.Count;

        public bool HasEdge(T value)
        {
            return Edges.Any(e => e.Destination.Value.Equals(value));
        }

        public Edge<T> GetEdge(T value)
        {
            return Edges.Find(e => e.Destination.Value.Equals(value));
        }

        public void AddEdge(Edge<T> edge)
        {
            Edges.Add(edge);
        }

        public void AddEdges(IEnumerable<Edge<T>> edges)
        {
            Edges.AddRange(edges);
        }

        public void RemoveEdge(Edge<T> edge)
        {
            Edges.Remove(edge);
        }

        public override string ToString()
        {
            return $"{Value}: {string.Join(" ", Edges.Select(e => e.ToString()))}";
        }
    }
}
