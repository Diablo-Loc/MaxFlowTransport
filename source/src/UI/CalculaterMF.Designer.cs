using System.Drawing;

namespace src.UI
{
    partial class CalculaterMF
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
            components = new System.ComponentModel.Container();
            dgvCapacity = new DataGridView();
            btnCreat = new Button();
            lblInput = new Label();
            btnClear = new Button();
            btnRun = new Button();
            txbInputDemand = new TextBox();
            txbInputSupply = new TextBox();
            lblDemand = new Label();
            lblSupply = new Label();
            lblMaxFlow = new Label();
            lblMauSupply = new Label();
            lblMauDemand = new Label();
            lblExCapa = new Label();
            lblChooseTestCase = new Label();
            cbTestCase = new ComboBox();
            pnlDraw = new Panel();
            pnlZoom = new Panel();
            bntzomin = new Button();
            btnzomout = new Button();
            pnlTicker = new Panel();
            lblTicker = new Label();
            chkEnableBalancing = new CheckBox();
            chkEnableAnimation = new CheckBox();
            chkColorByFlow = new CheckBox();
            btnToggleInput = new Button();
            pnlInput = new Panel();
            zoomTip = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)dgvCapacity).BeginInit();
            pnlDraw.SuspendLayout();
            pnlZoom.SuspendLayout();
            pnlTicker.SuspendLayout();
            pnlInput.SuspendLayout();
            SuspendLayout();
            // 
            // dgvCapacity
            // 
            dgvCapacity.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            dgvCapacity.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCapacity.BackgroundColor = Color.LightSteelBlue;
            dgvCapacity.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCapacity.Location = new Point(601, 16);
            dgvCapacity.Name = "dgvCapacity";
            dgvCapacity.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dgvCapacity.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvCapacity.Size = new Size(356, 204);
            dgvCapacity.TabIndex = 8;
            // 
            // btnCreat
            // 
            btnCreat.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCreat.BackColor = Color.MediumSeaGreen;
            btnCreat.FlatAppearance.BorderColor = Color.White;
            btnCreat.FlatAppearance.MouseDownBackColor = Color.FromArgb(192, 255, 192);
            btnCreat.FlatAppearance.MouseOverBackColor = Color.White;
            btnCreat.FlatStyle = FlatStyle.Popup;
            btnCreat.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCreat.Location = new Point(464, 130);
            btnCreat.Name = "btnCreat";
            btnCreat.Size = new Size(116, 39);
            btnCreat.TabIndex = 7;
            btnCreat.Text = "Create";
            btnCreat.UseVisualStyleBackColor = false;
            btnCreat.Click += btnCreat_Click;
            // 
            // lblInput
            // 
            lblInput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblInput.BackColor = Color.Transparent;
            lblInput.FlatStyle = FlatStyle.Flat;
            lblInput.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblInput.ForeColor = Color.Black;
            lblInput.Location = new Point(33, 0);
            lblInput.Name = "lblInput";
            lblInput.Size = new Size(957, 55);
            lblInput.TabIndex = 6;
            lblInput.Text = "INPUT";
            lblInput.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnClear
            // 
            btnClear.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClear.BackColor = Color.MediumSeaGreen;
            btnClear.FlatAppearance.BorderColor = Color.White;
            btnClear.FlatAppearance.MouseDownBackColor = Color.FromArgb(192, 255, 192);
            btnClear.FlatAppearance.MouseOverBackColor = Color.White;
            btnClear.FlatStyle = FlatStyle.Popup;
            btnClear.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnClear.Location = new Point(642, 287);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(116, 42);
            btnClear.TabIndex = 5;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += button1_Click;
            // 
            // btnRun
            // 
            btnRun.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnRun.BackColor = Color.MediumSeaGreen;
            btnRun.FlatAppearance.BorderColor = Color.White;
            btnRun.FlatAppearance.MouseDownBackColor = Color.FromArgb(192, 255, 192);
            btnRun.FlatAppearance.MouseOverBackColor = Color.White;
            btnRun.FlatStyle = FlatStyle.Popup;
            btnRun.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRun.Location = new Point(259, 287);
            btnRun.Name = "btnRun";
            btnRun.Size = new Size(116, 42);
            btnRun.TabIndex = 4;
            btnRun.Text = "Run";
            btnRun.UseVisualStyleBackColor = false;
            btnRun.Click += btnRun_Click;
            // 
            // txbInputDemand
            // 
            txbInputDemand.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txbInputDemand.BackColor = Color.WhiteSmoke;
            txbInputDemand.Location = new Point(171, 136);
            txbInputDemand.Name = "txbInputDemand";
            txbInputDemand.Size = new Size(161, 27);
            txbInputDemand.TabIndex = 3;
            // 
            // txbInputSupply
            // 
            txbInputSupply.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txbInputSupply.BackColor = Color.WhiteSmoke;
            txbInputSupply.Location = new Point(171, 32);
            txbInputSupply.Name = "txbInputSupply";
            txbInputSupply.Size = new Size(161, 27);
            txbInputSupply.TabIndex = 2;
            // 
            // lblDemand
            // 
            lblDemand.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblDemand.BackColor = Color.Transparent;
            lblDemand.FlatStyle = FlatStyle.Flat;
            lblDemand.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDemand.ForeColor = Color.Black;
            lblDemand.Location = new Point(45, 130);
            lblDemand.Name = "lblDemand";
            lblDemand.Size = new Size(107, 31);
            lblDemand.TabIndex = 1;
            lblDemand.Text = "Demand";
            // 
            // lblSupply
            // 
            lblSupply.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblSupply.BackColor = Color.Transparent;
            lblSupply.FlatStyle = FlatStyle.Flat;
            lblSupply.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSupply.ForeColor = Color.Black;
            lblSupply.Location = new Point(45, 32);
            lblSupply.Name = "lblSupply";
            lblSupply.Size = new Size(90, 31);
            lblSupply.TabIndex = 0;
            lblSupply.Text = "Supply";
            // 
            // lblMaxFlow
            // 
            lblMaxFlow.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblMaxFlow.AutoSize = true;
            lblMaxFlow.BackColor = Color.Transparent;
            lblMaxFlow.FlatStyle = FlatStyle.Flat;
            lblMaxFlow.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMaxFlow.Location = new Point(0, 0);
            lblMaxFlow.Name = "lblMaxFlow";
            lblMaxFlow.Size = new Size(203, 31);
            lblMaxFlow.TabIndex = 2;
            lblMaxFlow.Text = "Maximum Flow =";
            // 
            // lblMauSupply
            // 
            lblMauSupply.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblMauSupply.BackColor = Color.Transparent;
            lblMauSupply.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMauSupply.Location = new Point(171, 71);
            lblMauSupply.Name = "lblMauSupply";
            lblMauSupply.Size = new Size(153, 20);
            lblMauSupply.TabIndex = 9;
            lblMauSupply.Text = "Example -S0: 5, 10, 40";
            lblMauSupply.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblMauDemand
            // 
            lblMauDemand.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblMauDemand.BackColor = Color.Transparent;
            lblMauDemand.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMauDemand.Location = new Point(171, 177);
            lblMauDemand.Name = "lblMauDemand";
            lblMauDemand.Size = new Size(140, 20);
            lblMauDemand.TabIndex = 10;
            lblMauDemand.Text = "Example -D0: 20,7,3";
            lblMauDemand.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblExCapa
            // 
            lblExCapa.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblExCapa.BackColor = Color.Transparent;
            lblExCapa.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblExCapa.Location = new Point(601, 223);
            lblExCapa.Name = "lblExCapa";
            lblExCapa.Size = new Size(239, 46);
            lblExCapa.TabIndex = 11;
            lblExCapa.Text = "Enter a non-negative integer. \r\nFor example: S0 → D0 = 8";
            lblExCapa.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblChooseTestCase
            // 
            lblChooseTestCase.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblChooseTestCase.BackColor = Color.Transparent;
            lblChooseTestCase.FlatStyle = FlatStyle.Flat;
            lblChooseTestCase.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblChooseTestCase.ForeColor = Color.Black;
            lblChooseTestCase.Location = new Point(45, 213);
            lblChooseTestCase.Name = "lblChooseTestCase";
            lblChooseTestCase.Size = new Size(199, 31);
            lblChooseTestCase.TabIndex = 13;
            lblChooseTestCase.Text = "Choose Test Case:";
            // 
            // cbTestCase
            // 
            cbTestCase.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            cbTestCase.FormattingEnabled = true;
            cbTestCase.Location = new Point(241, 219);
            cbTestCase.Name = "cbTestCase";
            cbTestCase.Size = new Size(91, 28);
            cbTestCase.Sorted = true;
            cbTestCase.TabIndex = 14;
            // 
            // pnlDraw
            // 
            pnlDraw = new DoubleBufferedPanel();
            pnlDraw.Controls.Add(pnlZoom);
            pnlDraw.Controls.Add(pnlTicker);
            pnlDraw.Controls.Add(chkEnableBalancing);
            pnlDraw.Controls.Add(chkEnableAnimation);
            pnlDraw.Controls.Add(chkColorByFlow);
            pnlDraw.Controls.Add(btnToggleInput);
            pnlDraw.Controls.Add(lblMaxFlow);
            pnlDraw.Dock = DockStyle.Fill;
            pnlDraw.Location = new Point(0, 0);
            pnlDraw.Name = "pnlDraw";
            pnlDraw.Size = new Size(993, 661);
            pnlDraw.TabIndex = 15;
            // 
            // pnlZoom
            // 
            pnlZoom.BackColor = Color.Transparent;
            pnlZoom.Controls.Add(bntzomin);
            pnlZoom.Controls.Add(btnzomout);
            pnlZoom.Dock = DockStyle.Bottom;
            pnlZoom.Location = new Point(0, 609);
            pnlZoom.Name = "pnlZoom";
            pnlZoom.Size = new Size(993, 52);
            pnlZoom.TabIndex = 26;
            // 
            // bntzomin
            // 
            bntzomin.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            bntzomin.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            bntzomin.Location = new Point(968, 0);
            bntzomin.Name = "bntzomin";
            bntzomin.Size = new Size(25, 24);
            bntzomin.TabIndex = 22;
            bntzomin.Text = "+";
            zoomTip.SetToolTip(bntzomin, "📌 Dùng con cuộn để phóng to/thu nhỏ\n🖱️ Giữ chuột giữa để di chuyển");
            bntzomin.UseVisualStyleBackColor = true;
            bntzomin.Click += bntzomin_Click;
            // 
            // btnzomout
            // 
            btnzomout.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnzomout.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnzomout.Location = new Point(968, 28);
            btnzomout.Name = "btnzomout";
            btnzomout.Size = new Size(25, 24);
            btnzomout.TabIndex = 23;
            btnzomout.Text = "-";
            zoomTip.SetToolTip(btnzomout, "📌 Dùng con cuộn để phóng to/thu nhỏ\n🖱️ Giữ chuột giữa để di chuyển");
            btnzomout.UseVisualStyleBackColor = true;
            btnzomout.Click += btnzomout_Click;
            // 
            // pnlTicker
            // 
            pnlTicker.BackColor = Color.Transparent;
            pnlTicker.Controls.Add(lblTicker);
            pnlTicker.Location = new Point(324, 3);
            pnlTicker.Name = "pnlTicker";
            pnlTicker.Size = new Size(434, 29);
            pnlTicker.TabIndex = 25;
            // 
            // lblTicker
            // 
            lblTicker.Anchor = AnchorStyles.Top;
            lblTicker.AutoSize = true;
            lblTicker.BackColor = Color.Transparent;
            lblTicker.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblTicker.ForeColor = Color.FromArgb(235, 157, 10);
            lblTicker.Location = new Point(200, 5);
            lblTicker.Name = "lblTicker";
            lblTicker.Size = new Size(414, 23);
            lblTicker.TabIndex = 24;
            lblTicker.Text = "Bạn có thể di chuyển các node sao cho dễ nhìn hơn";
            lblTicker.Visible = false;
            // 
            // chkEnableBalancing
            // 
            chkEnableBalancing.AutoSize = true;
            chkEnableBalancing.BackColor = Color.Transparent;
            chkEnableBalancing.Location = new Point(12, 103);
            chkEnableBalancing.Name = "chkEnableBalancing";
            chkEnableBalancing.Size = new Size(264, 24);
            chkEnableBalancing.TabIndex = 20;
            chkEnableBalancing.Text = "Automatic supply/demand balance";
            chkEnableBalancing.UseVisualStyleBackColor = true;
            // 
            // chkEnableAnimation
            // 
            chkEnableAnimation.AutoSize = true;
            chkEnableAnimation.BackColor = Color.Transparent;
            chkEnableAnimation.Checked = true;
            chkEnableAnimation.CheckState = CheckState.Checked;
            chkEnableAnimation.Location = new Point(12, 73);
            chkEnableAnimation.Name = "chkEnableAnimation";
            chkEnableAnimation.Size = new Size(149, 24);
            chkEnableAnimation.TabIndex = 19;
            chkEnableAnimation.Text = "Enable Animation";
            chkEnableAnimation.UseVisualStyleBackColor = true;
            // 
            // chkColorByFlow
            // 
            chkColorByFlow.AutoSize = true;
            chkColorByFlow.BackColor = Color.Transparent;
            chkColorByFlow.Checked = true;
            chkColorByFlow.CheckState = CheckState.Checked;
            chkColorByFlow.Location = new Point(12, 43);
            chkColorByFlow.Name = "chkColorByFlow";
            chkColorByFlow.Size = new Size(122, 24);
            chkColorByFlow.TabIndex = 18;
            chkColorByFlow.Text = "Color by Flow";
            chkColorByFlow.UseVisualStyleBackColor = true;
            // 
            // btnToggleInput
            // 
            btnToggleInput.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnToggleInput.Location = new Point(896, 0);
            btnToggleInput.Name = "btnToggleInput";
            btnToggleInput.Size = new Size(94, 31);
            btnToggleInput.TabIndex = 17;
            btnToggleInput.Text = "Hide Input";
            btnToggleInput.UseVisualStyleBackColor = true;
            btnToggleInput.Click += btnToggleInput_Click;
            // 
            // pnlInput
            // 
            pnlInput.AutoSize = true;
            pnlInput.Controls.Add(dgvCapacity);
            pnlInput.Controls.Add(btnClear);
            pnlInput.Controls.Add(cbTestCase);
            pnlInput.Controls.Add(btnRun);
            pnlInput.Controls.Add(lblChooseTestCase);
            pnlInput.Controls.Add(btnCreat);
            pnlInput.Controls.Add(lblMauDemand);
            pnlInput.Controls.Add(lblExCapa);
            pnlInput.Controls.Add(lblMauSupply);
            pnlInput.Controls.Add(txbInputDemand);
            pnlInput.Controls.Add(lblDemand);
            pnlInput.Controls.Add(lblSupply);
            pnlInput.Controls.Add(txbInputSupply);
            pnlInput.Controls.Add(lblInput);
            pnlInput.Dock = DockStyle.Bottom;
            pnlInput.Location = new Point(0, 329);
            pnlInput.Name = "pnlInput";
            pnlInput.Size = new Size(993, 332);
            pnlInput.TabIndex = 16;
            // 
            // CalculaterMF
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(993, 661);
            Controls.Add(pnlInput);
            Controls.Add(pnlDraw);
            DoubleBuffered = true;
            Name = "CalculaterMF";
            Text = "CalculaterMF";
            ((System.ComponentModel.ISupportInitialize)dgvCapacity).EndInit();
            pnlDraw.ResumeLayout(false);
            pnlDraw.PerformLayout();
            pnlZoom.ResumeLayout(false);
            pnlTicker.ResumeLayout(false);
            pnlTicker.PerformLayout();
            pnlInput.ResumeLayout(false);
            pnlInput.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txbInputSupply;
        private Label lblDemand;
        private Label lblSupply;
        private Label lblInput;
        private Button btnClear;
        private Button btnRun;
        private TextBox txbInputDemand;
        private Button btnCreat;
        private DataGridView dgvCapacity;
        private Label lblMaxFlow;
        private DoubleBufferedPanel panelInput;
        private Label lblMauSupply;
        private Label lblMauDemand;
        private Label lblExCapa;
        private Label lblChooseTestCase;
        private ComboBox cbTestCase;
        private Panel pnlDraw;
        private Panel pnlInput;
        private Button btnToggleInput;
        private CheckBox chkColorByFlow;
        private CheckBox chkEnableAnimation;
        private CheckBox chkEnableBalancing;
        private ToolTip zoomTip;
        private Label lblTicker;
        private Button bntzomin;
        private Button btnzomout;
        private Panel pnlTicker;
        private Panel pnlZoom;
    }
}