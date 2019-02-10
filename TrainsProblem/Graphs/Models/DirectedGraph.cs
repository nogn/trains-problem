using System.Collections.Generic;

namespace TrainsProblem.Graphs.Models
{
    class DirectedGraph<T> : Graph<T>
    {
        public DirectedGraph(IEnumerable<Vertex<T>> initialVertices = null) 
            : base(initialVertices) { }
    }
}
