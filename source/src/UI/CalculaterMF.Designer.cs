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
            pnlInput = new Panel();
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
            pnlInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCapacity).BeginInit();
            SuspendLayout();
            // 
            // pnlInput
            // 
            pnlInput.BackColor = SystemColors.AppWorkspace;
            pnlInput.Controls.Add(dgvCapacity);
            pnlInput.Controls.Add(btnCreat);
            pnlInput.Controls.Add(lblInput);
            pnlInput.Controls.Add(btnClear);
            pnlInput.Controls.Add(btnRun);
            pnlInput.Controls.Add(txbInputDemand);
            pnlInput.Controls.Add(txbInputSupply);
            pnlInput.Controls.Add(lblDemand);
            pnlInput.Controls.Add(lblSupply);
            pnlInput.Location = new Point(39, 258);
            pnlInput.Name = "pnlInput";
            pnlInput.Size = new Size(909, 391);
            pnlInput.TabIndex = 0;
            // 
            // dgvCapacity
            // 
            dgvCapacity.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCapacity.Location = new Point(491, 52);
            dgvCapacity.Name = "dgvCapacity";
            dgvCapacity.RowHeadersWidth = 51;
            dgvCapacity.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvCapacity.Size = new Size(371, 204);
            dgvCapacity.TabIndex = 8;
            // 
            // btnCreat
            // 
            btnCreat.FlatAppearance.BorderColor = Color.White;
            btnCreat.FlatAppearance.MouseDownBackColor = Color.FromArgb(192, 255, 192);
            btnCreat.FlatAppearance.MouseOverBackColor = Color.White;
            btnCreat.FlatStyle = FlatStyle.Popup;
            btnCreat.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCreat.Location = new Point(353, 131);
            btnCreat.Name = "btnCreat";
            btnCreat.Size = new Size(116, 39);
            btnCreat.TabIndex = 7;
            btnCreat.Text = "Create";
            btnCreat.UseVisualStyleBackColor = true;
            btnCreat.Click += btnCreat_Click;
            // 
            // lblInput
            // 
            lblInput.AutoSize = true;
            lblInput.FlatStyle = FlatStyle.Flat;
            lblInput.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblInput.ForeColor = Color.Lime;
            lblInput.Location = new Point(365, 0);
            lblInput.Name = "lblInput";
            lblInput.Size = new Size(134, 54);
            lblInput.TabIndex = 6;
            lblInput.Text = "INPUT";
            // 
            // btnClear
            // 
            btnClear.FlatAppearance.BorderColor = Color.White;
            btnClear.FlatAppearance.MouseDownBackColor = Color.FromArgb(192, 255, 192);
            btnClear.FlatAppearance.MouseOverBackColor = Color.White;
            btnClear.FlatStyle = FlatStyle.Popup;
            btnClear.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnClear.Location = new Point(502, 310);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(116, 42);
            btnClear.TabIndex = 5;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += button1_Click;
            // 
            // btnRun
            // 
            btnRun.FlatAppearance.BorderColor = Color.White;
            btnRun.FlatAppearance.MouseDownBackColor = Color.FromArgb(192, 255, 192);
            btnRun.FlatAppearance.MouseOverBackColor = Color.White;
            btnRun.FlatStyle = FlatStyle.Popup;
            btnRun.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRun.Location = new Point(245, 310);
            btnRun.Name = "btnRun";
            btnRun.Size = new Size(116, 42);
            btnRun.TabIndex = 4;
            btnRun.Text = "Run";
            btnRun.UseVisualStyleBackColor = true;
            btnRun.Click += btnRun_Click;
            // 
            // txbInputDemand
            // 
            txbInputDemand.Location = new Point(174, 196);
            txbInputDemand.Name = "txbInputDemand";
            txbInputDemand.Size = new Size(129, 27);
            txbInputDemand.TabIndex = 3;
            // 
            // txbInputSupply
            // 
            txbInputSupply.Location = new Point(174, 67);
            txbInputSupply.Name = "txbInputSupply";
            txbInputSupply.Size = new Size(129, 27);
            txbInputSupply.TabIndex = 2;
            // 
            // lblDemand
            // 
            lblDemand.AutoSize = true;
            lblDemand.FlatStyle = FlatStyle.Flat;
            lblDemand.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDemand.ForeColor = Color.Lime;
            lblDemand.Location = new Point(50, 195);
            lblDemand.Name = "lblDemand";
            lblDemand.Size = new Size(101, 31);
            lblDemand.TabIndex = 1;
            lblDemand.Text = "Demand";
            // 
            // lblSupply
            // 
            lblSupply.AutoSize = true;
            lblSupply.FlatStyle = FlatStyle.Flat;
            lblSupply.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSupply.ForeColor = Color.Lime;
            lblSupply.Location = new Point(50, 63);
            lblSupply.Name = "lblSupply";
            lblSupply.Size = new Size(84, 31);
            lblSupply.TabIndex = 0;
            lblSupply.Text = "Supply";
            // 
            // txbResult
            // 
            txbResult.BackColor = SystemColors.ActiveCaption;
            txbResult.Location = new Point(284, 80);
            txbResult.Multiline = true;
            txbResult.Name = "txbResult";
            txbResult.ReadOnly = true;
            txbResult.ScrollBars = ScrollBars.Vertical;
            txbResult.Size = new Size(378, 159);
            txbResult.TabIndex = 1;
            // 
            // lblMaxFlow
            // 
            lblMaxFlow.AutoSize = true;
            lblMaxFlow.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMaxFlow.Location = new Point(284, 9);
            lblMaxFlow.Name = "lblMaxFlow";
            lblMaxFlow.Size = new Size(203, 31);
            lblMaxFlow.TabIndex = 2;
            lblMaxFlow.Text = "Maximum Flow =";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Light", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(284, 49);
            label1.Name = "label1";
            label1.Size = new Size(230, 28);
            label1.TabIndex = 3;
            label1.Text = "Edges (forward) with flow:";
            // 
            // CalculaterMF
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(987, 661);
            Controls.Add(label1);
            Controls.Add(lblMaxFlow);
            Controls.Add(txbResult);
            Controls.Add(pnlInput);
            Name = "CalculaterMF";
            Text = "CalculaterMF";
            pnlInput.ResumeLayout(false);
            pnlInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCapacity).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlInput;
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
    }
}