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
    public partial class XemHSSKNhanVien : Form
    {
        public XemHSSKNhanVien(string value,string date)
        {
            InitializeComponent();
            txtmanv.Text = value;
            DateTime dt = Convert.ToDateTime(date);
            dateTimePickerSKNV.Value = dt;
            loaddl();
        }
        public void loaddl()
        {
            SqlConnection kn = new SqlConnection(@"Data Source=DESKTOP-RGHAECC;Initial Catalog=SucKhoeNhanVien_PNT;Integrated Security=True");
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
            //string sqlkhamtheluc = "SELECT * from LichSuBenh,TienSuBenh  where LichSuBenh.Id_LichSuBenh = TienSuBenh.Id_LichSuBenh And LichSuBenh.IdNhanVien = '" + txtidnv.Text + "' And LichSuBenh.NgayKham = '" + dateTimePickerSKNV.Value.ToString("yyyy-MM-dd") + "' ";
            string sqlkhamtheluc = "SELECT * from LichSuBenh,TienSuBenh  where LichSuBenh.Id_LichSuBenh = TienSuBenh.Id_LichSuBenh And LichSuBenh.IdNhanVien = '" + txtidnv.Text +"'";
            SqlCommand cmdsqlkhamtheluc = new SqlCommand(sqlkhamtheluc,kn);
            SqlDataAdapter comsqlkhamtheluc = new SqlDataAdapter(cmdsqlkhamtheluc);
            DataTable tableTSB = new DataTable();
            comsqlkhamtheluc.Fill(tableTSB);
            txtchieucao.Text = tableTSB.Rows[0]["ChieuCao"].ToString();
            txtcannang.Text = tableTSB.Rows[0]["CanNang"].ToString();
            txtBMI.Text = tableTSB.Rows[0]["ChisoBMI"].ToString();
            txtmach.Text = (string)tableTSB.Rows[0]["Mach"].ToString();
            txthuyetap.Text = (string)tableTSB.Rows[0]["HuyetAp"];
            txtPLTL.Text = (string)tableTSB.Rows[0]["PhanLoai"];
            txtTSB.Text = (string)tableTSB.Rows[0]["TienSuBenh"];
            // Lấy dữ liệu Lâm sàng nội khoa
            string sqlLSnoikhoa = "SELECT * from LichSuBenh,LamSang_NoiKhoa  where LichSuBenh.Id_LichSuBenh = LamSang_NoiKhoa.Id_LichSuBenh And LichSuBenh.IdNhanVien = '" + txtidnv.Text + "' And LichSuBenh.NgayKham = '" + dateTimePickerSKNV.Value.ToString("yyyy-MM-dd") + "' ";
            SqlCommand cmdsqlLSnoikhoa = new SqlCommand(sqlLSnoikhoa,kn);
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
            SqlCommand cmdsqlLSDL = new SqlCommand(sqlLSDL,kn);
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
            SqlCommand cmdsqlLSTMH = new SqlCommand(sqlLSTMH,kn);
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
            SqlCommand cmdsqlLSRHM = new SqlCommand(sqlLSRHM,kn);
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
            SqlCommand cmdsqlMat = new SqlCommand(sqlLSMat,kn);
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
            string sqlCLS = "select* from LichSuBenh, CanLamSang where LichSuBenh.Id_LichSuBenh = CanLamSang.Id_LichSuBenh And LichSuBenh.IdNhanVien = '" + txtidnv.Text + "' And LichSuBenh.NgayKham = '" + dateTimePickerSKNV.Value.ToString("yyyy-MM-dd") + "' ";
            SqlCommand cmdsqlCLS = new SqlCommand(sqlCLS, kn);
            SqlDataAdapter comsqlCLS = new SqlDataAdapter(cmdsqlCLS);
            DataTable tblCLS = new DataTable();
            comsqlCLS.Fill(tblCLS);
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


    }
}
