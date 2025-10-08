    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace src.Models
{
    public class Utils
    {
        /*public static (int[] supply, int[] demand, int[,] capacity) SampleData()
        {
            int[] supply = { 10 };
            int[] demand = { 5, 5 };

            int[,] cap = {
            {0,10}
            };

            return (supply, demand, cap);
        }*/
        //Lấy supply và demand từ input của textbox vào và random capacity
        public static int[,] SampleCapacity(int supplyCount, int demandCount)
        {
            int[,] cap = new int[supplyCount, demandCount];
            Random rnd = new Random();

            for (int i = 0; i < supplyCount; i++)
            {
                for (int j = 0; j < demandCount; j++)
                {
                    cap[i, j] = rnd.Next(5, 15); 
                }
            }
            return cap;
        }
        
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
    }
}
