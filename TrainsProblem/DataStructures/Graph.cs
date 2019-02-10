using System.Collections.Generic;
using System.Linq;

namespace TrainsProblem.DataStructures
{
    public class Graph<T>
    {
        public Graph(IEnumerable<Vertex<T>> vertices = null)
        {
            Vertices = vertices?.ToList() ?? new List<Vertex<T>>();
        }

        public List<Vertex<T>> Vertices { get; }

        public int VerticesCount => Vertices.Count;

        public Vertex<T> GetVertex(T value)
        {
            return Vertices.Find(v => v.Value.Equals(value));
        }

        public bool HasVertex(T value)
        {
            return Vertices.Any(v => v.Value.Equals(value));
        }

        public void AddVertex(T value)
        {
            Vertices.Add(new Vertex<T>(value));
        }

        public override string ToString()
        {
            return string.Join("\n", Vertices.Select(v => v.ToString()));
        }
    }
}
