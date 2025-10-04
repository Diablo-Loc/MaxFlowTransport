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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CalculaterMF));
            dgvCapacity = new DataGridView();
            btnCreat = new Button();
            lblInput = new Label();
            btnClear = new Button();
            btnRun = new Button();
            txbInputDemand = new TextBox();
            txbInputSupply = new TextBox();
            lblDemand = new Label();
            lblSupply = new Label();
            txbResult = new TextBox();
            lblMaxFlow = new Label();
            label1 = new Label();
            lblMauSupply = new Label();
            lblMauDemand = new Label();
            lblExCapa = new Label();
            label2 = new Label();
            lblChooseTestCase = new Label();
            cbTestCase = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvCapacity).BeginInit();
            SuspendLayout();
            // 
            // dgvCapacity
            // 
            dgvCapacity.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            dgvCapacity.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCapacity.BackgroundColor = Color.LightSteelBlue;
            dgvCapacity.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCapacity.Location = new Point(571, 319);
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
            btnCreat.Location = new Point(423, 391);
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
            lblInput.Location = new Point(27, 262);
            lblInput.Name = "lblInput";
            lblInput.Size = new Size(915, 54);
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
            btnClear.Location = new Point(589, 596);
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
            btnRun.Location = new Point(249, 596);
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
            txbInputDemand.Location = new Point(236, 447);
            txbInputDemand.Name = "txbInputDemand";
            txbInputDemand.Size = new Size(161, 27);
            txbInputDemand.TabIndex = 3;
            // 
            // txbInputSupply
            // 
            txbInputSupply.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txbInputSupply.BackColor = Color.WhiteSmoke;
            txbInputSupply.Location = new Point(236, 343);
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
            lblDemand.Location = new Point(110, 441);
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
            lblSupply.Location = new Point(110, 343);
            lblSupply.Name = "lblSupply";
            lblSupply.Size = new Size(90, 31);
            lblSupply.TabIndex = 0;
            lblSupply.Text = "Supply";
            // 
            // txbResult
            // 
            txbResult.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txbResult.BackColor = SystemColors.ActiveCaption;
            txbResult.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txbResult.ForeColor = Color.Black;
            txbResult.Location = new Point(297, 78);
            txbResult.Multiline = true;
            txbResult.Name = "txbResult";
            txbResult.ReadOnly = true;
            txbResult.ScrollBars = ScrollBars.Vertical;
            txbResult.Size = new Size(384, 159);
            txbResult.TabIndex = 1;
            // 
            // lblMaxFlow
            // 
            lblMaxFlow.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblMaxFlow.AutoSize = true;
            lblMaxFlow.BackColor = Color.Transparent;
            lblMaxFlow.FlatStyle = FlatStyle.Flat;
            lblMaxFlow.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMaxFlow.Location = new Point(297, 7);
            lblMaxFlow.Name = "lblMaxFlow";
            lblMaxFlow.Size = new Size(203, 31);
            lblMaxFlow.TabIndex = 2;
            lblMaxFlow.Text = "Maximum Flow =";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Light", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(297, 47);
            label1.Name = "label1";
            label1.Size = new Size(230, 28);
            label1.TabIndex = 3;
            label1.Text = "Edges (forward) with flow:";
            // 
            // lblMauSupply
            // 
            lblMauSupply.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblMauSupply.BackColor = Color.Transparent;
            lblMauSupply.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMauSupply.Location = new Point(236, 382);
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
            lblMauDemand.Location = new Point(236, 488);
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
            lblExCapa.Location = new Point(571, 535);
            lblExCapa.Name = "lblExCapa";
            lblExCapa.Size = new Size(239, 46);
            lblExCapa.TabIndex = 11;
            lblExCapa.Text = "Enter a non-negative integer. \r\nFor example: S0 → D0 = 8";
            lblExCapa.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(284, 240);
            label2.Name = "label2";
            label2.Size = new Size(203, 20);
            label2.TabIndex = 12;
            label2.Text = "SRC: Source, SNK: Sink.";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblChooseTestCase
            // 
            lblChooseTestCase.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblChooseTestCase.BackColor = Color.Transparent;
            lblChooseTestCase.FlatStyle = FlatStyle.Flat;
            lblChooseTestCase.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblChooseTestCase.ForeColor = Color.Black;
            lblChooseTestCase.Location = new Point(110, 524);
            lblChooseTestCase.Name = "lblChooseTestCase";
            lblChooseTestCase.Size = new Size(199, 31);
            lblChooseTestCase.TabIndex = 13;
            lblChooseTestCase.Text = "Choose Test Case:";
            // 
            // cbTestCase
            // 
            cbTestCase.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            cbTestCase.FormattingEnabled = true;
            cbTestCase.Location = new Point(306, 530);
            cbTestCase.Name = "cbTestCase";
            cbTestCase.Size = new Size(91, 28);
            cbTestCase.TabIndex = 14;
            // 
            // CalculaterMF
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(993, 661);
            Controls.Add(cbTestCase);
            Controls.Add(lblChooseTestCase);
            Controls.Add(label2);
            Controls.Add(lblExCapa);
            Controls.Add(lblMauDemand);
            Controls.Add(lblMauSupply);
            Controls.Add(dgvCapacity);
            Controls.Add(label1);
            Controls.Add(btnRun);
            Controls.Add(btnClear);
            Controls.Add(btnCreat);
            Controls.Add(lblMaxFlow);
            Controls.Add(txbResult);
            Controls.Add(lblInput);
            Controls.Add(txbInputDemand);
            Controls.Add(lblSupply);
            Controls.Add(txbInputSupply);
            Controls.Add(lblDemand);
            DoubleBuffered = true;
            Name = "CalculaterMF";
            Text = "CalculaterMF";
            ((System.ComponentModel.ISupportInitialize)dgvCapacity).EndInit();
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
        private TextBox txbResult;
        private Button btnCreat;
        private DataGridView dgvCapacity;
        private Label lblMaxFlow;
        private Label label1;
        private DoubleBufferedPanel panelInput;
        private Label lblMauSupply;
        private Label lblMauDemand;
        private Label lblExCapa;
        private Label label2;
        private Label lblChooseTestCase;
        private ComboBox cbTestCase;
    }
}