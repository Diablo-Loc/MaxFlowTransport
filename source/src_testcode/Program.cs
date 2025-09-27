using System;
using System.Runtime.CompilerServices;
using System.Windows.Forms.VisualStyles;
using src.Models;
using src.Algorithms;

namespace src_testcode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Lấy dữ liệu mẫu
            var (supply, demand, cap) = Utils.SampleData();

            // Xây dựng đồ thị vận tải
            Graph g = Utils.BuildTransportationGraph(supply, demand, cap);

            // Tính max flow: nguồn = supply.Length + demand.Length,
            // đích   = supply.Length + demand.Length + 1
            int source = supply.Length + demand.Length;
            int sink = source + 1;

            int maxFlow = MaxFlowSolve.EdmondKarp(g, source, sink);

            Console.WriteLine($"Maximum Flow = {maxFlow}");

            Console.WriteLine("\nEdges with final flow:");
            foreach (var e in g.GetAllEdges())
            {
                if (e.Flow > 0)
                    Console.WriteLine($"{e.From} -> {e.To} | Flow = {e.Flow}/{e.Capacity}");
            }

        }
    }
}
