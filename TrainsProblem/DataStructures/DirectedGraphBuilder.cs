namespace TrainsProblem.DataStructures
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
            if (!graph.HasVertex(value))
                graph.AddVertex(value);
        }

        private void AddEdgeIfNew(T srcValue, T destValue, int weight)
        {
            var source = graph.GetVertex(srcValue);
            var destination = graph.GetVertex(destValue);

            if (!source.HasEdge(destValue))
                source.AddEdge(new Edge<T>(destination, weight));
        }
    }
}
