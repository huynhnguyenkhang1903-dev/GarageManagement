using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using Project_GarageManagement.Enities;

namespace Project_GarageManagement
{
    public partial class frmCars : Form
    {
        private int selectedCarId = -1;

        public frmCars()
        {
            InitializeComponent();
            LoadCars();

            dgvCars.CellClick += dgvCars_CellClick;
            btnDelete.Click += btnDelete_Click;
        }

        //private string GetConnectionString()
        //{
        //    var cs = System.Configuration.ConfigurationManager.ConnectionStrings["GarageManagementEntities"];
        //    if (cs == null) throw new Exception("Không tìm thấy connection string 'GarageManagementEntities'");
        //    return cs.ConnectionString;
        //}


        private void LoadCars()
        {
            try
            {
                using (GarageManagementEntities db = new GarageManagementEntities())
                {
                    var cars = db.XEs
                                 .Select(x => new
                                 {
                                     x.MaXe,
                                     x.TenXe,
                                     x.HangXe,
                                     x.BienSo,
                                     x.NamSX
                                 })
                                 .ToList();

                    dgvCars.DataSource = cars;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể load danh sách xe: " + ex.Message);
            }
        }

        private void ClearTextBoxes()
        {
            txtTenXe.Clear();
            txtHangXe.Clear();
            txtBienSo.Clear();
            txtNamSX.Clear();
            selectedCarId = -1;
        }

        private void dgvCars_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCars.Rows[e.RowIndex];
                if (row.Cells["MaXe"].Value != DBNull.Value)
                    selectedCarId = Convert.ToInt32(row.Cells["MaXe"].Value);
                else
                    selectedCarId = -1;

                txtTenXe.Text = row.Cells["TenXe"].Value == DBNull.Value ? "" : row.Cells["TenXe"].Value.ToString();
                txtHangXe.Text = row.Cells["HangXe"].Value == DBNull.Value ? "" : row.Cells["HangXe"].Value.ToString();
                txtBienSo.Text = row.Cells["BienSo"].Value == DBNull.Value ? "" : row.Cells["BienSo"].Value.ToString();
                txtNamSX.Text = row.Cells["NamSx"].Value == DBNull.Value ? "" : row.Cells["NamSX"].Value.ToString();
            }
        }




        private void btnSave_Click(object sender, EventArgs e)
        {
            //if (selectedCarId < 0)
            //{
            //    MessageBox.Show("Chọn xe cần lưu!");
            //    return;
            //}

            //try
            //{
            //    using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            //    {
            //        conn.Open();
            //        string query = @"UPDATE Cars 
            //                         SET Name=@Name, Brand=@Brand, LicensePlate=@LicensePlate, Year=@Year 
            //                         WHERE VehicleId=@VehicleId";
            //        using (SqlCommand cmd = new SqlCommand(query, conn))
            //        {
            //            cmd.Parameters.AddWithValue("@Name", txtName.Text);
            //            cmd.Parameters.AddWithValue("@Brand", txtBrand.Text);
            //            cmd.Parameters.AddWithValue("@LicensePlate", txtLicensePlate.Text);
            //            cmd.Parameters.AddWithValue("@Year", int.Parse(txtYear.Text));
            //            cmd.Parameters.AddWithValue("@VehicleId", selectedCarId);
            //            int rows = cmd.ExecuteNonQuery();
            //            MessageBox.Show($"{rows} dòng đã được lưu!");
            //        }
            //    }

            //    ClearTextBoxes();
            //    LoadCars();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Lỗi khi lưu: " + ex.Message);
            //}
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            //if (selectedCarId < 0)
            //{
            //    MessageBox.Show("Chọn xe cần xóa!");
            //    return;
            //}

            //try
            //{
            //    using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            //    {
            //        conn.Open();
            //        string query = "DELETE FROM Cars WHERE VehicleId=@VehicleId";
            //        using (SqlCommand cmd = new SqlCommand(query, conn))
            //        {
            //            cmd.Parameters.AddWithValue("@VehicleId", selectedCarId);
            //            int rows = cmd.ExecuteNonQuery();
            //            MessageBox.Show($"{rows} dòng đã bị xóa!");
            //        }
            //    }

            //    ClearTextBoxes();
            //    LoadCars();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Lỗi khi xóa: " + ex.Message);
            //}
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedCarId < 0)
            {
                MessageBox.Show("Chọn xe cần sửa!");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTenXe.Text) ||
                string.IsNullOrWhiteSpace(txtHangXe.Text) ||
                string.IsNullOrWhiteSpace(txtBienSo.Text) ||
                !int.TryParse(txtNamSX.Text, out int year))
            {
                MessageBox.Show("Nhập đầy đủ thông tin và Năm SX phải là số!");
                return;
            }

            using (GarageManagementEntities db = new GarageManagementEntities())
            {
                XE car = db.XEs.Find(selectedCarId);
                if (car != null)
                {
                    car.TenXe = txtTenXe.Text;
                    car.HangXe = txtHangXe.Text;
                    car.BienSo = txtBienSo.Text;
                    car.NamSX = year;

                    db.SaveChanges();
                    MessageBox.Show("Cập nhật thành công!");
                }
                else
                {
                    MessageBox.Show("Không tìm thấy xe để cập nhật!");
                }
            }

            LoadCars();
            ClearTextBoxes();
        }
       



        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenXe.Text) ||
                string.IsNullOrWhiteSpace(txtHangXe.Text) ||
                string.IsNullOrWhiteSpace(txtBienSo.Text) ||
                !int.TryParse(txtNamSX.Text, out int year))
            {
                MessageBox.Show("Nhập đầy đủ thông tin và Year phải là số!");
                return;
            }

            try
            {
                using (GarageManagementEntities db = new GarageManagementEntities())
                {
                    XE car = new XE
                    {
                        TenXe = txtTenXe.Text,
                        HangXe = txtHangXe.Text,
                        BienSo = txtBienSo.Text,
                        NamSX = year
                    };

                    db.XEs.Add(car);
                    db.SaveChanges();
                }

                MessageBox.Show("Đã thêm 1 dòng thành công!");
                ClearTextBoxes();
                LoadCars();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm: " + ex.Message);
            }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (selectedCarId < 0)
            {
                MessageBox.Show("Chọn xe cần xóa!");
                return;
            }

            using (GarageManagementEntities db = new GarageManagementEntities())
            {
                XE car = db.XEs.Find(selectedCarId);
                if (car != null)
                {
                    db.XEs.Remove(car);
                    db.SaveChanges();

                    MessageBox.Show("Xóa thành công!");
                    LoadCars();
                    ClearTextBoxes();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy xe để xóa!");
                }
            }
        }
    }
    }










