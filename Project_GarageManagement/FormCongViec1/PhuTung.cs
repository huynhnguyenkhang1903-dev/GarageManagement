using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_GarageManagement
{
    public partial class frmPhuTung : Form
    {
        private DataTable dt;
        public frmPhuTung()
        {
            InitializeComponent();
            dt = new DataTable();
            dt.Columns.Add("MaPhuTung", typeof(string));
            dt.Columns.Add("SoLuong", typeof(int));
            dt.Columns.Add("ThanhTien", typeof(decimal));

            dgvPhuTung.DataSource = dt;
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát chương trình?",
                       "Thông báo",
                       MessageBoxButtons.OKCancel,
                       MessageBoxIcon.Question)
       != DialogResult.OK)
            {
            }
            this.Close();
        }

        private void frmChiTietPhuTung_Load(object sender, EventArgs e)
        {
            dgvPhuTung.Columns.Add("MaPhuTung", "Mã phụ tùng");
            dgvPhuTung.Columns.Add("SoLuong", "Số lượng");
            dgvPhuTung.Columns.Add("ThanhTien", "Thành tiền");
        }

        private void thêmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menu = sender as ToolStripMenuItem;
            if (menu == null) return;

            string ma = txtTenPhuTung.Text.Trim();
            int soLuong;
            decimal thanhTien;

            int.TryParse(txtSoLuongTon.Text, out soLuong);
            decimal.TryParse(txtDonGia.Text, out thanhTien);

            if (menu.Text == "Thêm")
            {
                dt.Rows.Add(ma, soLuong, thanhTien);
            }
            else if (menu.Text == "Xóa")
            {
                if (dgvPhuTung.CurrentRow != null)
                {
                    dgvPhuTung.Rows.RemoveAt(dgvPhuTung.CurrentRow.Index);
                }
            }
            else if (menu.Text == "Sửa")
            {
                if (dgvPhuTung.CurrentRow != null)
                {
                    int index = dgvPhuTung.CurrentRow.Index;
                    dt.Rows[index]["MaPhuTung"] = ma;
                    dt.Rows[index]["SoLuong"] = soLuong;
                    dt.Rows[index]["ThanhTien"] = thanhTien;
                }
            }
        }

        private void dgvChiTietPhuTung_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvPhuTung.Rows.Count)
            {
                DataGridViewRow row = dgvPhuTung.Rows[e.RowIndex];
                txtTenPhuTung.Text = row.Cells["MaPhuTung"].Value?.ToString();
                txtSoLuongTon.Text = row.Cells["SoLuongTon"].Value?.ToString();
                txtDonGia.Text = row.Cells["DonGia"].Value?.ToString();
            }
        }
        private void ClearTextBox()
        {
            txtTenPhuTung.Clear();
            txtSoLuongTon.Clear();
            txtDonGia.Clear();
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvPhuTung.CurrentRow != null)
            {
                int index = dgvPhuTung.CurrentRow.Index;
                if (index >= 0 && index < dt.Rows.Count)
                {
                    dt.Rows.RemoveAt(index);
                    ClearTextBox();
                }
            }
            else
            {
                MessageBox.Show("Chọn dòng cần xóa!");
            }
        }

        private void sửaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvPhuTung.CurrentRow != null)
            {
                int index = dgvPhuTung.CurrentRow.Index;
                if (index >= 0 && index < dt.Rows.Count)
                {
                    dt.Rows[index]["TenPhuTung"] = txtTenPhuTung.Text.Trim();
                    dt.Rows[index]["SoLuongTon"] = int.Parse(txtSoLuongTon.Text);
                    dt.Rows[index]["DonGia"] = decimal.Parse(txtDonGia.Text);
                }
            }
            else
            {
                MessageBox.Show("Chọn dòng cần sửa!");
            }
        }

        private void chiTiếtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChiTietPhuTung f = new frmChiTietPhuTung();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void frmPhuTung_Load(object sender, EventArgs e)
        {

        }
    }
}
