using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SucKhoeNhanVien
{
    public partial class FrMain : Form
    {
        public FrMain()
        {
            InitializeComponent();
        }
        //Kiểm tra xem Form con tồn tại chưa
        private bool CheckExistForm(string name)
        {
            bool check = false;
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == name)
                {
                    check = true;
                    break;
                }
            }
            return check;
        }
        //Khởi động form con nếu chưa tồn tại và load lại form con nếu đã tồn tại
        private void ActiveChildForm(string name)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == name)
                {
                    frm.Activate();
                    break;
                }
            }
        }
        //Khởi động form them nhan vien
        private void bt_NhanVien_Click(object sender, EventArgs e)
        {
            if (!CheckExistForm("Fr_ThemNhanVien"))
            {
                QuanLyNhanVien frnhanvien = new QuanLyNhanVien();
                frnhanvien.MdiParent = this;
                frnhanvien.Show();
                //pnbackground.Visible = false;
 
              
            }
            else
                ActiveChildForm("Fr_ThemNhanVien");
        }

        private void btqlsk_Click(object sender, EventArgs e)
        {
            if (!CheckExistForm("Fr_QuanLyHoSo"))
            {
                Fr_QuanLyHoSo frhoso = new Fr_QuanLyHoSo();
                frhoso.MdiParent = this;
                frhoso.Show();
            }
        }

        private void btthemhssk_Click(object sender, EventArgs e)
        {
            //Kiểm tra form đã tồn tại chưa
            if (!CheckExistForm("FrDSthemHS"))
            {
                FrDSthemHS frhoso = new FrDSthemHS();
                frhoso.MdiParent = this;
                frhoso.Show();
            }
        }

        private void bt_nghiencuu_Click(object sender, EventArgs e)
        {
            //Kiểm tra form đã tồn tại chưa
            if (!CheckExistForm("Fr_QuanLyNghienCuu"))
            {
                Fr_QuanLyNghienCuu frnghiencuu = new Fr_QuanLyNghienCuu();
                frnghiencuu.MdiParent = this;
                frnghiencuu.Show();
            }
        }

        private void bt_bacocao_Click(object sender, EventArgs e)
        {
            //Kiểm tra form đã tồn tại chưa

        }

        private void bt_csht_Click(object sender, EventArgs e)
        {
            //Kiểm tra form đã tồn tại chưa
            if (!CheckExistForm("Fr_QuanLyCoSoHaTang"))
            {
                Fr_QuanLyCoSoHaTang frcsht = new Fr_QuanLyCoSoHaTang();
                frcsht.MdiParent = this;
                frcsht.Show();
            }
        }
    }
}
