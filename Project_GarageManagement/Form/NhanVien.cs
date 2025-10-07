using System;
using System.Data;
using System.Windows.Forms;

namespace Project_GarageManagement
{
    public partial class frmNhanVien : Form
    {
        private DataTable dt;
        private int nextId = 1;

        public frmNhanVien()
        {
            InitializeComponent();

            dt = new DataTable();
            dt.Columns.Add("MaNV", typeof(int));
            dt.Columns.Add("HoTen", typeof(string));
            dt.Columns.Add("ChucVu", typeof(string));
            dt.Columns.Add("SoDienThoai", typeof(string));
            dt.Columns.Add("Luong", typeof(decimal));

            dgvNhanVien.DataSource = dt;
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            dgvNhanVien.Columns[0].HeaderText = "Mã NV";
            dgvNhanVien.Columns[1].HeaderText = "Họ tên";
            dgvNhanVien.Columns[2].HeaderText = "Chức vụ";
            dgvNhanVien.Columns[3].HeaderText = "Số điện thoại";
            dgvNhanVien.Columns[4].HeaderText = "Lương";

            dgvNhanVien.Columns[0].ReadOnly = true;
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtMaNV.Text = dgvNhanVien.Rows[e.RowIndex].Cells[0].Value?.ToString();
                txtHoTen.Text = dgvNhanVien.Rows[e.RowIndex].Cells[1].Value?.ToString();
                txtChucVu.Text = dgvNhanVien.Rows[e.RowIndex].Cells[2].Value?.ToString();
                txtSoDienThoai.Text = dgvNhanVien.Rows[e.RowIndex].Cells[3].Value?.ToString();
                txtLuong.Text = dgvNhanVien.Rows[e.RowIndex].Cells[4].Value?.ToString();
            }
        }

        private void ClearTextBox()
        {
            txtMaNV.Clear();
            txtHoTen.Clear();
            txtChucVu.Clear();
            txtSoDienThoai.Clear();
            txtLuong.Clear();
        }

        private void thêmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên!");
                return;
            }

            if (!decimal.TryParse(txtLuong.Text, out decimal luong))
            {
                MessageBox.Show("Lương không hợp lệ!");
                return;
            }

            dt.Rows.Add(nextId++, txtHoTen.Text, txtChucVu.Text, txtSoDienThoai.Text, luong);
            ClearTextBox();
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvNhanVien.CurrentRow != null)
            {
                dt.Rows.RemoveAt(dgvNhanVien.CurrentRow.Index);
                ClearTextBox();
            }
        }

        private void sửaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvNhanVien.CurrentRow != null)
            {
                int index = dgvNhanVien.CurrentRow.Index;
                dt.Rows[index]["HoTen"] = txtHoTen.Text;
                dt.Rows[index]["ChucVu"] = txtChucVu.Text;
                dt.Rows[index]["SoDienThoai"] = txtSoDienThoai.Text;
                dt.Rows[index]["Luong"] = decimal.Parse(txtLuong.Text);
            }
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
