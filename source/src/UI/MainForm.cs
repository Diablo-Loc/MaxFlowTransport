using src.UI.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            OpenChildForm(new Home(), sender);
            btnHome.BackColor = Color.NavajoWhite;
            btnCalculateMaxFlow.BackColor = Color.AntiqueWhite;
            btnSimlator.BackColor = Color.AntiqueWhite;
        }
        private void btnCalculateMaxFlow_Click(object sender, EventArgs e)
        {
            OpenChildForm(new CalculaterMF(), sender);
            btnCalculateMaxFlow.BackColor = Color.NavajoWhite;
            btnHome.BackColor = Color.AntiqueWhite;
            btnSimlator.BackColor = Color.AntiqueWhite;

        }

        private void btnSimulator_Click(object sender, EventArgs e)
        {
            OpenChildForm(new GraphVisualizer(), sender);
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
        }

    }
}
