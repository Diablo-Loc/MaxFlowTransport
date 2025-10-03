using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace src.Models
{
    public class Node
    {
        public int _id { get; set; }//số thứ tự đỉnh
        public string _label { get; set; }//tên hiển thị các đỉnh trên UI
        public float X { get; set; } //vị trí x
        public float Y { get; set; } //vị trí y
        public Node() { }
        public Node(int id, string label, float x, float y)
        {
            _id = id;
            _label = label;
            X = x;
            Y = y;
        }

    }
}
