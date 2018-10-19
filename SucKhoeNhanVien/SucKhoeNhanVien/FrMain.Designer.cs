namespace SucKhoeNhanVien
{
    partial class FrMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrMain));
            this.bt_NhanVien = new System.Windows.Forms.Button();
            this.btqlsk = new System.Windows.Forms.Button();
            this.btthemhssk = new System.Windows.Forms.Button();
            this.bt_nghiencuu = new System.Windows.Forms.Button();
            this.bt_csht = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // bt_NhanVien
            // 
            this.bt_NhanVien.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.bt_NhanVien.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.bt_NhanVien.Image = ((System.Drawing.Image)(resources.GetObject("bt_NhanVien.Image")));
            this.bt_NhanVien.Location = new System.Drawing.Point(6, 14);
            this.bt_NhanVien.Name = "bt_NhanVien";
            this.bt_NhanVien.Size = new System.Drawing.Size(119, 83);
            this.bt_NhanVien.TabIndex = 0;
            this.bt_NhanVien.Text = "Quản Lý Nhân Viên";
            this.bt_NhanVien.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bt_NhanVien.UseVisualStyleBackColor = false;
            this.bt_NhanVien.Click += new System.EventHandler(this.bt_NhanVien_Click);
            // 
            // btqlsk
            // 
            this.btqlsk.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btqlsk.Image = ((System.Drawing.Image)(resources.GetObject("btqlsk.Image")));
            this.btqlsk.Location = new System.Drawing.Point(132, 16);
            this.btqlsk.Margin = new System.Windows.Forms.Padding(4);
            this.btqlsk.Name = "btqlsk";
            this.btqlsk.Size = new System.Drawing.Size(129, 80);
            this.btqlsk.TabIndex = 1;
            this.btqlsk.Text = "Quản Lý HS Sức Khỏe";
            this.btqlsk.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btqlsk.UseVisualStyleBackColor = false;
            this.btqlsk.Click += new System.EventHandler(this.btqlsk_Click);
            // 
            // btthemhssk
            // 
            this.btthemhssk.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btthemhssk.Image = ((System.Drawing.Image)(resources.GetObject("btthemhssk.Image")));
            this.btthemhssk.Location = new System.Drawing.Point(269, 16);
            this.btthemhssk.Margin = new System.Windows.Forms.Padding(4);
            this.btthemhssk.Name = "btthemhssk";
            this.btthemhssk.Size = new System.Drawing.Size(129, 80);
            this.btthemhssk.TabIndex = 2;
            this.btthemhssk.Text = "Thêm HSSK Nhân Viên";
            this.btthemhssk.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btthemhssk.UseVisualStyleBackColor = false;
            this.btthemhssk.Click += new System.EventHandler(this.btthemhssk_Click);
            // 
            // bt_nghiencuu
            // 
            this.bt_nghiencuu.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.bt_nghiencuu.Image = ((System.Drawing.Image)(resources.GetObject("bt_nghiencuu.Image")));
            this.bt_nghiencuu.Location = new System.Drawing.Point(7, 14);
            this.bt_nghiencuu.Margin = new System.Windows.Forms.Padding(4);
            this.bt_nghiencuu.Name = "bt_nghiencuu";
            this.bt_nghiencuu.Size = new System.Drawing.Size(129, 80);
            this.bt_nghiencuu.TabIndex = 3;
            this.bt_nghiencuu.Text = "Quản Lý Nghiên Cứu";
            this.bt_nghiencuu.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bt_nghiencuu.UseVisualStyleBackColor = false;
            this.bt_nghiencuu.Click += new System.EventHandler(this.bt_nghiencuu_Click);
            // 
            // bt_csht
            // 
            this.bt_csht.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.bt_csht.Image = ((System.Drawing.Image)(resources.GetObject("bt_csht.Image")));
            this.bt_csht.Location = new System.Drawing.Point(16, 16);
            this.bt_csht.Margin = new System.Windows.Forms.Padding(4);
            this.bt_csht.Name = "bt_csht";
            this.bt_csht.Size = new System.Drawing.Size(135, 80);
            this.bt_csht.TabIndex = 4;
            this.bt_csht.Text = "Quản Lý Cơ Sở Hạ Tầng";
            this.bt_csht.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bt_csht.UseVisualStyleBackColor = false;
            this.bt_csht.Click += new System.EventHandler(this.bt_csht_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.bt_csht);
            this.groupBox1.Location = new System.Drawing.Point(405, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(325, 103);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Quản Lý Cơ Sở Hạ Tầng";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btthemhssk);
            this.groupBox2.Controls.Add(this.btqlsk);
            this.groupBox2.Controls.Add(this.bt_NhanVien);
            this.groupBox2.Location = new System.Drawing.Point(0, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(406, 103);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Quản Lý Sức Khỏe Nhân Viên ";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(159, 15);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(159, 81);
            this.button1.TabIndex = 5;
            this.button1.Text = "Quản Lý Hệ Thống Nước Thải";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.bt_nghiencuu);
            this.groupBox3.Location = new System.Drawing.Point(730, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(613, 103);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Quản Lý Nghiên Cứu";
            // 
            // FrMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1344, 687);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MaximumSize = new System.Drawing.Size(1360, 726);
            this.MinimumSize = new System.Drawing.Size(1297, 726);
            this.Name = "FrMain";
            this.Text = "QuanLySucKhoe";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button bt_NhanVien;
        private System.Windows.Forms.Button btqlsk;
        private System.Windows.Forms.Button btthemhssk;
        private System.Windows.Forms.Button bt_nghiencuu;
        private System.Windows.Forms.Button bt_csht;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}