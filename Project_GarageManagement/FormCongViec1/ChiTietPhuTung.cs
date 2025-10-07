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
    public partial class frmChiTietPhuTung : Form
    {
        private DataTable dt;
        public frmChiTietPhuTung()
        {
            InitializeComponent();
            dt = new DataTable();
            dt.Columns.Add("MaPhuTung", typeof(string));
            dt.Columns.Add("SoLuong", typeof(int));
            dt.Columns.Add("ThanhTien", typeof(decimal));

            dgvChiTietPhuTung.DataSource = dt;
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
            dgvChiTietPhuTung.Columns.Add("MaPhuTung", "Mã phụ tùng");
            dgvChiTietPhuTung.Columns.Add("SoLuong", "Số lượng");
            dgvChiTietPhuTung.Columns.Add("ThanhTien", "Thành tiền");
        }


        private void dgvChiTietPhuTung_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvChiTietPhuTung.Rows.Count)
            {
                DataGridViewRow row = dgvChiTietPhuTung.Rows[e.RowIndex];
                txtMaPhuTung.Text = row.Cells["MaPhuTung"].Value?.ToString();
                txtSoLuong.Text = row.Cells["SoLuong"].Value?.ToString();
                txtThanhTien.Text = row.Cells["ThanhTien"].Value?.ToString();
            }
        }
        private void ClearTextBox()
        {
            txtMaPhuTung.Clear();
            txtSoLuong.Clear();
            txtThanhTien.Clear();
        }

        private void thêmToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ToolStripMenuItem menu = sender as ToolStripMenuItem;
            if (menu == null) return;

            string ma = txtMaPhuTung.Text.Trim();
            int soLuong;
            decimal thanhTien;

            int.TryParse(txtSoLuong.Text, out soLuong);
            decimal.TryParse(txtThanhTien.Text, out thanhTien);

            if (menu.Text == "Thêm")
            {
                dt.Rows.Add(ma, soLuong, thanhTien);
            }
            else if (menu.Text == "Xóa")
            {
                if (dgvChiTietPhuTung.CurrentRow != null)
                {
                    dgvChiTietPhuTung.Rows.RemoveAt(dgvChiTietPhuTung.CurrentRow.Index);
                }
            }
            else if (menu.Text == "Sửa")
            {
                if (dgvChiTietPhuTung.CurrentRow != null)
                {
                    int index = dgvChiTietPhuTung.CurrentRow.Index;
                    dt.Rows[index]["MaPhuTung"] = ma;
                    dt.Rows[index]["SoLuong"] = soLuong;
                    dt.Rows[index]["ThanhTien"] = thanhTien;
                }
            }
        }

        private void xóaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (dgvChiTietPhuTung.CurrentRow != null)
            {
                int index = dgvChiTietPhuTung.CurrentRow.Index;
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

        private void sửaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (dgvChiTietPhuTung.CurrentRow != null)
            {
                int index = dgvChiTietPhuTung.CurrentRow.Index;
                if (index >= 0 && index < dt.Rows.Count)
                {
                    dt.Rows[index]["MaPhuTung"] = txtMaPhuTung.Text.Trim();
                    dt.Rows[index]["SoLuong"] = int.Parse(txtSoLuong.Text);
                    dt.Rows[index]["ThanhTien"] = decimal.Parse(txtThanhTien.Text);
                }
            }
            else
            {
                MessageBox.Show("Chọn dòng cần sửa!");
            }
        }

        private void thêmToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menu = sender as ToolStripMenuItem;
            if (menu == null) return;

            string ma = txtMaPhuTung.Text.Trim();
            int soLuong;
            decimal thanhTien;

            int.TryParse(txtSoLuong.Text, out soLuong);
            decimal.TryParse(txtThanhTien.Text, out thanhTien);

            if (menu.Text == "Thêm")
            {
                dt.Rows.Add(ma, soLuong, thanhTien);
            }
            else if (menu.Text == "Xóa")
            {
                if (dgvChiTietPhuTung.CurrentRow != null)
                {
                    dgvChiTietPhuTung.Rows.RemoveAt(dgvChiTietPhuTung.CurrentRow.Index);
                }
            }
            else if (menu.Text == "Sửa")
            {
                if (dgvChiTietPhuTung.CurrentRow != null)
                {
                    int index = dgvChiTietPhuTung.CurrentRow.Index;
                    dt.Rows[index]["MaPhuTung"] = ma;
                    dt.Rows[index]["SoLuong"] = soLuong;
                    dt.Rows[index]["ThanhTien"] = thanhTien;
                }
            }
        }

        private void xóaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (dgvChiTietPhuTung.CurrentRow != null)
            {
                int index = dgvChiTietPhuTung.CurrentRow.Index;
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

        private void sửaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (dgvChiTietPhuTung.CurrentRow != null)
            {
                int index = dgvChiTietPhuTung.CurrentRow.Index;
                if (index >= 0 && index < dt.Rows.Count)
                {
                    dt.Rows[index]["MaPhuTung"] = txtMaPhuTung.Text.Trim();
                    dt.Rows[index]["SoLuong"] = int.Parse(txtSoLuong.Text);
                    dt.Rows[index]["ThanhTien"] = decimal.Parse(txtThanhTien.Text);
                }
            }
            else
            {
                MessageBox.Show("Chọn dòng cần sửa!");
            }
        }

        private void thoátToolStripMenuItem1_Click(object sender, EventArgs e)
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
    }
}
