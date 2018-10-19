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
    public partial class FrThemNV : Form
    {
        public FrThemNV()
        {
            InitializeComponent();
            loadcbchucvu();
            loadcbkhoa();
            loadcbgioitinh();
        }
        // Kết nối cơ sở dữ liệu
        public void ketnoi()
        {
            try
            {
                SqlConnection kn = new SqlConnection(@"Data Source=DESKTOP-RGHAECC;Initial Catalog=SucKhoeNhanVien_PNT;Integrated Security=True");
                kn.Open();
                string sql = "Insert into NhanVien ";
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
        public void loadcbchucvu()
        {
            SqlConnection kn = new SqlConnection(@"Data Source=DESKTOP-RGHAECC;Initial Catalog=SucKhoeNhanVien_PNT;Integrated Security=True");
            kn.Open();
            string sql = "Select IdChucVu,TenChucVu from ChucVu ";
            SqlCommand commandsql = new SqlCommand(sql, kn);//thực thi các chức năng câu lệnh trong sql 
            SqlDataAdapter com = new SqlDataAdapter(commandsql);// vận chuyển dữ liệu
            DataTable dt = new DataTable();
            com.Fill(dt);
            cbchucvu.DisplayMember = "TenChucVu";
            cbchucvu.ValueMember = "IdChucVu";
            cbchucvu.DataSource = (dt);
            cbchucvu.DropDownHeight = cbkhoa.Font.Height * 5;// giới hạn cbbox
        }
        public void loadcbkhoa()
        {
            SqlConnection kn = new SqlConnection(@"Data Source=DESKTOP-RGHAECC;Initial Catalog=SucKhoeNhanVien_PNT;Integrated Security=True");
            kn.Open();
            string sql = "Select IdKhoa,TenKhoa from Khoa ";
            SqlCommand commandsql = new SqlCommand(sql, kn);//thực thi các chức năng câu lệnh trong sql 
            SqlDataAdapter com = new SqlDataAdapter(commandsql);// vận chuyển dữ liệu
            DataTable dt = new DataTable();
            com.Fill(dt);
            cbkhoa.DisplayMember = "TenKhoa";
            cbkhoa.ValueMember = "IdKhoa";
            cbkhoa.DataSource = (dt);
            cbkhoa.DropDownHeight = cbkhoa.Font.Height * 5;
        }
        public void loadcbgioitinh()
        {
            SqlConnection kn = new SqlConnection(@"Data Source=DESKTOP-RGHAECC;Initial Catalog=SucKhoeNhanVien_PNT;Integrated Security=True");
            kn.Open();
            string sql = "Select IdGioiTinh,TenGT from GioiTinh ";
            SqlCommand commandsql = new SqlCommand(sql, kn);//thực thi các chức năng câu lệnh trong sql 
            SqlDataAdapter com = new SqlDataAdapter(commandsql);// vận chuyển dữ liệu
            DataTable dt = new DataTable();
            com.Fill(dt);
            cbgioitinh.DisplayMember = "TenGT";
            cbgioitinh.ValueMember = "IdGioiTinh";
            cbgioitinh.DataSource = (dt);
            cbgioitinh.DropDownHeight = cbgioitinh.Font.Height * 5;
        }

        // hàm kiểm tra mã nhân viên đã tồn tại

        private void btLuu_Click(object sender, EventArgs e)
        {
            SqlConnection kn = new SqlConnection(@"Data Source=DESKTOP-RGHAECC;Initial Catalog=SucKhoeNhanVien_PNT;Integrated Security=True");
            kn.Open();
            string sql = "SELECT COUNT(*) FROM NhanVien WHERE(MaNV = @user)";
            SqlCommand check_MaNV = new SqlCommand(sql, kn);//thực thi các chức năng câu lệnh trong sql 
            SqlDataAdapter com = new SqlDataAdapter(check_MaNV);// vận chuyển dữ liệu
            check_MaNV.Parameters.AddWithValue("@user", txtmanvthem.Text);
            int UserExist = (int)check_MaNV.ExecuteScalar();
            if (UserExist > 0)
            {
                MessageBox.Show(" Mã Nhân Viên đã tồn tại");
            }
            if(txtmanvthem.Text == "")
            {
                MessageBox.Show(" Bạn chưa nhập mã nhân viên");
            }
            if (txttennvthem.Text == "")
            {
                MessageBox.Show(" Bạn chưa nhập tên nhân viên");
            }

            else
            {
                
                string themnv = "Insert into NhanVien VALUES (@MaNV,@TenNV,@Khoa,@NgaySinh,@CMND,@IdChucVu,@IdGioiTinh)";
                SqlCommand commandsql = new SqlCommand(themnv, kn);//thực thi các chức năng câu lệnh trong sql 
                SqlDataAdapter comthem = new SqlDataAdapter(commandsql);// vận chuyển dữ liệu
                commandsql.Parameters.AddWithValue("@MaNV", txtmanvthem.Text); //Tried Parse and Convert.
                commandsql.Parameters.AddWithValue("@TenNV", txttennvthem.Text);
                commandsql.Parameters.AddWithValue("@Khoa", cbkhoa.SelectedValue.ToString());
                commandsql.Parameters.AddWithValue("@NgaySinh", dateTimePickerNV.Value.Date);
                commandsql.Parameters.AddWithValue("@CMND", txtcmnd.Text);
                commandsql.Parameters.AddWithValue("@IdChucVu", cbchucvu.SelectedValue.ToString());
                commandsql.Parameters.AddWithValue("@IdGioiTinh", cbgioitinh.SelectedValue.ToString());
                commandsql.ExecuteNonQuery();
                this.Close();
                MessageBox.Show("Lưu thành công");
            }
        }

        private void btboqua_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
        
}
