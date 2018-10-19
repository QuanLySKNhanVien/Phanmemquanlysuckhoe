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
    public partial class FrThemSKNhanVien : Form
    {
        public FrThemSKNhanVien(string value)
        {
            InitializeComponent();
            txtmanv.Text = value;
            loaddl();
        }
        // Lấy dữ liệu Nhân Viên cần thêm HSSK
        public void loaddl()
        {
            SqlConnection kn = new SqlConnection(@"Data Source=DESKTOP-RGHAECC;Initial Catalog=SucKhoeNhanVien_PNT;Integrated Security=True");
            kn.Open();
            string sql = "SELECT * from NhanVien, Khoa where NhanVien.Khoa = Khoa.IdKhoa And NhanVien.MaNV like N'" + txtmanv.Text + "' ";
            SqlCommand commandsql = new SqlCommand(sql, kn);//thực thi các chức năng câu lệnh trong sql 
            SqlDataAdapter com = new SqlDataAdapter(commandsql);// vận chuyển dữ liệu
            DataTable table = new DataTable();//tạo một bảng ảo trong hện thống
            com.Fill(table);// đổ dữ liệu vào bảng ảo
            txttennv.Text = (string)table.Rows[0]["TenNV"];
            txtphongban.Text = (string)table.Rows[0]["TenKhoa"]; 
            txtmanv.Text = (string)table.Rows[0]["MaNV"];
            int idnhanvien = (int)table.Rows[0].ItemArray[0];
            txtidnv.Text = idnhanvien.ToString();
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            SqlConnection kn = new SqlConnection(@"Data Source=DESKTOP-RGHAECC;Initial Catalog=SucKhoeNhanVien_PNT;Integrated Security=True");
            kn.Open();
            // Thêm lịch sử bệnh
            string themlichsubenh = "insert into LichSuBenh VALUES (@IdNhanVien,@MaNV,@NgayKham,@PhanLoaiSK,@BenhKhac,@ghichu)" + "SELECT CAST(scope_identity() AS int)" ;
            SqlCommand commandLSB = new SqlCommand(themlichsubenh,kn);
            SqlDataAdapter comLSB = new SqlDataAdapter(commandLSB);
            commandLSB.Parameters.AddWithValue("@IdNhanVien",txtidnv.Text);
            commandLSB.Parameters.AddWithValue("@MaNV",txtmanv.Text);
            commandLSB.Parameters.AddWithValue("@NgayKham",dateTimePickerSKNV.Value.Date);
            commandLSB.Parameters.AddWithValue("@PhanLoaiSK", txtPLSucKhoe.Text);
            commandLSB.Parameters.AddWithValue("@BenhKhac",txtbenhkhac.Text);
            commandLSB.Parameters.AddWithValue("@ghichu", txtghichuthich.Text);
            int newId = (int)commandLSB.ExecuteScalar();

            //Thêm chi tiết khám thể lực
            string themkhamtheluc = "Insert into TienSuBenh VALUES (@Id_LichSuBenh,@ChieuCao,@CanNang,@ChisoBMI,@HuyetAp,@Mach,@PhanLoai,@TienSuBenh)";
            SqlCommand commandsql = new SqlCommand(themkhamtheluc, kn);//thực thi các chức năng câu lệnh trong sql 
            SqlDataAdapter comthem = new SqlDataAdapter(commandsql);// vận chuyển dữ liệu
            commandsql.Parameters.AddWithValue("@Id_LichSuBenh",newId.ToString());
            commandsql.Parameters.AddWithValue("@ChieuCao", txtchieucao.Text); //Tried Parse and Convert.
            commandsql.Parameters.AddWithValue("@CanNang", txtcannang.Text);
            commandsql.Parameters.AddWithValue("@ChisoBMI",txtBMI.Text);
            commandsql.Parameters.AddWithValue("@HuyetAp", txthuyetap.Text);
            commandsql.Parameters.AddWithValue("@Mach", txtmach.Text);
            commandsql.Parameters.AddWithValue("@PhanLoai", txtPLTL.Text);
            commandsql.Parameters.AddWithValue("@TienSuBenh",txtTSB.Text);
            commandsql.ExecuteNonQuery();
            //Thêm chi tiết khám lâm sàng nội khoa
            string themLSnoikhoa = "Insert into LamSang_NoiKhoa VALUES (@Id_LichSuBenh,@PL_TuanHoan,@PL_HoHap,@PL_TieuHoa,@PL_ThanTietNieu,@PL_NoiTiet,@ghichu)";
            SqlCommand commandLSnoikhoa = new SqlCommand(themLSnoikhoa, kn);//thực thi các chức năng câu lệnh trong sql 
            SqlDataAdapter comLSnoikhoa = new SqlDataAdapter(commandLSnoikhoa);// vận chuyển dữ liệu
            commandLSnoikhoa.Parameters.AddWithValue("@Id_LichSuBenh", newId);
            commandLSnoikhoa.Parameters.AddWithValue("@PL_TuanHoan", txtchieucao.Text); //Tried Parse and Convert.
            commandLSnoikhoa.Parameters.AddWithValue("@PL_HoHap", txtcannang.Text);
            commandLSnoikhoa.Parameters.AddWithValue("@PL_TieuHoa", txtBMI.Text);
            commandLSnoikhoa.Parameters.AddWithValue("@PL_ThanTietNieu", txthuyetap.Text);
            commandLSnoikhoa.Parameters.AddWithValue("@PL_NoiTiet", txtmach.Text);
            commandLSnoikhoa.Parameters.AddWithValue("@ghichu", txtBSKham.Text);
            commandLSnoikhoa.ExecuteNonQuery();
            //Thêm chi tiết khám da liễu
            string themLSdalieu = "Insert into LamSang_DaLieu VALUES (@Id_LichSuBenh,@PL_CoXuongKhop,@PL_ThanKinh,@PL_TamThan,@PL_DaLieu,@TenBS)";
            SqlCommand commandLSdalieu = new SqlCommand(themLSdalieu, kn);//thực thi các chức năng câu lệnh trong sql 
            SqlDataAdapter comLSdalieu = new SqlDataAdapter(commandLSdalieu);// vận chuyển dữ liệu
            commandLSdalieu.Parameters.AddWithValue("@Id_LichSuBenh", newId);
            commandLSdalieu.Parameters.AddWithValue("@PL_CoXuongKhop", txtPLxuongkhop.Text); //Tried Parse and Convert.
            commandLSdalieu.Parameters.AddWithValue("@PL_ThanKinh", txtPLthankinh.Text);
            commandLSdalieu.Parameters.AddWithValue("@PL_TamThan", txtPLtamthan.Text);
            commandLSdalieu.Parameters.AddWithValue("@PL_DaLieu", txtPLdalieu.Text);
            commandLSdalieu.Parameters.AddWithValue("@PL_NoiTiet", txtPLNoiTiet.Text);
            commandLSdalieu.Parameters.AddWithValue("@TenBS", txtBSkhamDL.Text);
            commandLSdalieu.ExecuteNonQuery();
            //Thêm chi tiết khám tai mũi họng
            string themTaiMuiHong = "Insert into LamSang_TaiMuiHong VALUES (@Id_LichSuBenh,@TaiTrai_NoiThuong,@TaiTrai_NoiTham,@TaiPhai_NoiThuong,@TaiPhai_NoiTham,@BenhTMH,@PhanLoai,@BSKham)";
            SqlCommand commandLSTaiMuiHong = new SqlCommand(themTaiMuiHong, kn);//thực thi các chức năng câu lệnh trong sql 
            SqlDataAdapter comtaimuihong = new SqlDataAdapter(commandLSTaiMuiHong);// vận chuyển dữ liệu
            commandLSTaiMuiHong.Parameters.AddWithValue("@Id_LichSuBenh", newId);
            commandLSTaiMuiHong.Parameters.AddWithValue("@TaiTrai_NoiThuong", txttraithuong.Text); //Tried Parse and Convert.
            commandLSTaiMuiHong.Parameters.AddWithValue("@TaiTrai_NoiTham", txttraitham.Text);
            commandLSTaiMuiHong.Parameters.AddWithValue("@TaiPhai_NoiThuong",txtphaithuong.Text);
            commandLSTaiMuiHong.Parameters.AddWithValue("@TaiPhai_NoiTham", txtphaitham.Text);
            commandLSTaiMuiHong.Parameters.AddWithValue("@BenhTMH", txtBenhMHkhac.Text);
            commandLSTaiMuiHong.Parameters.AddWithValue("@PhanLoai", txtPLmuihong.Text);
            commandLSTaiMuiHong.Parameters.AddWithValue("@BSKham", txtBSkhamDL.Text);
            commandLSTaiMuiHong.ExecuteNonQuery();

            //Thêm chi tiết khám rang
            string themrang = "Insert into LamSang_RangHam VALUES (@Id_LichSuBenh,@HamTren,@HamDuoi,@BenhVeRang,@PhanLoai,@BSKham)";
            SqlCommand commandLSrang = new SqlCommand(themrang, kn);//thực thi các chức năng câu lệnh trong sql 
            SqlDataAdapter comrang = new SqlDataAdapter(commandLSrang);// vận chuyển dữ liệu
            commandLSrang.Parameters.AddWithValue("@Id_LichSuBenh", newId);
            commandLSrang.Parameters.AddWithValue("@HamTren", txthamtren.Text); //Tried Parse and Convert.
            commandLSrang.Parameters.AddWithValue("@HamDuoi", txthamduoi.Text);
            commandLSrang.Parameters.AddWithValue("@BenhVeRang", txtBenhrangkhac.Text);
            commandLSrang.Parameters.AddWithValue("@PhanLoai", txtPLrang.Text);
            commandLSrang.Parameters.AddWithValue("@BSKham", txtBSRang.Text);
            commandLSrang.ExecuteNonQuery();
            //Thêm chi tiết khám mat
            string themmat = "Insert into LamSang_Mat VALUES (@Id_LichSuBenh,@KhongKinhTrai,@KhongKinhPhai,@KinhPhai,@KinhTrai,@BenhMat,@PhanLoai,@BacSiKham)";
            SqlCommand commandLSMat = new SqlCommand(themmat, kn);//thực thi các chức năng câu lệnh trong sql 
            SqlDataAdapter commat = new SqlDataAdapter(commandLSMat);// vận chuyển dữ liệu
            commandLSMat.Parameters.AddWithValue("@Id_LichSuBenh", newId);
            commandLSMat.Parameters.AddWithValue("@KhongKinhTrai", txtkokinhtrai.Text); //Tried Parse and Convert.
            commandLSMat.Parameters.AddWithValue("@KhongKinhPhai", txtkokinhphai.Text);
            commandLSMat.Parameters.AddWithValue("@KinhPhai", txtcokinhphai.Text);
            commandLSMat.Parameters.AddWithValue("@KinhTrai", txtcokinhtrai.Text);
            commandLSMat.Parameters.AddWithValue("@BenhMat", txtbenhmatkhac.Text);
            commandLSMat.Parameters.AddWithValue("@PhanLoai", txtPLmat.Text);
            commandLSMat.Parameters.AddWithValue("@BacSiKham", txtBSmat.Text);
            commandLSMat.ExecuteNonQuery();
            //Thêm chi tiết khám phụ khoa
            string themphukhoa = "Insert into LamSang_PhuKhoa VALUES (@Id_LichSuBenh,@SanPK,@PhanLoai,@GhiChu,@BSKham)";
            SqlCommand commandphukhoa = new SqlCommand(themphukhoa, kn);//thực thi các chức năng câu lệnh trong sql 
            SqlDataAdapter comphukhoa = new SqlDataAdapter(commandphukhoa);// vận chuyển dữ liệu
            commandphukhoa.Parameters.AddWithValue("@Id_LichSuBenh", newId);
            commandphukhoa.Parameters.AddWithValue("@SanPK", txtkokinhtrai.Text); //Tried Parse and Convert.
            commandphukhoa.Parameters.AddWithValue("@PhanLoai", txtkokinhphai.Text);
            commandphukhoa.Parameters.AddWithValue("@GhiChu", txtcokinhphai.Text);
            commandphukhoa.Parameters.AddWithValue("@BSKham", txtBSmat.Text);
            commandphukhoa.ExecuteNonQuery();
            //Thêm chi tiết Cận Lâm Sàng
            string themCLS = "Insert into CanLamSang VALUES (@Id_LichSuBenh,@KetQua,@DanhGia,@BSKham)";
            SqlCommand commandCLS = new SqlCommand(themCLS, kn);//thực thi các chức năng câu lệnh trong sql 
            SqlDataAdapter comCLS = new SqlDataAdapter(commandCLS);// vận chuyển dữ liệu
            commandCLS.Parameters.AddWithValue("@Id_LichSuBenh", newId);
            commandCLS.Parameters.AddWithValue("@KetQua", txtkokinhtrai.Text); //Tried Parse and Convert.
            commandCLS.Parameters.AddWithValue("@DanhGia", txtkokinhphai.Text);
            commandCLS.Parameters.AddWithValue("@BSKham", txtBSmat.Text);
            commandCLS.ExecuteNonQuery();

            MessageBox.Show("Lưu thành công");
            this.Close();
            }
        }
}
