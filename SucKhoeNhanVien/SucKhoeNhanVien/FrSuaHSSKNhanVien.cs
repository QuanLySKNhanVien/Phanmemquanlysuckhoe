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
    public partial class FrSuaHSSKNhanVien : Form
    {
        SqlConnection kn = new SqlConnection(@"Data Source=DESKTOP-RGHAECC;Initial Catalog=SucKhoeNhanVien_PNT;Integrated Security=True");
        public FrSuaHSSKNhanVien(string value, string date,string idLSB)
        {
            InitializeComponent();
            txtmanv.Text = value;
            DateTime dt = Convert.ToDateTime(date);
            dateTimePickerSKNV.Value = dt;
            txtidlsb.Text = idLSB;
            loaddl();
        }
        public void loaddl()
        {

            kn.Open();
            string sql = "SELECT * from NhanVien, Khoa where NhanVien.Khoa = Khoa.IdKhoa And NhanVien.MaNV like N'" + txtmanv.Text + "' ";
            // Lấy dữ liệu hành chính
            SqlCommand commandsql = new SqlCommand(sql, kn);//thực thi các chức năng câu lệnh trong sql 
            SqlDataAdapter com = new SqlDataAdapter(commandsql);// vận chuyển dữ liệu
            DataTable table = new DataTable();//tạo một bảng ảo trong hện thống
            com.Fill(table);// đổ dữ liệu vào bảng ảo
            int idnhanvien = (int)table.Rows[0].ItemArray[0];
            txtidnv.Text = idnhanvien.ToString();
            txttennv.Text = (string)table.Rows[0]["TenNV"];
            txtphongban.Text = (string)table.Rows[0]["TenKhoa"];
            txtmanv.Text = (string)table.Rows[0]["MaNV"];
            //Lấy dữ liệu tiền sử bệnh
            string sqlkhamtheluc = "SELECT * from LichSuBenh,TienSuBenh  where LichSuBenh.Id_LichSuBenh = TienSuBenh.Id_LichSuBenh And LichSuBenh.IdNhanVien = '" + txtidnv.Text + "' ";
            SqlCommand cmdsqlkhamtheluc = new SqlCommand(sqlkhamtheluc, kn);
            SqlDataAdapter comsqlkhamtheluc = new SqlDataAdapter(cmdsqlkhamtheluc);
            DataTable tableTSB = new DataTable();
            comsqlkhamtheluc.Fill(tableTSB);
            //(tableTSB.Rows[0]["mach"] == null) ? int.Empty : tableTSB.Rows[0]["mach"].ToString();
            //int mach = (int)tableTSB.Rows[0]["Mach"];
            txtchieucao.Text = tableTSB.Rows[0]["ChieuCao"].ToString();
            txtcannang.Text = tableTSB.Rows[0]["CanNang"].ToString();
            txtBMI.Text = tableTSB.Rows[0]["ChisoBMI"].ToString();
            txtmach.Text = (string)tableTSB.Rows[0]["Mach"].ToString() ;
            txthuyetap.Text = (string)tableTSB.Rows[0]["HuyetAp"];
            txtPLTL.Text = (string)tableTSB.Rows[0]["PhanLoai"];
            txtTSB.Text = (string)tableTSB.Rows[0]["TienSuBenh"];
            // Lấy dữ liệu Lâm sàng nội khoa
            string sqlLSnoikhoa = "SELECT * from LichSuBenh,LamSang_NoiKhoa  where LichSuBenh.Id_LichSuBenh = LamSang_NoiKhoa.Id_LichSuBenh And LichSuBenh.IdNhanVien = '" + txtidnv.Text + "' And LichSuBenh.NgayKham = '" + dateTimePickerSKNV.Value.ToString("yyyy-MM-dd") + "' ";
            SqlCommand cmdsqlLSnoikhoa = new SqlCommand(sqlLSnoikhoa, kn);
            SqlDataAdapter comsqlLSnoikhoa = new SqlDataAdapter(cmdsqlLSnoikhoa);
            DataTable tableLSNK = new DataTable();
            comsqlLSnoikhoa.Fill(tableLSNK);
            txtPLtuanhoan.Text = (string)tableLSNK.Rows[0]["PL_TuanHoan"];
            txtPLhohap.Text = (string)tableLSNK.Rows[0]["PL_HoHap"];
            txtPLtieuhoa.Text = (string)tableLSNK.Rows[0]["PL_TieuHoa"];
            txtPLthan.Text = (string)tableLSNK.Rows[0]["PL_ThanTietNieu"];
            txtPLNoiTiet.Text = (string)tableLSNK.Rows[0]["PL_NoiTiet"];
            txtBSKham.Text = (string)tableLSNK.Rows[0]["GhiChu"];
            // Lấy dữ liệu lâm sàng da liễu
            string sqlLSDL = "SELECT * from LamSang_DaLieu, LichSuBenh where LichSuBenh.Id_LichSuBenh = LamSang_DaLieu.Id_LichSuBenh And LichSuBenh.IdNhanVien = '" + txtidnv.Text + "' And LichSuBenh.NgayKham = '" + dateTimePickerSKNV.Value.ToString("yyyy-MM-dd") + "' ";
            SqlCommand cmdsqlLSDL = new SqlCommand(sqlLSDL, kn);
            SqlDataAdapter comsqlLSDL = new SqlDataAdapter(cmdsqlLSDL);
            DataTable tblLSDL = new DataTable();
            comsqlLSDL.Fill(tblLSDL);
            txtPLxuongkhop.Text = (string)tblLSDL.Rows[0]["PL_CoXuongKhop"];
            txtPLthankinh.Text = (string)tblLSDL.Rows[0]["PL_ThanKinh"];
            txtPLtamthan.Text = (string)tblLSDL.Rows[0]["PL_TamThan"];
            txtPLdalieu.Text = (string)tblLSDL.Rows[0]["PL_DaLieu"];
            txtBSkhamDL.Text = (string)tblLSDL.Rows[0]["TenBS"];
            // Lấy dữ liệu lâm sàng tai mũi họng
            string sqlLSTMH = "SELECT * from LichSuBenh,LamSang_TaiMuiHong where LichSuBenh.Id_LichSuBenh = LamSang_TaiMuiHong.Id_LichSuBenh And LichSuBenh.IdNhanVien = '" + txtidnv.Text + "' And LichSuBenh.NgayKham = '" + dateTimePickerSKNV.Value.ToString("yyyy-MM-dd") + "' ";
            SqlCommand cmdsqlLSTMH = new SqlCommand(sqlLSTMH, kn);
            SqlDataAdapter comsqlLSTMH = new SqlDataAdapter(cmdsqlLSTMH);
            DataTable tblLSTMH = new DataTable();
            comsqlLSTMH.Fill(tblLSTMH);
            txttraithuong.Text = (string)tblLSTMH.Rows[0]["TaiTrai_NoiThuong"];
            txtphaithuong.Text = (string)tblLSTMH.Rows[0]["TaiPhai_NoiThuong"];
            txtphaitham.Text = (string)tblLSTMH.Rows[0]["TaiPhai_NoiTham"];
            txttraitham.Text = (string)tblLSTMH.Rows[0]["TaiTrai_NoiTham"];
            txtBenhMHkhac.Text = (string)tblLSTMH.Rows[0]["BenhTMH"];
            txtPLmuihong.Text = (string)tblLSTMH.Rows[0]["PhanLoai"];
            txtBSmuihong.Text = (string)tblLSTMH.Rows[0]["BSKham"];
            // Lấy dữ liệu lâm sàng răng hàm mặt
            string sqlLSRHM = "SELECT * from LamSang_RangHam,LichSuBenh where LichSuBenh.Id_LichSuBenh = LamSang_RangHam.Id_LichSuBenh And LichSuBenh.IdNhanVien = '" + txtidnv.Text + "' And LichSuBenh.NgayKham = '" + dateTimePickerSKNV.Value.ToString("yyyy-MM-dd") + "' ";
            SqlCommand cmdsqlLSRHM = new SqlCommand(sqlLSRHM, kn);
            SqlDataAdapter comsqlLSRHM = new SqlDataAdapter(cmdsqlLSRHM);
            DataTable tblLSRHM = new DataTable();
            comsqlLSRHM.Fill(tblLSRHM);
            txthamtren.Text = (string)tblLSRHM.Rows[0]["HamTren"];
            txthamduoi.Text = (string)tblLSRHM.Rows[0]["HamDuoi"];
            txtBenhrangkhac.Text = (string)tblLSRHM.Rows[0]["BenhVeRang"];
            txtPLrang.Text = (string)tblLSRHM.Rows[0]["PhanLoai"];
            txtBSRang.Text = (string)tblLSRHM.Rows[0]["BSKham"];
            // Lấy dữ liệu lâm sàng mắt
            string sqlLSMat = "Select * from LichSuBenh,LamSang_Mat where LichSuBenh.Id_LichSuBenh = LamSang_Mat.Id_LichSuBenh And LichSuBenh.IdNhanVien = '" + txtidnv.Text + "' And LichSuBenh.NgayKham = '" + dateTimePickerSKNV.Value.ToString("yyyy-MM-dd") + "' ";
            SqlCommand cmdsqlMat = new SqlCommand(sqlLSMat, kn);
            SqlDataAdapter comsqlMat = new SqlDataAdapter(cmdsqlMat);
            DataTable tblLSMat = new DataTable();
            comsqlMat.Fill(tblLSMat);
            txtkokinhphai.Text = (string)tblLSMat.Rows[0]["KhongKinhPhai"];
            txtkokinhtrai.Text = (string)tblLSMat.Rows[0]["KhongKinhTrai"];
            txtcokinhphai.Text = (string)tblLSMat.Rows[0]["KinhPhai"];
            txtcokinhtrai.Text = (string)tblLSMat.Rows[0]["KinhTrai"];
            txtbenhmatkhac.Text = (string)tblLSMat.Rows[0]["BenhMat"];
            txtPLmat.Text = (string)tblLSMat.Rows[0]["PhanLoai"];
            txtBSmat.Text = (string)tblLSMat.Rows[0]["BacSiKham"];
            // Lấy dữ liệu phụ khoa
            string sqlLSPK = "Select * from LichSuBenh,LamSang_PhuKhoa where LichSuBenh.Id_LichSuBenh = LamSang_PhuKhoa.Id_LichSuBenh And LichSuBenh.IdNhanVien = '" + txtidnv.Text + "' And LichSuBenh.NgayKham = '" + dateTimePickerSKNV.Value.ToString("yyyy-MM-dd") + "' ";
            SqlCommand cmdsqlLSPK = new SqlCommand(sqlLSPK, kn);
            SqlDataAdapter comsqlLSPK = new SqlDataAdapter(cmdsqlLSPK);
            DataTable tblLSPK = new DataTable();
            comsqlLSPK.Fill(tblLSPK);
            txtpara.Text = (string)tblLSPK.Rows[0]["SanPK"];
            txtPLphukhoa.Text = (string)tblLSPK.Rows[0]["PhanLoai"];
            //txtghichu.Text = (string)tblLSPK.Rows[0]["GhiChu"];
            txtghichu.Text = (tblLSPK.Rows[0]["GhiChu"] == null) ? string.Empty : tblLSPK.Rows[0]["GhiChu"].ToString();
            txtBSphukhoa.Text = (string)tblLSPK.Rows[0]["BSKham"];
            //Lấy dữ liệu cận lâm sàng
            string sqlCLS = "select* from LichSuBenh, CanLamSang where LichSuBenh.Id_LichSuBenh = CanLamSang.Id_LichSuBenh And LichSuBenh.IdNhanVien = '" + txtidnv.Text +"'";
            SqlCommand cmdsqlCLS = new SqlCommand(sqlCLS, kn);
            SqlDataAdapter comsqlCLS = new SqlDataAdapter(cmdsqlCLS);
            DataTable tblCLS = new DataTable();
            comsqlCLS.Fill(tblCLS);
            //(tableTSB.Rows[0]["mach"] == null) ? int.Empty : tableTSB.Rows[0]["mach"].ToString();
            txtkqCLS.Text = (string)tblCLS.Rows[0]["KetQua"];
            txtdanhgia.Text = (string)tblCLS.Rows[0]["DanhGia"];
            txtBSCLS.Text = (string)tblCLS.Rows[0]["BsKham"];
            // Lấy dữ liệu lịch sử bệnh 
            string sqlLSB = "select* from LichSuBenh where LichSuBenh.IdNhanVien = '" + txtidnv.Text + "' And LichSuBenh.NgayKham = '" + dateTimePickerSKNV.Value.ToString("yyyy-MM-dd") + "'  ";
            SqlCommand cmdsqlLSB = new SqlCommand(sqlLSB, kn);
            SqlDataAdapter comsqlLSB = new SqlDataAdapter(cmdsqlLSB);
            DataTable tblLSB = new DataTable();
            comsqlLSB.Fill(tblLSB);
            //var date = (DateTime)tblLSB.Rows[0]["NgayKham"];
            //dateTimePickerSKNV.Value = date;
            txtPLSucKhoe.Text = (string)tblLSB.Rows[0]["PhanLoaiSK"];
            txtbenhkhac.Text = (string)tblLSB.Rows[0]["BenhKhac"];
            txtBSKetLuan.Text = (string)tblLSB.Rows[0]["GhiChu"];

        }
        private void btLuuSuaSK_Click(object sender, EventArgs e)
        {
            //Sửa tiền sử bệnh nhân viên
            string suaTSBnv = "Update TienSuBenh Set ChieuCao = @chieucao,CanNang = @cannang,ChisoBMI = @BMI,HuyetAp = @huyetap,Mach = @mach,PhanLoai=@PLTSB,TienSuBenh=@TSB where Id_LichSuBenh = '" + txtidlsb.Text + "' ";
            SqlCommand commandsuaTSBnv = new SqlCommand(suaTSBnv, kn);//thực thi các chức năng câu lệnh trong sql 
            SqlDataAdapter comsuaTSBnv = new SqlDataAdapter(commandsuaTSBnv);// vận chuyển dữ liệu
            //Tried Parse and Convert.
            commandsuaTSBnv.Parameters.AddWithValue("@chieucao", txtchieucao.Text);
            commandsuaTSBnv.Parameters.AddWithValue("@cannang", txtcannang.Text);
            commandsuaTSBnv.Parameters.AddWithValue("@BMI", txtBMI.Text);
            commandsuaTSBnv.Parameters.AddWithValue("@huyetap", txthuyetap.Text);
            commandsuaTSBnv.Parameters.AddWithValue("@mach", txtmach.Text);
            commandsuaTSBnv.Parameters.AddWithValue("@PLTSB", txtPLTL.Text);
            commandsuaTSBnv.Parameters.AddWithValue("@TSB", txtTSB.Text);
            commandsuaTSBnv.ExecuteNonQuery();
            // Sửa Lâm sàng Nội khoa
            string suaLSNK = "Update LamSang_NoiKhoa Set PL_TuanHoan = @tuanhoan,PL_HoHap = @hohap,PL_TieuHoa = @tieuhoa,PL_ThanTietNieu = @tietnieu,PL_NoiTiet = @noitiet,GhiChu = @ghichu where Id_LichSuBenh = '" + txtidlsb.Text + "' ";
            SqlCommand commandsuaLSNK = new SqlCommand(suaLSNK, kn);
            SqlDataAdapter comsuaLSNK = new SqlDataAdapter(commandsuaLSNK);
            commandsuaLSNK.Parameters.AddWithValue("@tuanhoan",txtPLtuanhoan.Text);
            commandsuaLSNK.Parameters.AddWithValue("@hohap",txtPLhohap.Text);
            commandsuaLSNK.Parameters.AddWithValue("@tieuhoa",txtPLtieuhoa.Text);
            commandsuaLSNK.Parameters.AddWithValue("@tietnieu",txtPLthan.Text);
            commandsuaLSNK.Parameters.AddWithValue("@noitiet",txtPLNoiTiet.Text);
            commandsuaLSNK.Parameters.AddWithValue("@ghichu",txtBSKham.Text);
            commandsuaLSNK.ExecuteNonQuery();
            // Sửa Lâm Sàng da liễu
            string suaLSDL = "Update LamSang_DaLieu Set PL_CoXuongKhop = @xuongkhop ,PL_ThanKinh = @thankinh ,PL_TamThan = @tamthan ,PL_DaLieu = @dalieu,TenBS = @bacsidl where Id_LichSuBenh = '" + txtidlsb.Text + "' ";
            SqlCommand commandsuaDL = new SqlCommand(suaLSDL,kn);
            SqlDataAdapter comDL = new SqlDataAdapter(commandsuaDL);
            commandsuaDL.Parameters.AddWithValue("@xuongkhop",txtPLxuongkhop.Text);
            commandsuaDL.Parameters.AddWithValue("@thankinh",txtPLthankinh.Text);
            commandsuaDL.Parameters.AddWithValue("@tamthan",txtPLtamthan.Text);
            commandsuaDL.Parameters.AddWithValue("@dalieu",txtPLdalieu.Text);
            commandsuaDL.Parameters.AddWithValue("@bacsidl",txtBSkhamDL.Text);
            commandsuaDL.ExecuteNonQuery();
            //Sửa Lâm sàng tai mũi họng
            /*string suaTMH = "Update LamSang_TaiMuiHong Set TaiTrai_NoiThuong = @traithuong ,TaiTrai_NoiTham = @traitham ,TaiPhai_NoiThuong = @phaithuong ,TaiPhai_NoiTham = @phaitham ,BenhTMH = @benhTMH ,PhanLoai = @PLTMH ,BSKham = @BSKham where Id_LichSuBenh = '" + txtidlsb.Text + "'";
            SqlCommand commandsuaTMH = new SqlCommand(suaTMH,kn);
            SqlDataAdapter comsuaTMH = new SqlDataAdapter(commandsuaTMH);
            commandsuaTMH.Parameters.AddWithValue("@traithuong",txttraithuong.Text);
            commandsuaTMH.Parameters.AddWithValue("@traitham",txttraitham.Text);
            commandsuaTMH.Parameters.AddWithValue("@phaithuong",txtphaithuong);
            commandsuaTMH.Parameters.AddWithValue("@phaitham",txtphaitham.Text);
            commandsuaTMH.Parameters.AddWithValue("@benhTMH",txtBenhMHkhac.Text);
            commandsuaTMH.Parameters.AddWithValue("@PLTMH",txtPLmuihong.Text);
            commandsuaTMH.Parameters.AddWithValue("@BSKham",txtBSKham.Text);
            commandsuaTMH.ExecuteNonQuery();*/
            string suaLSTMH = "Update LamSang_TaiMuiHong Set TaiTrai_NoiThuong = @trainoithuong,TaiTrai_NoiTham = @trainoitham ,TaiPhai_NoiThuong = @phainoithuong ,TaiPhai_NoiTham = @phainoitham ,BenhTMH = @benhTMH,PhanLoai = @PLTMH ,BSKham =@bsTMH where Id_LichSuBenh = '" + txtidlsb.Text + "'";
            SqlCommand commandsuaLSTMH = new SqlCommand(suaLSTMH, kn);
            SqlDataAdapter comsuaLSTMH = new SqlDataAdapter(commandsuaLSTMH);
            commandsuaLSTMH.Parameters.AddWithValue("@trainoithuong", txttraithuong.Text);
            commandsuaLSTMH.Parameters.AddWithValue("@trainoitham", txttraitham.Text);
            commandsuaLSTMH.Parameters.AddWithValue("@phainoithuong", txtphaithuong.Text);
            commandsuaLSTMH.Parameters.AddWithValue("@phainoitham", txtphaitham.Text);
            commandsuaLSTMH.Parameters.AddWithValue("@benhTMH", txtBenhMHkhac.Text);
            commandsuaLSTMH.Parameters.AddWithValue("@PLTMH", txtPLmuihong.Text);
            commandsuaLSTMH.Parameters.AddWithValue("@bsTMH", txtBSmuihong.Text);
            commandsuaLSTMH.ExecuteNonQuery();
            // Sửa Lâm Sàng Răng Hàm Mặt
            string suaRHM = "Update LamSang_RangHam Set HamTren = @hamtren ,HamDuoi = @hamduoi ,BenhVeRang = @benhrang ,PhanLoai = @phanloairang ,BSKham = @bsrang where Id_LichSuBenh = '" + txtidlsb.Text + "'";
            SqlCommand commandsuaRHM = new SqlCommand(suaRHM,kn);
            SqlDataAdapter comsuaRHM = new SqlDataAdapter(commandsuaRHM);
            commandsuaRHM.Parameters.AddWithValue("@hamtren",txthamtren.Text);
            commandsuaRHM.Parameters.AddWithValue("@hamduoi",txthamduoi.Text);
            commandsuaRHM.Parameters.AddWithValue("@benhrang",txtBenhrangkhac.Text);
            commandsuaRHM.Parameters.AddWithValue("@phanloairang",txtPLrang.Text);
            commandsuaRHM.Parameters.AddWithValue("@bsrang",txtBSRang.Text);
            commandsuaRHM.ExecuteNonQuery();
            //Sửa Lâm Sàng Mắt
            string suaMat = "Update LamSang_Mat Set KhongKinhTrai = @khongtrai ,KhongKinhPhai = @khongphai ,KinhPhai = @kinhphai ,KinhTrai = @kinhtrai ,BenhMat = @benhmat ,PhanLoai = @PLmat ,BacSiKham = @bsmat  where Id_LichSuBenh = '" + txtidlsb.Text + "'";
            SqlCommand commandsuaMat = new SqlCommand(suaMat, kn);
            SqlDataAdapter comsuaMat = new SqlDataAdapter(commandsuaMat);
            commandsuaMat.Parameters.AddWithValue("@khongtrai", txtkokinhtrai.Text);
            commandsuaMat.Parameters.AddWithValue("@khongphai", txtkokinhphai.Text);
            commandsuaMat.Parameters.AddWithValue("@kinhphai", txtcokinhphai.Text);
            commandsuaMat.Parameters.AddWithValue("@kinhtrai", txtcokinhtrai.Text);
            commandsuaMat.Parameters.AddWithValue("@benhmat", txtbenhmatkhac.Text);
            commandsuaMat.Parameters.AddWithValue("@PLmat", txtPLmat.Text);
            commandsuaMat.Parameters.AddWithValue("@bsmat", txtBSmat.Text);
            commandsuaMat.ExecuteNonQuery();
            // Sửa lâm sàng phụ khoa
            string suaPK = "Update LamSang_PhuKhoa Set SanPK = @para ,PhanLoai = @PLPK ,GhiChu = @ghichu ,BSKham = @bskham  where Id_LichSuBenh = '" + txtidlsb.Text + "'";
            SqlCommand commandsuaPK = new SqlCommand(suaPK, kn);
            SqlDataAdapter comsuaPK = new SqlDataAdapter(commandsuaPK);
            commandsuaPK.Parameters.AddWithValue("@para", txtpara.Text);
            commandsuaPK.Parameters.AddWithValue("@PLPK", txtPLphukhoa.Text);
            commandsuaPK.Parameters.AddWithValue("@ghichu", txtghichu.Text);
            commandsuaPK.Parameters.AddWithValue("@bskham", txtBSphukhoa.Text);
            commandsuaPK.ExecuteNonQuery();
            // Sửa cận lâm sàng
            string suaCLS = "Update CanLamSang Set KetQua = @ketqua ,DanhGia = @danhgia ,BsKham = @bscls where Id_LichSuBenh = '" + txtidlsb.Text + "'";
            SqlCommand commandsuaCLS = new SqlCommand(suaCLS, kn);
            SqlDataAdapter comsuaCLS = new SqlDataAdapter(commandsuaCLS);
            commandsuaCLS.Parameters.AddWithValue("@ketqua", txtkqCLS.Text);
            commandsuaCLS.Parameters.AddWithValue("@danhgia", txtdanhgia.Text);
            commandsuaCLS.Parameters.AddWithValue("@bscls", txtBSCLS.Text);
            commandsuaCLS.ExecuteNonQuery();
            //Sửa lịch sử bệnh
            string suaLSB = "Update LichSuBenh Set NgayKham = @ngaykham ,PhanLoaiSK = @plsk ,BenhKhac= @benhkhac ,GhiChu = @ghichu where Id_LichSuBenh = '" + txtidlsb.Text + "'";
            SqlCommand commandsuaLSB = new SqlCommand(suaLSB, kn);
            SqlDataAdapter comsuaLSB = new SqlDataAdapter(commandsuaLSB);
            commandsuaLSB.Parameters.AddWithValue("@ngaykham", dateTimePickerSKNV.Value.Date);
            commandsuaLSB.Parameters.AddWithValue("@plsk", txtPLSucKhoe.Text);
            commandsuaLSB.Parameters.AddWithValue("@benhkhac", txtbenhkhac.Text);
            commandsuaLSB.Parameters.AddWithValue("@ghichu", txtBSKetLuan.Text);
            commandsuaLSB.ExecuteNonQuery();
            MessageBox.Show("cập nhật dữ liệu thành công");
            this.Close();

        }
    }
}
