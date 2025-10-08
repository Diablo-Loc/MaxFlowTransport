using Microsoft.VisualBasic.Devices;
using src.Algorithms;
using src.Models;
using src.UI.Controls;
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
using System.Windows.Forms.VisualStyles;
using System.Xml.Linq;


namespace src.UI
{

    public partial class CalculaterMF : Form
    {
        private List<Node> Nodes = new List<Node>();
        public List<Edge> Edges = new List<Edge>();
        private List<Tuple<int, int, int>> uiEdges = new List<Tuple<int, int, int>>();
        private float scaleFactor = 1.0f;
        private const int NODE_RADIUS = 20;
        private float zoomFactor = 1.0f;
        private PointF panOffset = new PointF(0, 0);
        private Point lastMousePos;
        private bool isPanning = false;
        private float autoScale = 1.0f;
        private float margin = 40f;
        private bool isInputVisible = true;
        private System.Windows.Forms.Timer flowTimer;
        private System.Windows.Forms.Timer tickerTimer;
        private float flowPhase = 0f; // góc pha của hiệu ứng dòng chảy
        private TransportInput transportInput;
        private Node draggingNode = null;
        private Point dragOffset;
        private string mode = "Select";
        private Edge selectedEdge = null;
        public CalculaterMF()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            StyleRoundedButton(btnCreat, 20);
            StyleRoundedButton(btnRun, 20);
            StyleRoundedButton(btnClear, 20);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint |
                          ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();
            LoadTestCases();

            cbTestCase.SelectedIndexChanged += cbTestCase_SelectedIndexChanged;
            flowTimer = new System.Windows.Forms.Timer();
            flowTimer.Interval = 500;
            flowTimer.Tick += (s, e) =>
            {
                flowPhase += 0.02f;
                if (flowPhase > 100f) flowPhase -= 100f;
                pnlDraw.Invalidate();
            };
            flowTimer.Start();
            pnlDraw.BackColor = Color.White;
            pnlDraw.Paint += PnlDraw_Paint;
            pnlDraw.BringToFront();
            pnlDraw.MouseWheel += PnlDraw_MouseWheel;
            pnlDraw.Resize += pnlDraw_Resize;
            pnlDraw.MouseWheel += PnlDraw_MouseWheel;
            pnlDraw.MouseDown += PnlDraw_MouseDown;
            pnlDraw.MouseUp += PnlDraw_MouseUp;
            pnlDraw.MouseMove += PnlDraw_MouseMove;
            pnlDraw.Resize += (s, e) =>
            {
                AutoArrangeNodes();
                AutoFitGraphToPanel();
                pnlDraw.Invalidate();
            };
            tickerTimer = new System.Windows.Forms.Timer();
            tickerTimer.Interval = 1;
            tickerTimer.Tick += (s, e) =>
            {
                lblTicker.Left -= 2;
                if (lblTicker.Right < 0)
                {
                    lblTicker.Left = pnlTicker.Width;
                }
            };
            if (isInputVisible)
                pnlDraw.Height = this.ClientSize.Height - pnlInput.Height - 20;
            else
                pnlDraw.Height = this.ClientSize.Height - 20;
            chkEnableAnimation.CheckedChanged += (s, e) =>
            {
                if (chkEnableAnimation.Checked)
                    flowTimer.Start();
                else
                    flowTimer.Stop();

                pnlDraw.Invalidate();
            };
            chkEnableBalancing.CheckedChanged += (s, e) =>
            {
                bool hasInputFromUI =
                    pnlInput.Visible &&
                    !string.IsNullOrWhiteSpace(txbInputSupply.Text) &&
                    !string.IsNullOrWhiteSpace(txbInputDemand.Text);

                bool hasTransportInput = !pnlInput.Visible && transportInput != null;

                if (hasInputFromUI || hasTransportInput)
                {
                    btnRun.PerformClick();
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu để xử lý. Vui lòng nhập hoặc chọn test case.");
                }
            };
            chkColorByFlow.CheckedChanged += (s, e) => pnlDraw.Invalidate();
        }

