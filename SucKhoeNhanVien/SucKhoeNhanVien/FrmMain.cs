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
    }
}
