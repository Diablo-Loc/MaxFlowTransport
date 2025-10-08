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
            btnMinimize = new Button();
            btnMaximize = new Button();
            btnExit = new Button();
            pnlMenu = new Panel();
            cmbLanguage = new ComboBox();
            lblLanguage = new Label();
            btnSimlator = new Button();
            btnCalculateMaxFlow = new Button();
            btnHome = new Button();
            pnlNameGroup = new Panel();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            panel2 = new Panel();
            pnlUserManual = new Panel();
            lblmain = new Label();
            pnlHienThi = new Panel();
            pictureBox1 = new PictureBox();
            pnltopbar.SuspendLayout();
            pnlMenu.SuspendLayout();
            pnlNameGroup.SuspendLayout();
            panel2.SuspendLayout();
            pnlHienThi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pnltopbar
            // 
            pnltopbar.BackColor = Color.FromArgb(64, 64, 64);
            pnltopbar.Controls.Add(btnMinimize);
            pnltopbar.Controls.Add(btnMaximize);
            pnltopbar.Controls.Add(btnExit);
            pnltopbar.Dock = DockStyle.Top;
            pnltopbar.Location = new Point(0, 0);
            pnltopbar.Name = "pnltopbar";
            pnltopbar.Size = new Size(1197, 33);
            pnltopbar.TabIndex = 0;
            // 
            // btnMinimize
            // 
            btnMinimize.BackColor = Color.Transparent;
            btnMinimize.BackgroundImage = (Image)resources.GetObject("btnMinimize.BackgroundImage");
            btnMinimize.BackgroundImageLayout = ImageLayout.Stretch;
            btnMinimize.Dock = DockStyle.Right;
            btnMinimize.FlatAppearance.BorderSize = 0;
            btnMinimize.FlatStyle = FlatStyle.Flat;
            btnMinimize.Location = new Point(1098, 0);
            btnMinimize.Name = "btnMinimize";
            btnMinimize.Size = new Size(33, 33);
            btnMinimize.TabIndex = 2;
            btnMinimize.Text = "--";
            btnMinimize.UseVisualStyleBackColor = false;
            btnMinimize.Click += btnMinimize_Click;
            btnMinimize.MouseEnter += btn_MouseEnter;
            btnMinimize.MouseLeave += btn_MouseLeave;
            // 
            // btnMaximize
            // 
            btnMaximize.BackColor = Color.Transparent;
            btnMaximize.BackgroundImage = (Image)resources.GetObject("btnMaximize.BackgroundImage");
            btnMaximize.BackgroundImageLayout = ImageLayout.Stretch;
            btnMaximize.Dock = DockStyle.Right;
            btnMaximize.FlatAppearance.BorderSize = 0;
            btnMaximize.FlatStyle = FlatStyle.Flat;
            btnMaximize.Location = new Point(1131, 0);
            btnMaximize.Name = "btnMaximize";
            btnMaximize.Size = new Size(33, 33);
            btnMaximize.TabIndex = 1;
            btnMaximize.UseVisualStyleBackColor = false;
            btnMaximize.Click += btnMaximize_Click;
            btnMaximize.MouseEnter += btn_MouseEnter;
            btnMaximize.MouseLeave += btn_MouseLeave;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.Transparent;
            btnExit.BackgroundImage = (Image)resources.GetObject("btnExit.BackgroundImage");
            btnExit.BackgroundImageLayout = ImageLayout.Stretch;
            btnExit.Dock = DockStyle.Right;
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.ForeColor = SystemColors.ActiveCaptionText;
            btnExit.Location = new Point(1164, 0);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(33, 33);
            btnExit.TabIndex = 0;
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            btnExit.MouseEnter += btn_MouseEnter;
            btnExit.MouseLeave += btn_MouseLeave;
            // 
            // pnlMenu
            // 
            pnlMenu.BackColor = Color.DimGray;
            pnlMenu.Controls.Add(cmbLanguage);
            pnlMenu.Controls.Add(lblLanguage);
            pnlMenu.Controls.Add(btnSimlator);
            pnlMenu.Controls.Add(btnCalculateMaxFlow);
            pnlMenu.Controls.Add(btnHome);
            pnlMenu.Controls.Add(pnlNameGroup);
            pnlMenu.Dock = DockStyle.Left;
            pnlMenu.Location = new Point(0, 33);
            pnlMenu.Name = "pnlMenu";
            pnlMenu.Size = new Size(200, 759);
            pnlMenu.TabIndex = 1;
            // 
            // cmbLanguage
            // 
            cmbLanguage.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            cmbLanguage.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLanguage.FormattingEnabled = true;
            cmbLanguage.Items.AddRange(new object[] { "English", "Tiếng Việt" });
            cmbLanguage.Location = new Point(28, 634);
            cmbLanguage.Name = "cmbLanguage";
            cmbLanguage.Size = new Size(151, 28);
            cmbLanguage.TabIndex = 5;
            cmbLanguage.SelectedIndexChanged += cmbLanguage_SelectedIndexChanged;
            // 
            // lblLanguage
            // 
            lblLanguage.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblLanguage.AutoSize = true;
            lblLanguage.ForeColor = Color.White;
            lblLanguage.Location = new Point(28, 611);
            lblLanguage.Name = "lblLanguage";
            lblLanguage.Size = new Size(74, 20);
            lblLanguage.TabIndex = 4;
            lblLanguage.Text = "Language";
            // 
            // btnSimlator
            // 
            btnSimlator.Dock = DockStyle.Top;
            btnSimlator.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSimlator.Location = new Point(0, 286);
            btnSimlator.Name = "btnSimlator";
            btnSimlator.Size = new Size(200, 75);
            btnSimlator.TabIndex = 1;
            btnSimlator.Text = "Max Flow Simulator";
            btnSimlator.UseVisualStyleBackColor = true;
            btnSimlator.Click += btnSimulator_Click;
            // 
            // btnCalculateMaxFlow
            // 
            btnCalculateMaxFlow.Dock = DockStyle.Top;
            btnCalculateMaxFlow.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCalculateMaxFlow.Location = new Point(0, 211);
            btnCalculateMaxFlow.Name = "btnCalculateMaxFlow";
            btnCalculateMaxFlow.Size = new Size(200, 75);
            btnCalculateMaxFlow.TabIndex = 3;
            btnCalculateMaxFlow.Text = "Transportation Problem";
            btnCalculateMaxFlow.UseVisualStyleBackColor = true;
            btnCalculateMaxFlow.Click += btnCalculateMaxFlow_Click;
            // 
            // btnHome
            // 
            btnHome.Dock = DockStyle.Top;
            btnHome.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnHome.Location = new Point(0, 136);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(200, 75);
            btnHome.TabIndex = 2;
            btnHome.Text = "Home";
            btnHome.UseVisualStyleBackColor = true;
            btnHome.Click += btnHome_Click;
            // 
            // pnlNameGroup
            // 
            pnlNameGroup.BackColor = Color.DarkGray;
            pnlNameGroup.Controls.Add(label3);
            pnlNameGroup.Controls.Add(label2);
            pnlNameGroup.Controls.Add(label1);
            pnlNameGroup.Dock = DockStyle.Top;
            pnlNameGroup.Location = new Point(0, 0);
            pnlNameGroup.Name = "pnlNameGroup";
            pnlNameGroup.Size = new Size(200, 136);
            pnlNameGroup.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.FlatStyle = FlatStyle.Flat;
            label3.Font = new Font("Segoe UI", 10.8F, FontStyle.Italic);
            label3.ForeColor = Color.White;
            label3.Location = new Point(6, 88);
            label3.Name = "label3";
            label3.Size = new Size(175, 25);
            label3.TabIndex = 2;
            label3.Text = "Nguyễn Công Thành";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.FlatStyle = FlatStyle.Flat;
            label2.Font = new Font("Segoe UI", 10.8F, FontStyle.Italic);
            label2.ForeColor = Color.White;
            label2.Location = new Point(6, 53);
            label2.Name = "label2";
            label2.Size = new Size(121, 25);
            label2.TabIndex = 1;
            label2.Text = "Trần Thiên Ân";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.FlatStyle = FlatStyle.Flat;
            label1.Font = new Font("Segoe UI", 10.8F, FontStyle.Italic);
            label1.ForeColor = Color.White;
            label1.Location = new Point(6, 19);
            label1.Name = "label1";
            label1.Size = new Size(142, 25);
            label1.TabIndex = 0;
            label1.Text = "Nguyễn Đăk Lộc";
            // 
            // panel2
            // 
            panel2.BackColor = Color.Gray;
            panel2.Controls.Add(pnlUserManual);
            panel2.Controls.Add(lblmain);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(200, 33);
            panel2.Name = "panel2";
            panel2.Size = new Size(997, 88);
            panel2.TabIndex = 2;
            // 
            // pnlUserManual
            // 
            pnlUserManual.Anchor = AnchorStyles.Right;
            pnlUserManual.BackgroundImage = (Image)resources.GetObject("pnlUserManual.BackgroundImage");
            pnlUserManual.BackgroundImageLayout = ImageLayout.Stretch;
            pnlUserManual.BorderStyle = BorderStyle.FixedSingle;
            pnlUserManual.Location = new Point(941, 43);
            pnlUserManual.Name = "pnlUserManual";
            pnlUserManual.Size = new Size(53, 42);
            pnlUserManual.TabIndex = 1;
            pnlUserManual.MouseEnter += pnlUserManual_MouseEnter;
            // 
            // lblmain
            // 
            lblmain.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblmain.Font = new Font("Showcard Gothic", 24F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblmain.ForeColor = Color.Cyan;
            lblmain.Location = new Point(396, 19);
            lblmain.Name = "lblmain";
            lblmain.Size = new Size(209, 50);
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
            FormBorderStyle = FormBorderStyle.None;
            Name = "MainForm";
            Text = "MainForm";
            pnltopbar.ResumeLayout(false);
            pnlMenu.ResumeLayout(false);
            pnlMenu.PerformLayout();
            pnlNameGroup.ResumeLayout(false);
            pnlNameGroup.PerformLayout();
            panel2.ResumeLayout(false);
            pnlHienThi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnltopbar;
        private Panel pnlMenu;
        private Button btnHome;
        private Panel pnlNameGroup;
        private Panel panel2;
        private Button btnCalculateMaxFlow;
        private Label lblmain;
        private Panel pnlHienThi;
        private PictureBox pictureBox1;
        private Label label1;
        private Label label3;
        private Label label2;
        private Button btnExit;
        private Button btnMinimize;
        private Button btnMaximize;
        private Button btnSimlator;
        private ComboBox cmbLanguage;
        private Label lblLanguage;
        private Panel pnlUserManual;
    }
}