using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SucKhoeNhanVien
{
    public partial class ThemCoSoHaTang : Form
    {
        public ThemCoSoHaTang()
        {
            InitializeComponent();
            loadcbbiensoxe();
        }
        // Kết nối cơ sở dữ liệu
        public void ketnoi()
        {
            try
            {
                SqlConnection kn = new SqlConnection(@"Data Source=DESKTOP-RGHAECC;Initial Catalog=SucKhoeNhanVien_PNT;Integrated Security=True");
                kn.Open();
                string sql = "Insert into QuanLyXe_TaiXe ";
                SqlCommand commandsql = new SqlCommand(sql, kn);//thực thi các chức năng câu lệnh trong sql 
                SqlDataAdapter com = new SqlDataAdapter(commandsql);// vận chuyển dữ liệu

            }
            catch
            {
                MessageBox.Show("Lỗi kết nối vui lòng kiểm tra lại");
            }
            finally
            {
                SqlConnection kn = new SqlConnection(@"Data Source=DESKTOP-RGHAECC;Initial Catalog=SucKhoeNhanVien_PNT;Integrated Security=True");
                kn.Close();
            }
        }
        public void loadcbbiensoxe()
        {
            SqlConnection kn = new SqlConnection(@"Data Source=DESKTOP-RGHAECC;Initial Catalog=SucKhoeNhanVien_PNT;Integrated Security=True");
            kn.Open();
            string sql = "Select ID_Xe,BienSoXe from XeCuuThuong ";
            SqlCommand commandsql = new SqlCommand(sql, kn);//thực thi các chức năng câu lệnh trong sql 
            SqlDataAdapter com = new SqlDataAdapter(commandsql);// vận chuyển dữ liệu
            DataTable dt = new DataTable();
            com.Fill(dt);
            cbbiensoxe.DisplayMember = "BienSoXe";
            cbbiensoxe.ValueMember = "ID_Xe";
            cbbiensoxe.DataSource = (dt);
            cbbiensoxe.DropDownHeight = cbbiensoxe.Font.Height * 5;// giới hạn cbbox
        }
        // hàm kiểm tra mã nhân viên đã tồn tại

    
        private void btboqua_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btLuu_Click_1(object sender, EventArgs e)
        {
            SqlConnection kn = new SqlConnection(@"Data Source=DESKTOP-RGHAECC;Initial Catalog=SucKhoeNhanVien_PNT;Integrated Security=True");
            kn.Open();
            if (txttennvthem.Text == "")
            {
                MessageBox.Show(" Bạn chưa nhập ten nhân viên");
            }
            else
            {

                string themqlx = "Insert into QuanLyXe_TaiXe VALUES (@Id_Xe,@TenNV,@NgayNhan,@NgayTra,@TrangThaiNhan,@TrangThaiGiao)";
                SqlCommand commandsql = new SqlCommand(themqlx, kn);//thực thi các chức năng câu lệnh trong sql 
                SqlDataAdapter comthem = new SqlDataAdapter(commandsql);// vận chuyển dữ liệu
                commandsql.Parameters.AddWithValue("@Id_Xe", cbbiensoxe.SelectedValue.ToString()); //Tried Parse and Convert.
                commandsql.Parameters.AddWithValue("@TenNV", txttennvthem.Text);
                commandsql.Parameters.AddWithValue("@NgayNhan", datetimengaynhan.Value.Date);
                commandsql.Parameters.AddWithValue("@NgayTra", datetimengaygiao.Value.Date);
                commandsql.Parameters.AddWithValue("@TrangThaiNhan", txttrangthainhan.Text);
                commandsql.Parameters.AddWithValue("@TrangThaiGiao", txttrangthaigiao.Text);
                commandsql.ExecuteNonQuery();
                this.Close();
                MessageBox.Show("Lưu thành công");
            }
        }
    }
}
