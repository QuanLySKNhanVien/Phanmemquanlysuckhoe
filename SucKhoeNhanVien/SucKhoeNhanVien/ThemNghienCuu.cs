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
    public partial class ThemNghienCuu : Form
    {
        public ThemNghienCuu()
        {
            InitializeComponent();
        }

        private void ThemNghienCuu_Load(object sender, EventArgs e)
        {
            ketnoi();
            loadcbCNC();
            loadcbTTNC();
        }
        // ket noi 
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
        public void loadcbCNC()
        {
            SqlConnection kn = new SqlConnection(@"Data Source=DESKTOP-RGHAECC;Initial Catalog=SucKhoeNhanVien_PNT;Integrated Security=True");
            kn.Open();
            string sql = "Select Id_CapNghienCuu,CapNghienCuu from CapNghienCuu ";
            SqlCommand commandsql = new SqlCommand(sql, kn);//thực thi các chức năng câu lệnh trong sql 
            SqlDataAdapter com = new SqlDataAdapter(commandsql);// vận chuyển dữ liệu
            DataTable dt = new DataTable();
            com.Fill(dt);
            cbCNC.DisplayMember = "CapNghienCuu";
            cbCNC.ValueMember = "Id_CapNghienCuu";
            cbCNC.DataSource = (dt);
            cbCNC.DropDownHeight = cbCNC.Font.Height * 5;// giới hạn cbbox
        }
        public void loadcbTTNC()
        {
            SqlConnection kn = new SqlConnection(@"Data Source=DESKTOP-RGHAECC;Initial Catalog=SucKhoeNhanVien_PNT;Integrated Security=True");
            kn.Open();
            string sql = "Select Id_TrangThai,TenTrangThai from TrangThaiNghienCuu ";
            SqlCommand commandsql = new SqlCommand(sql, kn);//thực thi các chức năng câu lệnh trong sql 
            SqlDataAdapter com = new SqlDataAdapter(commandsql);// vận chuyển dữ liệu
            DataTable dt = new DataTable();
            com.Fill(dt);
            cbTTNC.DisplayMember = "TenTrangThai";
            cbTTNC.ValueMember = "Id_TrangThai";
            cbTTNC.DataSource = (dt);
            cbTTNC.DropDownHeight = cbCNC.Font.Height * 5;// giới hạn cbbox
        }

        private void bt_saveNC_Click(object sender, EventArgs e)
        {
            SqlConnection kn = new SqlConnection(@"Data Source=DESKTOP-RGHAECC;Initial Catalog=SucKhoeNhanVien_PNT;Integrated Security=True");
            kn.Open();
            string sql = "SELECT COUNT(*) FROM NghienCuu WHERE(MaSo = @user)";
            SqlCommand check_MaNC = new SqlCommand(sql, kn);//thực thi các chức năng câu lệnh trong sql 
            SqlDataAdapter com = new SqlDataAdapter(check_MaNC);// vận chuyển dữ liệu
            check_MaNC.Parameters.AddWithValue("@user", txtmanc.Text);
            int UserExist = (int)check_MaNC.ExecuteScalar();
            if (UserExist > 0)
            {
                MessageBox.Show(" Mã Nghiên Cứu đã tồn tại");
            }
            if (txtmanc.Text == "")
            {
                MessageBox.Show(" Bạn chưa nhập mã Nghiên Cứu");
            }
            if (txttennc.Text == "")
            {
                MessageBox.Show(" Bạn chưa nhập tên Nghiên Cứu");
            }

            else
            {

                string themnc = "Insert into NghienCuu VALUES (@MaSo,@TenNghienCuu,@Id_CapNghienCuu,@Id_TrangThaiNghienCuu,@NhaTaiTro,@Follow,@NguoiPhuTrach,@Tg_ThucHien,@CoMauChungVN,@CoMauChungPNT,@NgayKhoiDongSite,@ThoiGianKTTDung,@TienDoThuDung,@ChuNhiemDeTai,@KinhPhi,@ThoiGianThucHien,@NguonKP,@NgayDuyet,@SoQD,@DonViChuTri,@KQnghiemthu,@GhiChu)";
                SqlCommand commandsql = new SqlCommand(themnc, kn);//thực thi các chức năng câu lệnh trong sql 
                SqlDataAdapter comthem = new SqlDataAdapter(commandsql);// vận chuyển dữ liệu
                commandsql.Parameters.AddWithValue("@MaSo", txtmanc.Text); //Tried Parse and Convert.
                commandsql.Parameters.AddWithValue("@TenNghienCuu", txttennc.Text);
                commandsql.Parameters.AddWithValue("@Id_CapNghienCuu", cbCNC.SelectedValue.ToString());
                commandsql.Parameters.AddWithValue("@Id_TrangThaiNghienCuu", cbTTNC.SelectedValue.ToString());
                commandsql.Parameters.AddWithValue("@NhaTaiTro", txtnhataitro.Text);
                commandsql.Parameters.AddWithValue("@Follow", txtfollow.Text);
                commandsql.Parameters.AddWithValue("@NguoiPhuTrach", txtnguoiphutrach.Text);
                commandsql.Parameters.AddWithValue("@Tg_ThucHien", txtthgianthuchien1.Text);
                commandsql.Parameters.AddWithValue("@CoMauChungVN", txtcomauvn.Text);
                commandsql.Parameters.AddWithValue("@CoMauChungPNT", txtcomauPNT.Text);
                commandsql.Parameters.AddWithValue("@NgayKhoiDongSite", txtngaykdsite.Text); //Tried Parse and Convert.
                commandsql.Parameters.AddWithValue("@ThoiGianKTTDung", txtngayktthudung.Text);
                commandsql.Parameters.AddWithValue("@TienDoThuDung", txttiendothudung.Text);
                commandsql.Parameters.AddWithValue("@ChuNhiemDeTai", txtchunhiem.Text);
                commandsql.Parameters.AddWithValue("@KinhPhi", txtkinhphi.Text);
                commandsql.Parameters.AddWithValue("@ThoiGianThucHien", txttgianthuchien2.Text);
                commandsql.Parameters.AddWithValue("@NguonKP", txtnguonkp.Text);
                commandsql.Parameters.AddWithValue("@NgayDuyet", txtngayduyet.Text);
                commandsql.Parameters.AddWithValue("@SoQD", txtsoqd.Text);
                commandsql.Parameters.AddWithValue("@DonViChuTri", txtdonvichutri.Text);
                commandsql.Parameters.AddWithValue("@KQnghiemthu", txtkqnghiemthu.Text);
                commandsql.Parameters.AddWithValue("@GhiChu", txtghichu.Text);
                
                commandsql.ExecuteNonQuery();
                this.Close();
                MessageBox.Show("Lưu thành công");
            }
        }

        private void bt_exitNC_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
