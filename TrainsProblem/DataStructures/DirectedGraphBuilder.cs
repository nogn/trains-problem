namespace TrainsProblem.DataStructures
{
    public class DirectedGraphBuilder<T> : GraphBuilder<T>
    {
        public override void AddEdge(T srcValue, T destValue, int weight)
        {
            AddVertexIfNew(srcValue);
            AddVertexIfNew(destValue);

            AddEdgeIfNew(srcValue, destValue, weight);
        }

        private void AddVertexIfNew(T value)
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
