using src.Algorithms;
using src.Helpers;
using src.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace src.UI
{
    public partial class GraphVisualizer : Form
    {
        private List<Node> Nodes = new List<Node>();
        public List<Edge> Edges = new List<Edge>();
        private List<Tuple<int, int, int>> uiEdges = new List<Tuple<int, int, int>>(); // từId, đếnId, capacity  (dùng sau)
        private int nextNodeId = 0;
        private string mode = "Select"; // "AddNode", "AddEdge", "Select"
        private const int NODE_RADIUS = 24;
        private Node firstNode = null; // node đầu khi add edge
        private Font edgeFont = new Font("Arial", 10);
        private Node selectedNode = null;
        private Node draggingNode = null;
        private Point dragOffset;
        private Node sourceNode = null;
        private Node sinkNode = null;
        private List<Node> sourceNodes = new List<Node>();
        private List<Node> sinkNodes = new List<Node>();
        private System.Windows.Forms.Timer animationTimer;
        private float flowPhase = 0f; // dùng để dịch chuyển hiệu ứng

        public GraphVisualizer()
        {
            InitializeComponent();
            pnlDraw.Paint += PanelDraw_Paint;
            pnlDraw.MouseClick += PanelDraw_MouseClick;
            pnlDraw.MouseDown += PanelDraw_MouseDown;
            pnlDraw.MouseMove += PanelDraw_MouseMove;
            pnlDraw.MouseUp += PanelDraw_MouseUp;
            animationTimer = new System.Windows.Forms.Timer();
            animationTimer.Interval = 30; // ~30ms cho mượt
            animationTimer.Tick += AnimationTimer_Tick;
            animationTimer.Start();

            btnAddNode.Click += (s, e) => { mode = "AddNode"; btnAddNode.BackColor = Color.LightGreen; };
            btnAddEdge.Click += (s, e) => { mode = "AddEdge"; btnAddNode.BackColor = SystemColors.Control; };
            btnClear.Click += BtnClear_Click;
        }
        private void PanelDraw_MouseDown(object sender, MouseEventArgs e)
        {
            if (mode == "Select")
            {
                var hit = FindNodeAt(e.X, e.Y);
                if (hit != null)
                {
                    draggingNode = hit;
                    dragOffset = new Point((int)(e.X - hit.X), (int)(e.Y - hit.Y));
                }
            }
        }
        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            flowPhase += 0.02f;
            if (flowPhase > 1f) flowPhase -= 1f;
            pnlDraw.Invalidate(); // vẽ lại
        }
        private void PanelDraw_MouseMove(object sender, MouseEventArgs e)
        {
            if (draggingNode != null)
            {
                draggingNode.X = e.X - dragOffset.X;
                draggingNode.Y = e.Y - dragOffset.Y;
                pnlDraw.Invalidate(); // vẽ lại để node & cạnh di chuyển
            }
            else
            {
                // Hover highlight như cũ

                pnlDraw.Invalidate();
            }
        }
        private void PanelDraw_MouseUp(object sender, MouseEventArgs e)
        {
            draggingNode = null;
        }
        private void ReindexNodes()
        {
            // Tạo map từ oldId -> newId
            var idMap = new Dictionary<int, int>();
            for (int i = 0; i < Nodes.Count; i++)
            {
                idMap[Nodes[i]._id] = i;
                Nodes[i]._id = i;
                Nodes[i]._label = "N" + i;
            }

            // Update edges theo id mới
            var newEdges = new List<Tuple<int, int, int>>();
            foreach (var edge in uiEdges)
            {
                if (idMap.ContainsKey(edge.Item1) && idMap.ContainsKey(edge.Item2))
                {
                    newEdges.Add(new Tuple<int, int, int>(
                        idMap[edge.Item1],
                        idMap[edge.Item2],
                        edge.Item3
                    ));
                }
            }
            uiEdges = newEdges;
            nextNodeId = Nodes.Count;
        }

        public class DoubleBufferedPanel : Panel
        {
            public DoubleBufferedPanel()
            {
                this.DoubleBuffered = true;
                this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                              ControlStyles.AllPaintingInWmPaint |
                              ControlStyles.UserPaint, true);
                this.UpdateStyles();
            }
        }
        private void PanelDraw_MouseClick(object sender, MouseEventArgs e)
        {
            if (mode == "AddNode")
            {
                var hit = FindNodeAt(e.X, e.Y);
                if (hit != null) return;

                var node = new Node(nextNodeId, $"N{nextNodeId}", e.X, e.Y);
                Nodes.Add(node);
                nextNodeId++;
                pnlDraw.Invalidate();
            }
            else if (mode == "AddEdge")
            {
                var hit = FindNodeAt(e.X, e.Y);
                if (hit == null) return;

                if (firstNode == null)
                {
                    // chọn node đầu tiên
                    firstNode = hit;
                }
                else
                {
                    // chọn node thứ 2 => tạo edge
                    if (hit._id != firstNode._id)
                    {
                        string input = Microsoft.VisualBasic.Interaction.InputBox(
                            $"Enter capacity for edge {firstNode._label} -> {hit._label}",
                            "Capacity", "10");

                        if (int.TryParse(input, out int capacity))
                        {
                            uiEdges.Add(new Tuple<int, int, int>(firstNode._id, hit._id, capacity));
                        }
                    }
                    firstNode = null;
                    pnlDraw.Invalidate();
                }
            }
            else if (mode == "EraseNode")
            {
                var hit = FindNodeAt(e.X, e.Y);
                if (hit != null)
                {
                    uiEdges.RemoveAll(edge => edge.Item1 == hit._id || edge.Item2 == hit._id);
                    Nodes.Remove(hit);
                    ReindexNodes();
                    pnlDraw.Invalidate();
                }
            }
            else if (mode == "EraseEdge")
            {
                var hitEdge = FindEdgeAt(e.X, e.Y);
                if (hitEdge != null)
                {
                    uiEdges.Remove(hitEdge);
                    pnlDraw.Invalidate();
                }
            }
            if (mode == "SelectSource")
            {
                var hit = FindNodeAt(e.X, e.Y);
                sourceNode = hit;
                sourceNodes.Clear();
                sourceNodes.Add(hit);
                pnlDraw.Invalidate();
            }
            else if (mode == "SelectSink")
            {
                var hit = FindNodeAt(e.X, e.Y);
                sinkNode = hit;
                sinkNodes.Clear();
                sinkNodes.Add(hit);
                pnlDraw.Invalidate();
            }
            else if (mode == "SelectSourceMulti")
            {
                var hit = FindNodeAt(e.X, e.Y);
                if (hit != null && !sourceNodes.Contains(hit))
                    sourceNodes.Add(hit);
                pnlDraw.Invalidate();
            }
            else if (mode == "SelectSinkMulti")
            {
                var hit = FindNodeAt(e.X, e.Y);
                if (hit != null && !sinkNodes.Contains(hit))
                    sinkNodes.Add(hit);
                pnlDraw.Invalidate();
            }


        }
        private Node FindNodeAt(int x, int y)
        {
            int r = NODE_RADIUS + 4;
            foreach (var n in Nodes)
            {
                float dx = n.X - x;
                float dy = n.Y - y;
                if (dx * dx + dy * dy <= r * r) return n;
            }
            return null;
        }
        private Tuple<int, int, int> FindEdgeAt(int x, int y)
        {
            const int EDGE_CLICK_RADIUS = 6;

            foreach (var edge in uiEdges)
            {
                Node from = Nodes.First(n => n._id == edge.Item1);
                Node to = Nodes.First(n => n._id == edge.Item2);

                float x1 = from.X;
                float y1 = from.Y;
                float x2 = to.X;
                float y2 = to.Y;

                // Tính khoảng cách từ điểm (x, y) đến đoạn thẳng (x1, y1)-(x2, y2)
                float dx = x2 - x1;
                float dy = y2 - y1;

                float lengthSquared = dx * dx + dy * dy;
                if (lengthSquared == 0) continue;

                float t = ((x - x1) * dx + (y - y1) * dy) / lengthSquared;
                t = Math.Max(0, Math.Min(1, t));

                float projX = x1 + t * dx;
                float projY = y1 + t * dy;

                float dist = (float)Math.Sqrt((x - projX) * (x - projX) + (y - projY) * (y - projY));

                if (dist <= EDGE_CLICK_RADIUS)
                    return edge; // Return the Tuple directly
            }

            return null;
        }
        
        private void PanelDraw_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.Clear(Color.White);

            // Draw edges
            foreach (var edge in uiEdges)
            {
                Node from = Nodes.First(n => n._id == edge.Item1);
                Node to = Nodes.First(n => n._id == edge.Item2);
                int capacity = edge.Item3;

                // Tìm dữ liệu cạnh thực tế
                var edgeData = Edges.FirstOrDefault(ed => ed.From == from._id && ed.To == to._id);

                // Tô màu và độ dày cạnh
                Color edgeColor = (edgeData != null && edgeData.Flow > 0) ? Color.Blue : Color.Black;
                float thickness = (edgeData != null && edgeData.Flow > 0)
                    ? Math.Min(8, 2 + edgeData.Flow * 0.02f) // Giới hạn max 8px
                    : 2;


                float dx = to.X - from.X;
                float dy = to.Y - from.Y;
                float len = (float)Math.Sqrt(dx * dx + dy * dy);

                // Bỏ qua nếu trùng điểm hoặc len quá nhỏ
                if (len < 0.5f)
                    continue;

                // Giới hạn độ dài tối đa để tránh tràn (nếu cạnh cực lớn)
                float maxLen = 1000f;
                if (len > maxLen)
                {
                    float scale = maxLen / len;
                    to = new Node(to._id, to._label, from.X + dx * scale, from.Y + dy * scale);
                }

                             
                if (len < 0.1f) continue;

                // Vector đơn vị
                float ux = dx / len;
                float uy = dy / len;

                // Tính điểm bắt đầu & kết thúc (cách mép node ra)
                PointF start = new PointF(from.X + ux * NODE_RADIUS, from.Y + uy * NODE_RADIUS);
                PointF end = new PointF(to.X - ux * NODE_RADIUS, to.Y - uy * NODE_RADIUS);

                // Vẽ mũi tên
                using (var pen = new Pen(edgeColor, thickness))
                {
                    pen.CustomEndCap = new AdjustableArrowCap(5, 7, true);
                    g.DrawLine(pen, start, end);
                    if (edgeData != null && edgeData.Flow > 0)
                    {
                        int particleCount = Math.Min(5, edgeData.Flow / 5); // số hạt theo flow
                        for (int i = 0; i < particleCount; i++)
                        {
                            float phaseOffset = (flowPhase + i * 0.2f) % 1f;
                            float px = start.X + (end.X - start.X) * phaseOffset;
                            float py = start.Y + (end.Y - start.Y) * phaseOffset;

                            float radius = 4f;
                            using (var brush1 = new SolidBrush(Color.Orange))
                            {
                                g.FillEllipse(brush1, px - radius, py - radius, radius * 2, radius * 2);
                            }
                        }
                    }
                }


                // Tính vị trí nhãn
                float midX = (from.X + to.X) / 2;
                float midY = (from.Y + to.Y) / 2;
                float offsetX = (to.Y - from.Y) * 0.05f;
                float offsetY = (from.X - to.X) * 0.05f;

                // Gán nhãn và màu chữ
                string label;
                Brush brush;

                if (edgeData != null)
                {
                    label = $"{edgeData.Flow}/{edgeData.Capacity}";
                    brush = (edgeData.Flow > 0) ? Brushes.DarkBlue : Brushes.Gray;
                }
                else
                {
                    label = capacity.ToString();
                    brush = Brushes.DarkRed;
                }
                if (uiEdges.Count < 300)
                    g.DrawString(label, edgeFont, brush, midX + offsetX, midY + offsetY);

            }

            // Draw nodes
            foreach (var n in Nodes)
            {
                var rect = new Rectangle(
                    (int)(n.X - NODE_RADIUS),
                    (int)(n.Y - NODE_RADIUS),
                    NODE_RADIUS * 2,
                    NODE_RADIUS * 2);

                Color fill;
                if (sourceNodes.Contains(n))
                    fill = Color.LightGreen;
                else if (sinkNodes.Contains(n))
                    fill = Color.IndianRed;
                else if (n == selectedNode)
                    fill = Color.Orange;
                else
                    fill = Color.LightSkyBlue;

                using (var brush = new SolidBrush(fill))
                    g.FillEllipse(brush, rect);

                g.DrawEllipse(Pens.Black, rect);

                var f = this.Font;
                var sz = g.MeasureString(n._label, f);
                g.DrawString(n._label, f, Brushes.Black, n.X - sz.Width / 2, n.Y - sz.Height / 2);
            }

        }

        private Graph BuildGraphFromUI()
        {
            Graph g = new Graph(Nodes.Count);
            foreach (var edge in uiEdges)
            {
                g.AddEdge(edge.Item1, edge.Item2, edge.Item3);
            }
            return g;
        }
        private void PanelDraw_EraseEdge(object sender, MouseEventArgs e)
        {
            var hitEdge = FindEdgeAt(e.X, e.Y);
            if (hitEdge != null)
            {
                uiEdges.Remove(hitEdge);
                pnlDraw.Invalidate();
            }
            pnlDraw.MouseClick -= PanelDraw_EraseEdge;
        }
        private void PanelDraw_EditEdge(object sender, MouseEventArgs e)
        {
            var hitEdge = FindEdgeAt(e.X, e.Y);
            if (hitEdge != null)
            {
                string direction = $"N{hitEdge.Item1} → N{hitEdge.Item2}";
                string prompt = $"Edge direction: {direction}\nCurrent Capacity: {hitEdge.Item3}\n\nEnter new capacity:";

                string input = Microsoft.VisualBasic.Interaction.InputBox(
                    prompt, "Edge editing", hitEdge.Item3.ToString());


                if (int.TryParse(input, out int newCap))
                {
                    // Cập nhật cạnh
                    uiEdges.Remove(hitEdge);
                    uiEdges.Add(new Tuple<int, int, int>(hitEdge.Item1, hitEdge.Item2, newCap));
                    pnlDraw.Invalidate();
                }
            }

            // bỏ event sau 1 lần dùng để không bị double
            pnlDraw.MouseClick -= PanelDraw_EditEdge;
        }
        private void btnSelect_Click(object sender, EventArgs e)
        {
            mode = "Select";
            btnSelect.BackColor = Color.LightGreen;
            btnEraseNode.BackColor = SystemColors.Control;
            btnEraseEdge.BackColor = SystemColors.Control;
            btnAddNode.BackColor = SystemColors.Control;
            btnAddEdge.BackColor = SystemColors.Control;
            btnSelectSource.BackColor = SystemColors.Control;
            btnSelectSink.BackColor = SystemColors.Control;
        }
        private void btnAddNode_Click(object sender, EventArgs e)
        {
            mode = "AddNode";
            btnAddNode.BackColor = Color.LightGreen;
            btnEraseEdge.BackColor = SystemColors.Control;
            btnSelect.BackColor = SystemColors.Control;
            btnEraseNode.BackColor = SystemColors.Control;
            btnAddEdge.BackColor = SystemColors.Control;
            btnSelectSource.BackColor = SystemColors.Control;
            btnSelectSink.BackColor = SystemColors.Control;
        }
        private void btnAddEdge_Click(object sender, EventArgs e)
        {
            mode = "AddEdge";
            btnAddEdge.BackColor = Color.LightGreen;
            btnAddNode.BackColor = SystemColors.Control;
            btnEraseEdge.BackColor = SystemColors.Control;
            btnSelect.BackColor = SystemColors.Control;
            btnEraseNode.BackColor = SystemColors.Control;
            btnSelectSource.BackColor = SystemColors.Control;
            btnSelectSink.BackColor = SystemColors.Control;
        }
        private void btnEditEdge_Click(object sender, EventArgs e)
        {
            pnlDraw.MouseClick += PanelDraw_EditEdge;
            btnEditEdge.BackColor = Color.LightGreen;
            btnSelect.BackColor = SystemColors.Control;
            btnEraseNode.BackColor = SystemColors.Control;
            btnEraseEdge.BackColor = SystemColors.Control;
            btnAddNode.BackColor = SystemColors.Control;
            btnAddEdge.BackColor = SystemColors.Control;
            btnSelectSource.BackColor = SystemColors.Control;
            btnSelectSink.BackColor = SystemColors.Control;
            MessageBox.Show("Click on the edge you want to edit capacity.");
        }
        
        private void btnEraseNode_Click(object sender, EventArgs e)
        {
            mode = "EraseNode";
            btnEraseNode.BackColor = Color.LightGreen;
            btnEraseEdge.BackColor = SystemColors.Control;
            btnAddNode.BackColor = SystemColors.Control;
            btnAddEdge.BackColor = SystemColors.Control;
            btnSelect.BackColor = SystemColors.Control;
            btnSelectSource.BackColor = SystemColors.Control;
            btnSelectSink.BackColor = SystemColors.Control;
            btnEditEdge.BackColor =SystemColors.Control;
            MessageBox.Show("Click the button to erase (you are in Erase Node mode).");
        }
        private void btnEraseEdge_Click(object sender, EventArgs e)
        {
            mode = "EraseEdge";
            btnEraseEdge.BackColor = Color.LightGreen;
            btnEraseNode.BackColor = SystemColors.Control;
            btnAddNode.BackColor = SystemColors.Control;
            btnAddEdge.BackColor = SystemColors.Control;
            btnSelectSource.BackColor = SystemColors.Control;
            btnSelectSink.BackColor = SystemColors.Control;
            MessageBox.Show("Click on the edge to erase (you are in Erase Edge mode).");
        }
        
        private void BtnClear_Click(object sender, EventArgs e)
        {
            Graph newGraph = new Graph(Nodes.Count);
            btnEraseNode.BackColor = SystemColors.Control;
            btnEraseEdge.BackColor = SystemColors.Control;
            btnAddNode.BackColor = SystemColors.Control;
            btnAddEdge.BackColor = SystemColors.Control;
            btnSelect.BackColor = SystemColors.Control;
            btnSelectSource.BackColor = SystemColors.Control;
            btnSelectSink.BackColor = SystemColors.Control;
            btnEditEdge.BackColor = SystemColors.Control;
            Nodes.Clear();
            uiEdges.Clear();
            sourceNodes.Clear();
            sinkNodes.Clear();
            selectedNode = null;
            nextNodeId = 0;
            lblMaxFlow.Text = "0";
            Nodes.Clear();
            Edges.Clear();
            pnlDraw.Invalidate();
        }

        private void buttonSelectSource_Click(object sender, EventArgs e)
        {
            mode = "SelectSourceMulti";
            btnSelectSource.BackColor = Color.LightGreen;
            btnSelectSink.BackColor = SystemColors.Control;
            btnEraseNode.BackColor = SystemColors.Control;
            btnEraseEdge.BackColor = SystemColors.Control;
            btnAddNode.BackColor = SystemColors.Control;
            btnAddEdge.BackColor = SystemColors.Control;
        }

        private void buttonSelectSink_Click(object sender, EventArgs e)
        {
            mode = "SelectSinkMulti";
            btnSelectSink.BackColor = Color.LightGreen;
            btnSelectSource.BackColor = SystemColors.Control;
            btnEraseNode.BackColor = SystemColors.Control;
            btnEraseEdge.BackColor = SystemColors.Control;
            btnAddNode.BackColor = SystemColors.Control;
            btnAddEdge.BackColor = SystemColors.Control;
        }
        private void btnRun_Click(object sender, EventArgs e)
        {
            try
            {
                Graph g = BuildGraphFromUI();
                if (g == null || Nodes.Count == 0)
                {
                    MessageBox.Show("No graph defined.");
                    return;
                }

                if (sourceNodes.Count == 0 || sinkNodes.Count == 0)
                {
                    MessageBox.Show("Please select at least one source and one sink.");
                    return;
                }

                int superSource = Nodes.Count;
                int superSink = Nodes.Count + 1;
                Graph newGraph = new Graph(Nodes.Count + 2);

                foreach (var edge in uiEdges)
                {
                    if (edge.Item1 < newGraph._vertexCount && edge.Item2 < newGraph._vertexCount)
                        newGraph.AddEdge(edge.Item1, edge.Item2, Math.Max(1, edge.Item3));
                }

                foreach (var s in sourceNodes.Where(n => n != null))
                {
                    newGraph.AddEdge(superSource, s._id, int.MaxValue / 4);
                }


                foreach (var t in sinkNodes.Where(n => n != null))
                {
                    newGraph.AddEdge(t._id, superSink, int.MaxValue / 4);
                }
                if (!CheckReachability(newGraph.GetAllEdges().ToList(), sourceNodes, sinkNodes))
                {
                    MessageBox.Show("There is no path in the selected direction. Check the edge direction.");
                    return;
                }
                //chạy edmondkarf
                int maxFlow = MaxFlowSolve.EdmondKarp(newGraph, superSource, superSink);
                lblMaxFlow.Text = $"{maxFlow}";
                // Lưu kết quả edges để vẽ
                Edges = newGraph.GetAllEdges().ToList();
                pnlDraw.Invalidate();
            }
            catch (Exception ex)
            {
                lblMaxFlow.Text = "Error: " + ex.Message;
            }
            mode = "Select";
        }
        //Check có bị cạnh ngược lại khi tạo ko
        public bool CheckReachability(List<Edge> edges, List<Node> sources, List<Node> sinks)
        {
            foreach (var s in sources)
            {
                if (s == null) continue;
                foreach (var t in sinks)
                {
                    if (t == null) continue;

                    if (HasPath(edges, s._id, t._id))
                        return true;
                }
            }
            return false;
        }

        private bool HasPath(List<Edge> edges, int sourceId, int sinkId)
        {
            var visited = new HashSet<int>();
            var queue = new Queue<int>();
            queue.Enqueue(sourceId);
            visited.Add(sourceId);

            while (queue.Count > 0)
            {
                int current = queue.Dequeue();
                if (current == sinkId)
                    return true;

                foreach (var edge in edges)
                {
                    if (edge.From == current && !visited.Contains(edge.To))
                    {
                        visited.Add(edge.To);
                        queue.Enqueue(edge.To);
                    }
                }
            }
            return false;
        }
        public void ApplyLanguage()
        {
            btnAddNode.Text = LanguageManager.Get("BtnAddNode");
            btnAddEdge.Text = LanguageManager.Get("BtnAddEdge");
            btnClear.Text = LanguageManager.Get("BtnClear");
            btnRun.Text = LanguageManager.Get("BtnRun");
            label1.Text = LanguageManager.Get("LabelMaxFlow");
            btnEraseNode.Text = LanguageManager.Get("BtnEraseNode");
            btnEditEdge.Text = LanguageManager.Get("BtnEditEdge");
            btnEraseEdge.Text = LanguageManager.Get("BtnEraseEdge");
            btnSelect.Text = LanguageManager.Get("BtnSelect");
            btnSelectSource.Text = LanguageManager.Get("BtnSelectSource");
            btnSelectSink.Text = LanguageManager.Get("BtnSelectSink");

        }


    }
}
