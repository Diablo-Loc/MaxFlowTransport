using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using src.Algorithms;
using src.Models;

namespace src.UI
{
    public partial class CalculaterMF : Form
    {
        public CalculaterMF()
        {
            InitializeComponent();
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
                    MessageBox.Show(err, "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Graph g = Utils.BuildTransportationGraph(supply, demand, cap);
                int source = supply.Length + demand.Length;
                int sink = source + 1;
                int maxFlow = MaxFlowSolve.EdmondKarp(g, source, sink);

                var sb = new StringBuilder();
                lblMaxFlow.Text=($"Maximum Flow = {maxFlow}");
                                
                foreach (var e1 in g.Edges) // chỉ in cạnh thuận
                {
                    sb.AppendLine($"{e1.From} -> {e1.To} | Flow = {e1.Flow}/{e1.Capacity}");
                }
                txbResult.Text = sb.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chạy: " + ex.Message);
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
                col.Width = 60;
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
                errMsg = "Chưa tạo bảng capacity. Nhấn 'Tạo bảng capacity' trước.";
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
                            errMsg = $"Giá trị không hợp lệ tại ô S{i},D{j}. Hãy nhập số nguyên không âm.";
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
                MessageBox.Show("Lỗi khi tạo bảng: " + ex.Message);
            }
        }
    }
}
