using Project_GarageManagement;
using System;
using System.Data;
using System.Windows.Forms;

namespace Project_GarageManagement
{
    public partial class frmKhachHang : Form
    {
        private DataTable dt;
        private int nextId = 1; // Tự động tăng mã KH

        public frmKhachHang()
        {
            InitializeComponent();
            dt = new DataTable();

            dt.Columns.Add("MaKH", typeof(int));
            dt.Columns.Add("HoTen", typeof(string));
            dt.Columns.Add("SoDienThoai", typeof(string));
            dt.Columns.Add("DiaChi", typeof(string));
            dt.Columns.Add("Email", typeof(string));

            dgvKhachHang.DataSource = dt;
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            dgvKhachHang.Columns[0].HeaderText = "Mã KH";
            dgvKhachHang.Columns[1].HeaderText = "Họ tên";
            dgvKhachHang.Columns[2].HeaderText = "Số điện thoại";
            dgvKhachHang.Columns[3].HeaderText = "Địa chỉ";
            dgvKhachHang.Columns[4].HeaderText = "Email";

            dgvKhachHang.Columns[0].ReadOnly = true; // Không cho sửa mã KH
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtMaKH.Text = dgvKhachHang.Rows[e.RowIndex].Cells[0].Value?.ToString();
                txtHoTen.Text = dgvKhachHang.Rows[e.RowIndex].Cells[1].Value?.ToString();
                txtSDT.Text = dgvKhachHang.Rows[e.RowIndex].Cells[2].Value?.ToString();
                txtDiaChi.Text = dgvKhachHang.Rows[e.RowIndex].Cells[3].Value?.ToString();
                txtEmail.Text = dgvKhachHang.Rows[e.RowIndex].Cells[4].Value?.ToString();
            }
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClearTextBox()
        {
            txtMaKH.Clear();
            txtHoTen.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();
            txtEmail.Clear();
        }

        private void thêmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên!");
                return;
            }

            dt.Rows.Add(nextId++, txtHoTen.Text, txtSDT.Text, txtDiaChi.Text, txtEmail.Text);
            ClearTextBox();
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvKhachHang.CurrentRow != null)
            {
                dt.Rows.RemoveAt(dgvKhachHang.CurrentRow.Index);
                ClearTextBox();
            }
        }

        private void sửaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvKhachHang.CurrentRow != null)
            {
                int index = dgvKhachHang.CurrentRow.Index;
                dt.Rows[index]["HoTen"] = txtHoTen.Text;
                dt.Rows[index]["SoDienThoai"] = txtSDT.Text;
                dt.Rows[index]["DiaChi"] = txtDiaChi.Text;
                dt.Rows[index]["Email"] = txtEmail.Text;
            }
        }
    }
}
