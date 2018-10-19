namespace SucKhoeNhanVien
{
    partial class FrSuaNV
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
            this.cbkhoa = new System.Windows.Forms.ComboBox();
            this.cbchucvu = new System.Windows.Forms.ComboBox();
            this.txtcmnd = new System.Windows.Forms.TextBox();
            this.txttennvsua = new System.Windows.Forms.TextBox();
            this.txtmanvsua = new System.Windows.Forms.TextBox();
            this.btboqua = new System.Windows.Forms.Button();
            this.btLuu = new System.Windows.Forms.Button();
            this.lbNgaySinh = new System.Windows.Forms.Label();
            this.dateTimePickerSuaNV = new System.Windows.Forms.DateTimePicker();
            this.lbCMND = new System.Windows.Forms.Label();
            this.lbChucVu = new System.Windows.Forms.Label();
            this.lbkhoa = new System.Windows.Forms.Label();
            this.lbtennv = new System.Windows.Forms.Label();
            this.lbmanhanvien = new System.Windows.Forms.Label();
            this.lbgioitinh = new System.Windows.Forms.Label();
            this.cbgt = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cbkhoa
            // 
            this.cbkhoa.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.cbkhoa.AllowDrop = true;
            this.cbkhoa.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbkhoa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbkhoa.FormattingEnabled = true;
            this.cbkhoa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbkhoa.ItemHeight = 13;
            this.cbkhoa.Location = new System.Drawing.Point(341, 68);
            this.cbkhoa.Name = "cbkhoa";
            this.cbkhoa.Size = new System.Drawing.Size(174, 21);
            this.cbkhoa.TabIndex = 37;
            // 
            // cbchucvu
            // 
            this.cbchucvu.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.cbchucvu.AllowDrop = true;
            this.cbchucvu.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbchucvu.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbchucvu.FormattingEnabled = true;
            this.cbchucvu.Location = new System.Drawing.Point(341, 23);
            this.cbchucvu.Name = "cbchucvu";
            this.cbchucvu.Size = new System.Drawing.Size(174, 21);
            this.cbchucvu.Sorted = true;
            this.cbchucvu.TabIndex = 36;
            // 
            // txtcmnd
            // 
            this.txtcmnd.Location = new System.Drawing.Point(105, 114);
            this.txtcmnd.Name = "txtcmnd";
            this.txtcmnd.Size = new System.Drawing.Size(149, 20);
            this.txtcmnd.TabIndex = 35;
            // 
            // txttennvsua
            // 
            this.txttennvsua.Location = new System.Drawing.Point(105, 70);
            this.txttennvsua.Name = "txttennvsua";
            this.txttennvsua.Size = new System.Drawing.Size(149, 20);
            this.txttennvsua.TabIndex = 34;
            // 
            // txtmanvsua
            // 
            this.txtmanvsua.Location = new System.Drawing.Point(105, 25);
            this.txtmanvsua.Name = "txtmanvsua";
            this.txtmanvsua.ReadOnly = true;
            this.txtmanvsua.Size = new System.Drawing.Size(149, 20);
            this.txtmanvsua.TabIndex = 33;
            // 
            // btboqua
            // 
            this.btboqua.Location = new System.Drawing.Point(440, 234);
            this.btboqua.Name = "btboqua";
            this.btboqua.Size = new System.Drawing.Size(75, 23);
            this.btboqua.TabIndex = 32;
            this.btboqua.Text = "Bỏ Qua";
            this.btboqua.UseVisualStyleBackColor = true;
            this.btboqua.Click += new System.EventHandler(this.btboqua_Click);
            // 
            // btLuu
            // 
            this.btLuu.Location = new System.Drawing.Point(341, 234);
            this.btLuu.Name = "btLuu";
            this.btLuu.Size = new System.Drawing.Size(75, 23);
            this.btLuu.TabIndex = 31;
            this.btLuu.Text = "Lưu";
            this.btLuu.UseVisualStyleBackColor = true;
            this.btLuu.Click += new System.EventHandler(this.btLuu_Click);
            // 
            // lbNgaySinh
            // 
            this.lbNgaySinh.AutoSize = true;
            this.lbNgaySinh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbNgaySinh.Location = new System.Drawing.Point(262, 116);
            this.lbNgaySinh.Name = "lbNgaySinh";
            this.lbNgaySinh.Size = new System.Drawing.Size(62, 15);
            this.lbNgaySinh.TabIndex = 30;
            this.lbNgaySinh.Text = "Ngày Sinh";
            // 
            // dateTimePickerSuaNV
            // 
            this.dateTimePickerSuaNV.CustomFormat = "";
            this.dateTimePickerSuaNV.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerSuaNV.Location = new System.Drawing.Point(341, 111);
            this.dateTimePickerSuaNV.Name = "dateTimePickerSuaNV";
            this.dateTimePickerSuaNV.Size = new System.Drawing.Size(174, 20);
            this.dateTimePickerSuaNV.TabIndex = 29;
            // 
            // lbCMND
            // 
            this.lbCMND.AutoSize = true;
            this.lbCMND.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbCMND.Location = new System.Drawing.Point(16, 116);
            this.lbCMND.Name = "lbCMND";
            this.lbCMND.Size = new System.Drawing.Size(43, 15);
            this.lbCMND.TabIndex = 28;
            this.lbCMND.Text = "CMND";
            // 
            // lbChucVu
            // 
            this.lbChucVu.AutoSize = true;
            this.lbChucVu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbChucVu.Location = new System.Drawing.Point(262, 27);
            this.lbChucVu.Name = "lbChucVu";
            this.lbChucVu.Size = new System.Drawing.Size(53, 15);
            this.lbChucVu.TabIndex = 27;
            this.lbChucVu.Text = "Chức Vụ";
            // 
            // lbkhoa
            // 
            this.lbkhoa.AutoSize = true;
            this.lbkhoa.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbkhoa.Location = new System.Drawing.Point(262, 70);
            this.lbkhoa.Name = "lbkhoa";
            this.lbkhoa.Size = new System.Drawing.Size(35, 15);
            this.lbkhoa.TabIndex = 26;
            this.lbkhoa.Text = "Khoa";
            // 
            // lbtennv
            // 
            this.lbtennv.AutoSize = true;
            this.lbtennv.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbtennv.Location = new System.Drawing.Point(16, 70);
            this.lbtennv.Name = "lbtennv";
            this.lbtennv.Size = new System.Drawing.Size(87, 15);
            this.lbtennv.TabIndex = 25;
            this.lbtennv.Text = "Tên Nhân Viên";
            // 
            // lbmanhanvien
            // 
            this.lbmanhanvien.AutoSize = true;
            this.lbmanhanvien.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbmanhanvien.Location = new System.Drawing.Point(16, 27);
            this.lbmanhanvien.Name = "lbmanhanvien";
            this.lbmanhanvien.Size = new System.Drawing.Size(84, 15);
            this.lbmanhanvien.TabIndex = 24;
            this.lbmanhanvien.Text = "Mã Nhân Viên";
            // 
            // lbgioitinh
            // 
            this.lbgioitinh.AutoSize = true;
            this.lbgioitinh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbgioitinh.Location = new System.Drawing.Point(16, 159);
            this.lbgioitinh.Name = "lbgioitinh";
            this.lbgioitinh.Size = new System.Drawing.Size(57, 15);
            this.lbgioitinh.TabIndex = 38;
            this.lbgioitinh.Text = "Giới Tính";
            // 
            // cbgt
            // 
            this.cbgt.FormattingEnabled = true;
            this.cbgt.Location = new System.Drawing.Point(105, 152);
            this.cbgt.Name = "cbgt";
            this.cbgt.Size = new System.Drawing.Size(149, 21);
            this.cbgt.TabIndex = 39;
            // 
            // cbgioitinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 282);
            this.Controls.Add(this.cbgt);
            this.Controls.Add(this.lbgioitinh);
            this.Controls.Add(this.cbkhoa);
            this.Controls.Add(this.cbchucvu);
            this.Controls.Add(this.txtcmnd);
            this.Controls.Add(this.txttennvsua);
            this.Controls.Add(this.txtmanvsua);
            this.Controls.Add(this.btboqua);
            this.Controls.Add(this.btLuu);
            this.Controls.Add(this.lbNgaySinh);
            this.Controls.Add(this.dateTimePickerSuaNV);
            this.Controls.Add(this.lbCMND);
            this.Controls.Add(this.lbChucVu);
            this.Controls.Add(this.lbkhoa);
            this.Controls.Add(this.lbtennv);
            this.Controls.Add(this.lbmanhanvien);
            this.Name = "cbgioitinh";
            this.Text = "SuaThongTinNhanVien";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbkhoa;
        private System.Windows.Forms.ComboBox cbchucvu;
        private System.Windows.Forms.TextBox txtcmnd;
        private System.Windows.Forms.TextBox txttennvsua;
        private System.Windows.Forms.TextBox txtmanvsua;
        private System.Windows.Forms.Button btboqua;
        private System.Windows.Forms.Button btLuu;
        private System.Windows.Forms.Label lbNgaySinh;
        private System.Windows.Forms.DateTimePicker dateTimePickerSuaNV;
        private System.Windows.Forms.Label lbCMND;
        private System.Windows.Forms.Label lbChucVu;
        private System.Windows.Forms.Label lbkhoa;
        private System.Windows.Forms.Label lbtennv;
        private System.Windows.Forms.Label lbmanhanvien;
        private System.Windows.Forms.Label lbgioitinh;
        private System.Windows.Forms.ComboBox cbgt;
    }
}