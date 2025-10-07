namespace Project_GarageManagement
{
    partial class frmCars
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCars));
            this.dgvCars = new System.Windows.Forms.DataGridView();
            this.ColMaXe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColHoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColHangXe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColBienSo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNamSX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTenXe = new System.Windows.Forms.TextBox();
            this.txtHangXe = new System.Windows.Forms.TextBox();
            this.txtBienSo = new System.Windows.Forms.TextBox();
            this.txtNamSX = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCars)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCars
            // 
            this.dgvCars.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCars.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCars.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColMaXe,
            this.ColHoTen,
            this.ColHangXe,
            this.ColBienSo,
            this.ColNamSX});
            this.dgvCars.Location = new System.Drawing.Point(367, 12);
            this.dgvCars.Name = "dgvCars";
            this.dgvCars.RowHeadersWidth = 51;
            this.dgvCars.RowTemplate.Height = 24;
            this.dgvCars.Size = new System.Drawing.Size(421, 363);
            this.dgvCars.TabIndex = 0;
            // 
            // ColMaXe
            // 
            this.ColMaXe.HeaderText = "Mã Xe";
            this.ColMaXe.MinimumWidth = 6;
            this.ColMaXe.Name = "ColMaXe";
            // 
            // ColHoTen
            // 
            this.ColHoTen.HeaderText = "Họ Tên";
            this.ColHoTen.MinimumWidth = 6;
            this.ColHoTen.Name = "ColHoTen";
            // 
            // ColHangXe
            // 
            this.ColHangXe.HeaderText = "Hãng Xe";
            this.ColHangXe.MinimumWidth = 6;
            this.ColHangXe.Name = "ColHangXe";
            // 
            // ColBienSo
            // 
            this.ColBienSo.HeaderText = "Biển Số";
            this.ColBienSo.MinimumWidth = 6;
            this.ColBienSo.Name = "ColBienSo";
            // 
            // ColNamSX
            // 
            this.ColNamSX.HeaderText = "Năm Sản Xuất";
            this.ColNamSX.MinimumWidth = 6;
            this.ColNamSX.Name = "ColNamSX";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tên Xe";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Hãng xe";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Biển số";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(36, 242);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(181, 242);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 5;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(36, 316);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Năm Sản Xuất";
            // 
            // txtTenXe
            // 
            this.txtTenXe.Location = new System.Drawing.Point(145, 30);
            this.txtTenXe.Name = "txtTenXe";
            this.txtTenXe.Size = new System.Drawing.Size(190, 22);
            this.txtTenXe.TabIndex = 9;
            // 
            // txtHangXe
            // 
            this.txtHangXe.Location = new System.Drawing.Point(145, 81);
            this.txtHangXe.Name = "txtHangXe";
            this.txtHangXe.Size = new System.Drawing.Size(190, 22);
            this.txtHangXe.TabIndex = 10;
            // 
            // txtBienSo
            // 
            this.txtBienSo.Location = new System.Drawing.Point(145, 129);
            this.txtBienSo.Name = "txtBienSo";
            this.txtBienSo.Size = new System.Drawing.Size(190, 22);
            this.txtBienSo.TabIndex = 11;
            // 
            // txtNamSX
            // 
            this.txtNamSX.Location = new System.Drawing.Point(145, 189);
            this.txtNamSX.Name = "txtNamSX";
            this.txtNamSX.Size = new System.Drawing.Size(190, 22);
            this.txtNamSX.TabIndex = 12;
            // 
            // frmCars
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtNamSX);
            this.Controls.Add(this.txtBienSo);
            this.Controls.Add(this.txtHangXe);
            this.Controls.Add(this.txtTenXe);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvCars);
            this.Name = "frmCars";
            this.Text = "Cars";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCars)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCars;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTenXe;
        private System.Windows.Forms.TextBox txtHangXe;
        private System.Windows.Forms.TextBox txtBienSo;
        private System.Windows.Forms.TextBox txtNamSX;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColMaXe;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColHoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColHangXe;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColBienSo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNamSX;
    }
}

