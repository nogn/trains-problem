using System.Collections.Generic;

namespace TrainsProblem.Graphs.Models
{
    interface IGraph<T>
    {
        List<Vertex<T>> Vertices { get; }
        Vertex<T> GetVertex(T value);
    }
}
