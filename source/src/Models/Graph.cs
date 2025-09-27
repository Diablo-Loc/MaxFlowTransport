using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace src.Models
{
    public class Graph
    {
        public int _vertexCount;// số đỉnh
        private List<Edge>[] _adj;// ds kề (list cạnh cho mỗi đỉnh)
        private List<Edge> _edges { get; }// này là ds cạnh
        public Graph() { }
        public Graph(int vertexCount)
        {
            _vertexCount = vertexCount;
            _adj = new List<Edge>[vertexCount];
            for (int i = 0; i < vertexCount; i++)
                _adj[i] = new List<Edge>();
            _edges = new List<Edge>();
        }
        //thêm from->to với sức chưa capacity và ngược lại:to->from với sức chứa capacity=0
        public void AddEdge(int from, int to, int capacity)
        {
            var forward = new Edge(from, to, capacity);
            var backward = new Edge(to, from, 0);
            _adj[from].Add(forward);
            _adj[to].Add(backward);
            _edges.Add(forward);
        }
        // lấy list cạnh kề đỉnh v
        public IEnumerable<Edge> GetAdj(int v)
        {
            return _adj[v];
        }
        //trả số đỉnh
        public int VertexCount()
        {
            return _vertexCount;
        }
        //lấy cạnh xuất phát từ đỉnh
        public IEnumerable<Edge> GetEdgesFrom(int node)
        {
            return _adj[node];
        }
        public IEnumerable<Edge> GetAllEdges()
        {
            foreach (var list in _adj)
                foreach (var e in list)
                    yield return e;
        }

        //Tìm cạnh ngược 
        public Edge GetReverseEdge(Edge e)
        {
            return _adj[e.To].FirstOrDefault(x => x.From == e.To);
        }
    }
}
