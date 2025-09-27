using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace src.Models
{
    public class Utils
    {
        public static Graph BuildTransportationGraph(int[]cung, int[]cau, int[,] capacity)
        {
            int m=cung.Length;
            int n=cau.Length;
            int totalVertices = m + n + 2;
            int superSource = m + n;
            int superSink = m + n + 1;
            Graph g = new Graph(totalVertices);
            // superSource tới mỗi nguồn
            for (int i = 0; i < m; i++)
                g.AddEdge(superSource, i, cung[i]);
            // Nguồn tới đích
            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                    g.AddEdge(i, m + j, capacity[i, j]);
            // mỗi đích tới superSink
            for (int j = 0; j < n; j++)
                g.AddEdge(m + j, superSink, cau[j]);
            return g;
        }
        // đây là phần nhập(input)
        public static (int[], int[], int[,]) SampleData()
        {
            int[] cung = { 15, 20 };        // 2 nguồn
            int[] cau = { 10, 12, 13 };    // 3 đích
            int[,] cap = {
                { 10, 10, 5 },
                { 5, 10, 20 }
            };
            return (cung, cau, cap);
        }
    }
}
