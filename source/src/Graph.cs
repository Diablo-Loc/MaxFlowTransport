using System;
using System.Collections.Generic;

namespace MaxFlowTransport.Models // hoặc namespace src.Models
{
    public class Edge
    {
        public int From { get; }
        public int To { get; }
        public int Capacity { get; set; }

        public Edge(int from, int to, int capacity)
        {
            From = from;
            To = to;
            Capacity = capacity;
        }
    }

    public class Graph
    {
        public int Vertices { get; }
        public int[,] Capacity { get; }

        public Graph(int vertices)
        {
            Vertices = vertices;
            Capacity = new int[vertices, vertices];
        }

        public void AddEdge(int u, int v, int capacity)
        {
            Capacity[u, v] = capacity;
        }
    }

    public static class GraphParser
    {
        /// <summary>
        /// Parse danh sách cạnh từ chuỗi nhập liệu (edge list format).
        /// Mỗi dòng: u v capacity
        /// </summary>
        public static Graph FromEdgeList(string input, int vertices)
        {
            var graph = new Graph(vertices);
            var lines = input.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in lines)
            {
                var parts = line.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length != 3)
                    throw new FormatException($"Sai định dạng dòng: {line}");

                int u = int.Parse(parts[0]);
                int v = int.Parse(parts[1]);
                int capacity = int.Parse(parts[2]);

                graph.AddEdge(u, v, capacity);
            }

            return graph;
        }
    }
}
