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
    public partial class SuaNghienCuu : Form
    {
        SqlConnection kn = new SqlConnection(@"Data Source=DESKTOP-RGHAECC;Initial Catalog=SucKhoeNhanVien_PNT;Integrated Security=True");
        public SuaNghienCuu(string value,string valueid)
        {
            InitializeComponent();
            txtmanc.Text = value;
            txtidnghiencuu.Text = valueid;
            loaddata();
            
        }
        public class Capnghiencuu
        {
            public string CapNghienCuu { get; set; }
            public int Id_CapNghienCuu { get; set; }
        }
        public class Trangthainghiencuu
        {
            public string TenTrangThai { get; set; }
            public int Id_TrangThai { get; set; }
        }
        public void loaddata()
        {
            kn.Open();
            string sql = "SELECT * from NghienCuu,CapNghienCuu,TrangThaiNghienCuu where NghienCuu.Id_CapNghienCuu = CapNghienCuu.Id_CapNghienCuu And NghienCuu.Id_TrangThaiNghienCuu = TrangThaiNghienCuu.Id_TrangThai And NghienCuu.MaSo like N'" + txtmanc.Text + "' ";
            string loadcnc = "Select * from CapNghienCuu";
            string loadtrangthainc = "Select * from TrangThaiNghienCuu";
            // Lấy dữ liệu hành chính
            SqlCommand commandsql = new SqlCommand(sql, kn);//thực thi các chức năng câu lệnh trong sql 
            SqlDataAdapter com = new SqlDataAdapter(commandsql);// vận chuyển dữ liệu
            DataTable table = new DataTable();//tạo một bảng ảo trong hện thống
            SqlCommand commandcnc = new SqlCommand(loadcnc, kn);//thực thi các chức năng câu lệnh trong sql 
            SqlDataAdapter comcnc = new SqlDataAdapter(commandcnc);// vận chuyển dữ liệu
            DataTable tablecnc = new DataTable();//tạo một bảng ảo trong hện thống
            SqlCommand commandttnc = new SqlCommand(loadtrangthainc, kn);//thực thi các chức năng câu lệnh trong sql 
            SqlDataAdapter comttnc = new SqlDataAdapter(commandttnc);// vận chuyển dữ liệu
            DataTable tablettnc = new DataTable();//tạo một bảng ảo trong hện thống
            comcnc.Fill(tablecnc);
            comttnc.Fill(tablettnc);
            com.Fill(table);// đổ dữ liệu vào bảng ảo
            int idnghiencuu = (int)table.Rows[0].ItemArray[0];
            txtidnghiencuu.Text = idnghiencuu.ToString();
            txttennc.Text = (string)table.Rows[0]["TenNghienCuu"];
            txtnhataitro.Text = (string)table.Rows[0]["NhaTaiTro"];
            txtfollow.Text = (string)table.Rows[0]["Follow"];
            txtthoigianth2.Text = (string)table.Rows[0]["Tg_ThucHien"];
            txtkinhphi.Text = (string)table.Rows[0]["KinhPhi"];
            txtchunhiem.Text = (string)table.Rows[0]["NhaTaiTro"];
            txtcomauvn.Text = (string)table.Rows[0]["CoMauChungVN"];
            txtcomauPNT.Text = (string)table.Rows[0]["CoMauChungPNT"];
            txtnguonkp.Text = (string)table.Rows[0]["NguonKP"];
            txtngayktthudung.Text = (string)table.Rows[0]["ThoiGianKTTDung"];
            txtngaykdsite.Text = (string)table.Rows[0]["NgayKhoiDongSite"];
            txtsoqd.Text = (string)table.Rows[0]["SoQD"];
            txttiendothudung.Text = (string)table.Rows[0]["TienDoThuDung"];
            txtkqnghiemthu.Text = (string)table.Rows[0]["KQnghiemthu"];
            txtdonvichutri.Text = (string)table.Rows[0]["DonViChuTri"];
            txtngayduyet.Text = (string)table.Rows[0]["NgayDuyet"];
            txtghichu.Text = (string)table.Rows[0]["GhiChu"];
            txtnguoiphutrach.Text = (string)table.Rows[0]["NguoiPhuTrach"];
            // hiển thị combo cấp nghiên cứu
            cbCNC.DisplayMember = "CapNghienCuu";
            cbCNC.ValueMember = "Id_CapNghienCuu";
            List<Capnghiencuu> list = new List<Capnghiencuu>(); // define a list
            for (var i = 0; i < tablecnc.Rows.Count; i++)
            {
                var cv = new Capnghiencuu { CapNghienCuu = (string)tablecnc.Rows[i].ItemArray[1], Id_CapNghienCuu = (int)tablecnc.Rows[i].ItemArray[0] };
                list.Add(cv);
            }
            cbCNC.DataSource = list; //gán ds chức vụ vào source dữ liệu của combox.
            var idCNC = (int)table.Rows[0].ItemArray[3]; //Lấy id chức vụ của nv truyền vào
            var CNC = list.Where(x => x.Id_CapNghienCuu == idCNC).FirstOrDefault();
            var index = cbCNC.Items.IndexOf(CNC); //tìm chỉ số index của chức vụ mà nv truyền vào nằm ở vị trí nào trong combobox.
            cbCNC.SelectedIndex = index; // gán index cho selected.
            // hiển thị combo trạng thái nghiên cứu
            cbTTNC.DisplayMember = "TenTrangThai";
            cbTTNC.ValueMember = "Id_TrangThai";
            List<Trangthainghiencuu> listttnc = new List<Trangthainghiencuu>(); // define a list
            for (var i = 0; i < tablettnc.Rows.Count; i++)
            {
                var ttnc = new Trangthainghiencuu { TenTrangThai = (string)tablettnc.Rows[i].ItemArray[1], Id_TrangThai = (int)tablettnc.Rows[i].ItemArray[0] };
                listttnc.Add(ttnc);
            }
            cbTTNC.DataSource = listttnc; //gán ds chức vụ vào source dữ liệu của combox.
            var idTTNC = (int)table.Rows[0].ItemArray[4]; //Lấy id chức vụ của nv truyền vào
            var TTNC = listttnc.Where(x => x.Id_TrangThai == idTTNC).FirstOrDefault();
            var indexTTNC = cbTTNC.Items.IndexOf(TTNC); //tìm chỉ số index của chức vụ mà nv truyền vào nằm ở vị trí nào trong combobox.
            cbTTNC.SelectedIndex = index; // gán index cho selected.
        }

        private void bt_saveNC_Click(object sender, EventArgs e)
        {
            //Sửa nghiên cứu
            string suaNC = "Update NghienCuu Set MaSo = @maso,TenNghienCuu = @tennghiencuu,Id_CapNghienCuu = @IdCNC,Id_TrangThaiNghienCuu = @IdTTNC,NhaTaiTro = @NhaTT,Follow = @follow,NguoiPhuTrach = @nguoipt,Tg_ThucHien = @tgthuchien1,CoMauChungVN = @comauvn,CoMauChungPNT = @comaupnt,NgayKhoiDongSite = @ngaykds,ThoiGianKTTDung = @tgthudung,TienDoThuDung = @tiendotd,ChuNhiemDeTai = @chunhiemdt,KinhPhi = @kinhphi,ThoiGianThucHien = @tgthuchien2,NguonKP = @nguonkp,NgayDuyet = @ngayduyet,SoQD = @soqd,DonViChuTri = @donvict,KQnghiemthu = @kqnghiemthu, GhiChu = @ghichu where Id_NghienCuu = '" + txtidnghiencuu.Text + "' ";
            SqlCommand commandsuaNC = new SqlCommand(suaNC, kn);//thực thi các chức năng câu lệnh trong sql 
            SqlDataAdapter comsuaNC = new SqlDataAdapter(commandsuaNC);// vận chuyển dữ liệu
            //Tried Parse and Convert.
            commandsuaNC.Parameters.AddWithValue("@maso", txtmanc.Text);
            commandsuaNC.Parameters.AddWithValue("@tennghiencuu", txttennc.Text);
            commandsuaNC.Parameters.AddWithValue("@IdCNC", cbCNC.SelectedValue.ToString());
            commandsuaNC.Parameters.AddWithValue("@IdTTNC", cbTTNC.SelectedValue.ToString());
            commandsuaNC.Parameters.AddWithValue("@NhaTT", txtnhataitro.Text);
            commandsuaNC.Parameters.AddWithValue("@follow", txtfollow.Text);
            commandsuaNC.Parameters.AddWithValue("@nguoipt", txtnguoiphutrach.Text);     
            commandsuaNC.Parameters.AddWithValue("@tgthuchien1", txtthoigianth1.Text);
            commandsuaNC.Parameters.AddWithValue("@comauvn", txtcomauvn.Text);
            commandsuaNC.Parameters.AddWithValue("@comaupnt", txtcomauPNT.Text);
            commandsuaNC.Parameters.AddWithValue("@ngaykds", txtngaykdsite.Text);
            commandsuaNC.Parameters.AddWithValue("@tgthudung", txtngayktthudung.Text);
            commandsuaNC.Parameters.AddWithValue("@tiendotd", txttiendothudung.Text);
            commandsuaNC.Parameters.AddWithValue("@chunhiemdt", txtchunhiem.Text);
            commandsuaNC.Parameters.AddWithValue("@kinhphi", txtkinhphi.Text);
            commandsuaNC.Parameters.AddWithValue("@tgthuchien2", txtthoigianth2.Text);
            commandsuaNC.Parameters.AddWithValue("@nguonkp", txtnguonkp.Text);
            commandsuaNC.Parameters.AddWithValue("@ngayduyet",txtngayduyet.Text);
            commandsuaNC.Parameters.AddWithValue("@soqd",txtsoqd.Text);
            commandsuaNC.Parameters.AddWithValue("@donvict", txtdonvichutri.Text);
            commandsuaNC.Parameters.AddWithValue("@kqnghiemthu", txtkqnghiemthu.Text);
            commandsuaNC.Parameters.AddWithValue("@ghichu", txtghichu.Text);
            commandsuaNC.ExecuteNonQuery();
            MessageBox.Show("cập nhật dữ liệu thành công");
            this.Close();
        }
    }
}
