using src.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace src.Algorithms
{
    public class Bfs
    {
        public static bool BfsCheck(Graph g, int s, int t, Edge[] p)
        {
            bool[] visited = new bool[g._vertexCount];
            MyQueue<int> Q = new MyQueue<int>();
            Q.HangCho(s);
            visited[s] = true;
            while (Q.Dem > 0)
            {
                int u = Q.LoaiBoHangCho();
                foreach (var e in g.GetEdgesFrom(u))
                {
                    if (!visited[e.To] && e.ResidualCapacity() > 0)
                    {
                        p[e.To] = e;
                        visited[e.To] = true;
                        if (e.To == t) return true;
                        Q.HangCho(e.To);
                    }
                }
            }
            return false;
        }
    }
    public class MyQueue<T>
    {
        private List<T> list = new List<T>();

        public void HangCho(T item)
        {
            list.Add(item);
        }
        public T LoaiBoHangCho()
        {
            if (list.Count == 0) throw new InvalidOperationException();
            T value = list[0];
            list.RemoveAt(0);
            return value;
        }

        public int Dem =>list.Count;
        }
    }