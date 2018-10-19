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
    public partial class Fr_QuanLyNghienCuu : Form
    {
        public Fr_QuanLyNghienCuu()
        {
            InitializeComponent();
            ketnoi();
        }
        public void ketnoi()
        {
            try
            {
                SqlConnection kn = new SqlConnection(@"Data Source=DESKTOP-RGHAECC;Initial Catalog=SucKhoeNhanVien_PNT;Integrated Security=True");
                kn.Open();
                string sql = "SELECT NghienCuu.Id_NghienCuu, NghienCuu.MaSo,NghienCuu.TenNghienCuu,CapNghienCuu.CapNghienCuu,TrangThaiNghienCuu.TenTrangThai,NghienCuu.ChuNhiemDeTai from NghienCuu,CapNghienCuu,TrangThaiNghienCuu where NghienCuu.Id_CapNghienCuu = CapNghienCuu.Id_CapNghienCuu And NghienCuu.Id_TrangThaiNghienCuu = TrangThaiNghienCuu.Id_TrangThai";
                SqlCommand commandsql = new SqlCommand(sql, kn);//thực thi các chức năng câu lệnh trong sql 
                SqlDataAdapter com = new SqlDataAdapter(commandsql);// vận chuyển dữ liệu
                DataTable table = new DataTable();//tạo một bảng ảo trong hện thống
                com.Fill(table);// đổ dữ liệu vào bảng ảo
                datagvnghiencuu.DataSource = table; //bảng ảo này đc đổ vào datagrid
                datagvnghiencuu.Columns[0].HeaderText = "ID Nghiên cứu";
                datagvnghiencuu.Columns[1].HeaderText = "Mã Số Nghiên Cứu";
                datagvnghiencuu.Columns[2].HeaderText = "Tên Nghiên Cứu";
                datagvnghiencuu.Columns[3].HeaderText = "Cấp nghiên cứu";
                datagvnghiencuu.Columns[4].HeaderText = "Trạng thái nghiên cứu";
                datagvnghiencuu.Columns[5].HeaderText = " Chủ nhiệm đề tài ";
                DataGridViewCellStyle style = datagvnghiencuu.ColumnHeadersDefaultCellStyle;// Tô đậm header của cột
                style.Font = new Font(datagvnghiencuu.Font, FontStyle.Bold);// Tô đậm header của cột
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
            txtmanghiencuu.DataBindings.Clear();// xóa dữ liệu hiện tại trong textbox
            txtmanghiencuu.DataBindings.Add("Text", datagvnghiencuu.DataSource, "MaSo");//lấy dữ liệu đưa vào textbox
            txttennghiencuu.DataBindings.Clear();
            txttennghiencuu.DataBindings.Add("Text", datagvnghiencuu.DataSource, "TenNghienCuu");
            txtchunhiem.DataBindings.Clear();
            txtchunhiem.DataBindings.Add("Text", datagvnghiencuu.DataSource, "ChuNhiemDeTai");
            txtidnc.DataBindings.Clear();
            txtidnc.DataBindings.Add("Text",datagvnghiencuu.DataSource, "Id_NghienCuu");
        }

        private void btthem_Click(object sender, EventArgs e)
        {
            //Kiểm tra form đã tồn tại chưa
            FrThemNV fc = Application.OpenForms["ThemNghienCuu"] != null ? (FrThemNV)Application.OpenForms["ThemNghienCuu"] : null;
            if (fc != null)
            {
                fc.Activate();
            }
            //form is visible
            else
            {
                ThemNghienCuu frthem = new ThemNghienCuu();
                frthem.Show();
            }
        }

        private void btsua_Click(object sender, EventArgs e)
        {
            SuaNghienCuu frsuanc = new SuaNghienCuu(txtmanghiencuu.Text,txtidnc.Text);
            frsuanc.ShowDialog();
        }

        private void btlammoi_Click(object sender, EventArgs e)
        {
            ketnoi();
        }

        private void bt_baocaoNC_Click(object sender, EventArgs e)
        {
            string conString = @"Data Source=DESKTOP-RGHAECC;Initial Catalog=SucKhoeNhanVien_PNT;Integrated Security=True";
            SqlConnection sqlCon = new SqlConnection(conString);
            sqlCon.Open();

            SqlDataAdapter da = new SqlDataAdapter("SELECT NghienCuu.Id_NghienCuu, NghienCuu.MaSo,NghienCuu.TenNghienCuu,CapNghienCuu.CapNghienCuu,TrangThaiNghienCuu.TenTrangThai,NghienCuu.ChuNhiemDeTai,NghienCuu.NhaTaiTro,NghienCuu.Follow,NghienCuu.NguoiPhuTrach,NghienCuu.Tg_ThucHien,NghienCuu.CoMauChungVN,NghienCuu.CoMauChungPNT,NghienCuu.NgayKhoiDongSite,NghienCuu.ThoiGianKTTDung,NghienCuu.TienDoThuDung,NghienCuu.KinhPhi,NghienCuu.NguonKP,NghienCuu.NgayDuyet,NghienCuu.SoQD from NghienCuu,CapNghienCuu,TrangThaiNghienCuu where NghienCuu.Id_CapNghienCuu = CapNghienCuu.Id_CapNghienCuu And NghienCuu.Id_TrangThaiNghienCuu = TrangThaiNghienCuu.Id_TrangThai", sqlCon);
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
            ExcelApp.ActiveWorkbook.SaveCopyAs("C:\\Users\\Oanh\\Desktop\\BaoCaoNghienCuu.xls");
            ExcelApp.ActiveWorkbook.Saved = true;
            ExcelApp.Quit();
            MessageBox.Show("Done");
        }
    }
    
}
