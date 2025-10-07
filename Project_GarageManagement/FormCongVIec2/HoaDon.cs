using System;
using System.Data;
using System.Windows.Forms;

namespace Project_GarageManagement
{
    public partial class frmHoaDon : Form
    {
        private DataTable dt;
        private int nextId = 1;


        public frmHoaDon()
        {
            InitializeComponent();
            dt = new DataTable();
        }

        private void HoaDon_Load(object sender, EventArgs e)
        {
            dt = new DataTable();
            dt.Columns.Add("MaHoaDon", typeof(int));
            dt.Columns.Add("NgayLap", typeof(DateTime));
            dt.Columns.Add("MaXe", typeof(int));
            dt.Columns.Add("MaNV", typeof(int));
            dt.Columns.Add("TongTien", typeof(decimal));

            dgvHoaDon.DataSource = dt;
        }

        private void sửaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.CurrentRow != null)
            {
                int index = dgvHoaDon.CurrentRow.Index;
                dt.Rows[index]["MaXe"] = int.Parse(txtMaXe.Text);
                dt.Rows[index]["MaNV"] = int.Parse(txtMaNV.Text);
                dt.Rows[index]["TongTien"] = decimal.Parse(txtTongTien.Text);
            }
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.CurrentRow != null)
            {
                int index = dgvHoaDon.CurrentRow.Index;
                dt.Rows[index].Delete();
            }
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void xóaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (dgvHoaDon.CurrentRow != null)
            {
                int index = dgvHoaDon.CurrentRow.Index;
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
            if (dgvHoaDon.CurrentRow != null)
            {
                int index = dgvHoaDon.CurrentRow.Index;
                if (index >= 0 && index < dt.Rows.Count)
                {
                    // Kiểm tra dữ liệu nhập vào
                    if (!int.TryParse(txtMaXe.Text.Trim(), out int maXe))
                    {
                        MessageBox.Show("Mã xe phải là số nguyên!");
                        return;
                    }

                    if (!int.TryParse(txtMaNV.Text.Trim(), out int maNV))
                    {
                        MessageBox.Show("Mã nhân viên phải là số nguyên!");
                        return;
                    }

                    if (!decimal.TryParse(txtTongTien.Text.Trim(), out decimal tongTien))
                    {
                        MessageBox.Show("Tổng tiền phải là số!");
                        return;
                    }

                    // Gán dữ liệu sửa vào dòng hiện tại
                    dt.Rows[index]["MaXe"] = maXe;
                    dt.Rows[index]["MaNV"] = maNV;
                    dt.Rows[index]["TongTien"] = tongTien;
                    dt.Rows[index]["NgayLap"] = dtpNgayLap.Value;

                    MessageBox.Show("Sửa hóa đơn thành công!");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng cần sửa!");
            }
        }

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvHoaDon.Rows.Count)
            {
                DataGridViewRow row = dgvHoaDon.Rows[e.RowIndex];
                txtMaXe.Text = row.Cells["MaXe"].Value.ToString();
                txtMaNV.Text = row.Cells["MaNV"].Value.ToString();
                txtTongTien.Text = row.Cells["TongTien"].Value.ToString();

                if (row.Cells["NgayLap"].Value != DBNull.Value)
                {
                    dtpNgayLap.Value = Convert.ToDateTime(row.Cells["NgayLap"].Value);
                }
            }
        }

        private void thoátToolStripMenuItem_Click_1(object sender, EventArgs e)
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
        private void ClearTextBox()
        {
            txtMaXe.Clear();
            txtMaNV.Clear();
            txtTongTien.Clear();
        }

        private void thêmToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtMaXe.Text.Trim(), out int maXe))
                {
                    MessageBox.Show("Mã xe phải là số nguyên!");
                    return;
                }

                if (!int.TryParse(txtMaNV.Text.Trim(), out int maNV))
                {
                    MessageBox.Show("Mã nhân viên phải là số nguyên!");
                    return;
                }

                if (!decimal.TryParse(txtTongTien.Text.Trim(), out decimal tongTien))
                {
                    MessageBox.Show("Tổng tiền phải là số!");
                    return;
                }

                DataRow row = dt.NewRow();
                row["MaHoaDon"] = nextId++;
                row["NgayLap"] = dtpNgayLap.Value; // lấy từ DateTimePicker
                row["MaXe"] = maXe;
                row["MaNV"] = maNV;
                row["TongTien"] = tongTien;

                dt.Rows.Add(row);
                ClearTextBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm hóa đơn: " + ex.Message);
            }
        }
    }
}
