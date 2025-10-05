namespace src.UI
{
    partial class GraphVisualizer
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
            pnlDraw = new DoubleBufferedPanel();
            btnAddNode = new Button();
            btnAddEdge = new Button();
            btnClear = new Button();
            btnRun = new Button();
            lblMaxFlow = new Label();
            label1 = new Label();
            btnEraseNode = new Button();
            btnEditEdge = new Button();
            btnEraseEdge = new Button();
            btnSelect = new Button();
            btnSelectSource = new Button();
            btnSelectSink = new Button();
            SuspendLayout();
            // 
            // pnlDraw
            // 
            pnlDraw.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlDraw.Location = new Point(15, 62);
            pnlDraw.Name = "pnlDraw";
            pnlDraw.Size = new Size(949, 524);
            pnlDraw.TabIndex = 0;
            // 
            // btnAddNode
            // 
            btnAddNode.Location = new Point(127, 27);
            btnAddNode.Name = "btnAddNode";
            btnAddNode.Size = new Size(94, 29);
            btnAddNode.TabIndex = 1;
            btnAddNode.Text = "Add Node";
            btnAddNode.UseVisualStyleBackColor = true;
            btnAddNode.Click += btnAddNode_Click;
            // 
            // btnAddEdge
            // 
            btnAddEdge.Location = new Point(239, 27);
            btnAddEdge.Name = "btnAddEdge";
            btnAddEdge.Size = new Size(94, 29);
            btnAddEdge.TabIndex = 2;
            btnAddEdge.Text = "Add Edge";
            btnAddEdge.UseVisualStyleBackColor = true;
            btnAddEdge.Click += btnAddEdge_Click;
            // 
            // btnClear
            // 
            btnClear.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClear.Location = new Point(870, 27);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(94, 29);
            btnClear.TabIndex = 3;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // btnRun
            // 
            btnRun.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnRun.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRun.Location = new Point(795, 597);
            btnRun.Name = "btnRun";
            btnRun.Size = new Size(128, 44);
            btnRun.TabIndex = 4;
            btnRun.Text = "Run";
            btnRun.UseVisualStyleBackColor = true;
            btnRun.Click += btnRun_Click;
            // 
            // lblMaxFlow
            // 
            lblMaxFlow.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblMaxFlow.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMaxFlow.Location = new Point(501, 605);
            lblMaxFlow.Name = "lblMaxFlow";
            lblMaxFlow.Size = new Size(180, 28);
            lblMaxFlow.TabIndex = 5;
            lblMaxFlow.Text = "---";
            lblMaxFlow.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(377, 606);
            label1.Name = "label1";
            label1.Size = new Size(99, 28);
            label1.TabIndex = 6;
            label1.Text = "Max Flow:";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnEraseNode
            // 
            btnEraseNode.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEraseNode.Location = new Point(532, 27);
            btnEraseNode.Name = "btnEraseNode";
            btnEraseNode.Size = new Size(94, 29);
            btnEraseNode.TabIndex = 7;
            btnEraseNode.Text = "Erase Node";
            btnEraseNode.UseVisualStyleBackColor = true;
            btnEraseNode.Click += btnEraseNode_Click;
            // 
            // btnEditEdge
            // 
            btnEditEdge.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEditEdge.Location = new Point(760, 27);
            btnEditEdge.Name = "btnEditEdge";
            btnEditEdge.Size = new Size(94, 29);
            btnEditEdge.TabIndex = 8;
            btnEditEdge.Text = "Edit Edge";
            btnEditEdge.UseVisualStyleBackColor = true;
            btnEditEdge.Click += btnEditEdge_Click;
            // 
            // btnEraseEdge
            // 
            btnEraseEdge.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEraseEdge.Location = new Point(647, 27);
            btnEraseEdge.Name = "btnEraseEdge";
            btnEraseEdge.Size = new Size(94, 29);
            btnEraseEdge.TabIndex = 9;
            btnEraseEdge.Text = "Erase Edge";
            btnEraseEdge.UseVisualStyleBackColor = true;
            btnEraseEdge.Click += btnEraseEdge_Click;
            // 
            // btnSelect
            // 
            btnSelect.Location = new Point(15, 27);
            btnSelect.Name = "btnSelect";
            btnSelect.Size = new Size(94, 29);
            btnSelect.TabIndex = 10;
            btnSelect.Text = "Select";
            btnSelect.UseVisualStyleBackColor = true;
            btnSelect.Click += btnSelect_Click;
            // 
            // btnSelectSource
            // 
            btnSelectSource.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSelectSource.Location = new Point(15, 604);
            btnSelectSource.Name = "btnSelectSource";
            btnSelectSource.Size = new Size(139, 30);
            btnSelectSource.TabIndex = 11;
            btnSelectSource.Text = "Select Source(s)";
            btnSelectSource.UseVisualStyleBackColor = true;
            btnSelectSource.Click += buttonSelectSource_Click;
            // 
            // btnSelectSink
            // 
            btnSelectSink.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSelectSink.Location = new Point(180, 604);
            btnSelectSink.Name = "btnSelectSink";
            btnSelectSink.Size = new Size(139, 30);
            btnSelectSink.TabIndex = 12;
            btnSelectSink.Text = "Select Sink(s)";
            btnSelectSink.UseVisualStyleBackColor = true;
            btnSelectSink.Click += buttonSelectSink_Click;
            // 
            // GraphVisualizer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(977, 645);
            Controls.Add(btnSelectSink);
            Controls.Add(btnSelectSource);
            Controls.Add(btnSelect);
            Controls.Add(btnEraseEdge);
            Controls.Add(btnEditEdge);
            Controls.Add(btnEraseNode);
            Controls.Add(label1);
            Controls.Add(lblMaxFlow);
            Controls.Add(btnRun);
            Controls.Add(btnClear);
            Controls.Add(btnAddEdge);
            Controls.Add(btnAddNode);
            Controls.Add(pnlDraw);
            Name = "GraphVisualizer";
            Text = "GraphVisualizer";
            ResumeLayout(false);
        }

        #endregion

        private DoubleBufferedPanel pnlDraw;
        private Button btnAddNode;
        private Button btnAddEdge;
        private Button btnClear;
        private Button btnRun;
        private Label lblMaxFlow;
        private Label label1;
        private Button btnEraseNode;
        private Button btnEditEdge;
        private Button btnEraseEdge;
        private Button btnSelect;
        private Button btnSelectSource;
        private Button btnSelectSink;
    }
}