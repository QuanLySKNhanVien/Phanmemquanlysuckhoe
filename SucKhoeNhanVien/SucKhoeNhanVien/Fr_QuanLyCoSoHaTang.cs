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
using System.IO;
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using xl = Microsoft.Office.Interop.Excel;

namespace SucKhoeNhanVien
{
    public partial class Fr_QuanLyCoSoHaTang : Form
    {
        public Fr_QuanLyCoSoHaTang()
        {
            InitializeComponent();
            ketnoi();
        }
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
        // Kết nối cơ sở dữ liệu
        public void ketnoi()
        {
            try
            {
                SqlConnection kn = new SqlConnection(@"Data Source=DESKTOP-RGHAECC;Initial Catalog=SucKhoeNhanVien_PNT;Integrated Security=True");
                kn.Open();
                string sql = "Select QuanLyXe_TaiXe.Id_LichSuLaiXe,QuanLyXe_TaiXe.Id_Xe,XeCuuThuong.BienSoXe,XeCuuThuong.Ngaycap,QuanLyXe_TaiXe.NgayNhan,QuanLyXe_TaiXe.TrangThaiNhan,QuanLyXe_TaiXe.NgayTra,QuanLyXe_TaiXe.TrangThaiGiao,QuanLyXe_TaiXe.TenNV from QuanLyXe_TaiXe, XeCuuThuong where QuanLyXe_TaiXe.Id_Xe = XeCuuThuong.ID_Xe";
                SqlCommand commandsql = new SqlCommand(sql, kn);//thực thi các chức năng câu lệnh trong sql 
                SqlDataAdapter com = new SqlDataAdapter(commandsql);// vận chuyển dữ liệu
                System.Data.DataTable table = new System.Data.DataTable();//tạo một bảng ảo trong hện thống
                com.Fill(table);// đổ dữ liệu vào bảng ảo
                datagvDSxe.DataSource = table; //bảng ảo này đc đổ vào datagrid
                datagvDSxe.Columns[0].HeaderText = "Stt";
                datagvDSxe.Columns[1].HeaderText = "ID Xe";
                datagvDSxe.Columns[2].HeaderText = "Biển Số Xe";
                datagvDSxe.Columns[3].HeaderText = "Ngày Cấp";
                datagvDSxe.Columns[4].HeaderText = "Ngày Nhận";
                datagvDSxe.Columns[5].HeaderText = "Trạng Thái Nhận";
                datagvDSxe.Columns[6].HeaderText = "Ngày Giao";
                datagvDSxe.Columns[7].HeaderText = "Trạng Thái Giao";
                datagvDSxe.Columns[8].HeaderText = "Tên Nhân Viên";
                

                DataGridViewCellStyle style = datagvDSxe.ColumnHeadersDefaultCellStyle;// Tô đậm header của cột
                style.Font = new System.Drawing.Font(datagvDSxe.Font, FontStyle.Bold);// Tô đậm header của cột
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
            txtmasoxe.DataBindings.Clear();// xóa dữ liệu hiện tại trong textbox
            txtmasoxe.DataBindings.Add("Text", datagvDSxe.DataSource, "BienSoXe");//lấy dữ liệu đưa vào textbox
            txttennv.DataBindings.Clear();
            txttennv.DataBindings.Add("Text", datagvDSxe.DataSource, "TenNV");
            txttrangthainhan.DataBindings.Clear();
            txttrangthainhan.DataBindings.Add("Text", datagvDSxe.DataSource, "TrangThaiNhan");
            txttrangthaigiao.DataBindings.Clear();
            txttrangthaigiao.DataBindings.Add("Text", datagvDSxe.DataSource, "TrangThaiGiao");
            txtidqlxe.DataBindings.Clear();
            txtidqlxe.DataBindings.Add("Text", datagvDSxe.DataSource, "Id_LichSuLaiXe");
        }

        private void btthem_Click(object sender, EventArgs e)
        {
            //Kiểm tra form đã tồn tại chưa
            ThemCoSoHaTang fc = System.Windows.Forms.Application.OpenForms["ThemCoSoHaTang"] != null ? (ThemCoSoHaTang)System.Windows.Forms.Application.OpenForms["ThemCoSoHaTang"] : null;
            if (fc != null)
            {
                fc.Activate();
            }
            //form is visible
            else
            {
                ThemCoSoHaTang frthem = new ThemCoSoHaTang();
                frthem.Show();
            }
        }

        private void btlammoi_Click(object sender, EventArgs e)
        {
            try
            {
                ketnoi();
            }
            catch
            {
                MessageBox.Show("Lỗi kết nối vui lòng kiểm tra lại");
            }
        }

        private void bttim_Click(object sender, EventArgs e)
        {
            if (txtmasoxe.Text != "" && txttennv.Text == "" && txttrangthaigiao.Text == "" && txttrangthainhan.Text == "")
            {
                SqlConnection kn = new SqlConnection(@"Data Source=DESKTOP-RGHAECC;Initial Catalog=SucKhoeNhanVien_PNT;Integrated Security=True");
                kn.Open();
                string sql = "Select QuanLyXe_TaiXe.Id_LichSuLaiXe,QuanLyXe_TaiXe.Id_Xe,XeCuuThuong.BienSoXe,XeCuuThuong.Ngaycap,QuanLyXe_TaiXe.NgayNhan,QuanLyXe_TaiXe.TrangThaiNhan,QuanLyXe_TaiXe.NgayTra,QuanLyXe_TaiXe.TrangThaiGiao,QuanLyXe_TaiXe.TenNV from QuanLyXe_TaiXe, XeCuuThuong where QuanLyXe_TaiXe.Id_Xe = XeCuuThuong.ID_Xe And XeCuuThuong.BienSoXe like N'%" + txtmasoxe.Text.Trim() + "%' ";
                SqlCommand commandsql = new SqlCommand(sql, kn);//thực thi các chức năng câu lệnh trong sql 
                SqlDataAdapter com = new SqlDataAdapter(commandsql);// vận chuyển dữ liệu
                System.Data.DataTable table = new System.Data.DataTable();//tạo một bảng ảo trong hện thống
                com.Fill(table);// đổ dữ liệu vào bảng ảo
                datagvDSxe.DataSource = table; //bảng ảo này đc đổ vào datagrid
                DataGridViewCellStyle style = datagvDSxe.ColumnHeadersDefaultCellStyle;// Tô đậm header của cột
                style.Font = new System.Drawing.Font(datagvDSxe.Font, FontStyle.Bold);// Tô đậm header của cột
                style.BackColor = Color.Navy;
                style.ForeColor = Color.White;//Tô màu header
                Binding();
            }
            else if (txtmasoxe.Text == "" && txttennv.Text != "" && txttrangthaigiao.Text == "" && txttrangthainhan.Text == "")
            {
                SqlConnection kn = new SqlConnection(@"Data Source=DESKTOP-RGHAECC;Initial Catalog=SucKhoeNhanVien_PNT;Integrated Security=True");
                kn.Open();
                string sql = "Select QuanLyXe_TaiXe.Id_LichSuLaiXe,QuanLyXe_TaiXe.Id_Xe,XeCuuThuong.BienSoXe,XeCuuThuong.Ngaycap,QuanLyXe_TaiXe.NgayNhan,QuanLyXe_TaiXe.TrangThaiNhan,QuanLyXe_TaiXe.NgayTra,QuanLyXe_TaiXe.TrangThaiGiao,QuanLyXe_TaiXe.TenNV from QuanLyXe_TaiXe, XeCuuThuong where QuanLyXe_TaiXe.Id_Xe = XeCuuThuong.ID_Xe And QuanLyXe_TaiXe.TenNV like N'%" + txttennv.Text.Trim() + "%'  ";
                SqlCommand commandsql = new SqlCommand(sql, kn);//thực thi các chức năng câu lệnh trong sql 
                SqlDataAdapter com = new SqlDataAdapter(commandsql);// vận chuyển dữ liệu
                System.Data.DataTable table = new System.Data.DataTable();//tạo một bảng ảo trong hện thống
                com.Fill(table);// đổ dữ liệu vào bảng ảo
                datagvDSxe.DataSource = table; //bảng ảo này đc đổ vào datagrid
                DataGridViewCellStyle style = datagvDSxe.ColumnHeadersDefaultCellStyle;// Tô đậm header của cột
                style.Font = new System.Drawing.Font(datagvDSxe.Font, FontStyle.Bold);// Tô đậm header của cột
                style.BackColor = Color.Navy;
                style.ForeColor = Color.White;//Tô màu header
                Binding();
            }
            else if (txtmasoxe.Text == "" && txttennv.Text == "" && txttrangthaigiao.Text != "" && txttrangthainhan.Text == "")
            {
                SqlConnection kn = new SqlConnection(@"Data Source=DESKTOP-RGHAECC;Initial Catalog=SucKhoeNhanVien_PNT;Integrated Security=True");
                kn.Open();
                string sql = "Select QuanLyXe_TaiXe.Id_LichSuLaiXe,QuanLyXe_TaiXe.Id_Xe,XeCuuThuong.BienSoXe,XeCuuThuong.Ngaycap,QuanLyXe_TaiXe.NgayNhan,QuanLyXe_TaiXe.TrangThaiNhan,QuanLyXe_TaiXe.NgayTra,QuanLyXe_TaiXe.TrangThaiGiao,QuanLyXe_TaiXe.TenNV from QuanLyXe_TaiXe, XeCuuThuong where QuanLyXe_TaiXe.Id_Xe = XeCuuThuong.ID_Xe And QuanLyXe_TaiXe.TrangThaiGiao like N'%" + txttrangthaigiao.Text.Trim() + "%'  ";
                SqlCommand commandsql = new SqlCommand(sql, kn);//thực thi các chức năng câu lệnh trong sql 
                SqlDataAdapter com = new SqlDataAdapter(commandsql);// vận chuyển dữ liệu
                System.Data.DataTable table  = new System.Data.DataTable();//tạo một bảng ảo trong hện thống
                com.Fill(table);// đổ dữ liệu vào bảng ảo
                datagvDSxe.DataSource = table; //bảng ảo này đc đổ vào datagrid
                DataGridViewCellStyle style = datagvDSxe.ColumnHeadersDefaultCellStyle;// Tô đậm header của cột
                style.Font = new System.Drawing.Font(datagvDSxe.Font, FontStyle.Bold);// Tô đậm header của cột
                style.BackColor = Color.Navy;
                style.ForeColor = Color.White;//Tô màu header
                Binding();
            }
            else if (txtmasoxe.Text == "" && txttennv.Text == "" && txttrangthaigiao.Text == "" && txttrangthainhan.Text != "")
            {
                SqlConnection kn = new SqlConnection(@"Data Source=DESKTOP-RGHAECC;Initial Catalog=SucKhoeNhanVien_PNT;Integrated Security=True");
                kn.Open();
                string sql = "Select QuanLyXe_TaiXe.Id_LichSuLaiXe,QuanLyXe_TaiXe.Id_Xe,XeCuuThuong.BienSoXe,XeCuuThuong.Ngaycap,QuanLyXe_TaiXe.NgayNhan,QuanLyXe_TaiXe.TrangThaiNhan,QuanLyXe_TaiXe.NgayTra,QuanLyXe_TaiXe.TrangThaiGiao,QuanLyXe_TaiXe.TenNV from QuanLyXe_TaiXe, XeCuuThuong where QuanLyXe_TaiXe.Id_Xe = XeCuuThuong.ID_Xe And QuanLyXe_TaiXe.TrangThaiNhan like N'%" + txttrangthainhan.Text.Trim() + "%' ";
                SqlCommand commandsql = new SqlCommand(sql, kn);//thực thi các chức năng câu lệnh trong sql 
                SqlDataAdapter com = new SqlDataAdapter(commandsql);// vận chuyển dữ liệu
                System.Data.DataTable table = new System.Data.DataTable();//tạo một bảng ảo trong hện thống
                com.Fill(table);// đổ dữ liệu vào bảng ảo
                datagvDSxe.DataSource = table; //bảng ảo này đc đổ vào datagrid
                DataGridViewCellStyle style = datagvDSxe.ColumnHeadersDefaultCellStyle;// Tô đậm header của cột
                style.Font = new System.Drawing.Font(datagvDSxe.Font, FontStyle.Bold);// Tô đậm header của cột
                style.BackColor = Color.Navy;
                style.ForeColor = Color.White;//Tô màu header
                Binding();
            }
          
        }
        
        private void btsua_Click(object sender, EventArgs e)
        {
            Fr_SuaQuanLyXe frsuaqlx = new Fr_SuaQuanLyXe(txtidqlxe.Text);
            frsuaqlx.ShowDialog();
        }

        private void bt_baocao_Click(object sender, EventArgs e)
        {
            string conString = @"Data Source=DESKTOP-RGHAECC;Initial Catalog=SucKhoeNhanVien_PNT;Integrated Security=True";
            SqlConnection sqlCon = new SqlConnection(conString);
            sqlCon.Open();

            SqlDataAdapter da = new SqlDataAdapter("Select QuanLyXe_TaiXe.Id_LichSuLaiXe,QuanLyXe_TaiXe.Id_Xe,XeCuuThuong.BienSoXe,XeCuuThuong.Ngaycap,QuanLyXe_TaiXe.NgayNhan,QuanLyXe_TaiXe.TrangThaiNhan,QuanLyXe_TaiXe.NgayTra,QuanLyXe_TaiXe.TrangThaiGiao,QuanLyXe_TaiXe.TenNV from QuanLyXe_TaiXe, XeCuuThuong where QuanLyXe_TaiXe.Id_Xe = XeCuuThuong.ID_Xe", sqlCon);
            System.Data.DataTable dtMainSQLData = new System.Data.DataTable();
            da.Fill(dtMainSQLData);
            DataColumnCollection dcCollection = dtMainSQLData.Columns;
            // Export Data into EXCEL Sheet
            Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
            ExcelApp.Application.Workbooks.Add(Type.Missing);
            ExcelApp.Columns.ColumnWidth = 20;

            // ExcelApp.Cells.CopyFromRecordset(objRS);
            for (int i = 1; i < dtMainSQLData.Rows.Count + 2; i++)
            {

                for (int j = 1; j < dtMainSQLData.Columns.Count + 1; j++)
                {

                    if (i == 1)
                    {
                        ExcelApp.Cells[i, j] = dcCollection[j - 1].ToString();
                        ExcelApp.Cells[i, j].Font.Bold = true;
                        ExcelApp.Cells[i, j].HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                        Microsoft.Office.Interop.Excel.Range formatRange;
                        Microsoft.Office.Interop.Excel.Borders border = ExcelApp.Cells[i, j].Borders;
                        formatRange = ExcelApp.Cells[i, j];
                        formatRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.CornflowerBlue);

                    }

                    else
                        ExcelApp.Cells[i, j] = dtMainSQLData.Rows[i - 2][j - 1].ToString();
                    ExcelApp.Cells[i, j].HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlLeft;
                    ExcelApp.Cells[i, j].Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                    ExcelApp.Cells[i, j].Style.Wraptext = true;

                }
            }
            ExcelApp.ActiveWorkbook.SaveCopyAs("C:\\Users\\Oanh\\Desktop\\BaoCaoCSHaTang.xls");
            ExcelApp.ActiveWorkbook.Saved = true;
            ExcelApp.Quit();
            MessageBox.Show("Done");
        }
    }
   }


