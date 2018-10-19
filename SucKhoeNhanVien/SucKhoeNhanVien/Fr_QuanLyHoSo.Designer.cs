namespace SucKhoeNhanVien
{
    partial class Fr_QuanLyHoSo
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
            this.groupqlnv = new System.Windows.Forms.GroupBox();
            this.txtidLSB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btxem = new System.Windows.Forms.Button();
            this.btlammoi = new System.Windows.Forms.Button();
            this.btsua = new System.Windows.Forms.Button();
            this.lbkhoa = new System.Windows.Forms.Label();
            this.bttim = new System.Windows.Forms.Button();
            this.txtkhoa = new System.Windows.Forms.TextBox();
            this.txttennv = new System.Windows.Forms.TextBox();
            this.txtmanv = new System.Windows.Forms.TextBox();
            this.lbtennv = new System.Windows.Forms.Label();
            this.lbmanhanvien = new System.Windows.Forms.Label();
            this.lbDSNV = new System.Windows.Forms.Label();
            this.datagvSKNhanVien = new System.Windows.Forms.DataGridView();
            this.bt_baocao = new System.Windows.Forms.Button();
            this.groupqlnv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagvSKNhanVien)).BeginInit();
            this.SuspendLayout();
            // 
            // groupqlnv
            // 
            this.groupqlnv.Controls.Add(this.bt_baocao);
            this.groupqlnv.Controls.Add(this.txtidLSB);
            this.groupqlnv.Controls.Add(this.label1);
            this.groupqlnv.Controls.Add(this.dateTimePicker1);
            this.groupqlnv.Controls.Add(this.btxem);
            this.groupqlnv.Controls.Add(this.btlammoi);
            this.groupqlnv.Controls.Add(this.btsua);
            this.groupqlnv.Controls.Add(this.lbkhoa);
            this.groupqlnv.Controls.Add(this.bttim);
            this.groupqlnv.Controls.Add(this.txtkhoa);
            this.groupqlnv.Controls.Add(this.txttennv);
            this.groupqlnv.Controls.Add(this.txtmanv);
            this.groupqlnv.Controls.Add(this.lbtennv);
            this.groupqlnv.Controls.Add(this.lbmanhanvien);
            this.groupqlnv.Location = new System.Drawing.Point(12, 12);
            this.groupqlnv.Name = "groupqlnv";
            this.groupqlnv.Size = new System.Drawing.Size(1302, 107);
            this.groupqlnv.TabIndex = 8;
            this.groupqlnv.TabStop = false;
            // 
            // txtidLSB
            // 
            this.txtidLSB.Location = new System.Drawing.Point(822, 75);
            this.txtidLSB.Name = "txtidLSB";
            this.txtidLSB.ReadOnly = true;
            this.txtidLSB.Size = new System.Drawing.Size(100, 20);
            this.txtidLSB.TabIndex = 20;
            this.txtidLSB.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(15, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 15);
            this.label1.TabIndex = 18;
            this.label1.Text = "Ngày Khám";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(103, 73);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 17;
            // 
            // btxem
            // 
            this.btxem.Location = new System.Drawing.Point(1109, 34);
            this.btxem.Name = "btxem";
            this.btxem.Size = new System.Drawing.Size(75, 23);
            this.btxem.TabIndex = 15;
            this.btxem.Text = "Xem";
            this.btxem.UseVisualStyleBackColor = true;
            this.btxem.Click += new System.EventHandler(this.btxem_Click);
            // 
            // btlammoi
            // 
            this.btlammoi.Location = new System.Drawing.Point(1011, 34);
            this.btlammoi.Name = "btlammoi";
            this.btlammoi.Size = new System.Drawing.Size(75, 23);
            this.btlammoi.TabIndex = 14;
            this.btlammoi.Text = "Làm Mới";
            this.btlammoi.UseVisualStyleBackColor = true;
            this.btlammoi.Click += new System.EventHandler(this.btlammoi_Click);
            // 
            // btsua
            // 
            this.btsua.Location = new System.Drawing.Point(914, 35);
            this.btsua.Name = "btsua";
            this.btsua.Size = new System.Drawing.Size(75, 23);
            this.btsua.TabIndex = 13;
            this.btsua.Text = "Sửa";
            this.btsua.UseVisualStyleBackColor = true;
            this.btsua.Click += new System.EventHandler(this.btsua_Click);
            // 
            // lbkhoa
            // 
            this.lbkhoa.AutoSize = true;
            this.lbkhoa.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbkhoa.Location = new System.Drawing.Point(583, 40);
            this.lbkhoa.Name = "lbkhoa";
            this.lbkhoa.Size = new System.Drawing.Size(35, 15);
            this.lbkhoa.TabIndex = 11;
            this.lbkhoa.Text = "Khoa";
            // 
            // bttim
            // 
            this.bttim.Location = new System.Drawing.Point(822, 35);
            this.bttim.Name = "bttim";
            this.bttim.Size = new System.Drawing.Size(75, 23);
            this.bttim.TabIndex = 6;
            this.bttim.Text = "Tìm";
            this.bttim.UseVisualStyleBackColor = true;
            this.bttim.Click += new System.EventHandler(this.bttim_Click);
            // 
            // txtkhoa
            // 
            this.txtkhoa.Location = new System.Drawing.Point(624, 37);
            this.txtkhoa.Name = "txtkhoa";
            this.txtkhoa.Size = new System.Drawing.Size(164, 20);
            this.txtkhoa.TabIndex = 10;
            // 
            // txttennv
            // 
            this.txttennv.Location = new System.Drawing.Point(391, 37);
            this.txttennv.Name = "txttennv";
            this.txttennv.Size = new System.Drawing.Size(164, 20);
            this.txttennv.TabIndex = 9;
            // 
            // txtmanv
            // 
            this.txtmanv.Location = new System.Drawing.Point(103, 37);
            this.txtmanv.Name = "txtmanv";
            this.txtmanv.Size = new System.Drawing.Size(164, 20);
            this.txtmanv.TabIndex = 8;
            // 
            // lbtennv
            // 
            this.lbtennv.AutoSize = true;
            this.lbtennv.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbtennv.Location = new System.Drawing.Point(302, 40);
            this.lbtennv.Name = "lbtennv";
            this.lbtennv.Size = new System.Drawing.Size(87, 15);
            this.lbtennv.TabIndex = 7;
            this.lbtennv.Text = "Tên Nhân Viên";
            // 
            // lbmanhanvien
            // 
            this.lbmanhanvien.AutoSize = true;
            this.lbmanhanvien.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbmanhanvien.Location = new System.Drawing.Point(15, 40);
            this.lbmanhanvien.Name = "lbmanhanvien";
            this.lbmanhanvien.Size = new System.Drawing.Size(84, 15);
            this.lbmanhanvien.TabIndex = 6;
            this.lbmanhanvien.Text = "Mã Nhân Viên";
            // 
            // lbDSNV
            // 
            this.lbDSNV.AutoSize = true;
            this.lbDSNV.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbDSNV.Location = new System.Drawing.Point(12, 132);
            this.lbDSNV.Name = "lbDSNV";
            this.lbDSNV.Size = new System.Drawing.Size(251, 21);
            this.lbDSNV.TabIndex = 9;
            this.lbDSNV.Text = "Danh Sách Sức Khỏe Nhân Viên";
            // 
            // datagvSKNhanVien
            // 
            this.datagvSKNhanVien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.datagvSKNhanVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagvSKNhanVien.Location = new System.Drawing.Point(12, 172);
            this.datagvSKNhanVien.Name = "datagvSKNhanVien";
            this.datagvSKNhanVien.Size = new System.Drawing.Size(1297, 341);
            this.datagvSKNhanVien.TabIndex = 10;
            // 
            // bt_baocao
            // 
            this.bt_baocao.Location = new System.Drawing.Point(1205, 34);
            this.bt_baocao.Name = "bt_baocao";
            this.bt_baocao.Size = new System.Drawing.Size(75, 23);
            this.bt_baocao.TabIndex = 21;
            this.bt_baocao.Text = "Báo cáo";
            this.bt_baocao.UseVisualStyleBackColor = true;
            this.bt_baocao.Click += new System.EventHandler(this.bt_baocao_Click);
            // 
            // Fr_QuanLyHoSo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1326, 528);
            this.Controls.Add(this.datagvSKNhanVien);
            this.Controls.Add(this.lbDSNV);
            this.Controls.Add(this.groupqlnv);
            this.Location = new System.Drawing.Point(0, 97);
            this.MaximumSize = new System.Drawing.Size(1342, 567);
            this.Name = "Fr_QuanLyHoSo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Fr_QuanLyHoSo";
            this.groupqlnv.ResumeLayout(false);
            this.groupqlnv.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagvSKNhanVien)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupqlnv;
        private System.Windows.Forms.Button btxem;
        private System.Windows.Forms.Button btlammoi;
        private System.Windows.Forms.Button btsua;
        private System.Windows.Forms.Label lbkhoa;
        private System.Windows.Forms.Button bttim;
        private System.Windows.Forms.TextBox txtkhoa;
        private System.Windows.Forms.TextBox txttennv;
        private System.Windows.Forms.TextBox txtmanv;
        private System.Windows.Forms.Label lbtennv;
        private System.Windows.Forms.Label lbmanhanvien;
        private System.Windows.Forms.Label lbDSNV;
        private System.Windows.Forms.DataGridView datagvSKNhanVien;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtidLSB;
        private System.Windows.Forms.Button bt_baocao;
    }
}