namespace SucKhoeNhanVien
{
    partial class FrDSthemHS
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
            this.btthem = new System.Windows.Forms.Button();
            this.lbkhoa = new System.Windows.Forms.Label();
            this.bttim = new System.Windows.Forms.Button();
            this.txtkhoathem = new System.Windows.Forms.TextBox();
            this.txttennvthem = new System.Windows.Forms.TextBox();
            this.txtmanvthem = new System.Windows.Forms.TextBox();
            this.lbtennv = new System.Windows.Forms.Label();
            this.lbmanhanvien = new System.Windows.Forms.Label();
            this.lbDSNV = new System.Windows.Forms.Label();
            this.datagvNhanVienThem = new System.Windows.Forms.DataGridView();
            this.groupqlnv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagvNhanVienThem)).BeginInit();
            this.SuspendLayout();
            // 
            // groupqlnv
            // 
            this.groupqlnv.Controls.Add(this.btthem);
            this.groupqlnv.Controls.Add(this.lbkhoa);
            this.groupqlnv.Controls.Add(this.bttim);
            this.groupqlnv.Controls.Add(this.txtkhoathem);
            this.groupqlnv.Controls.Add(this.txttennvthem);
            this.groupqlnv.Controls.Add(this.txtmanvthem);
            this.groupqlnv.Controls.Add(this.lbtennv);
            this.groupqlnv.Controls.Add(this.lbmanhanvien);
            this.groupqlnv.Location = new System.Drawing.Point(12, 12);
            this.groupqlnv.Name = "groupqlnv";
            this.groupqlnv.Size = new System.Drawing.Size(1302, 93);
            this.groupqlnv.TabIndex = 9;
            this.groupqlnv.TabStop = false;
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
            // bttim
            // 
            this.bttim.Location = new System.Drawing.Point(821, 35);
            this.bttim.Name = "bttim";
            this.bttim.Size = new System.Drawing.Size(75, 23);
            this.bttim.TabIndex = 6;
            this.bttim.Text = "Tìm";
            this.bttim.UseVisualStyleBackColor = true;
            // 
            // txtkhoathem
            // 
            this.txtkhoathem.Location = new System.Drawing.Point(624, 37);
            this.txtkhoathem.Name = "txtkhoathem";
            this.txtkhoathem.Size = new System.Drawing.Size(164, 20);
            this.txtkhoathem.TabIndex = 10;
            // 
            // txttennvthem
            // 
            this.txttennvthem.Location = new System.Drawing.Point(391, 37);
            this.txttennvthem.Name = "txttennvthem";
            this.txttennvthem.Size = new System.Drawing.Size(164, 20);
            this.txttennvthem.TabIndex = 9;
            // 
            // txtmanvthem
            // 
            this.txtmanvthem.Location = new System.Drawing.Point(103, 37);
            this.txtmanvthem.Name = "txtmanvthem";
            this.txtmanvthem.Size = new System.Drawing.Size(164, 20);
            this.txtmanvthem.TabIndex = 8;
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
            this.lbDSNV.Location = new System.Drawing.Point(12, 125);
            this.lbDSNV.Name = "lbDSNV";
            this.lbDSNV.Size = new System.Drawing.Size(176, 21);
            this.lbDSNV.TabIndex = 10;
            this.lbDSNV.Text = "Danh Sách Nhân Viên";
            // 
            // datagvNhanVienThem
            // 
            this.datagvNhanVienThem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.datagvNhanVienThem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagvNhanVienThem.Location = new System.Drawing.Point(12, 165);
            this.datagvNhanVienThem.Name = "datagvNhanVienThem";
            this.datagvNhanVienThem.Size = new System.Drawing.Size(1297, 341);
            this.datagvNhanVienThem.TabIndex = 11;
            // 
            // FrDSthemHS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1326, 528);
            this.Controls.Add(this.datagvNhanVienThem);
            this.Controls.Add(this.lbDSNV);
            this.Controls.Add(this.groupqlnv);
            this.Location = new System.Drawing.Point(0, 97);
            this.MaximumSize = new System.Drawing.Size(1342, 567);
            this.MinimumSize = new System.Drawing.Size(798, 567);
            this.Name = "FrDSthemHS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "FrDSthemHS";
            this.groupqlnv.ResumeLayout(false);
            this.groupqlnv.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagvNhanVienThem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupqlnv;
        private System.Windows.Forms.Button btthem;
        private System.Windows.Forms.Label lbkhoa;
        private System.Windows.Forms.Button bttim;
        private System.Windows.Forms.TextBox txtkhoathem;
        private System.Windows.Forms.TextBox txttennvthem;
        private System.Windows.Forms.TextBox txtmanvthem;
        private System.Windows.Forms.Label lbtennv;
        private System.Windows.Forms.Label lbmanhanvien;
        private System.Windows.Forms.Label lbDSNV;
        private System.Windows.Forms.DataGridView datagvNhanVienThem;
    }
}