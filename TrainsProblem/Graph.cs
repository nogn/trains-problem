using System;
using System.Collections.Generic;
using System.Text;

namespace TrainsProblem
{
    public class Graph
    {
        //private readonly int size;
        private readonly IDictionary<char, ICollection<char>> vertices;

        //public Graph(int size)
        //{
        //    this.size = size;
        //}

        public Graph()
        {
            vertices = new Dictionary<char, ICollection<char>>();
        }
    }
}
