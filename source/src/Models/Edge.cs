using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace src.Models
{
    internal class Edge
    {
        public int From { get; private set; }     // đỉnh xuất phát
        public int To { get; private set; }       // đỉnh đích
        public int Capacity { get; private set; } // sức chứa
        public int Flow { get; private set; }     // dòng chảy hiện tại
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
        public void AddFlow(int amount)
        {
            Flow += amount;
        }

    }
}
