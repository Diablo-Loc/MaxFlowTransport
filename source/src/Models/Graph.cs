using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace src.Models
{
    public class Graph
    {
        public readonly int _vertexCount;// số đỉnh
        private readonly List<Edge>[] _adj;// ds kề (list cạnh cho mỗi đỉnh)
        private readonly List<Edge> _edges;// này là ds cạnh

        public Graph(int vertexCount)
        {
            _vertexCount = vertexCount;
            _adj = new List<Edge>[vertexCount];
            for (int i = 0; i < vertexCount; i++)
                _adj[i] = new List<Edge>();
            _edges = new List<Edge>();
        }
        //thêm  from->to với sức chưa capacity và ngược lại:to->from với sức chứa capacity=0
        public void AddEdge(int from, int to, int capacity)
        {
            var forward = new Edge(from, to, capacity);
            var backward = new Edge(to, from, 0);
            forward.Reverse = backward;
            backward.Reverse = forward;
            _adj[from].Add(forward);
            _adj[to].Add(backward);
            _edges.Add(forward);
        }
        // lấy list cạnh kề 1 đỉnh
        public IEnumerable<Edge> GetAdj(int v)
        {
            return _adj[v];
        }
        //trả số đỉnh
        public int VertexCount => _vertexCount;
        //lấy cạnh xuất phát từ đỉnh
        public IEnumerable<Edge> GetEdgesFrom(int node)
        {
            return _adj[node];
        }
        // Trả về tất cả cạnh thuận (dùng khi in kết quả)
        public IEnumerable<Edge> Edges => _edges;
        //Trả về danh sách các cạnh
        public IEnumerable<Edge> GetAllEdges()
        {
            foreach (var list in _adj)
                foreach (var e in list)
                    if (e.Capacity > 0)   // bỏ reverse nếu có capacity = 0
                        yield return e;
        }
        
    }
}
