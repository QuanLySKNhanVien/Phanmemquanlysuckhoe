namespace SucKhoeNhanVien
{
    partial class QuanLyNhanVien
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuanLyNhanVien));
            this.bttim = new System.Windows.Forms.Button();
            this.groupqlnv = new System.Windows.Forms.GroupBox();
            this.btxoa = new System.Windows.Forms.Button();
            this.btlammoi = new System.Windows.Forms.Button();
            this.btsua = new System.Windows.Forms.Button();
            this.btthem = new System.Windows.Forms.Button();
            this.lbkhoa = new System.Windows.Forms.Label();
            this.txtkhoa = new System.Windows.Forms.TextBox();
            this.txttennv = new System.Windows.Forms.TextBox();
            this.txtmanv = new System.Windows.Forms.TextBox();
            this.lbtennv = new System.Windows.Forms.Label();
            this.lbmanhanvien = new System.Windows.Forms.Label();
            this.lbDSNV = new System.Windows.Forms.Label();
            this.datagvNhanVien = new System.Windows.Forms.DataGridView();
            this.groupqlnv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagvNhanVien)).BeginInit();
            this.SuspendLayout();
            // 
            // bttim
            // 
            this.bttim.Location = new System.Drawing.Point(821, 35);
            this.bttim.Name = "bttim";
            this.bttim.Size = new System.Drawing.Size(75, 23);
            this.bttim.TabIndex = 6;
            this.bttim.Text = "Tìm";
            this.bttim.UseVisualStyleBackColor = true;
            this.bttim.Click += new System.EventHandler(this.bttim_Click);
            // 
            // groupqlnv
            // 
            this.groupqlnv.Controls.Add(this.btxoa);
            this.groupqlnv.Controls.Add(this.btlammoi);
            this.groupqlnv.Controls.Add(this.btsua);
            this.groupqlnv.Controls.Add(this.btthem);
            this.groupqlnv.Controls.Add(this.lbkhoa);
            this.groupqlnv.Controls.Add(this.bttim);
            this.groupqlnv.Controls.Add(this.txtkhoa);
            this.groupqlnv.Controls.Add(this.txttennv);
            this.groupqlnv.Controls.Add(this.txtmanv);
            this.groupqlnv.Controls.Add(this.lbtennv);
            this.groupqlnv.Controls.Add(this.lbmanhanvien);
            this.groupqlnv.Location = new System.Drawing.Point(12, 14);
            this.groupqlnv.Name = "groupqlnv";
            this.groupqlnv.Size = new System.Drawing.Size(1302, 93);
            this.groupqlnv.TabIndex = 7;
            this.groupqlnv.TabStop = false;
            // 
            // btxoa
            // 
            this.btxoa.Location = new System.Drawing.Point(1211, 35);
            this.btxoa.Name = "btxoa";
            this.btxoa.Size = new System.Drawing.Size(75, 23);
            this.btxoa.TabIndex = 15;
            this.btxoa.Text = "Xóa";
            this.btxoa.UseVisualStyleBackColor = true;
            this.btxoa.Click += new System.EventHandler(this.btxoa_Click);
            // 
            // btlammoi
            // 
            this.btlammoi.Location = new System.Drawing.Point(1113, 35);
            this.btlammoi.Name = "btlammoi";
            this.btlammoi.Size = new System.Drawing.Size(75, 23);
            this.btlammoi.TabIndex = 14;
            this.btlammoi.Text = "Làm Mới";
            this.btlammoi.UseVisualStyleBackColor = true;
            this.btlammoi.Click += new System.EventHandler(this.btlammoi_Click);
            // 
            // btsua
            // 
            this.btsua.Location = new System.Drawing.Point(1015, 35);
            this.btsua.Name = "btsua";
            this.btsua.Size = new System.Drawing.Size(75, 23);
            this.btsua.TabIndex = 13;
            this.btsua.Text = "Sửa";
            this.btsua.UseVisualStyleBackColor = true;
            this.btsua.Click += new System.EventHandler(this.btsua_Click);
            // 
            // btthem
            // 
            this.btthem.Location = new System.Drawing.Point(916, 35);
            this.btthem.Name = "btthem";
            this.btthem.Size = new System.Drawing.Size(75, 23);
            this.btthem.TabIndex = 12;
            this.btthem.Text = "Thêm";
            this.btthem.UseVisualStyleBackColor = true;
            this.btthem.Click += new System.EventHandler(this.btthem_Click);
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
            this.lbDSNV.Location = new System.Drawing.Point(13, 133);
            this.lbDSNV.Name = "lbDSNV";
            this.lbDSNV.Size = new System.Drawing.Size(176, 21);
            this.lbDSNV.TabIndex = 8;
            this.lbDSNV.Text = "Danh Sách Nhân Viên";
            // 
            // datagvNhanVien
            // 
            this.datagvNhanVien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.datagvNhanVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagvNhanVien.Location = new System.Drawing.Point(17, 175);
            this.datagvNhanVien.Name = "datagvNhanVien";
            this.datagvNhanVien.Size = new System.Drawing.Size(1297, 341);
            this.datagvNhanVien.TabIndex = 9;
            // 
            // QuanLyNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1326, 528);
            this.Controls.Add(this.datagvNhanVien);
            this.Controls.Add(this.lbDSNV);
            this.Controls.Add(this.groupqlnv);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(0, 97);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1342, 567);
            this.MinimumSize = new System.Drawing.Size(798, 567);
            this.Name = "QuanLyNhanVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "QuanLyNhanVien";
            this.Load += new System.EventHandler(this.QuanLyNhanVien_Load);
            this.groupqlnv.ResumeLayout(false);
            this.groupqlnv.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagvNhanVien)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bttim;
        private System.Windows.Forms.GroupBox groupqlnv;
        private System.Windows.Forms.Button btsua;
        private System.Windows.Forms.Button btthem;
        private System.Windows.Forms.Label lbkhoa;
        private System.Windows.Forms.TextBox txtkhoa;
        private System.Windows.Forms.TextBox txttennv;
        private System.Windows.Forms.TextBox txtmanv;
        private System.Windows.Forms.Label lbtennv;
        private System.Windows.Forms.Label lbmanhanvien;
        private System.Windows.Forms.Label lbDSNV;
        private System.Windows.Forms.DataGridView datagvNhanVien;
        private System.Windows.Forms.Button btlammoi;
        private System.Windows.Forms.Button btxoa;
    }
}