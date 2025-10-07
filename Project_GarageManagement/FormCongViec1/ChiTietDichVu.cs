using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_GarageManagement.FormCongViec
{
    public partial class frmChiTietDichVu : Form
    {
        private DataTable dt;

        public frmChiTietDichVu()
        {
            InitializeComponent();

            dt = new DataTable();
            dt.Columns.Add("MaDichVu", typeof(string));
            dt.Columns.Add("SoLuong", typeof(int));
            dt.Columns.Add("ThanhTien", typeof(decimal));

            dgvChiTietDichVu.DataSource = dt;  
        }

        private void thêmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menu = sender as ToolStripMenuItem;
            if (menu == null) return;

            string ma = txtMaDichVu.Text.Trim();
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
                if (dgvChiTietDichVu.CurrentRow != null)
                {
                    dgvChiTietDichVu.Rows.RemoveAt(dgvChiTietDichVu.CurrentRow.Index);
                }
            }
            else if (menu.Text == "Sửa")
            {
                if (dgvChiTietDichVu.CurrentRow != null)
                {
                    int index = dgvChiTietDichVu.CurrentRow.Index;
                    dt.Rows[index]["MaDichVu"] = ma;
                    dt.Rows[index]["SoLuong"] = soLuong;
                    dt.Rows[index]["ThanhTien"] = thanhTien;
                }
            }
            }

        private void dgvChiTietDichVu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvChiTietDichVu.Rows.Count)
            {
                DataGridViewRow row = dgvChiTietDichVu.Rows[e.RowIndex];
                txtMaDichVu.Text = row.Cells["MaDichVu"].Value?.ToString();
                txtSoLuong.Text = row.Cells["SoLuong"].Value?.ToString();
                txtThanhTien.Text = row.Cells["ThanhTien"].Value?.ToString();
            }
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvChiTietDichVu.CurrentRow != null)
            {
                int index = dgvChiTietDichVu.CurrentRow.Index;
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
            if (dgvChiTietDichVu.CurrentRow != null)
            {
                int index = dgvChiTietDichVu.CurrentRow.Index;
                if (index >= 0 && index < dt.Rows.Count)
                {
                    dt.Rows[index]["MaDichVu"] = txtMaDichVu.Text.Trim();
                    dt.Rows[index]["SoLuong"] = int.Parse(txtSoLuong.Text);
                    dt.Rows[index]["ThanhTien"] = decimal.Parse(txtThanhTien.Text);
                }
            }
            else
            {
                MessageBox.Show("Chọn dòng cần sửa!");
            }
        }
        private void ClearTextBox()
        {
            txtMaDichVu.Clear();
            txtSoLuong.Clear();
            txtThanhTien.Clear();
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

        private void frmChiTietDichVu_Load(object sender, EventArgs e)
        {
            dgvChiTietDichVu.Columns.Add("MaDichVu", "Mã dịch vụ");
            dgvChiTietDichVu.Columns.Add("SoLuong", "Số lượng");
            dgvChiTietDichVu.Columns.Add("ThanhTien", "Thành tiền");
        }
    }
}
