using src.Helpers;
using src.UI.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static src.UI.Controls.FormDragger;


namespace src.UI
{
    public partial class MainForm : Form
    {
        private Button currentButton;
        private Form activeForm;
        private bool isDragging = false;
        private Point dragStartPoint = Point.Empty;
        private Home homeForm;
        private CalculaterMF calculaterForm;
        private GraphVisualizer graphForm;
        private Panel pnlManualPopup;
        private RichTextBox rtbManual;
        private System.Windows.Forms.Timer manualHideTimer;
        private string currentLanguage = "en";
        private Stopwatch manualHideStopwatch;
        private bool isMouseOutside = false;
        public MainForm()
        {
            InitializeComponent();
            FormDragger dragger = new FormDragger(pnltopbar, this, pnltopbar);
            btnHome.BackColor = Color.AntiqueWhite;
            btnCalculateMaxFlow.BackColor = Color.AntiqueWhite;
            btnSimlator.BackColor = Color.AntiqueWhite;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Resize += (s, e) =>
            {
                if (this.WindowState == FormWindowState.Normal)
                    UIHelper.ApplyRoundedCorners(this, 30);
                else
                    this.Region = null;
            };
            this.Load += MainForm_Load;


        }
        private void ActiveButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    Color color = BackColor;
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.Black;
                    //currentButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
                }
            }
        }
        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null) activeForm.Close();

            ActiveButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.pnlHienThi.Controls.Add(childForm);
            this.pnlHienThi.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }
        //Mở form mới
        private void btnHome_Click(object sender, EventArgs e)
        {
            homeForm = new Home();
            OpenChildForm(homeForm, sender);
            homeForm.ApplyLanguage();
            pnlUserManual.Visible = false;
            btnHome.BackColor = Color.NavajoWhite;
            btnCalculateMaxFlow.BackColor = Color.AntiqueWhite;
            btnSimlator.BackColor = Color.AntiqueWhite;
        }

        private void btnCalculateMaxFlow_Click(object sender, EventArgs e)
        {
            calculaterForm = new CalculaterMF();
            OpenChildForm(calculaterForm, sender);
            calculaterForm.ApplyLanguage();
            pnlUserManual.Visible = true;
            btnCalculateMaxFlow.BackColor = Color.NavajoWhite;
            btnHome.BackColor = Color.AntiqueWhite;
            btnSimlator.BackColor = Color.AntiqueWhite;
        }

        private void btnSimulator_Click(object sender, EventArgs e)
        {
            graphForm = new GraphVisualizer();
            OpenChildForm(graphForm, sender);
            graphForm.ApplyLanguage();
            pnlUserManual.Visible = true;
            btnSimlator.BackColor = Color.NavajoWhite;
            btnCalculateMaxFlow.BackColor = Color.AntiqueWhite;
            btnHome.BackColor = Color.AntiqueWhite;
        }
        //Nút tương tác
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
         
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
           

        }
        private void btn_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn == btnExit)
                btn.BackColor = Color.Red;
            else if (btn == btnMaximize)
                btn.BackColor = Color.Orange;
            else if (btn == btnMinimize)
                btn.BackColor = Color.Gold;
        }

        private void btn_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.BackColor = Color.Transparent; // hoặc màu gốc của bạn
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
                UIHelper.ApplyRoundedCorners(this, 30);
            LanguageManager.SetLanguage("en");
            ApplyLanguage();
            InitManualPanel();
            cmbLanguage.SelectedItem = "English";
            pnlUserManual.Visible = false;
        }
        private void cmbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            string lang = cmbLanguage.SelectedItem.ToString();
            if (lang == "English")
            {
                LanguageManager.SetLanguage("en");
                currentLanguage = "en";
            }
            else if (lang == "Tiếng Việt")
            {
                LanguageManager.SetLanguage("vi");
                currentLanguage = "vi";
            }
            ApplyLanguage();

            if (homeForm != null && !homeForm.IsDisposed)
                homeForm.ApplyLanguage();

            if (calculaterForm != null && !calculaterForm.IsDisposed)
                calculaterForm.ApplyLanguage();

            if (graphForm != null && !graphForm.IsDisposed)
                graphForm.ApplyLanguage();
        }
        private void ApplyLanguage()
        {
            btnSimlator.Text = LanguageManager.Get("NavMaxFlowSimulator");
            btnCalculateMaxFlow.Text = LanguageManager.Get("NavTransportation");
            btnHome.Text = LanguageManager.Get("NavHome");
            lblmain.Text = LanguageManager.Get("TitleGroup11");
            lblLanguage.Text = LanguageManager.Get("LabelLanguage");
        }
        private void InitManualPanel()
        {
            pnlManualPopup = new Panel();
            pnlManualPopup.Size = new Size(700, 300);
            pnlManualPopup.BackColor = Color.LightYellow;
            pnlManualPopup.Visible = false;
            pnlManualPopup.BorderStyle = BorderStyle.FixedSingle;

            rtbManual = new RichTextBox();
            rtbManual.Dock = DockStyle.Fill;
            rtbManual.Font = new Font("Segoe UI", 10);
            rtbManual.ReadOnly = true;
            rtbManual.BackColor = Color.LightYellow;
            rtbManual.BorderStyle = BorderStyle.None;
            rtbManual.ScrollBars = RichTextBoxScrollBars.Vertical;
            rtbManual.Multiline = true;
            rtbManual.WordWrap = true;
            manualHideTimer = new System.Windows.Forms.Timer();
            manualHideTimer.Interval = 100;
            manualHideTimer.Tick += ManualHideTimer_Tick;
            pnlManualPopup.Controls.Add(rtbManual);
            this.Controls.Add(pnlManualPopup);

            manualHideStopwatch = new Stopwatch();

            // Gắn sự kiện trực tiếp
            pnlUserManual.MouseEnter += pnlUserManual_MouseEnter;
            //pnlUserManual.MouseLeave += pnlUserManual_MouseLeave;
        }
        private void ManualHideTimer_Tick(object sender, EventArgs e)
        {
            Point cursor = this.PointToClient(Cursor.Position);

            bool insideTrigger = pnlUserManual.Bounds.Contains(cursor);
            bool insidePopup = pnlManualPopup.Bounds.Contains(cursor);

            if (insideTrigger || insidePopup)
            {
                // Nếu chuột quay lại vùng → reset
                isMouseOutside = false;
                manualHideStopwatch.Reset();
            }
            else
            {
                if (!isMouseOutside)
                {
                    isMouseOutside = true;
                    manualHideStopwatch.Restart();
                }
                else if (manualHideStopwatch.ElapsedMilliseconds >= 500)
                {
                    pnlManualPopup.Visible = false;
                    manualHideTimer.Stop();
                    manualHideStopwatch.Stop();
                }
            }
        }
        private void ShowManual(string content)
        {
            if (rtbManual != null)
                rtbManual.Text = content;

            Point screenLocation = pnlUserManual.PointToScreen(new Point(0, pnlUserManual.Height));
            Point formLocation = this.PointToClient(screenLocation);

            int x = this.ClientSize.Width - pnlManualPopup.Width;
            int y = formLocation.Y;

            pnlManualPopup.Location = new Point(x, y);
            pnlManualPopup.Visible = true;
            pnlManualPopup.BringToFront();

            isMouseOutside = false;
            manualHideStopwatch.Reset();
            manualHideTimer.Start();
        }

        private void pnlUserManual_MouseEnter(object sender, EventArgs e)
        {
            if (activeForm is CalculaterMF)
            {
                if (currentLanguage == "vi")
                    ShowManual_Transportation_Vi();
                else
                    ShowManual_Transportation_En();
            }
            else if (activeForm is GraphVisualizer)
            {
                if (currentLanguage == "vi")
                    ShowManual_GraphVisualizer_Vi();
                else
                    ShowManual_GraphVisualizer_En();
            }
        }
        private void ShowManual_Transportation_Vi()
        {
            ShowManual(
        @"📘 USER MANUAL

Mục đích:
Ứng dụng mô phỏng bài toán Transportation / Max Flow, tính toán và hiển thị luồng vận chuyển trên đồ thị.

Cách sử dụng:
1. Nhập Supply và Demand (ví dụ: 20,15,10).
2. Nhấn Create để tạo bảng nhập chi phí/capacity giữa các node. Mỗi ô đại diện cho kết nối từ nguồn đến đích.
3. Nhấn Run để xem kết quả và đồ thị hiển thị flow/capacity.

⚙️ Tùy chọn:
• ✅ Color by Flow: tô màu cạnh theo giá trị luồng.
• ✅ Enable Animation: bật hiệu ứng mô phỏng.
• ✅ Auto Balance: tự động cân bằng cung – cầu.
• 🔘 Hide Input: ẩn vùng nhập liệu.
• ➕/➖: phóng to, thu nhỏ sơ đồ.

🌟 Tính năng nâng cao (khuyên dùng):
• 🟢 Kéo node bằng chuột: bạn có thể di chuyển các node để dễ quan sát sơ đồ.
• 🖱 Cuộn chuột để di chuyển toàn đồ thị: giữ chuột giữa hoặc dùng thanh cuộn để dịch chuyển vùng hiển thị.
• 🔍 Lăn chuột để zoom: lăn lên để phóng to, lăn xuống để thu nhỏ sơ đồ.

📈 Kết quả:
• Hiển thị Maximum Flow, luồng và dung lượng trên từng cạnh.
• Node xanh: đại diện cho Supply, Node đỏ: đại diện cho Demand."
            );
        }
        private void ShowManual_Transportation_En()
        {
            ShowManual(
        @"📘 USER MANUAL

Purpose:
This app simulates Transportation / Max Flow problems, calculates and visualizes flow on a graph.

How to use:
1. Enter Supply and Demand (e.g., 20,15,10).
2. Click Create to generate the cost/capacity table between nodes. Each cell represents a connection from source to destination.
3. Click Run to view results and flow/capacity graph.

⚙️ Options:
• ✅ Color by Flow: color edges by flow value.
• ✅ Enable Animation: enable simulation effects.
• ✅ Auto Balance: auto-balance supply and demand.
• 🔘 Hide Input: hide input section.
• ➕/➖: zoom in/out.

🌟 Advanced features (recommended):
• 🟢 Drag nodes with mouse: rearrange nodes for better visibility.
• 🖱 Scroll to move graph: use middle mouse or scrollbars.
• 🔍 Mouse wheel to zoom: scroll up to zoom in, down to zoom out.

📈 Output:
• Displays Maximum Flow, flow and capacity on each edge.
• Green node: Supply, Red node: Demand."
            );
        }
        private void ShowManual_GraphVisualizer_Vi()
        {
            ShowManual(
        @"📘 USER MANUAL – Max Flow Simulator

Mục đích:
Mô phỏng thuật toán Maximum Flow bằng cách tạo và thao tác trực tiếp trên đồ thị.

Cách sử dụng:
1. Nhấn Add Node → click lên vùng trống để tạo các đỉnh (node).
2. Nhấn Add Edge → click 2 node liên tiếp để tạo cạnh (edge).
3. Chọn Select Source(s) và Select Sink(s) để đánh dấu nguồn – đích.
4. Nhấn Run để chạy thuật toán và hiển thị giá trị Max Flow.

Tùy chọn chỉnh sửa:
• Select: chọn và di chuyển node.
• Erase Node / Edge: xóa phần tử đã chọn.
• Edit Edge: chỉnh sửa giá trị capacity.
• Clear: xóa toàn bộ đồ thị.

Kết quả:
• Hiển thị giá trị Max Flow.
• Cạnh thể hiện hướng và dung lượng dòng chảy."
            );
        }
        private void ShowManual_GraphVisualizer_En()
        {
            ShowManual(
        @"📘 USER MANUAL – Max Flow Simulator

Purpose:
Simulate the Maximum Flow algorithm by creating and interacting directly with a graph.

How to use:
1. Click Add Node → click on empty space to create nodes.
2. Click Add Edge → click two nodes in sequence to create an edge.
3. Use Select Source(s) and Select Sink(s) to mark source and destination.
4. Click Run to execute the algorithm and display the Max Flow value.

Editing options:
• Select: choose and move nodes.
• Erase Node / Edge: delete selected elements.
• Edit Edge: modify capacity value.
• Clear: remove the entire graph.

Output:
• Displays the Max Flow value.
• Edges show direction and flow capacity."
            );
        }
    }
}
