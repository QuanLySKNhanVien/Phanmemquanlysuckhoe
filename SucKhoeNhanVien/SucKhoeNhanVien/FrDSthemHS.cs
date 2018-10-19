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
    public partial class FrDSthemHS : Form
    {
        public FrDSthemHS()
        {
            InitializeComponent();
            ketnoi();
        }
        // Kết nối cơ sở dữ liệu
        public void ketnoi()
        {
            try
            {
                SqlConnection kn = new SqlConnection(@"Data Source=DESKTOP-RGHAECC;Initial Catalog=SucKhoeNhanVien_PNT;Integrated Security=True");
                kn.Open();
                string sql = "SELECT NhanVien.MaNV,NhanVien.TenNV,ChucVu.TenChucVu,Khoa.TenKhoa,NhanVien.CMND from NhanVien, ChucVu, Khoa where NhanVien.IdChucVu = ChucVu.IdChucVu And NhanVien.Khoa = Khoa.IdKhoa";
                SqlCommand commandsql = new SqlCommand(sql, kn);//thực thi các chức năng câu lệnh trong sql 
                SqlDataAdapter com = new SqlDataAdapter(commandsql);// vận chuyển dữ liệu
                DataTable table = new DataTable();//tạo một bảng ảo trong hện thống
                com.Fill(table);// đổ dữ liệu vào bảng ảo
                datagvNhanVienThem.DataSource = table; //bảng ảo này đc đổ vào datagrid
                datagvNhanVienThem.Columns[0].HeaderText = "Mã Nhân Viên";
                datagvNhanVienThem.Columns[1].HeaderText = "Tên Nhân Viên";
                datagvNhanVienThem.Columns[2].HeaderText = "Chức Vụ";
                datagvNhanVienThem.Columns[3].HeaderText = "Khoa/Phòng Ban";
                datagvNhanVienThem.Columns[4].HeaderText = "CMND";
                DataGridViewCellStyle style = datagvNhanVienThem.ColumnHeadersDefaultCellStyle;// Tô đậm header của cột
                style.Font = new Font(datagvNhanVienThem.Font, FontStyle.Bold);// Tô đậm header của cột
                style.BackColor = Color.Navy;
                style.ForeColor = Color.White;//Tô màu header
                Binding();
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
        public void Binding()
        {
            txtmanvthem.DataBindings.Clear();// xóa dữ liệu hiện tại trong textbox
            txtmanvthem.DataBindings.Add("Text", datagvNhanVienThem.DataSource, "MaNV");//lấy dữ liệu đưa vào textbox
            txttennvthem.DataBindings.Clear();
            txttennvthem.DataBindings.Add("Text", datagvNhanVienThem.DataSource, "TenNV");
            txtkhoathem.DataBindings.Clear();
            txtkhoathem.DataBindings.Add("Text", datagvNhanVienThem.DataSource, "TenKhoa");
        }
        //Không cho phép di chuyển form
        protected override void WndProc(ref Message m)
        {
            const int WM_NCLBUTTONDOWN = 161;
            const int WM_SYSCOMMAND = 274;
            const int HTCAPTION = 2;
            const int SC_MOVE = 61456;
            if ((m.Msg == WM_SYSCOMMAND) && (m.WParam.ToInt32() == SC_MOVE))
            {
                return;
            }
            if ((m.Msg == WM_NCLBUTTONDOWN) && (m.WParam.ToInt32() == HTCAPTION))
            {
                return;
            }
            base.WndProc(ref m);
        }
        //Hàm Tìm Nhân Viên
        private void bttim_Click(object sender, EventArgs e)
        {
            if (txtmanvthem.Text != "" && txttennvthem.Text == "" && txtkhoathem.Text == "")
            {
                SqlConnection kn = new SqlConnection(@"Data Source=DESKTOP-RGHAECC;Initial Catalog=SucKhoeNhanVien_PNT;Integrated Security=True");
                kn.Open();
                string sql = "SELECT NhanVien.MaNV,NhanVien.TenNV,ChucVu.TenChucVu,Khoa.TenKhoa,NhanVien.CMND from NhanVien, ChucVu, Khoa where NhanVien.IdChucVu = ChucVu.IdChucVu And NhanVien.Khoa = Khoa.IdKhoa And NhanVien.MaNV like N'%" + txtmanvthem.Text.Trim() + "%' ";
                SqlCommand commandsql = new SqlCommand(sql, kn);//thực thi các chức năng câu lệnh trong sql 
                SqlDataAdapter com = new SqlDataAdapter(commandsql);// vận chuyển dữ liệu
                DataTable table = new DataTable();//tạo một bảng ảo trong hện thống
                com.Fill(table);// đổ dữ liệu vào bảng ảo
                datagvNhanVienThem.DataSource = table; //bảng ảo này đc đổ vào datagrid
                DataGridViewCellStyle style = datagvNhanVienThem.ColumnHeadersDefaultCellStyle;// Tô đậm header của cột
                style.Font = new Font(datagvNhanVienThem.Font, FontStyle.Bold);// Tô đậm header của cột
                style.BackColor = Color.Navy;
                style.ForeColor = Color.White;//Tô màu header
                Binding();
            }
            else if (txtmanvthem.Text == "" && txttennvthem.Text != "" && txtkhoathem.Text == "")
            {
                SqlConnection kn = new SqlConnection(@"Data Source=DESKTOP-RGHAECC;Initial Catalog=SucKhoeNhanVien_PNT;Integrated Security=True");
                kn.Open();
                string sql = "SELECT NhanVien.MaNV,NhanVien.TenNV,ChucVu.TenChucVu,Khoa.TenKhoa,NhanVien.CMND from NhanVien, ChucVu, Khoa where NhanVien.IdChucVu = ChucVu.IdChucVu And NhanVien.Khoa = Khoa.IdKhoa And NhanVien.TenNV like N'%" + txttennvthem.Text.Trim() + "%' ";
                SqlCommand commandsql = new SqlCommand(sql, kn);//thực thi các chức năng câu lệnh trong sql 
                SqlDataAdapter com = new SqlDataAdapter(commandsql);// vận chuyển dữ liệu
                DataTable table = new DataTable();//tạo một bảng ảo trong hện thống
                com.Fill(table);// đổ dữ liệu vào bảng ảo
                datagvNhanVienThem.DataSource = table; //bảng ảo này đc đổ vào datagrid
                DataGridViewCellStyle style = datagvNhanVienThem.ColumnHeadersDefaultCellStyle;// Tô đậm header của cột
                style.Font = new Font(datagvNhanVienThem.Font, FontStyle.Bold);// Tô đậm header của cột
                style.BackColor = Color.Navy;
                style.ForeColor = Color.White;//Tô màu header
                Binding();
            }
            else if (txtmanvthem.Text == "" && txttennvthem.Text == "" && txtkhoathem.Text != "")
            {
                SqlConnection kn = new SqlConnection(@"Data Source=DESKTOP-RGHAECC;Initial Catalog=SucKhoeNhanVien_PNT;Integrated Security=True");
                kn.Open();
                string sql = "SELECT NhanVien.MaNV,NhanVien.TenNV,ChucVu.TenChucVu,Khoa.TenKhoa,NhanVien.CMND from NhanVien, ChucVu, Khoa where NhanVien.IdChucVu = ChucVu.IdChucVu And NhanVien.Khoa = Khoa.IdKhoa And Khoa.TenKhoa like N'%" + txtkhoathem.Text.Trim() + "%' ";
                SqlCommand commandsql = new SqlCommand(sql, kn);//thực thi các chức năng câu lệnh trong sql 
                SqlDataAdapter com = new SqlDataAdapter(commandsql);// vận chuyển dữ liệu
                DataTable table = new DataTable();//tạo một bảng ảo trong hện thống
                com.Fill(table);// đổ dữ liệu vào bảng ảo
                datagvNhanVienThem.DataSource = table; //bảng ảo này đc đổ vào datagrid
                DataGridViewCellStyle style = datagvNhanVienThem.ColumnHeadersDefaultCellStyle;// Tô đậm header của cột
                style.Font = new Font(datagvNhanVienThem.Font, FontStyle.Bold);// Tô đậm header của cột
                style.BackColor = Color.Navy;
                style.ForeColor = Color.White;//Tô màu header
                Binding();
            }
            else if (txtmanvthem.Text != "" && txttennvthem.Text != "" && txtkhoathem.Text == "")
            {
                SqlConnection kn = new SqlConnection(@"Data Source=DESKTOP-RGHAECC;Initial Catalog=SucKhoeNhanVien_PNT;Integrated Security=True");
                kn.Open();
                string sql = "SELECT NhanVien.MaNV,NhanVien.TenNV,ChucVu.TenChucVu,Khoa.TenKhoa,NhanVien.CMND from NhanVien, ChucVu, Khoa where NhanVien.IdChucVu = ChucVu.IdChucVu And NhanVien.Khoa = Khoa.IdKhoa And NhanVien.MaNV like '%" + txtmanvthem.Text.Trim() + "%' And NhanVien.TenNV like N'%" + txttennvthem.Text.Trim() + "%'";
                SqlCommand commandsql = new SqlCommand(sql, kn);//thực thi các chức năng câu lệnh trong sql 
                SqlDataAdapter com = new SqlDataAdapter(commandsql);// vận chuyển dữ liệu
                DataTable table = new DataTable();//tạo một bảng ảo trong hện thống
                com.Fill(table);// đổ dữ liệu vào bảng ảo
                datagvNhanVienThem.DataSource = table; //bảng ảo này đc đổ vào datagrid
                DataGridViewCellStyle style = datagvNhanVienThem.ColumnHeadersDefaultCellStyle;// Tô đậm header của cột
                style.Font = new Font(datagvNhanVienThem.Font, FontStyle.Bold);// Tô đậm header của cột
                style.BackColor = Color.Navy;
                style.ForeColor = Color.White;//Tô màu header
                Binding();
            }
            else if (txtmanvthem.Text != "" && txttennvthem.Text == "" && txtkhoathem.Text != "")
            {
                SqlConnection kn = new SqlConnection(@"Data Source=DESKTOP-RGHAECC;Initial Catalog=SucKhoeNhanVien_PNT;Integrated Security=True");
                kn.Open();
                string sql = "SELECT NhanVien.MaNV,NhanVien.TenNV,ChucVu.TenChucVu,Khoa.TenKhoa,NhanVien.CMND from NhanVien, ChucVu, Khoa where NhanVien.IdChucVu = ChucVu.IdChucVu And NhanVien.Khoa = Khoa.IdKhoa And NhanVien.MaNV like '%" + txtmanvthem.Text.Trim() + "%' And Khoa.TenKhoa like N'%" + txtkhoathem.Text.Trim() + "%'";
                SqlCommand commandsql = new SqlCommand(sql, kn);//thực thi các chức năng câu lệnh trong sql 
                SqlDataAdapter com = new SqlDataAdapter(commandsql);// vận chuyển dữ liệu
                DataTable table = new DataTable();//tạo một bảng ảo trong hện thống
                com.Fill(table);// đổ dữ liệu vào bảng ảo
                datagvNhanVienThem.DataSource = table; //bảng ảo này đc đổ vào datagrid
                DataGridViewCellStyle style = datagvNhanVienThem.ColumnHeadersDefaultCellStyle;// Tô đậm header của cột
                style.Font = new Font(datagvNhanVienThem.Font, FontStyle.Bold);// Tô đậm header của cột
                style.BackColor = Color.Navy;
                style.ForeColor = Color.White;//Tô màu header
                Binding();
            }
            else if (txtmanvthem.Text == "" && txttennvthem.Text != "" && txtkhoathem.Text != "")
            {
                SqlConnection kn = new SqlConnection(@"Data Source=DESKTOP-RGHAECC;Initial Catalog=SucKhoeNhanVien_PNT;Integrated Security=True");
                kn.Open();
                string sql = "SELECT NhanVien.MaNV,NhanVien.TenNV,ChucVu.TenChucVu,Khoa.TenKhoa,NhanVien.CMND from NhanVien, ChucVu, Khoa where NhanVien.IdChucVu = ChucVu.IdChucVu And NhanVien.Khoa = Khoa.IdKhoa And NhanVien.TenNV like '%" + txttennvthem.Text.Trim() + "%' And Khoa.TenKhoa like N'%" + txtkhoathem.Text.Trim() + "%'";
                SqlCommand commandsql = new SqlCommand(sql, kn);//thực thi các chức năng câu lệnh trong sql 
                SqlDataAdapter com = new SqlDataAdapter(commandsql);// vận chuyển dữ liệu
                DataTable table = new DataTable();//tạo một bảng ảo trong hện thống
                com.Fill(table);// đổ dữ liệu vào bảng ảo
                datagvNhanVienThem.DataSource = table; //bảng ảo này đc đổ vào datagrid
                DataGridViewCellStyle style = datagvNhanVienThem.ColumnHeadersDefaultCellStyle;// Tô đậm header của cột
                style.Font = new Font(datagvNhanVienThem.Font, FontStyle.Bold);// Tô đậm header của cột
                style.BackColor = Color.Navy;
                style.ForeColor = Color.White;//Tô màu header
                Binding();
            }
            else if (txtmanvthem.Text != "" && txttennvthem.Text != "" && txtkhoathem.Text != "")
            {
                SqlConnection kn = new SqlConnection(@"Data Source=DESKTOP-RGHAECC;Initial Catalog=SucKhoeNhanVien_PNT;Integrated Security=True");
                kn.Open();
                string sql = "SELECT NhanVien.MaNV,NhanVien.TenNV,ChucVu.TenChucVu,Khoa.TenKhoa,NhanVien.CMND from NhanVien, ChucVu, Khoa where NhanVien.IdChucVu = ChucVu.IdChucVu And NhanVien.Khoa = Khoa.IdKhoa And NhanVien.MaNV like N'%" + txtmanvthem.Text.Trim() + "%' And NhanVien.TenNV like N'%" + txttennvthem.Text.Trim() + "%' And Khoa.TenKhoa like N'%" + txtkhoathem.Text.Trim() + "%' ";
                SqlCommand commandsql = new SqlCommand(sql, kn);//thực thi các chức năng câu lệnh trong sql 
                SqlDataAdapter com = new SqlDataAdapter(commandsql);// vận chuyển dữ liệu
                DataTable table = new DataTable();//tạo một bảng ảo trong hện thống
                com.Fill(table);// đổ dữ liệu vào bảng ảo
                datagvNhanVienThem.DataSource = table; //bảng ảo này đc đổ vào datagrid
                DataGridViewCellStyle style = datagvNhanVienThem.ColumnHeadersDefaultCellStyle;// Tô đậm header của cột
                style.Font = new Font(datagvNhanVienThem.Font, FontStyle.Bold);// Tô đậm header của cột
                style.BackColor = Color.Navy;
                style.ForeColor = Color.White;//Tô màu header
                Binding();
            }
        }

        private void btthem_Click(object sender, EventArgs e)
        {
            //Kiểm tra form đã tồn tại chưa
            FrThemSKNhanVien fc = Application.OpenForms["FrThemSKNhanVien"] != null ? (FrThemSKNhanVien)Application.OpenForms["FrThemSKNhanVien"] : null;
            if (fc != null)
            {
                fc.Activate();
            }
            //form is visible
            else
            {
                FrThemSKNhanVien frthem = new FrThemSKNhanVien(txtmanvthem.Text);
                frthem.ShowDialog();
            }
        }
    }
}
