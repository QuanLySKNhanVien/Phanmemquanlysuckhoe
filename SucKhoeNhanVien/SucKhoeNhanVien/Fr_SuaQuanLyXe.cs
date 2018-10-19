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
using System.Collections;

namespace SucKhoeNhanVien
{
    public partial class Fr_SuaQuanLyXe : Form
    {
        SqlConnection kn = new SqlConnection(@"Data Source=DESKTOP-RGHAECC;Initial Catalog=SucKhoeNhanVien_PNT;Integrated Security=True");
        public Fr_SuaQuanLyXe(string value)
        {
            InitializeComponent();
            txtidQLX.Text = value;
            loaddl();
        }
        public class BienSoXe
        {
            public string bienso { get; set; }
            public int ID_Xe { get; set; }
        }
        public void loaddl()
        {
            kn.Open();
            string sql = "SELECT * from XeCuuThuong,QuanLyXe_TaiXe where XeCuuThuong.ID_Xe = QuanLyXe_TaiXe.Id_Xe And QuanLyXe_TaiXe.Id_LichSuLaiXe like N'" + txtidQLX.Text + "' ";
            string loadxe = "Select ID_Xe,BienSoXe from XeCuuThuong ";
            // Lấy dữ liệu hành chính
            SqlCommand commandsql = new SqlCommand(sql, kn);//thực thi các chức năng câu lệnh trong sql 
            SqlDataAdapter com = new SqlDataAdapter(commandsql);// vận chuyển dữ liệu
            DataTable table = new DataTable();//tạo một bảng ảo trong hện thống
            SqlCommand commandxe = new SqlCommand(loadxe, kn);//thực thi các chức năng câu lệnh trong sql 
            SqlDataAdapter comxe = new SqlDataAdapter(commandxe);// vận chuyển dữ liệu
            DataTable tablexe = new DataTable();//tạo một bảng ảo trong hện thống
            comxe.Fill(tablexe);
            com.Fill(table);// đổ dữ liệu vào bảng ảo
            int idqlxe = (int)table.Rows[0].ItemArray[0];
            txtidQLX.Text = idqlxe.ToString();
            txttennvthem.Text = (string)table.Rows[0]["TenNV"];
            txttrangthaigiao.Text = (string)table.Rows[0]["TrangThaiGiao"];
            txttrangthainhan.Text = (string)table.Rows[0]["TrangThaiNhan"];
            txtbienso.Text = (string)table.Rows[0]["BienSoXe"];
            // hiển thị ngày tháng năm sinh
            var dategiao = (DateTime)table.Rows[0].ItemArray[6];
            datetimengaygiao.Value = dategiao;
            var datenhan = (DateTime)table.Rows[0].ItemArray[7];
            datetimengaynhan.Value = datenhan;
            //dateTimePickerSuaNV.Value = date; //gán ngày tháng.
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            SqlConnection kn = new SqlConnection(@"Data Source=DESKTOP-RGHAECC;Initial Catalog=SucKhoeNhanVien_PNT;Integrated Security=True");
            kn.Open();
            if (txttennvthem.Text == "")
            {
                MessageBox.Show(" Bạn chưa nhập tên nhân viên");
            }
            else
            {
                string suaxe = "Update NhanVien Set Id_Xe = @Id_Xe ,TenNV = @TenNV,NgayNhan = @NgayNhan,NgayTra = @NgayTra,TrangThaiNhan = @TrangThaiNhan,TrangThaiGiao = @TrangThaiGiao where QuanLyXe_TaiXe.Id_LichSuLaiXe like N'" + txtidQLX.Text + "'  ";
                SqlCommand commandsua = new SqlCommand(suaxe, kn);//thực thi các chức năng câu lệnh trong sql 
                SqlDataAdapter comsua = new SqlDataAdapter(commandsua);// vận chuyển dữ liệu
                                                                       //Tried Parse and Convert.
                commandsua.Parameters.AddWithValue(" @Id_Xe", txtbienso.Text);
                commandsua.Parameters.AddWithValue("@TenNV", txttennvthem.Text);
                commandsua.Parameters.AddWithValue("@NgayNhan", datetimengaynhan.Value.Date);
                commandsua.Parameters.AddWithValue("@NgayTra", datetimengaygiao.Value.Date);
                commandsua.Parameters.AddWithValue("@TrangThaiNhan", txttrangthainhan.Text);
                commandsua.Parameters.AddWithValue("@TrangThaiGiao", txttrangthaigiao.Text);
                //int cbchoice = Convert.ToInt32(cbgt.SelectedValue.ToString());
                //commandsua.Parameters.AddWithValue("@Idgt", cbchoice);
                commandsua.ExecuteNonQuery();
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
