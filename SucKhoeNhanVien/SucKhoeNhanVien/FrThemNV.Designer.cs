namespace SucKhoeNhanVien
{
    partial class FrThemNV
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
            this.lbmanhanvien = new System.Windows.Forms.Label();
            this.lbtennv = new System.Windows.Forms.Label();
            this.lbkhoa = new System.Windows.Forms.Label();
            this.lbChucVu = new System.Windows.Forms.Label();
            this.lbCMND = new System.Windows.Forms.Label();
            this.dateTimePickerNV = new System.Windows.Forms.DateTimePicker();
            this.lbNgaySinh = new System.Windows.Forms.Label();
            this.btLuu = new System.Windows.Forms.Button();
            this.btboqua = new System.Windows.Forms.Button();
            this.txtmanvthem = new System.Windows.Forms.TextBox();
            this.txttennvthem = new System.Windows.Forms.TextBox();
            this.txtcmnd = new System.Windows.Forms.TextBox();
            this.cbchucvu = new System.Windows.Forms.ComboBox();
            this.cbkhoa = new System.Windows.Forms.ComboBox();
            this.cbgioitinh = new System.Windows.Forms.ComboBox();
            this.lbgioitinh = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbmanhanvien
            // 
            this.lbmanhanvien.AutoSize = true;
            this.lbmanhanvien.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbmanhanvien.Location = new System.Drawing.Point(12, 18);
            this.lbmanhanvien.Name = "lbmanhanvien";
            this.lbmanhanvien.Size = new System.Drawing.Size(84, 15);
            this.lbmanhanvien.TabIndex = 7;
            this.lbmanhanvien.Text = "Mã Nhân Viên";
            // 
            // lbtennv
            // 
            this.lbtennv.AutoSize = true;
            this.lbtennv.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbtennv.Location = new System.Drawing.Point(12, 61);
            this.lbtennv.Name = "lbtennv";
            this.lbtennv.Size = new System.Drawing.Size(87, 15);
            this.lbtennv.TabIndex = 8;
            this.lbtennv.Text = "Tên Nhân Viên";
            // 
            // lbkhoa
            // 
            this.lbkhoa.AutoSize = true;
            this.lbkhoa.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbkhoa.Location = new System.Drawing.Point(258, 61);
            this.lbkhoa.Name = "lbkhoa";
            this.lbkhoa.Size = new System.Drawing.Size(35, 15);
            this.lbkhoa.TabIndex = 12;
            this.lbkhoa.Text = "Khoa";
            // 
            // lbChucVu
            // 
            this.lbChucVu.AutoSize = true;
            this.lbChucVu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbChucVu.Location = new System.Drawing.Point(258, 18);
            this.lbChucVu.Name = "lbChucVu";
            this.lbChucVu.Size = new System.Drawing.Size(53, 15);
            this.lbChucVu.TabIndex = 13;
            this.lbChucVu.Text = "Chức Vụ";
            // 
            // lbCMND
            // 
            this.lbCMND.AutoSize = true;
            this.lbCMND.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbCMND.Location = new System.Drawing.Point(12, 107);
            this.lbCMND.Name = "lbCMND";
            this.lbCMND.Size = new System.Drawing.Size(43, 15);
            this.lbCMND.TabIndex = 14;
            this.lbCMND.Text = "CMND";
            // 
            // dateTimePickerNV
            // 
            this.dateTimePickerNV.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerNV.Location = new System.Drawing.Point(337, 102);
            this.dateTimePickerNV.Name = "dateTimePickerNV";
            this.dateTimePickerNV.Size = new System.Drawing.Size(174, 20);
            this.dateTimePickerNV.TabIndex = 15;
            // 
            // lbNgaySinh
            // 
            this.lbNgaySinh.AutoSize = true;
            this.lbNgaySinh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbNgaySinh.Location = new System.Drawing.Point(258, 107);
            this.lbNgaySinh.Name = "lbNgaySinh";
            this.lbNgaySinh.Size = new System.Drawing.Size(62, 15);
            this.lbNgaySinh.TabIndex = 16;
            this.lbNgaySinh.Text = "Ngày Sinh";
            // 
            // btLuu
            // 
            this.btLuu.Location = new System.Drawing.Point(336, 213);
            this.btLuu.Name = "btLuu";
            this.btLuu.Size = new System.Drawing.Size(75, 23);
            this.btLuu.TabIndex = 17;
            this.btLuu.Text = "Lưu";
            this.btLuu.UseVisualStyleBackColor = true;
            this.btLuu.Click += new System.EventHandler(this.btLuu_Click);
            // 
            // btboqua
            // 
            this.btboqua.Location = new System.Drawing.Point(436, 213);
            this.btboqua.Name = "btboqua";
            this.btboqua.Size = new System.Drawing.Size(75, 23);
            this.btboqua.TabIndex = 18;
            this.btboqua.Text = "Bỏ Qua";
            this.btboqua.UseVisualStyleBackColor = true;
            this.btboqua.Click += new System.EventHandler(this.btboqua_Click);
            // 
            // txtmanvthem
            // 
            this.txtmanvthem.Location = new System.Drawing.Point(101, 16);
            this.txtmanvthem.Name = "txtmanvthem";
            this.txtmanvthem.Size = new System.Drawing.Size(149, 20);
            this.txtmanvthem.TabIndex = 19;
            // 
            // txttennvthem
            // 
            this.txttennvthem.Location = new System.Drawing.Point(101, 61);
            this.txttennvthem.Name = "txttennvthem";
            this.txttennvthem.Size = new System.Drawing.Size(149, 20);
            this.txttennvthem.TabIndex = 20;
            // 
            // txtcmnd
            // 
            this.txtcmnd.Location = new System.Drawing.Point(101, 105);
            this.txtcmnd.Name = "txtcmnd";
            this.txtcmnd.Size = new System.Drawing.Size(149, 20);
            this.txtcmnd.TabIndex = 21;
            // 
            // cbchucvu
            // 
            this.cbchucvu.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.cbchucvu.AllowDrop = true;
            this.cbchucvu.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbchucvu.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbchucvu.FormattingEnabled = true;
            this.cbchucvu.Location = new System.Drawing.Point(337, 14);
            this.cbchucvu.Name = "cbchucvu";
            this.cbchucvu.Size = new System.Drawing.Size(174, 21);
            this.cbchucvu.Sorted = true;
            this.cbchucvu.TabIndex = 22;
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
            this.cbkhoa.Location = new System.Drawing.Point(337, 59);
            this.cbkhoa.Name = "cbkhoa";
            this.cbkhoa.Size = new System.Drawing.Size(174, 21);
            this.cbkhoa.TabIndex = 23;
            // 
            // cbgioitinh
            // 
            this.cbgioitinh.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.cbgioitinh.AllowDrop = true;
            this.cbgioitinh.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbgioitinh.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbgioitinh.FormattingEnabled = true;
            this.cbgioitinh.Location = new System.Drawing.Point(101, 145);
            this.cbgioitinh.Name = "cbgioitinh";
            this.cbgioitinh.Size = new System.Drawing.Size(149, 21);
            this.cbgioitinh.Sorted = true;
            this.cbgioitinh.TabIndex = 41;
            // 
            // lbgioitinh
            // 
            this.lbgioitinh.AutoSize = true;
            this.lbgioitinh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbgioitinh.Location = new System.Drawing.Point(12, 147);
            this.lbgioitinh.Name = "lbgioitinh";
            this.lbgioitinh.Size = new System.Drawing.Size(57, 15);
            this.lbgioitinh.TabIndex = 40;
            this.lbgioitinh.Text = "Giới Tính";
            // 
            // FrThemNV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 261);
            this.Controls.Add(this.cbgioitinh);
            this.Controls.Add(this.lbgioitinh);
            this.Controls.Add(this.cbkhoa);
            this.Controls.Add(this.cbchucvu);
            this.Controls.Add(this.txtcmnd);
            this.Controls.Add(this.txttennvthem);
            this.Controls.Add(this.txtmanvthem);
            this.Controls.Add(this.btboqua);
            this.Controls.Add(this.btLuu);
            this.Controls.Add(this.lbNgaySinh);
            this.Controls.Add(this.dateTimePickerNV);
            this.Controls.Add(this.lbCMND);
            this.Controls.Add(this.lbChucVu);
            this.Controls.Add(this.lbkhoa);
            this.Controls.Add(this.lbtennv);
            this.Controls.Add(this.lbmanhanvien);
            this.Name = "FrThemNV";
            this.Text = "ThemNV";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbmanhanvien;
        private System.Windows.Forms.Label lbtennv;
        private System.Windows.Forms.Label lbkhoa;
        private System.Windows.Forms.Label lbChucVu;
        private System.Windows.Forms.Label lbCMND;
        private System.Windows.Forms.DateTimePicker dateTimePickerNV;
        private System.Windows.Forms.Label lbNgaySinh;
        private System.Windows.Forms.Button btLuu;
        private System.Windows.Forms.Button btboqua;
        private System.Windows.Forms.TextBox txtmanvthem;
        private System.Windows.Forms.TextBox txttennvthem;
        private System.Windows.Forms.TextBox txtcmnd;
        private System.Windows.Forms.ComboBox cbchucvu;
        private System.Windows.Forms.ComboBox cbkhoa;
        private System.Windows.Forms.ComboBox cbgioitinh;
        private System.Windows.Forms.Label lbgioitinh;
    }
}