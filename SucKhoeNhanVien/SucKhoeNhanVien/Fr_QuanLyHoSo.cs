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
using Spire.Xls;
namespace SucKhoeNhanVien
{
    public partial class Fr_QuanLyHoSo : Form
    {
        public Fr_QuanLyHoSo()
        {
            /*
            //de tam day ti Oanh xoa nha, thu xem chay dc chua thoi.
            //Create a new workbook
            Spire.Xls.Workbook workbook = new Spire.Xls.Workbook();

            //Initialize worksheet
            workbook.CreateEmptySheets(1);
            Spire.Xls.Worksheet sheet = workbook.Worksheets[0];

            //Set sheet name
            sheet.Name = "Chart data";

            //Set the grid lines invisible
            sheet.GridLinesVisible = false;

            //Create a chart
            Spire.Xls.Chart chart = sheet.Charts.Add(ExcelChartType.Pie3D);

            //Set region of chart data
            chart.DataRange = sheet.Range["B2:B5"];
            chart.SeriesDataFromRange = false;

            //Set position of chart
            chart.LeftColumn = 1;
            chart.TopRow = 6;
            chart.RightColumn = 9;
            chart.BottomRow = 25;

            //Chart title
            chart.ChartTitle = "Sales by year";
            chart.ChartTitleArea.IsBold = true;
            chart.ChartTitleArea.Size = 12;

            //Initialize the chart series
            Spire.Xls.Charts.ChartSerie cs = chart.Series[0];

            //Chart Labels resource
            cs.CategoryLabels = sheet.Range["A2:A5"];

            //Chart value resource
            cs.Values = sheet.Range["B2:B5"];

            //Set the value visible in the chart
            cs.DataPoints.DefaultDataPoint.DataLabels.HasValue = true;

            //Year
            sheet.Range["A1"].Value = "Year";
            sheet.Range["A2"].Value = "2002";
            sheet.Range["A3"].Value = "2003";
            sheet.Range["A4"].Value = "2004";
            sheet.Range["A5"].Value = "2005";

            //Sales
            sheet.Range["B1"].Value = "Sales";
            sheet.Range["B2"].NumberValue = 4000;
            sheet.Range["B3"].NumberValue = 6000;
            sheet.Range["B4"].NumberValue = 7000;
            sheet.Range["B5"].NumberValue = 8500;

            //Style
            sheet.Range["A1:B1"].Style.Font.IsBold = true;
            sheet.Range["A2:B2"].Style.KnownColor = ExcelColors.LightYellow;
            sheet.Range["A3:B3"].Style.KnownColor = ExcelColors.LightGreen1;
            sheet.Range["A4:B4"].Style.KnownColor = ExcelColors.LightOrange;
            sheet.Range["A5:B5"].Style.KnownColor = ExcelColors.LightTurquoise;

            //Border
            sheet.Range["A1:B5"].Style.Borders[BordersLineType.EdgeTop].Color = Color.FromArgb(0, 0, 128);
            sheet.Range["A1:B5"].Style.Borders[BordersLineType.EdgeTop].LineStyle = LineStyleType.Thin;
            sheet.Range["A1:B5"].Style.Borders[BordersLineType.EdgeBottom].Color = Color.FromArgb(0, 0, 128);
            sheet.Range["A1:B5"].Style.Borders[BordersLineType.EdgeBottom].LineStyle = LineStyleType.Thin;
            sheet.Range["A1:B5"].Style.Borders[BordersLineType.EdgeLeft].Color = Color.FromArgb(0, 0, 128);
            sheet.Range["A1:B5"].Style.Borders[BordersLineType.EdgeLeft].LineStyle = LineStyleType.Thin;
            sheet.Range["A1:B5"].Style.Borders[BordersLineType.EdgeRight].Color = Color.FromArgb(0, 0, 128);
            sheet.Range["A1:B5"].Style.Borders[BordersLineType.EdgeRight].LineStyle = LineStyleType.Thin;

            //Number format
            sheet.Range["B2:C5"].Style.NumberFormat = "\"$\"#,##0";
            chart.PlotArea.Fill.Visible = false;

            //Save the file
            workbook.SaveToFile("Sample.xls", ExcelVersion.Version97to2003);

            //Launch the file
            System.Diagnostics.Process.Start("Sample.xls");
            */


            InitializeComponent();
            ketnoi();
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
        // Kết nối cơ sở dữ liệu
        public void ketnoi()
        {
            try
            {
                SqlConnection kn = new SqlConnection(@"Data Source=DESKTOP-RGHAECC;Initial Catalog=SucKhoeNhanVien_PNT;Integrated Security=True");
                kn.Open();
                string sql = "SELECT NhanVien.MaNV,NhanVien.TenNV,Khoa.TenKhoa,LichSuBenh.NgayKham,LichSuBenh.PhanLoaiSK,LichSuBenh.BenhKhac,LichSuBenh.Id_LichSuBenh from NhanVien, LichSuBenh, Khoa where NhanVien.IdNhanVien = LichSuBenh.IdNhanVien And NhanVien.Khoa = Khoa.IdKhoa";
                SqlCommand commandsql = new SqlCommand(sql, kn);//thực thi các chức năng câu lệnh trong sql 
                SqlDataAdapter com = new SqlDataAdapter(commandsql);// vận chuyển dữ liệu
                System.Data.DataTable table = new System.Data.DataTable();//tạo một bảng ảo trong hện thống
                com.Fill(table);// đổ dữ liệu vào bảng ảo
                datagvSKNhanVien.DataSource = table; //bảng ảo này đc đổ vào datagrid
                datagvSKNhanVien.Columns[0].HeaderText = "Mã Nhân Viên";
                datagvSKNhanVien.Columns[1].HeaderText = "Tên Nhân Viên";
                datagvSKNhanVien.Columns[2].HeaderText = "Khoa/Phòng Ban";
                datagvSKNhanVien.Columns[3].HeaderText = "Ngày Khám";
                datagvSKNhanVien.Columns[4].HeaderText = "Phân Loại Sức Khỏe";
                datagvSKNhanVien.Columns[5].HeaderText = "Bệnh khác";
                DataGridViewCellStyle style = datagvSKNhanVien.ColumnHeadersDefaultCellStyle;// Tô đậm header của cột
                style.Font = new System.Drawing.Font(datagvSKNhanVien.Font, FontStyle.Bold);// Tô đậm header của cột
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
            txtmanv.DataBindings.Clear();// xóa dữ liệu hiện tại trong textbox
            txtmanv.DataBindings.Add("Text", datagvSKNhanVien.DataSource, "MaNV");//lấy dữ liệu đưa vào textbox
            txttennv.DataBindings.Clear();
            txttennv.DataBindings.Add("Text", datagvSKNhanVien.DataSource, "TenNV");
            txtkhoa.DataBindings.Clear();
            txtkhoa.DataBindings.Add("Text", datagvSKNhanVien.DataSource, "TenKhoa");
            dateTimePicker1.DataBindings.Clear();
            dateTimePicker1.DataBindings.Add("Text", datagvSKNhanVien.DataSource, "NgayKham");
            txtidLSB.DataBindings.Clear();
            txtidLSB.DataBindings.Add("Text", datagvSKNhanVien.DataSource, "Id_LichSuBenh");
        }

        private void btlammoi_Click(object sender, EventArgs e)
        {
            ketnoi();
        }

        private void btxem_Click(object sender, EventArgs e)
        {
            //Kiểm tra form đã tồn tại chưa
            XemHSSKNhanVien fc = System.Windows.Forms.Application.OpenForms["XemHSSKNhanVien"] != null ? (XemHSSKNhanVien)System.Windows.Forms.Application.OpenForms["XemHSSKNhanVien"] : null;
            if (fc != null)
            {
                fc.Activate();
            }
            //form is visible
            else
            {
                XemHSSKNhanVien frthem = new XemHSSKNhanVien(txtmanv.Text,dateTimePicker1.Text);
                frthem.ShowDialog();
            }
        }

        private void bttim_Click(object sender, EventArgs e)
        {
            if (txtmanv.Text != "" && txttennv.Text == "" && txtkhoa.Text == "")
            {
                SqlConnection kn = new SqlConnection(@"Data Source=DESKTOP-RGHAECC;Initial Catalog=SucKhoeNhanVien_PNT;Integrated Security=True");
                kn.Open();
                string sql = "SELECT NhanVien.MaNV,NhanVien.TenNV,Khoa.TenKhoa,LichSuBenh.NgayKham,LichSuBenh.PhanLoaiSK,LichSuBenh.BenhKhac from NhanVien, LichSuBenh, Khoa where NhanVien.IdNhanVien = LichSuBenh.IdNhanVien And NhanVien.Khoa = Khoa.IdKhoa And NhanVien.MaNV like N'%" + txtmanv.Text.Trim() + "%' ";
                SqlCommand commandsql = new SqlCommand(sql, kn);//thực thi các chức năng câu lệnh trong sql 
                SqlDataAdapter com = new SqlDataAdapter(commandsql);// vận chuyển dữ liệu
                System.Data.DataTable table = new System.Data.DataTable();//tạo một bảng ảo trong hện thống
                com.Fill(table);// đổ dữ liệu vào bảng ảo
                datagvSKNhanVien.DataSource = table; //bảng ảo này đc đổ vào datagrid
                DataGridViewCellStyle style = datagvSKNhanVien.ColumnHeadersDefaultCellStyle;// Tô đậm header của cột
                style.Font = new System.Drawing.Font(datagvSKNhanVien.Font, FontStyle.Bold);// Tô đậm header của cột
                style.BackColor = Color.Navy;
                style.ForeColor = Color.White;//Tô màu header
                Binding();
            }
            else if (txtmanv.Text == "" && txttennv.Text != "" && txtkhoa.Text == "")
            {
                SqlConnection kn = new SqlConnection(@"Data Source=DESKTOP-RGHAECC;Initial Catalog=SucKhoeNhanVien_PNT;Integrated Security=True");
                kn.Open();
                string sql = "SELECT NhanVien.MaNV,NhanVien.TenNV,Khoa.TenKhoa,LichSuBenh.NgayKham,LichSuBenh.PhanLoaiSK,LichSuBenh.BenhKhac from NhanVien, LichSuBenh, Khoa where NhanVien.IdNhanVien = LichSuBenh.IdNhanVien And NhanVien.Khoa = Khoa.IdKhoa And NhanVien.TenNV like N'%" + txttennv.Text.Trim() + "%' ";
                SqlCommand commandsql = new SqlCommand(sql, kn);//thực thi các chức năng câu lệnh trong sql 
                SqlDataAdapter com = new SqlDataAdapter(commandsql);// vận chuyển dữ liệu
                System.Data.DataTable table = new System.Data.DataTable();//tạo một bảng ảo trong hện thống
                com.Fill(table);// đổ dữ liệu vào bảng ảo
                datagvSKNhanVien.DataSource = table; //bảng ảo này đc đổ vào datagrid
                DataGridViewCellStyle style = datagvSKNhanVien.ColumnHeadersDefaultCellStyle;// Tô đậm header của cột
                style.Font = new System.Drawing.Font(datagvSKNhanVien.Font, FontStyle.Bold);// Tô đậm header của cột
                style.BackColor = Color.Navy;
                style.ForeColor = Color.White;//Tô màu header
                Binding();
            }
            else if (txtmanv.Text == "" && txttennv.Text == "" && txtkhoa.Text != "")
            {
                SqlConnection kn = new SqlConnection(@"Data Source=DESKTOP-RGHAECC;Initial Catalog=SucKhoeNhanVien_PNT;Integrated Security=True");
                kn.Open();
                string sql = "SELECT NhanVien.MaNV,NhanVien.TenNV,Khoa.TenKhoa,LichSuBenh.NgayKham,LichSuBenh.PhanLoaiSK,LichSuBenh.BenhKhac from NhanVien, LichSuBenh, Khoa where NhanVien.IdNhanVien = LichSuBenh.IdNhanVien And NhanVien.Khoa = Khoa.IdKhoa And Khoa.TenKhoa like N'%" + txtkhoa.Text.Trim() + "%' ";
                SqlCommand commandsql = new SqlCommand(sql, kn);//thực thi các chức năng câu lệnh trong sql 
                SqlDataAdapter com = new SqlDataAdapter(commandsql);// vận chuyển dữ liệu
                System.Data.DataTable table = new System.Data.DataTable();//tạo một bảng ảo trong hện thống
                com.Fill(table);// đổ dữ liệu vào bảng ảo
                datagvSKNhanVien.DataSource = table; //bảng ảo này đc đổ vào datagrid
                DataGridViewCellStyle style = datagvSKNhanVien.ColumnHeadersDefaultCellStyle;// Tô đậm header của cột
                style.Font = new System.Drawing.Font(datagvSKNhanVien.Font, FontStyle.Bold);// Tô đậm header của cột
                style.BackColor = Color.Navy;
                style.ForeColor = Color.White;//Tô màu header
                Binding();
            }
            else if (txtmanv.Text != "" && txttennv.Text != "" && txtkhoa.Text == "")
            {
                SqlConnection kn = new SqlConnection(@"Data Source=DESKTOP-RGHAECC;Initial Catalog=SucKhoeNhanVien_PNT;Integrated Security=True");
                kn.Open();
                string sql = "SELECT NhanVien.MaNV,NhanVien.TenNV,Khoa.TenKhoa,LichSuBenh.NgayKham,LichSuBenh.PhanLoaiSK,LichSuBenh.BenhKhac from NhanVien, LichSuBenh, Khoa where NhanVien.IdNhanVien = LichSuBenh.IdNhanVien And NhanVien.Khoa = Khoa.IdKhoa And NhanVien.MaNV like '%" + txtmanv.Text.Trim() + "%' And NhanVien.TenNV like N'%" + txttennv.Text.Trim() + "%'";
                SqlCommand commandsql = new SqlCommand(sql, kn);//thực thi các chức năng câu lệnh trong sql 
                SqlDataAdapter com = new SqlDataAdapter(commandsql);// vận chuyển dữ liệu
                System.Data.DataTable table = new System.Data.DataTable();//tạo một bảng ảo trong hện thống
                com.Fill(table);// đổ dữ liệu vào bảng ảo
                datagvSKNhanVien.DataSource = table; //bảng ảo này đc đổ vào datagrid
                DataGridViewCellStyle style = datagvSKNhanVien.ColumnHeadersDefaultCellStyle;// Tô đậm header của cột
                style.Font = new System.Drawing.Font(datagvSKNhanVien.Font, FontStyle.Bold);// Tô đậm header của cột
                style.BackColor = Color.Navy;
                style.ForeColor = Color.White;//Tô màu header
                Binding();
            }
            else if (txtmanv.Text != "" && txttennv.Text == "" && txtkhoa.Text != "")
            {
                SqlConnection kn = new SqlConnection(@"Data Source=DESKTOP-RGHAECC;Initial Catalog=SucKhoeNhanVien_PNT;Integrated Security=True");
                kn.Open();
                string sql = "SELECT NhanVien.MaNV,NhanVien.TenNV,Khoa.TenKhoa,LichSuBenh.NgayKham,LichSuBenh.PhanLoaiSK,LichSuBenh.BenhKhac from NhanVien, LichSuBenh, Khoa where NhanVien.IdNhanVien = LichSuBenh.IdNhanVien And NhanVien.Khoa = Khoa.IdKhoa And NhanVien.MaNV like '%" + txtmanv.Text.Trim() + "%' And Khoa.TenKhoa like N'%" + txtkhoa.Text.Trim() + "%'";
                SqlCommand commandsql = new SqlCommand(sql, kn);//thực thi các chức năng câu lệnh trong sql 
                SqlDataAdapter com = new SqlDataAdapter(commandsql);// vận chuyển dữ liệu
                System.Data.DataTable table = new System.Data.DataTable();//tạo một bảng ảo trong hện thống
                com.Fill(table);// đổ dữ liệu vào bảng ảo
                datagvSKNhanVien.DataSource = table; //bảng ảo này đc đổ vào datagrid
                DataGridViewCellStyle style = datagvSKNhanVien.ColumnHeadersDefaultCellStyle;// Tô đậm header của cột
                style.Font = new System.Drawing.Font(datagvSKNhanVien.Font, FontStyle.Bold);// Tô đậm header của cột
                style.BackColor = Color.Navy;
                style.ForeColor = Color.White;//Tô màu header
                Binding();
            }
            else if (txtmanv.Text == "" && txttennv.Text != "" && txtkhoa.Text != "")
            {
                SqlConnection kn = new SqlConnection(@"Data Source=DESKTOP-RGHAECC;Initial Catalog=SucKhoeNhanVien_PNT;Integrated Security=True");
                kn.Open();
                string sql = "SELECT NhanVien.MaNV,NhanVien.TenNV,Khoa.TenKhoa,LichSuBenh.NgayKham,LichSuBenh.PhanLoaiSK,LichSuBenh.BenhKhac from NhanVien, LichSuBenh, Khoa where NhanVien.IdNhanVien = LichSuBenh.IdNhanVien And NhanVien.Khoa = Khoa.IdKhoa And NhanVien.TenNV like '%" + txttennv.Text.Trim() + "%' And Khoa.TenKhoa like N'%" + txtkhoa.Text.Trim() + "%'";
                SqlCommand commandsql = new SqlCommand(sql, kn);//thực thi các chức năng câu lệnh trong sql 
                SqlDataAdapter com = new SqlDataAdapter(commandsql);// vận chuyển dữ liệu
                System.Data.DataTable table = new System.Data.DataTable();//tạo một bảng ảo trong hện thống
                com.Fill(table);// đổ dữ liệu vào bảng ảo
                datagvSKNhanVien.DataSource = table; //bảng ảo này đc đổ vào datagrid
                DataGridViewCellStyle style = datagvSKNhanVien.ColumnHeadersDefaultCellStyle;// Tô đậm header của cột
                style.Font = new System.Drawing.Font(datagvSKNhanVien.Font, FontStyle.Bold);// Tô đậm header của cột
                style.BackColor = Color.Navy;
                style.ForeColor = Color.White;//Tô màu header
                Binding();
            }
            else if (txtmanv.Text != "" && txttennv.Text != "" && txtkhoa.Text != "")
            {
                SqlConnection kn = new SqlConnection(@"Data Source=DESKTOP-RGHAECC;Initial Catalog=SucKhoeNhanVien_PNT;Integrated Security=True");
                kn.Open();
                string sql = "SELECT NhanVien.MaNV,NhanVien.TenNV,Khoa.TenKhoa,LichSuBenh.NgayKham,LichSuBenh.PhanLoaiSK,LichSuBenh.BenhKhac from NhanVien, LichSuBenh, Khoa where NhanVien.IdNhanVien = LichSuBenh.IdNhanVien And NhanVien.Khoa = Khoa.IdKhoa And NhanVien.MaNV like N'%" + txtmanv.Text.Trim() + "%' And NhanVien.TenNV like N'%" + txttennv.Text.Trim() + "%' And Khoa.TenKhoa like N'%" + txtkhoa.Text.Trim() + "%' ";
                SqlCommand commandsql = new SqlCommand(sql, kn);//thực thi các chức năng câu lệnh trong sql 
                SqlDataAdapter com = new SqlDataAdapter(commandsql);// vận chuyển dữ liệu
                System.Data.DataTable table = new System.Data.DataTable();//tạo một bảng ảo trong hện thống
                com.Fill(table);// đổ dữ liệu vào bảng ảo
                datagvSKNhanVien.DataSource = table; //bảng ảo này đc đổ vào datagrid
                DataGridViewCellStyle style = datagvSKNhanVien.ColumnHeadersDefaultCellStyle;// Tô đậm header của cột
                style.Font = new System.Drawing.Font(datagvSKNhanVien.Font, FontStyle.Bold);// Tô đậm header của cột
                style.BackColor = Color.Navy;
                style.ForeColor = Color.White;//Tô màu header
                Binding();
            }
        }

        private void btsua_Click(object sender, EventArgs e)
        {
            //Kiểm tra form đã tồn tại chưa
            FrSuaHSSKNhanVien fc = System.Windows.Forms.Application.OpenForms["FrSuaHSSKNhanVien"] != null ? (FrSuaHSSKNhanVien)System.Windows.Forms.Application.OpenForms["XemHSSKNhanVien"] : null;
            if (fc != null)
            {
                fc.Activate();
            }
            //form is visible
            else
            {
                FrSuaHSSKNhanVien frsua = new FrSuaHSSKNhanVien(txtmanv.Text, dateTimePicker1.Text,txtidLSB.Text);
                frsua.ShowDialog();
            }
        }

        private void bt_baocao_Click(object sender, EventArgs e)
        {
            //Create a new workbook
            /*Spire.Xls.Workbook workbook = new Spire.Xls.Workbook();

            //Initialize worksheet
            workbook.CreateEmptySheets(1);
            Spire.Xls.Worksheet sheet = workbook.Worksheets[0];*/
            string conString = @"Data Source=DESKTOP-RGHAECC;Initial Catalog=SucKhoeNhanVien_PNT;Integrated Security=True";
            SqlConnection sqlCon = new SqlConnection(conString);
            sqlCon.Open();

            SqlDataAdapter da = new SqlDataAdapter("SELECT LichSuBenh.Id_LichSuBenh,NhanVien.MaNV,NhanVien.TenNV,Khoa.TenKhoa,ChucVu.TenChucVu,LichSuBenh.NgayKham,LichSuBenh.PhanLoaiSK,LichSuBenh.BenhKhac from NhanVien, LichSuBenh, Khoa , ChucVu where NhanVien.IdNhanVien = LichSuBenh.IdNhanVien And NhanVien.Khoa = Khoa.IdKhoa And NhanVien.IdChucVu = ChucVu.IdChucVu", sqlCon);
            System.Data.DataTable dtMainSQLData = new System.Data.DataTable();
            da.Fill(dtMainSQLData);
            DataColumnCollection dcCollection = dtMainSQLData.Columns;
            // Export Data into EXCEL Sheet
            Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
            ExcelApp.Application.Workbooks.Add(Type.Missing);
            ExcelApp.Columns.ColumnWidth = 20;

            //Create a new workbook
           // Spire.Xls.Workbook workbook = new Spire.Xls.Workbook();

            //Initialize worksheet
           // workbook.CreateEmptySheets(1);
            //Spire.Xls.Worksheet sheet = workbook.Worksheets[0];

            //Set sheet name
           /* sheet.Name = "Chart data";

            //Set the grid lines invisible
            sheet.GridLinesVisible = false;

            //Create a chart
            Spire.Xls.Chart chart = sheet.Charts.Add(ExcelChartType.Pie3D);

            //Set region of chart data
            chart.DataRange = sheet.Range["B2:B5"];
            chart.SeriesDataFromRange = false;

            //Set position of chart
            chart.LeftColumn = 1;
            chart.TopRow = 6;
            chart.RightColumn = 9;
            chart.BottomRow = 25;

            //Chart title
            chart.ChartTitle = "Sales by year";
            chart.ChartTitleArea.IsBold = true;
            chart.ChartTitleArea.Size = 12;

            //Initialize the chart series
            Spire.Xls.Charts.ChartSerie cs = chart.Series[0];

            //Chart Labels resource
            cs.CategoryLabels = sheet.Range["A2:A5"];

            //Chart value resource
            cs.Values = sheet.Range["B2:B5"];

            //Set the value visible in the chart
            cs.DataPoints.DefaultDataPoint.DataLabels.HasValue = true;

            //Year
            sheet.Range["A1"].Value = "Year";
            sheet.Range["A2"].Value = "2002";
            sheet.Range["A3"].Value = "2003";
            sheet.Range["A4"].Value = "2004";
            sheet.Range["A5"].Value = "2005";

            //Sales
            sheet.Range["B1"].Value = "Sales";
            sheet.Range["B2"].NumberValue = 4000;
            sheet.Range["B3"].NumberValue = 6000;
            sheet.Range["B4"].NumberValue = 7000;
            sheet.Range["B5"].NumberValue = 8500;

            //Style
            sheet.Range["A1:B1"].Style.Font.IsBold = true;
            sheet.Range["A2:B2"].Style.KnownColor = ExcelColors.LightYellow;
            sheet.Range["A3:B3"].Style.KnownColor = ExcelColors.LightGreen1;
            sheet.Range["A4:B4"].Style.KnownColor = ExcelColors.LightOrange;
            sheet.Range["A5:B5"].Style.KnownColor = ExcelColors.LightTurquoise;

            //Border
            sheet.Range["A1:B5"].Style.Borders[BordersLineType.EdgeTop].Color = Color.FromArgb(0, 0, 128);
            sheet.Range["A1:B5"].Style.Borders[BordersLineType.EdgeTop].LineStyle = LineStyleType.Thin;
            sheet.Range["A1:B5"].Style.Borders[BordersLineType.EdgeBottom].Color = Color.FromArgb(0, 0, 128);
            sheet.Range["A1:B5"].Style.Borders[BordersLineType.EdgeBottom].LineStyle = LineStyleType.Thin;
            sheet.Range["A1:B5"].Style.Borders[BordersLineType.EdgeLeft].Color = Color.FromArgb(0, 0, 128);
            sheet.Range["A1:B5"].Style.Borders[BordersLineType.EdgeLeft].LineStyle = LineStyleType.Thin;
            sheet.Range["A1:B5"].Style.Borders[BordersLineType.EdgeRight].Color = Color.FromArgb(0, 0, 128);
            sheet.Range["A1:B5"].Style.Borders[BordersLineType.EdgeRight].LineStyle = LineStyleType.Thin;

            //Number format
            sheet.Range["B2:C5"].Style.NumberFormat = "\"$\"#,##0";
            chart.PlotArea.Fill.Visible = false;

            //Save the file
           // workbook.SaveToFile("Sample.xls", ExcelVersion.Version97to2003);

            //Launch the file
            //System.Diagnostics.Process.Start("Sample.xls");

            */

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
                        formatRange = ExcelApp.Cells[i, j];
                        formatRange.Interior.Color = System.Drawing.
                        ColorTranslator.ToOle(System.Drawing.Color.CornflowerBlue);
                        
                    }
                
                    else
                        ExcelApp.Cells[i, j] = dtMainSQLData.Rows[i - 2][j - 1].ToString();
                        ExcelApp.Cells[i, j].HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                }
            }
            //Save the file
            //workbook.SaveToFile("Sample.xls", ExcelVersion.Version97to2003);

            //Launch the file
            System.Diagnostics.Process.Start("Sample.xls");
            ExcelApp.ActiveWorkbook.SaveCopyAs("C:\\Users\\Oanh\\Desktop\\BaoCaoSK.xls");
            ExcelApp.ActiveWorkbook.Saved = true;
            ExcelApp.Quit();
        }
        
}

}
