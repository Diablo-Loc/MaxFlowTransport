using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace src.Models
{
    internal class Graph
    {
        private readonly int _vertexCount;// số đỉnh
        private readonly List<Edge>[] _adj;// danh sách kề (list cạnh cho mỗi đỉnh)
        public Graph(int vertexCount)
        {
            _vertexCount = vertexCount;
            _adj = new List<Edge>[vertexCount];
            for (int i = 0; i < vertexCount; i++)
                _adj[i] = new List<Edge>();
        }
        //thêm from->to với sức chưa capacity và ngược lại:to->from với sức chứa capacity=0
        public void AddEdge(int from, int to, int capacity)
        {
            var forward = new Edge(from, to, capacity);
            var backward = new Edge(to, from, 0);
            _adj[from].Add(forward);
            _adj[to].Add(backward);
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
    }
}
