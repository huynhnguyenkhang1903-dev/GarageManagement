using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_GarageManagement.Enities.Login
{
    public partial class frmlogin : Form
    {
        public frmlogin()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void flogin_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            frmtrangchu f = new frmtrangchu();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }
    }
}
