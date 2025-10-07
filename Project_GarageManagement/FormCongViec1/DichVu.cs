using Project_GarageManagement;
using Project_GarageManagement.FormCongViec;
using System;
using System.Data;
using System.Windows.Forms;

namespace Project_GarageManagement
{
    public partial class frmDichVu : Form
    {
        private DataTable dt;

        public frmDichVu()
        {
            InitializeComponent();
            dt = new DataTable();
            dt.Columns.Add("TenDichVu", typeof(string));
            dt.Columns.Add("DonGia", typeof(decimal));
            dgvDichVu.DataSource = dt;
        }

        private void frmDichVu_Load(object sender, EventArgs e)
        {
            dgvDichVu.Columns[0].HeaderText = "Tên dịch vụ";
            dgvDichVu.Columns[1].HeaderText = "Đơn giá";
        }

        private void dgvDichVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtTenDichVu.Text = dgvDichVu.Rows[e.RowIndex].Cells[0].Value?.ToString();
                txtDonGia.Text = dgvDichVu.Rows[e.RowIndex].Cells[1].Value?.ToString();
            }
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClearTextBox()
        {
            txtTenDichVu.Clear();
            txtDonGia.Clear();
        }

        private void thêmToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenDichVu.Text))
            {
                MessageBox.Show("Nhập tên dịch vụ!");
                return;
            }

            if (!decimal.TryParse(txtDonGia.Text, out decimal donGia))
            {
                MessageBox.Show("Đơn giá không hợp lệ!");
                return;
            }

            dt.Rows.Add(txtTenDichVu.Text, donGia);
            ClearTextBox();
        }

        private void xóaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (dgvDichVu.CurrentRow != null)
            {
                dt.Rows.RemoveAt(dgvDichVu.CurrentRow.Index);
                ClearTextBox();
            }
        }

        private void sửaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (dgvDichVu.CurrentRow != null)
            {
                int index = dgvDichVu.CurrentRow.Index;
                dt.Rows[index]["TenDichVu"] = txtTenDichVu.Text;
                dt.Rows[index]["DonGia"] = decimal.Parse(txtDonGia.Text);
            }
        }

        private void chiTiếtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChiTietDichVu f = new frmChiTietDichVu();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }
    }
}
