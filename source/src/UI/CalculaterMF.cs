using src.Algorithms;
using src.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace src.UI
{
    public partial class CalculaterMF : Form
    {
        public CalculaterMF()
        {
            InitializeComponent();
            this.DoubleBuffered = true; 
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint |
                          ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();
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

        private void btnRun_Click(object sender, EventArgs e)
        {
            try
            {
                int[] supply = txbInputSupply.Text.Split(',', StringSplitOptions.RemoveEmptyEntries)
                                    .Select(x => int.Parse(x.Trim())).ToArray();
                int[] demand = txbInputDemand.Text.Split(',', StringSplitOptions.RemoveEmptyEntries)
                                    .Select(x => int.Parse(x.Trim())).ToArray(); 
                if (!TryReadCapacityGrid(out int[,] cap, out string err))
                {
                    MessageBox.Show(err, "Data error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Graph g = Utils.BuildTransportationGraph(supply, demand, cap);
                int source = supply.Length + demand.Length;
                int sink = source + 1;
                int maxFlow = MaxFlowSolve.EdmondKarp(g, source, sink);

                var sb = new StringBuilder();
                lblMaxFlow.Text=($"Maximum Flow = {maxFlow}");

                int nSupply = supply.Length;
                int nDemand = demand.Length;
                int sourceId = nSupply + nDemand;
                int sinkId = sourceId + 1;
                foreach (var e1 in g.GetAllEdges())
                {
                    if (e1.Flow == 0 || e1.Capacity == 0) continue;

                    string fromLabel, toLabel;
                    if (e1.From == source) fromLabel = "SRC";
                    else if (e1.From == sink) fromLabel = "SNK";
                    else if (e1.From < supply.Length) fromLabel = $"S{e1.From}";
                    else if (e1.From < supply.Length + demand.Length) fromLabel = $"D{e1.From - supply.Length}";
                    else fromLabel = $"N{e1.From}";

                    if (e1.To == source) toLabel = "SRC";
                    else if (e1.To == sink) toLabel = "SNK";
                    else if (e1.To < supply.Length) toLabel = $"S{e1.To}";
                    else if (e1.To < supply.Length + demand.Length) toLabel = $"D{e1.To - supply.Length}";
                    else toLabel = $"N{e1.To}";

                    sb.AppendLine($"{fromLabel} -> {toLabel} | Flow = {e1.Flow}/{e1.Capacity}");
                }
                txbResult.Text = sb.ToString();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while running: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txbInputSupply.Clear();
            txbInputDemand.Clear();
            dgvCapacity.Columns.Clear();
            dgvCapacity.Rows.Clear();
            lblMaxFlow.Text = ($"Maximum Flow = {0}");
            txbResult.Clear();
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
        

    }
}
