namespace src.UI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            pnltopbar = new Panel();
            pnlMenu = new Panel();
            btnSimulator = new Button();
            btnCalculateMaxFlow = new Button();
            pnlNameGroup = new Panel();
            panel2 = new Panel();
            lblmain = new Label();
            pnlHienThi = new Panel();
            pictureBox1 = new PictureBox();
            pnlMenu.SuspendLayout();
            panel2.SuspendLayout();
            pnlHienThi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pnltopbar
            // 
            pnltopbar.BackColor = Color.FromArgb(64, 64, 64);
            pnltopbar.Dock = DockStyle.Top;
            pnltopbar.Location = new Point(0, 0);
            pnltopbar.Name = "pnltopbar";
            pnltopbar.Size = new Size(1197, 33);
            pnltopbar.TabIndex = 0;
            // 
            // pnlMenu
            // 
            pnlMenu.BackColor = Color.DimGray;
            pnlMenu.Controls.Add(btnSimulator);
            pnlMenu.Controls.Add(btnCalculateMaxFlow);
            pnlMenu.Controls.Add(pnlNameGroup);
            pnlMenu.Dock = DockStyle.Left;
            pnlMenu.Location = new Point(0, 33);
            pnlMenu.Name = "pnlMenu";
            pnlMenu.Size = new Size(200, 759);
            pnlMenu.TabIndex = 1;
            // 
            // btnSimulator
            // 
            btnSimulator.Dock = DockStyle.Top;
            btnSimulator.Location = new Point(0, 211);
            btnSimulator.Name = "btnSimulator";
            btnSimulator.Size = new Size(200, 75);
            btnSimulator.TabIndex = 2;
            btnSimulator.Text = "Simulator";
            btnSimulator.UseVisualStyleBackColor = true;
            btnSimulator.Click += btnSimulator_Click;
            // 
            // btnCalculateMaxFlow
            // 
            btnCalculateMaxFlow.Dock = DockStyle.Top;
            btnCalculateMaxFlow.Location = new Point(0, 136);
            btnCalculateMaxFlow.Name = "btnCalculateMaxFlow";
            btnCalculateMaxFlow.Size = new Size(200, 75);
            btnCalculateMaxFlow.TabIndex = 1;
            btnCalculateMaxFlow.Text = "Calculater Max Flow";
            btnCalculateMaxFlow.UseVisualStyleBackColor = true;
            btnCalculateMaxFlow.Click += btnCalculateMaxFlow_Click;
            // 
            // pnlNameGroup
            // 
            pnlNameGroup.BackColor = Color.DarkGray;
            pnlNameGroup.Dock = DockStyle.Top;
            pnlNameGroup.Location = new Point(0, 0);
            pnlNameGroup.Name = "pnlNameGroup";
            pnlNameGroup.Size = new Size(200, 136);
            pnlNameGroup.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Gray;
            panel2.Controls.Add(lblmain);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(200, 33);
            panel2.Name = "panel2";
            panel2.Size = new Size(997, 88);
            panel2.TabIndex = 2;
            // 
            // lblmain
            // 
            lblmain.AutoSize = true;
            lblmain.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblmain.ForeColor = Color.Cyan;
            lblmain.Location = new Point(378, 19);
            lblmain.Name = "lblmain";
            lblmain.Size = new Size(208, 54);
            lblmain.TabIndex = 0;
            lblmain.Text = "GROUP 11";
            lblmain.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlHienThi
            // 
            pnlHienThi.BackgroundImageLayout = ImageLayout.Stretch;
            pnlHienThi.BorderStyle = BorderStyle.FixedSingle;
            pnlHienThi.Controls.Add(pictureBox1);
            pnlHienThi.Dock = DockStyle.Fill;
            pnlHienThi.Location = new Point(200, 121);
            pnlHienThi.Name = "pnlHienThi";
            pnlHienThi.Size = new Size(997, 671);
            pnlHienThi.TabIndex = 3;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(995, 669);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1197, 792);
            Controls.Add(pnlHienThi);
            Controls.Add(panel2);
            Controls.Add(pnlMenu);
            Controls.Add(pnltopbar);
            Name = "MainForm";
            Text = "MainForm";
            pnlMenu.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            pnlHienThi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnltopbar;
        private Panel pnlMenu;
        private Button btnCalculateMaxFlow;
        private Panel pnlNameGroup;
        private Panel panel2;
        private Button btnSimulator;
        private Label lblmain;
        private Panel pnlHienThi;
        private PictureBox pictureBox1;
    }
}