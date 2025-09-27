using src.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace src.Algorithms
{
    public class MaxFlowSolve
    {
        public static int EdmondKarp(Graph g, int source, int sink)
        {
            int maxflow = 0;
            Edge[] parent = new Edge[g._vertexCount];
            while (Bfs.BfsCheck(g, source, sink, parent))
            {
                int pathFlow = int.MaxValue;
                for (int v = sink; v != source; v = parent[v].From)
                {
                    pathFlow = Math.Min(pathFlow, parent[v].ResidualCapacity());
                }
                for (int v = sink; v != source; v = parent[v].From)
                {
                    Edge e = parent[v];
                    e.AddFlow(pathFlow);
                    Edge rev = g.GetReverseEdge(e);
                    if (rev != null)
                        rev.AddFlow(-pathFlow);
                }
                maxflow += pathFlow;
            }
            return maxflow;
        }
    }
}
