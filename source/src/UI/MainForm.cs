using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace src.UI
{
    public partial class MainForm : Form
    {
        private Button currentButton;
        private Form activeForm;
        public MainForm()
        {
            InitializeComponent();
            btnCalculateMaxFlow.BackColor = Color.AntiqueWhite;
            btnSimulator.BackColor = Color.AntiqueWhite;
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
        private void btnCalculateMaxFlow_Click(object sender, EventArgs e)
        {
            OpenChildForm(new CalculaterMF(), sender);
            btnCalculateMaxFlow.BackColor = Color.NavajoWhite;
            btnSimulator.BackColor = Color.AntiqueWhite;
        }

        private void btnSimulator_Click(object sender, EventArgs e)
        {
            OpenChildForm(new GraphVisualizer(), sender);
            btnSimulator.BackColor = Color.NavajoWhite;
            btnCalculateMaxFlow.BackColor = Color.AntiqueWhite;
        }
    }
}
