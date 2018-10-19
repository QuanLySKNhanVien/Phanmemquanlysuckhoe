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
    public partial class QuanLyNhanVien : Form
    {
        public QuanLyNhanVien()
        {
            InitializeComponent();
            ketnoi();
        }
        private void QuanLyNhanVien_Load(object sender, EventArgs e)
        {
        }
        // Kết nối cơ sở dữ liệu
        public void ketnoi()
        {
            try
            {
                SqlConnection kn = new SqlConnection(@"Data Source=DESKTOP-RGHAECC;Initial Catalog=SucKhoeNhanVien_PNT;Integrated Security=True");                                               
                kn.Open();
                string sql = "SELECT NhanVien.MaNV,NhanVien.TenNV,GioiTinh.TenGT,ChucVu.TenChucVu,Khoa.TenKhoa,NhanVien.CMND from NhanVien, ChucVu, Khoa,GioiTinh where NhanVien.IdChucVu = ChucVu.IdChucVu And NhanVien.Khoa = Khoa.IdKhoa";
                SqlCommand commandsql = new SqlCommand(sql, kn);//thực thi các chức năng câu lệnh trong sql 
                SqlDataAdapter com = new SqlDataAdapter(commandsql);// vận chuyển dữ liệu
                DataTable table = new DataTable();//tạo một bảng ảo trong hện thống
                com.Fill(table);// đổ dữ liệu vào bảng ảo
                datagvNhanVien.DataSource = table; //bảng ảo này đc đổ vào datagrid
                datagvNhanVien.Columns[0].HeaderText = "Mã Nhân Viên";
                datagvNhanVien.Columns[1].HeaderText = "Tên Nhân Viên";
                datagvNhanVien.Columns[2].HeaderText = "Giới Tính";
                datagvNhanVien.Columns[3].HeaderText = "Chức Vụ";
                datagvNhanVien.Columns[4].HeaderText = "Khoa/Phòng Ban";
                datagvNhanVien.Columns[5].HeaderText = "CMND";
                DataGridViewCellStyle style = datagvNhanVien.ColumnHeadersDefaultCellStyle;// Tô đậm header của cột
                style.Font = new Font(datagvNhanVien.Font, FontStyle.Bold);// Tô đậm header của cột
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
        //Lấy dữ liệu đổ lên textbox
        public void Binding()
        {
            txtmanv.DataBindings.Clear();// xóa dữ liệu hiện tại trong textbox
            txtmanv.DataBindings.Add("Text",datagvNhanVien.DataSource, "MaNV");//lấy dữ liệu đưa vào textbox
            txttennv.DataBindings.Clear();
            txttennv.DataBindings.Add("Text", datagvNhanVien.DataSource, "TenNV");
            txtkhoa.DataBindings.Clear();
            txtkhoa.DataBindings.Add("Text", datagvNhanVien.DataSource, "TenKhoa");
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
            if (txtmanv.Text != "" && txttennv.Text == "" && txtkhoa.Text == "")
            {
                SqlConnection kn = new SqlConnection(@"Data Source=DESKTOP-RGHAECC;Initial Catalog=SucKhoeNhanVien_PNT;Integrated Security=True");
                kn.Open();
                string sql = "SELECT NhanVien.MaNV,NhanVien.TenNV,ChucVu.TenChucVu,Khoa.TenKhoa,NhanVien.CMND from NhanVien, ChucVu, Khoa where NhanVien.IdChucVu = ChucVu.IdChucVu And NhanVien.Khoa = Khoa.IdKhoa And NhanVien.MaNV like N'%" + txtmanv.Text.Trim() + "%' ";
                SqlCommand commandsql = new SqlCommand(sql, kn);//thực thi các chức năng câu lệnh trong sql 
                SqlDataAdapter com = new SqlDataAdapter(commandsql);// vận chuyển dữ liệu
                DataTable table = new DataTable();//tạo một bảng ảo trong hện thống
                com.Fill(table);// đổ dữ liệu vào bảng ảo
                datagvNhanVien.DataSource = table; //bảng ảo này đc đổ vào datagrid
                DataGridViewCellStyle style = datagvNhanVien.ColumnHeadersDefaultCellStyle;// Tô đậm header của cột
                style.Font = new Font(datagvNhanVien.Font, FontStyle.Bold);// Tô đậm header của cột
                style.BackColor = Color.Navy;
                style.ForeColor = Color.White;//Tô màu header
                Binding();
            }
            else if (txtmanv.Text == "" && txttennv.Text != "" && txtkhoa.Text == "")
            {
                SqlConnection kn = new SqlConnection(@"Data Source=DESKTOP-RGHAECC;Initial Catalog=SucKhoeNhanVien_PNT;Integrated Security=True");
                kn.Open();
                string sql = "SELECT NhanVien.MaNV,NhanVien.TenNV,ChucVu.TenChucVu,Khoa.TenKhoa,NhanVien.CMND from NhanVien, ChucVu, Khoa where NhanVien.IdChucVu = ChucVu.IdChucVu And NhanVien.Khoa = Khoa.IdKhoa And NhanVien.TenNV like N'%" + txttennv.Text.Trim() + "%' ";
                SqlCommand commandsql = new SqlCommand(sql, kn);//thực thi các chức năng câu lệnh trong sql 
                SqlDataAdapter com = new SqlDataAdapter(commandsql);// vận chuyển dữ liệu
                DataTable table = new DataTable();//tạo một bảng ảo trong hện thống
                com.Fill(table);// đổ dữ liệu vào bảng ảo
                datagvNhanVien.DataSource = table; //bảng ảo này đc đổ vào datagrid
                DataGridViewCellStyle style = datagvNhanVien.ColumnHeadersDefaultCellStyle;// Tô đậm header của cột
                style.Font = new Font(datagvNhanVien.Font, FontStyle.Bold);// Tô đậm header của cột
                style.BackColor = Color.Navy;
                style.ForeColor = Color.White;//Tô màu header
                Binding();
            }
           else if (txtmanv.Text == "" && txttennv.Text == "" && txtkhoa.Text != "")
            {
                SqlConnection kn = new SqlConnection(@"Data Source=DESKTOP-RGHAECC;Initial Catalog=SucKhoeNhanVien_PNT;Integrated Security=True");
                kn.Open();
                string sql = "SELECT NhanVien.MaNV,NhanVien.TenNV,ChucVu.TenChucVu,Khoa.TenKhoa,NhanVien.CMND from NhanVien, ChucVu, Khoa where NhanVien.IdChucVu = ChucVu.IdChucVu And NhanVien.Khoa = Khoa.IdKhoa And Khoa.TenKhoa like N'%" + txtkhoa.Text.Trim() + "%' ";
                SqlCommand commandsql = new SqlCommand(sql, kn);//thực thi các chức năng câu lệnh trong sql 
                SqlDataAdapter com = new SqlDataAdapter(commandsql);// vận chuyển dữ liệu
                DataTable table = new DataTable();//tạo một bảng ảo trong hện thống
                com.Fill(table);// đổ dữ liệu vào bảng ảo
                datagvNhanVien.DataSource = table; //bảng ảo này đc đổ vào datagrid
                DataGridViewCellStyle style = datagvNhanVien.ColumnHeadersDefaultCellStyle;// Tô đậm header của cột
                style.Font = new Font(datagvNhanVien.Font, FontStyle.Bold);// Tô đậm header của cột
                style.BackColor = Color.Navy;
                style.ForeColor = Color.White;//Tô màu header
                Binding();
            }
            else if (txtmanv.Text != "" && txttennv.Text != "" && txtkhoa.Text == "")
            {
                SqlConnection kn = new SqlConnection(@"Data Source=DESKTOP-RGHAECC;Initial Catalog=SucKhoeNhanVien_PNT;Integrated Security=True");
                kn.Open();
                string sql = "SELECT NhanVien.MaNV,NhanVien.TenNV,ChucVu.TenChucVu,Khoa.TenKhoa,NhanVien.CMND from NhanVien, ChucVu, Khoa where NhanVien.IdChucVu = ChucVu.IdChucVu And NhanVien.Khoa = Khoa.IdKhoa And NhanVien.MaNV like '%" + txtmanv.Text.Trim() + "%' And NhanVien.TenNV like N'%" + txttennv.Text.Trim() + "%'";
                SqlCommand commandsql = new SqlCommand(sql, kn);//thực thi các chức năng câu lệnh trong sql 
                SqlDataAdapter com = new SqlDataAdapter(commandsql);// vận chuyển dữ liệu
                DataTable table = new DataTable();//tạo một bảng ảo trong hện thống
                com.Fill(table);// đổ dữ liệu vào bảng ảo
                datagvNhanVien.DataSource = table; //bảng ảo này đc đổ vào datagrid
                DataGridViewCellStyle style = datagvNhanVien.ColumnHeadersDefaultCellStyle;// Tô đậm header của cột
                style.Font = new Font(datagvNhanVien.Font, FontStyle.Bold);// Tô đậm header của cột
                style.BackColor = Color.Navy;
                style.ForeColor = Color.White;//Tô màu header
                Binding();
            }
            else if (txtmanv.Text != "" && txttennv.Text == "" && txtkhoa.Text != "")
            {
                SqlConnection kn = new SqlConnection(@"Data Source=DESKTOP-RGHAECC;Initial Catalog=SucKhoeNhanVien_PNT;Integrated Security=True");
                kn.Open();
                string sql = "SELECT NhanVien.MaNV,NhanVien.TenNV,ChucVu.TenChucVu,Khoa.TenKhoa,NhanVien.CMND from NhanVien, ChucVu, Khoa where NhanVien.IdChucVu = ChucVu.IdChucVu And NhanVien.Khoa = Khoa.IdKhoa And NhanVien.MaNV like '%" + txtmanv.Text.Trim() + "%' And Khoa.TenKhoa like N'%" + txtkhoa.Text.Trim() + "%'";
                SqlCommand commandsql = new SqlCommand(sql, kn);//thực thi các chức năng câu lệnh trong sql 
                SqlDataAdapter com = new SqlDataAdapter(commandsql);// vận chuyển dữ liệu
                DataTable table = new DataTable();//tạo một bảng ảo trong hện thống
                com.Fill(table);// đổ dữ liệu vào bảng ảo
                datagvNhanVien.DataSource = table; //bảng ảo này đc đổ vào datagrid
                DataGridViewCellStyle style = datagvNhanVien.ColumnHeadersDefaultCellStyle;// Tô đậm header của cột
                style.Font = new Font(datagvNhanVien.Font, FontStyle.Bold);// Tô đậm header của cột
                style.BackColor = Color.Navy;
                style.ForeColor = Color.White;//Tô màu header
                Binding();
            }
            else if (txtmanv.Text == "" && txttennv.Text != "" && txtkhoa.Text != "")
            {
                SqlConnection kn = new SqlConnection(@"Data Source=DESKTOP-RGHAECC;Initial Catalog=SucKhoeNhanVien_PNT;Integrated Security=True");
                kn.Open();
                string sql = "SELECT NhanVien.MaNV,NhanVien.TenNV,ChucVu.TenChucVu,Khoa.TenKhoa,NhanVien.CMND from NhanVien, ChucVu, Khoa where NhanVien.IdChucVu = ChucVu.IdChucVu And NhanVien.Khoa = Khoa.IdKhoa And NhanVien.TenNV like '%" + txttennv.Text.Trim() + "%' And Khoa.TenKhoa like N'%" + txtkhoa.Text.Trim() + "%'";
                SqlCommand commandsql = new SqlCommand(sql, kn);//thực thi các chức năng câu lệnh trong sql 
                SqlDataAdapter com = new SqlDataAdapter(commandsql);// vận chuyển dữ liệu
                DataTable table = new DataTable();//tạo một bảng ảo trong hện thống
                com.Fill(table);// đổ dữ liệu vào bảng ảo
                datagvNhanVien.DataSource = table; //bảng ảo này đc đổ vào datagrid
                DataGridViewCellStyle style = datagvNhanVien.ColumnHeadersDefaultCellStyle;// Tô đậm header của cột
                style.Font = new Font(datagvNhanVien.Font, FontStyle.Bold);// Tô đậm header của cột
                style.BackColor = Color.Navy;
                style.ForeColor = Color.White;//Tô màu header
                Binding();
            }
             else if(txtmanv.Text != "" && txttennv.Text != "" && txtkhoa.Text != "")
            {
                SqlConnection kn = new SqlConnection(@"Data Source=DESKTOP-RGHAECC;Initial Catalog=SucKhoeNhanVien_PNT;Integrated Security=True");
                kn.Open();
                string sql = "SELECT NhanVien.MaNV,NhanVien.TenNV,ChucVu.TenChucVu,Khoa.TenKhoa,NhanVien.CMND from NhanVien, ChucVu, Khoa where NhanVien.IdChucVu = ChucVu.IdChucVu And NhanVien.Khoa = Khoa.IdKhoa And NhanVien.MaNV like N'%" + txtmanv.Text.Trim() + "%' And NhanVien.TenNV like N'%" + txttennv.Text.Trim() + "%' And Khoa.TenKhoa like N'%" + txtkhoa.Text.Trim() + "%' ";
                SqlCommand commandsql = new SqlCommand(sql, kn);//thực thi các chức năng câu lệnh trong sql 
                SqlDataAdapter com = new SqlDataAdapter(commandsql);// vận chuyển dữ liệu
                DataTable table = new DataTable();//tạo một bảng ảo trong hện thống
                com.Fill(table);// đổ dữ liệu vào bảng ảo
                datagvNhanVien.DataSource = table; //bảng ảo này đc đổ vào datagrid
                DataGridViewCellStyle style = datagvNhanVien.ColumnHeadersDefaultCellStyle;// Tô đậm header của cột
                style.Font = new Font(datagvNhanVien.Font, FontStyle.Bold);// Tô đậm header của cột
                style.BackColor = Color.Navy;
                style.ForeColor = Color.White;//Tô màu header
                Binding();
            }
        }
     
        // Hàm load lại dữ liệu
        private void btlammoi_Click(object sender, EventArgs e)
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
                datagvNhanVien.DataSource = table; //bảng ảo này đc đổ vào datagrid
                datagvNhanVien.Columns[0].HeaderText = "Mã Nhân Viên";
                datagvNhanVien.Columns[1].HeaderText = "Tên Nhân Viên";
                datagvNhanVien.Columns[2].HeaderText = "Chức Vụ";
                datagvNhanVien.Columns[3].HeaderText = "Khoa/Phòng Ban";
                datagvNhanVien.Columns[4].HeaderText = "CMND";
                DataGridViewCellStyle style = datagvNhanVien.ColumnHeadersDefaultCellStyle;// Tô đậm header của cột
                style.Font = new Font(datagvNhanVien.Font, FontStyle.Bold);// Tô đậm header của cột
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

        // Hàm thêm nhân viên
        private void btthem_Click(object sender, EventArgs e)
        {
            //Kiểm tra form đã tồn tại chưa
            FrThemNV fc = Application.OpenForms["FrThemNV"] != null ? (FrThemNV)Application.OpenForms["FrThemNV"] : null;
            if (fc != null)
            {
                fc.Activate();
            }
            //form is visible
            else
            {
                FrThemNV frthem = new FrThemNV();
                frthem.Show();
            }

        }


        private void btsua_Click(object sender, EventArgs e)
        {
            FrSuaNV frsuanv = new FrSuaNV(txtmanv.Text);
            frsuanv.ShowDialog();
        }

        private void btxoa_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection kn = new SqlConnection(@"Data Source=DESKTOP-RGHAECC;Initial Catalog=SucKhoeNhanVien_PNT;Integrated Security=True");
                kn.Open();
                string sql = "DELETE from NhanVien where MaNV like N'" + txtmanv.Text + "'";
                SqlCommand commandsql = new SqlCommand(sql, kn);//thực thi các chức năng câu lệnh trong sql 
                SqlDataAdapter comthem = new SqlDataAdapter(commandsql);// vận chuyển dữ liệu
                commandsql.ExecuteNonQuery();
                MessageBox.Show("Xóa thành công");
            }
            catch
            {
                MessageBox.Show("Không xóa được dữ liệu");
            }

        }
    }
}
