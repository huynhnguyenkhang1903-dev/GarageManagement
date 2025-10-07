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
    public partial class frmtrangchu : Form
    {
        public frmtrangchu()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmtrangchu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát chương trình?",
                        "Thông báo",
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Question)
        != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void frmtrangchu_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            formPanel.Controls.Clear();

            // Tạo instance của form cần hiển thị
            frmCars frm = new frmCars();

            // Thiết lập form hiển thị trong panel (không là form độc lập)
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill; // cho full panel

            // Thêm form vào panel
            formPanel.Controls.Add(frm);

            // Hiển thị form
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            formPanel.Controls.Clear();

            // Tạo instance của form cần hiển thị
            frmKhachHang frm = new frmKhachHang();

            // Thiết lập form hiển thị trong panel (không là form độc lập)
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill; // cho full panel

            // Thêm form vào panel
            formPanel.Controls.Add(frm);

            // Hiển thị form
            frm.Show();
        }
    }
}
