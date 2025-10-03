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
            /*var (supply, demand, cap) = Utils.SampleData();
            Graph g = Utils.BuildTransportationGraph(supply, demand, cap);

            int source = supply.Length + demand.Length;
            int sink = source + 1;

            int maxFlow = MaxFlowSolve.EdmondKarp(g, source, sink);

            Console.WriteLine($"Maximum Flow = {maxFlow}\n");

            Console.WriteLine("Edges with final flow:");
            foreach (var e in g.Edges) // chỉ in cạnh thuận
            {
                Console.WriteLine($"{e.From} -> {e.To} | Flow = {e.Flow}/{e.Capacity}");
            }

            Console.WriteLine("\nDone.");*/
        }
    }
}
