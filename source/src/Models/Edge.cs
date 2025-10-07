using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace src.Models
{
    public class Edge
    {
        public bool IsHovered = false;
        public int From { get; set; }     // đỉnh xuất phát
        public int To { get; set; }       // đỉnh đích
        public int Capacity { get; set; } // sức chứa
        public int Flow { get; set; }     // dòng chảy hiện tại
        public Edge Reverse { get; set; } 
        public Edge() { }
        public Edge(int from, int to, int capacity)
        {
            From = from;
            To = to;
            Capacity = capacity;
            Flow = 0;
        }
        public int ResidualCapacity()
        {
            return Capacity - Flow;
        }
        public void AddFlow(int count)
        {
            Flow += count;
        }
        
    }
}
