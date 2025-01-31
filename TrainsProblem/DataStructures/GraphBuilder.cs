﻿namespace TrainsProblem.DataStructures
{
    public abstract class GraphBuilder<T>
    {
        protected Graph<T> graph;

        public GraphBuilder()
        {
            graph = new Graph<T>();
        }

        public Graph<T> GetGraph()
        {
            return graph;
        }

        public abstract void AddEdge(T source, T destination, int weight);
    }
}