        public class DoubleBufferedPanel : Panel
        {
            public DoubleBufferedPanel()
            {
                this.DoubleBuffered = true;
                this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                              ControlStyles.UserPaint |
                              ControlStyles.OptimizedDoubleBuffer, true);
                this.UpdateStyles();
            }
        }
        private void btnConfirmInput_Click(object sender, EventArgs e)
        {
            try
            {
                int[] supply = txbInputSupply.Text.Split(',', StringSplitOptions.RemoveEmptyEntries)
                                    .Select(x => int.Parse(x.Trim())).ToArray();
                int[] demand = txbInputDemand.Text.Split(',', StringSplitOptions.RemoveEmptyEntries)
                                    .Select(x => int.Parse(x.Trim())).ToArray();

                if (!TryReadCapacityGrid(out int[,] cap, out string err))
                {
                    MessageBox.Show(err, "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                transportInput = new TransportInput
                {
                    Supply = supply,
                    Demand = demand,
                    Capacity = CloneMatrix(cap)
                };

                panelInput.Visible = false;
                MessageBox.Show("Dữ liệu đã được lưu. Bạn có thể tiếp tục xử lý.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xác nhận dữ liệu: " + ex.Message);
            }
        }
        private int[,] CloneMatrix(int[,] original)
        {
            int rows = original.GetLength(0);
            int cols = original.GetLength(1);
            int[,] clone = new int[rows, cols];
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    clone[i, j] = original[i, j];
            return clone;
        }
        private void btnRun_Click(object sender, EventArgs e)
        {
            try
            {
                Nodes.Clear();
                uiEdges.Clear();
                Edges.Clear();

                int[] supply;
                int[] demand;
                int[,] cap;
                if (pnlInput.Visible)
                {
                    int[] originalSupply = txbInputSupply.Text.Split(',', StringSplitOptions.RemoveEmptyEntries)
                                                .Select(x => int.Parse(x.Trim())).ToArray();
                    int[] originalDemand = txbInputDemand.Text.Split(',', StringSplitOptions.RemoveEmptyEntries)
                                                .Select(x => int.Parse(x.Trim())).ToArray();

                    if (!TryReadCapacityGrid(out int[,] originalCap, out string err))
                    {
                        MessageBox.Show(err, "Data error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    supply = (int[])originalSupply.Clone();
                    demand = (int[])originalDemand.Clone();
                    cap = CloneMatrix(originalCap);
                    if (supply.Length + demand.Length > 6)
                    {
                        lblTicker.Visible = true;
                        pnlTicker.Visible = true;
                        lblTicker.Left = pnlTicker.Width;
                        tickerTimer.Start();
                    }
                    else
                    {
                        lblTicker.Visible = false;
                        pnlTicker.Visible = false;
                        tickerTimer.Stop();
                    }
                }
                // Nếu panel đã ẩn → dùng dữ liệu đã lưu
                else if (transportInput != null)
                {
                    supply = (int[])transportInput.Supply.Clone();
                    demand = (int[])transportInput.Demand.Clone();
                    cap = CloneMatrix(transportInput.Capacity);
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu đầu vào. Vui lòng nhập trước khi xử lý.");
                    return;
                }
                // Nếu bật chế độ cân bằng
                if (chkEnableBalancing.Checked)
                {
                    BalanceTransportationProblem(ref supply, ref demand, ref cap);
                }
                else
                {
                    if (supply.Sum() != demand.Sum())
                    {
                        MessageBox.Show("Tổng cung ≠ tổng cầu. Sơ đồ có thể không tối ưu!");
                    }
                }
                // Tạo graph và tính Max Flow
                Graph g = Utils.BuildTransportationGraph(supply, demand, cap);
                int source = supply.Length + demand.Length;
                int sink = source + 1;
                int maxFlow = MaxFlowSolve.EdmondKarp(g, source, sink);

                lblMaxFlow.Text = $"Maximum Flow = {maxFlow}";
                Edges = g.GetAllEdges().ToList();

                // Vẽ sơ đồ
                GenerateAutoLayout(supply, demand, cap);
                zoomFactor = 1.0f;
                panOffset = new PointF(pnlDraw.Width / 4f, 0);
                AutoArrangeNodes();
                AutoFitGraphToPanel();
                AutoFitGraph();
                pnlDraw.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while running: " + ex.Message);
            }
            mode = "Select";
        }

        private void GenerateAutoLayout(int[] supply, int[] demand, int[,] cap)
        {
            Nodes.Clear();
            uiEdges.Clear();

            int supplyCount = supply.Length;
            int demandCount = demand.Length;
            int panelWidth = pnlDraw.ClientSize.Width;
            int panelHeight = pnlDraw.ClientSize.Height;
            if (panelWidth < 100 || panelHeight < 100) return;
            int marginX = 100;
            int marginY = 40;
            float supplySpacing = (float)(panelHeight - 2 * marginY) / Math.Max(1, supplyCount - 1);
            float demandSpacing = (float)(panelHeight - 2 * marginY) / Math.Max(1, demandCount - 1);
            int leftX = marginX;
            int rightX = panelWidth - marginX;
            // Kiểm tra node giả
            bool hasDummySupply = supplyCount > cap.GetLength(0);
            bool hasDummyDemand = demandCount > cap.GetLength(1);
            // Tạo node supply (màu xanh hoặc xám nếu giả)
            for (int i = 0; i < supplyCount; i++)
            {
                float y = marginY + i * supplySpacing;
                string label = hasDummySupply && i == supplyCount - 1 ? $"S*({supply[i]})" : $"S{i}({supply[i]})";
                Nodes.Add(new Node(i, label, leftX, y));
            }
            // Tạo node demand (màu đỏ hoặc xám nếu giả)
            for (int j = 0; j < demandCount; j++)
            {
                float y = marginY + j * demandSpacing;
                string label = hasDummyDemand && j == demandCount - 1 ? $"D*({demand[j]})" : $"D{j}({demand[j]})";
                Nodes.Add(new Node(supplyCount + j, label, rightX, y));
            }
            // Cạnh giữa tất cả supply và demand
            for (int i = 0; i < supplyCount; i++)
            {
                for (int j = 0; j < demandCount; j++)
                {
                    uiEdges.Add(new Tuple<int, int, int>(i, supplyCount + j, cap[i, j]));
                }
            }
        }

        private void PnlDraw_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(Color.White);

            // Hệ số zoom và dịch chuyển
            g.TranslateTransform(panOffset.X, panOffset.Y);
            g.ScaleTransform(zoomFactor, zoomFactor);

            // ---- Vẽ cạnh ----
            foreach (var edge in uiEdges)
            {

                Node from = Nodes.First(n => n._id == edge.Item1);
                Node to = Nodes.First(n => n._id == edge.Item2);
                int capacity = edge.Item3;
                // Lấy dữ liệu flow (nếu có)
                var edgeData = Edges.FirstOrDefault(ed => ed.From == from._id && ed.To == to._id);
                int flow = edgeData?.Flow ?? 0;
                bool isDummyEdge = (capacity == 0 && flow == 0);
                // --- Chọn thông số hiển thị ---
                float valueForThickness = chkColorByFlow.Checked ? flow : capacity;
                float ratio = capacity > 0 ? (float)flow / capacity : 0;
                //Độ dày
                float thickness = Math.Min(10f, 1.5f + valueForThickness / 80f);
                 // Màu cạnh
                Color baseColor;
                if (isDummyEdge)
                {
                    baseColor = Color.DarkBlue; // cạnh giả
                }
                else if (chkColorByFlow.Checked)
                {
                    // Màu theo flow
                    baseColor = Color.FromArgb(
                        (int)(100 + 150 * ratio),
                        (int)(50 + 150 * (1 - ratio)),
                        (int)(255 - 100 * ratio)
                    );
                }
                else
                {
                    // Màu theo capacity
                    baseColor = GetEdgeColor(capacity);
                }
                //Xác định vị trí vẽ (chừa node)
                float dx = to.X - from.X;
                float dy = to.Y - from.Y;
                float len = (float)Math.Sqrt(dx * dx + dy * dy);
                if (len < 1f) continue;

                float ux = dx / len;
                float uy = dy / len;
                const int NODE_RADIUS = 20;
                PointF start = new PointF(from.X + ux * NODE_RADIUS, from.Y + uy * NODE_RADIUS);
                PointF end = new PointF(to.X - ux * NODE_RADIUS, to.Y - uy * NODE_RADIUS);
                //vẽ cạnh có dấu mũi tên
                using (var pen = new Pen(baseColor, thickness))
                {
                    pen.Alignment = PenAlignment.Center;
                    pen.LineJoin = LineJoin.Round;
                    var arrowCap = new AdjustableArrowCap(7, 9, false);
                    arrowCap.Filled = false; // mũi tên rỗng
                    pen.CustomEndCap = arrowCap;
                    // Viền trắng mờ làm nổi
                    using (var outlinePen = new Pen(Color.White, thickness + 2))
                    {
                        outlinePen.LineJoin = LineJoin.Round;
                        g.DrawLine(outlinePen, start, end);
                    }
                    g.DrawLine(pen, start, end);
                    // Hiệu ứng sáng di chuyển theo hướng cạnh (chỉ khi flow > 0)
                    if (flow > 0 && chkEnableAnimation.Checked)
                    {
                        float glowLen = 30f;
                        float t = flowPhase % 1.0f;

                        float posX = start.X + (end.X - start.X) * t;
                        float posY = start.Y + (end.Y - start.Y) * t;

                        int particleCount = Math.Max(1, Math.Min(5, flow / 5)); // max 5 hạt
                        for (int k = 0; k < particleCount; k++)
                        {
                            float phaseOffset = (flowPhase + k * 0.2f) % 1.0f;
                            float px = start.X + (end.X - start.X) * phaseOffset;
                            float py = start.Y + (end.Y - start.Y) * phaseOffset;

                            using (var brush = new SolidBrush(Color.Orange))
                            {
                                float radius = 8f;
                                g.FillEllipse(brush, px - radius, py - radius, radius * 2, radius * 2);
                            }
                        }

                    }
                    g.DrawLine(pen, start, end);
                }
                //  Ghi flow/capacity
                float midX = (start.X + end.X) / 2;
                float midY = (start.Y + end.Y) / 2;
                float offsetX = (to.Y - from.Y) * 0.05f;
                float offsetY = (from.X - to.X) * 0.05f;
                string label = isDummyEdge ? "—" : $"{flow}/{capacity}";
                // Màu chữ theo màu cạnh
                Color textColor = isDummyEdge ? Color.DarkGray : Color.FromArgb(
                    Math.Min(255, baseColor.R + 40),
                    Math.Min(255, baseColor.G + 40),
                    Math.Min(255, baseColor.B + 40)
                );
                using (var font = new Font("Segoe UI", 9, FontStyle.Bold))
                using (var brush = new SolidBrush(textColor))
                {
                    // Viền trắng mờ để chữ không chìm
                    using (var outlineBrush = new SolidBrush(Color.FromArgb(200, Color.White)))
                    {
                        g.DrawString(label, font, outlineBrush, midX + offsetX + 1, midY + offsetY + 1);
                    }
                    g.DrawString(label, font, brush, midX + offsetX, midY + offsetY);
                }
                //hiệu ứng hover vào cạnh

            }
            // ---- Vẽ node ----
            const int R = 20;
            foreach (var n in Nodes)
            {
                Brush nodeBrush;
                if (n._label.StartsWith("S*") || n._label.StartsWith("D*"))
                    nodeBrush = new SolidBrush(Color.LightGray); // node giả
                else if (n._label.StartsWith("D"))
                    nodeBrush = Brushes.OrangeRed;
                else
                    nodeBrush = Brushes.LightGreen;
                g.FillEllipse(nodeBrush, n.X - R, n.Y - R, R * 2, R * 2);
                g.DrawEllipse(Pens.Black, n.X - R, n.Y - R, R * 2, R * 2);

                var size = g.MeasureString(n._label, this.Font);
                g.DrawString(n._label, this.Font, Brushes.Black,
                             n.X - size.Width / 2, n.Y - size.Height / 2);
            }
        }
        private Color GetEdgeColor(int value)
        {
            value = Math.Max(0, Math.Min(1000, value));
            if (value < 200)
                return Color.FromArgb(170, 220, 255); // nhạt
            else if (value < 400)
                return Color.FromArgb(90, 180, 255);  // xanh vừa
            else if (value < 700)
                return Color.FromArgb(60, 120, 255);  // xanh đậm
            else
                return Color.FromArgb(150, 60, 255);  // tím mạnh
        }
        private void AutoArrangeNodes()
        {
            if (Nodes.Count == 0) return;
            var supplyNodes = Nodes.Where(n => n._label.StartsWith("S")).ToList();
            var demandNodes = Nodes.Where(n => n._label.StartsWith("D")).ToList();
            if (supplyNodes.Count == 0 || demandNodes.Count == 0) return;
            int panelW = Math.Max(1, pnlDraw.ClientSize.Width);
            int panelH = Math.Max(1, pnlDraw.ClientSize.Height);
            //1️Cấu hình mặc định
            int leftMargin = 80;
            int rightMargin = 80;
            int topMargin = 40;
            int bottomMargin = 40;

            // 2️ Tính khoảng cách giữa các node
            float availableHeight = panelH - topMargin - bottomMargin;
            float supplySpacing = availableHeight / Math.Max(1, supplyNodes.Count - 1);
            float demandSpacing = availableHeight / Math.Max(1, demandNodes.Count - 1);

            // Giới hạn khoảng cách tối thiểu để không chồng
            supplySpacing = Math.Max(supplySpacing, 25f);
            demandSpacing = Math.Max(demandSpacing, 25f);

            //3️ Tính vị trí X hai cột node
            int leftX = leftMargin + 60;
            int rightX = panelW - rightMargin - 60;
            // Nếu panel quá nhỏ hoặc node quá nhiều → scale tự động
            float scaleX = Math.Max(0.3f, Math.Min(1.0f, (float)(panelW) / 1000f));
            float scaleY = Math.Max(0.3f, Math.Min(1.0f, (float)(panelH) / 700f));
            float scale = Math.Min(scaleX, scaleY);
            // 4️ Cập nhật vị trí node
            for (int i = 0; i < supplyNodes.Count; i++)
            {
                supplyNodes[i].X = (int)(leftX * scale);
                supplyNodes[i].Y = (int)(topMargin + i * supplySpacing * scale);
            }

            for (int j = 0; j < demandNodes.Count; j++)
            {
                demandNodes[j].X = (int)(rightX * scale);
                demandNodes[j].Y = (int)(topMargin + j * demandSpacing * scale);
            }

            //5️Căn giữa toàn bộ đồ thị (nếu panel rộng hơn cần thiết)
            int minX = Convert.ToInt32(Nodes.Min(n => n.X));
            int maxX = Convert.ToInt32(Nodes.Max(n => n.X));
            int graphWidth = maxX - minX;
            int offsetX = (panelW - graphWidth) / 2 - minX;

            foreach (var n in Nodes)
                n.X += offsetX;

            pnlDraw.Invalidate();
        }
        private void AutoFitGraphToPanel()
        {
            if (Nodes.Count == 0) return;

            float minX = Nodes.Min(n => n.X);
            float maxX = Nodes.Max(n => n.X);
            float minY = Nodes.Min(n => n.Y);
            float maxY = Nodes.Max(n => n.Y);

            float graphWidth = maxX - minX + margin * 2;
            float graphHeight = maxY - minY + margin * 2;

            float panelWidth = pnlDraw.ClientSize.Width;
            float panelHeight = pnlDraw.ClientSize.Height;

            // Tính scale nhỏ nhất để toàn đồ thị vừa khung
            float scaleX = panelWidth / graphWidth;
            float scaleY = panelHeight / graphHeight;

            autoScale = Math.Min(scaleX, scaleY);

            // Dịch tâm về giữa panel
            float offsetX = (panelWidth - graphWidth * autoScale) / 2 - minX * autoScale + margin;
            float offsetY = (panelHeight - graphHeight * autoScale) / 2 - minY * autoScale + margin;

            // Cập nhật vị trí node theo tỉ lệ này
            foreach (var n in Nodes)
            {
                n.X = n.X * autoScale + offsetX;
                n.Y = n.Y * autoScale + offsetY;
            }
        }

        private void AutoFitGraph()
        {
            if (Nodes == null || Nodes.Count == 0)
                return;

            float minX = Nodes.Min(n => n.X);
            float maxX = Nodes.Max(n => n.X);
            float minY = Nodes.Min(n => n.Y);
            float maxY = Nodes.Max(n => n.Y);

            float graphWidth = maxX - minX + 100;
            float graphHeight = maxY - minY + 100;

            float panelWidth = pnlDraw.Width - 100;
            float panelHeight = pnlDraw.Height - 100;

            if (graphWidth <= 0 || graphHeight <= 0)
                return;

            // Tính tỉ lệ để vừa panel
            float scaleX = panelWidth / graphWidth;
            float scaleY = panelHeight / graphHeight;
            zoomFactor = Math.Min(scaleX, scaleY);

            // Căn giữa
            panOffset = new PointF(
                (pnlDraw.Width - graphWidth * zoomFactor) / 2f - minX * zoomFactor,
                (pnlDraw.Height - graphHeight * zoomFactor) / 2f - minY * zoomFactor
            );
        }
        private void pnlDraw_Resize(object sender, EventArgs e)
        {
            if (Nodes.Count > 0)
            {
                pnlDraw.Invalidate();
                pnlDraw.Refresh();
            }
        }
        private void PnlDraw_MouseWheel(object sender, MouseEventArgs e)
        {
            // Zoom tại vị trí chuột
            float oldZoom = zoomFactor;
            if (e.Delta > 0)
                zoomFactor *= 1.1f;
            else
                zoomFactor /= 1.1f;

            // Giới hạn zoom
            zoomFactor = Math.Max(0.3f, Math.Min(zoomFactor, 3.0f));

            // Căn giữa lại khi zoom
            panOffset.X = e.X - (e.X - panOffset.X) * (zoomFactor / oldZoom);
            panOffset.Y = e.Y - (e.Y - panOffset.Y) * (zoomFactor / oldZoom);
            pnlDraw.Invalidate();
        }
        private void PnlDraw_MouseDown(object sender, MouseEventArgs e)
        {
            pnlDraw.Invalidate();
            if (e.Button == MouseButtons.Middle)
            {
                isPanning = true;
                lastMousePos = e.Location;
            }
            if (mode == "Select")
            {
                var hit = FindNodeAt(e.X, e.Y);
                if (hit != null)
                {
                    draggingNode = hit;
                    dragOffset = new Point(  (int)(e.X - (hit.X * zoomFactor + panOffset.X)),
                                             (int)(e.Y - (hit.Y * zoomFactor + panOffset.Y))
                    );
                }
            }
        }
        private Node FindNodeAt(int x, int y)
        {
            int r = NODE_RADIUS + 4;
            foreach (var n in Nodes)
            {
                float screenX = n.X * zoomFactor + panOffset.X;
                float screenY = n.Y * zoomFactor + panOffset.Y;
                float dx = screenX - x;
                float dy = screenY - y;
                if (dx * dx + dy * dy <= r * r)
                    return n;
            }
            return null;
        }
        private void PnlDraw_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
                isPanning = false;
        }

        private void PnlDraw_MouseMove(object sender, MouseEventArgs e)
        {
            bool needRedraw = false;

            if (isPanning)
            {
                panOffset.X += e.X - lastMousePos.X;
                panOffset.Y += e.Y - lastMousePos.Y;
                lastMousePos = e.Location;
                needRedraw = true;
            }

            if(e.Button == MouseButtons.Left && draggingNode != null)
{
                float newX = (e.X - dragOffset.X - panOffset.X) / zoomFactor;
                float newY = (e.Y - dragOffset.Y - panOffset.Y) / zoomFactor;
                draggingNode.X = newX;
                draggingNode.Y = newY;
                pnlDraw.Invalidate();
            }

            if (needRedraw)
                pnlDraw.Invalidate();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            txbInputSupply.Clear();
            txbInputDemand.Clear();
            dgvCapacity.Columns.Clear();
            dgvCapacity.Rows.Clear();
            Nodes.Clear();
            Edges.Clear();
            uiEdges.Clear();
            pnlDraw.Invalidate();
            lblMaxFlow.Text = ($"Maximum Flow = --");
            cbTestCase.Text = ($"--");
            lblTicker.Visible = false;

        }
        private void CreateCapacityGrid(int[] supply, int[] demand, int[,] defaultCap = null)
        {
            dgvCapacity.Columns.Clear();
            dgvCapacity.Rows.Clear();
            int r = supply.Length;
            int c = demand.Length;
            for (int j = 0; j < c; j++)
            {
                var col = new DataGridViewTextBoxColumn();
                col.Name = "D" + j;
                col.HeaderText = "D" + j;
                col.ValueType = typeof(int);
                col.Width = 70;
                dgvCapacity.Columns.Add(col);
            }
            for (int i = 0; i < r; i++)
            {
                object[] row = new object[c];
                if (defaultCap != null)
                {
                    for (int j = 0; j < c; j++) row[j] = defaultCap[i, j];
                }
                dgvCapacity.Rows.Add(row);
                dgvCapacity.Rows[i].HeaderCell.Value = "S" + i;
            }
            dgvCapacity.RowHeadersVisible = true;
            dgvCapacity.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
        }
        private bool TryReadCapacityGrid(out int[,] cap, out string errMsg)
        {
            cap = null;
            errMsg = null;

            if (dgvCapacity.Columns.Count == 0 || dgvCapacity.Rows.Count == 0)
            {
                errMsg = "Capacity table not created yet. Click 'Create capacity table' first.";
                return false;
            }

            int r = dgvCapacity.Rows.Count;
            int c = dgvCapacity.Columns.Count;
            cap = new int[r, c];

            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    var cell = dgvCapacity.Rows[i].Cells[j].Value;
                    if (cell == null || string.IsNullOrWhiteSpace(cell.ToString()))
                    {
                        cap[i, j] = 0;
                    }
                    else
                    {
                        if (!int.TryParse(cell.ToString(), out int v) || v < 0)
                        {
                            errMsg = $"Invalid value in cell S{i},D{j}. Please enter a non-negative integer.";
                            return false;
                        }
                        cap[i, j] = v;
                    }
                }
            }

            return true;
        }
        private void btnCreat_Click(object sender, EventArgs e)
        {
            try
            {
                int[] supply = txbInputSupply.Text.Split(',', StringSplitOptions.RemoveEmptyEntries)
                                    .Select(x => int.Parse(x.Trim())).ToArray();
                int[] demand = txbInputDemand.Text.Split(',', StringSplitOptions.RemoveEmptyEntries)
                                    .Select(x => int.Parse(x.Trim())).ToArray();
                int[,] defaultCap = Utils.SampleCapacity(supply.Length, demand.Length);

                CreateCapacityGrid(supply, demand, defaultCap);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating table: " + ex.Message);
            }
        }
        private void LoadTestCases()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;

            // Truy ngược 2 cấp lên để tới thư mục gốc project
            string projectRoot = Path.GetFullPath(Path.Combine(baseDir, @"..\..\..\"));

            // Ghép thêm thư mục "Data Test"
            string dataDir = Path.Combine(projectRoot, "Data Test");

            if (!Directory.Exists(dataDir))
            {
                Directory.CreateDirectory(dataDir);
            }

            string[] files = Directory.GetFiles(dataDir, "*.txt");
            cbTestCase.Items.Clear();
            foreach (var f in files)
            {
                cbTestCase.Items.Add(Path.GetFileNameWithoutExtension(f));
            }
        }
        //đọc từ file .txt
        private void cbTestCase_SelectedIndexChanged(object sender, EventArgs e)
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;

            // Truy ngược 2 cấp lên để tới thư mục gốc project
            string projectRoot = Path.GetFullPath(Path.Combine(baseDir, @"..\..\..\"));

            // Ghép thêm thư mục "Data Test"
            string dataDir = Path.Combine(projectRoot, "Data Test");

            string fileName = cbTestCase.SelectedItem.ToString() + ".txt";
            string filePath = Path.Combine(dataDir, fileName);

            if (!File.Exists(filePath))
            {
                MessageBox.Show("File not found: " + fileName);
                return;
            }

            string[] lines = File.ReadAllLines(filePath);
            int lineIndex = 0;

            // đọc Supply
            var supplyLine = lines[lineIndex++].Replace("Supply:", "").Trim();
            txbInputSupply.Text = supplyLine;

            // đọc Demand
            var demandLine = lines[lineIndex++].Replace("Demand:", "").Trim();
            txbInputDemand.Text = demandLine;

            // đọc matrix
            lineIndex++; // bỏ dòng "Matrix:"
            var matrixLines = lines.Skip(lineIndex).Where(l => !string.IsNullOrWhiteSpace(l)).ToArray();

            int[] supply = supplyLine.Split(',').Select(x => int.Parse(x.Trim())).ToArray();
            int[] demand = demandLine.Split(',').Select(x => int.Parse(x.Trim())).ToArray();
            int[,] cap = new int[supply.Length, demand.Length];

            for (int i = 0; i < supply.Length; i++)
            {

                var parts = matrixLines[i].Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                         .Select(int.Parse).ToArray();
                for (int j = 0; j < demand.Length; j++)
                {
                    cap[i, j] = parts[j];
                }
            }

            // hiển thị lên DataGridView
            CreateCapacityGrid(supply, demand, cap);
        }
        private void btnToggleInput_Click(object sender, EventArgs e)
        {
            isInputVisible = !isInputVisible;
            pnlInput.Visible = isInputVisible;

            if (isInputVisible)
            {
                chkEnableBalancing.Visible = true;
                btnToggleInput.Text = "Hide Input";
                pnlDraw.Height = this.ClientSize.Height - pnlInput.Height - 20;
                pnlDraw.Top = 10;
            }
            else
            {
                chkEnableBalancing.Visible = false;
                try
                {
                    int[] supply = txbInputSupply.Text.Split(',', StringSplitOptions.RemoveEmptyEntries)
                                        .Select(x => int.Parse(x.Trim())).ToArray();
                    int[] demand = txbInputDemand.Text.Split(',', StringSplitOptions.RemoveEmptyEntries)
                                        .Select(x => int.Parse(x.Trim())).ToArray();
                    int totalSupply = supply.Sum();
                    int totalDemand = demand.Sum();

                    if (totalSupply != totalDemand && !chkEnableBalancing.Checked)
                    {
                        MessageBox.Show("Muốn xem ở chế độ tự cân bằng thì nhớ tích Automatic supply/demand balance trước khi vào!!!");
                    }
                    if (!TryReadCapacityGrid(out int[,] cap, out string err))
                    {

                        cap = new int[supply.Length, demand.Length]; // tạo ma trận rỗng để test
                    }
                    transportInput = new TransportInput
                    {
                        Supply = supply,
                        Demand = demand,
                        Capacity = CloneMatrix(cap)
                    };
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể lưu dữ liệu khi ẩn panel: " + ex.Message);
                    return;
                }

                btnToggleInput.Text = "Show Input";
                pnlDraw.Height = this.ClientSize.Height - 20;
                pnlDraw.Top = 10;
            }

            AutoArrangeNodes();
            pnlDraw.Invalidate();
        }
        public static void BalanceTransportationProblem(ref int[] supply, ref int[] demand, ref int[,] cap)
        {
            int totalSupply = supply.Sum();
            int totalDemand = demand.Sum();

            if (totalSupply == totalDemand)
                return;

            bool supplyIsDummy = totalSupply < totalDemand;

            if (supplyIsDummy)
            {
                int extraSupply = totalDemand - totalSupply;
                int oldSupplyCount = supply.Length;

                Array.Resize(ref supply, oldSupplyCount + 1);
                supply[oldSupplyCount] = extraSupply;

                int[,] newCap = new int[supply.Length, demand.Length];
                for (int i = 0; i < oldSupplyCount; i++)
                    for (int j = 0; j < demand.Length; j++)
                        newCap[i, j] = cap[i, j];

                int totalAssigned = 0;
                for (int j = 0; j < demand.Length; j++)
                {
                    int assigned = (int)Math.Round((double)demand[j] / totalDemand * extraSupply);
                    newCap[oldSupplyCount, j] = assigned;
                    totalAssigned += assigned;
                }

                int diff = extraSupply - totalAssigned;
                if (diff != 0)
                    newCap[oldSupplyCount, demand.Length - 1] += diff;

                cap = newCap;
            }
            else
            {
                int extraDemand = totalSupply - totalDemand;
                int oldDemandCount = demand.Length;

                Array.Resize(ref demand, oldDemandCount + 1);
                demand[oldDemandCount] = extraDemand;

                int[,] newCap = new int[supply.Length, demand.Length];
                for (int i = 0; i < supply.Length; i++)
                    for (int j = 0; j < oldDemandCount; j++)
                        newCap[i, j] = cap[i, j];

                int totalAssigned = 0;
                for (int i = 0; i < supply.Length; i++)
                {
                    int assigned = (int)Math.Round((double)supply[i] / totalSupply * extraDemand);
                    newCap[i, oldDemandCount] = assigned;
                    totalAssigned += assigned;
                }

                int diff = extraDemand - totalAssigned;
                if (diff != 0)
                    newCap[supply.Length - 1, oldDemandCount] += diff;

                cap = newCap;
            }

            EnsureDummyConnectivity(ref cap, supply, demand, supplyIsDummy);
        }
        public static void EnsureDummyConnectivity(ref int[,] cap, int[] supply, int[] demand, bool supplyIsDummy)
        {
            int m = supply.Length;
            int n = demand.Length;

            if (supplyIsDummy)
            {
                // TH: thêm supply giả → nối đến tất cả demand
                int dummyRow = m - 1;
                int totalDemand = demand.Sum();

                for (int j = 0; j < n; j++)
                {
                    if (cap[dummyRow, j] == 0)
                    {
                        cap[dummyRow, j] = (int)Math.Round((double)demand[j] / totalDemand * supply[dummyRow]);
                    }
                }
            }
            else
            {
                // TH: thêm demand giả → nối từ tất cả supply
                int dummyCol = n - 1;
                int totalSupply = supply.Sum();

                for (int i = 0; i < m; i++)
                {
                    if (cap[i, dummyCol] == 0)
                    {
                        cap[i, dummyCol] = (int)Math.Round((double)supply[i] / totalSupply * demand[dummyCol]);
                    }
                }
            }
        }
        private void bntzomin_Click(object sender, EventArgs e)
        {
            float oldZoom = zoomFactor;
            zoomFactor *= 1.1f;
            zoomFactor = Math.Min(zoomFactor, 3.0f);

            // Zoom vào giữa panel
            Point center = new Point(pnlDraw.Width / 2, pnlDraw.Height / 2);
            panOffset.X = center.X - (center.X - panOffset.X) * (zoomFactor / oldZoom);
            panOffset.Y = center.Y - (center.Y - panOffset.Y) * (zoomFactor / oldZoom);

            pnlDraw.Invalidate();
        }
        private void btnzomout_Click(object sender, EventArgs e)
        {
            float oldZoom = zoomFactor;
            zoomFactor /= 1.1f;
            zoomFactor = Math.Max(zoomFactor, 0.3f);

            Point center = new Point(pnlDraw.Width / 2, pnlDraw.Height / 2);
            panOffset.X = center.X - (center.X - panOffset.X) * (zoomFactor / oldZoom);
            panOffset.Y = center.Y - (center.Y - panOffset.Y) * (zoomFactor / oldZoom);

            pnlDraw.Invalidate();
        }
        private void StyleRoundedButton(Button btn, int radius)
        {
            // Bo góc
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(btn.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(btn.Width - radius, btn.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, btn.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();
            btn.Region = new Region(path);

            // Giao diện
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = ColorTranslator.FromHtml("#43a047");
            btn.ForeColor = Color.Black;
            btn.Font = new Font("Segoe UI", 11F, FontStyle.Bold);

            // Hiệu ứng hover
            btn.MouseEnter += (s, e) => btn.BackColor = Color.SeaGreen;
            btn.MouseLeave += (s, e) => btn.BackColor = ColorTranslator.FromHtml("#43a047");
        }
    }

}
    public class TransportInput
    {
        public int[] Supply { get; set; }
        public int[] Demand { get; set; }
        public int[,] Capacity { get; set; }
    }

