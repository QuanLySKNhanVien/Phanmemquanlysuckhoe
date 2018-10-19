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
    public partial class FrSuaNV : Form
    {
        public FrSuaNV(string value)
        {
            InitializeComponent();
            txtmanvsua.Text = value;
            loaddl();
        }
        public class ChucVu
        {
            public string TenChucVu { get; set; }
            public int IdChucVu { get; set; }
        }
        public class Khoa
        {
            public string TenKhoa { get; set; }
            public int IdKhoa { get; set; }
        }
        public class Gioitinh
        {
            public string TenGT { get; set; }
            public int IdGioiTinh { get; set; }
        }
        //load dữ liệu lên textbox,Datetimepicker và combobox
        public void loaddl()
        {
            SqlConnection kn = new SqlConnection(@"Data Source=DESKTOP-RGHAECC;Initial Catalog=SucKhoeNhanVien_PNT;Integrated Security=True");
            kn.Open();
            string sql = "SELECT * from NhanVien, ChucVu, Khoa, GioiTinh where NhanVien.IdChucVu = ChucVu.IdChucVu And NhanVien.Khoa = Khoa.IdKhoa And NhanVien.IdGioiTinh = GioiTinh.IdGioiTinh And NhanVien.MaNV like N'" + txtmanvsua.Text + "' ";
            string loadchucvu = "Select IdChucVu,TenChucVu from ChucVu ";
            string loadkhoa = "Select IdKhoa,TenKhoa from Khoa";
            string loadgt = "Select IdGioiTinh,TenGT from GioiTinh";
            SqlCommand commandsql = new SqlCommand(sql, kn);//thực thi các chức năng câu lệnh trong sql 
            SqlCommand commandcv = new SqlCommand(loadchucvu,kn);
            SqlCommand commandkhoa = new SqlCommand(loadkhoa,kn);
            SqlCommand commandgt = new SqlCommand(loadgt,kn);
            SqlDataAdapter com = new SqlDataAdapter(commandsql);// vận chuyển dữ liệu
            SqlDataAdapter comcv = new SqlDataAdapter(commandcv);
            SqlDataAdapter comkhoa = new SqlDataAdapter(commandkhoa);
            SqlDataAdapter comgt = new SqlDataAdapter(commandgt);
            DataTable table = new DataTable();//tạo một bảng ảo trong hện thống
            DataTable tablecv = new DataTable();
            DataTable tablekhoa = new DataTable();
            DataTable tablegt = new DataTable();
            com.Fill(table);// đổ dữ liệu vào bảng ảo
            comcv.Fill(tablecv);
            comkhoa.Fill(tablekhoa);
            comgt.Fill(tablegt);
            txttennvsua.Text = (string)table.Rows[0]["TenNV"];
            txtcmnd.DataBindings.Add("Text",table,"CMND");
            // hiển thị combo chức vụ
            cbchucvu.DisplayMember = "TenChucVu";
            cbchucvu.ValueMember = "IdChucVu";
            List<ChucVu> list = new List<ChucVu>(); // define a list
            for (var i = 0; i < tablecv.Rows.Count; i++)
            {
                var cv = new ChucVu{ TenChucVu = (string)tablecv.Rows[i].ItemArray[1], IdChucVu = (int)tablecv.Rows[i].ItemArray[0] };
                list.Add(cv);
            }
            cbchucvu.DataSource = list; //gán ds chức vụ vào source dữ liệu của combox.
            var idChucVu = (int)table.Rows[0].ItemArray[8]; //Lấy id chức vụ của nv truyền vào
            var chucvu = list.Where(x => x.IdChucVu == idChucVu).FirstOrDefault();
            var index = cbchucvu.Items.IndexOf(chucvu); //tìm chỉ số index của chức vụ mà nv truyền vào nằm ở vị trí nào trong combobox.
            cbchucvu.SelectedIndex = index; // gán index cho selected.
            //hiển thị combo khoa
            cbkhoa.DisplayMember = "TenKhoa";
            cbkhoa.ValueMember = "IdKhoa";
            List<Khoa> listkhoa = new List<Khoa>();
            for (var i=0; i < tablekhoa.Rows.Count; i++ )
            {
                var khoa = new Khoa { TenKhoa = (string)tablekhoa.Rows[i].ItemArray[1], IdKhoa = (int)tablekhoa.Rows[i].ItemArray[0] };
                listkhoa.Add(khoa);
            }
            cbkhoa.DataSource = listkhoa;
            var idkhoa = (int)table.Rows[0].ItemArray[8];
            var bienkhoa = listkhoa.Where(x => x.IdKhoa==idkhoa).FirstOrDefault();
            var indexkhoa = cbkhoa.Items.IndexOf(bienkhoa);
            cbkhoa.SelectedIndex = indexkhoa;
            //hiển thị combo gioi tinh
            cbgt.DisplayMember = "TenGT";
            cbgt.ValueMember = "IdGioiTinh";
            List<Gioitinh> listgt = new List<Gioitinh>(); // define a list
            for (var i = 0; i < tablegt.Rows.Count; i++)
            {
                var gt = new Gioitinh { TenGT = (string)tablegt.Rows[i].ItemArray[1], IdGioiTinh = (int)tablegt.Rows[i].ItemArray[0] };
                listgt.Add(gt);
            }
            cbgt.DataSource = listgt; //gán ds chức vụ vào source dữ liệu của combox.
            var idgioitinh = (int)table.Rows[0].ItemArray[12]; //Lấy id chức vụ của nv truyền vào
            var gioitinh = listgt.Where(x => x.IdGioiTinh == idgioitinh).FirstOrDefault();
            var indexgt = cbgt.Items.IndexOf(gioitinh); //tìm chỉ số index của chức vụ mà nv truyền vào nằm ở vị trí nào trong combobox.
            cbgt.SelectedIndex = indexgt; // gán index cho selected.
            // hiển thị ngày tháng năm sinh
            var date = (DateTime)table.Rows[0].ItemArray[4];
            dateTimePickerSuaNV.Value = date; //gán ngày tháng.
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            SqlConnection kn = new SqlConnection(@"Data Source=DESKTOP-RGHAECC;Initial Catalog=SucKhoeNhanVien_PNT;Integrated Security=True");
            kn.Open();          
            if (txttennvsua.Text == "")
            {
                MessageBox.Show(" Bạn chưa nhập tên nhân viên");
            }
            else
            { 
                    string suanv = "Update NhanVien Set TenNV= @TenNV,Khoa= @Khoa ,NgaySinh= @NgaySinh, CMND= @CMND ,IdGioiTinh = @Idgt,IdChucVu= @IdChucVu where MaNV like N'" + txtmanvsua.Text + "' ";
                    SqlCommand commandsua = new SqlCommand(suanv, kn);//thực thi các chức năng câu lệnh trong sql 
                    SqlDataAdapter comsua = new SqlDataAdapter(commandsua);// vận chuyển dữ liệu
              //Tried Parse and Convert.
                commandsua.Parameters.AddWithValue("@TenNV", txttennvsua.Text);
                commandsua.Parameters.AddWithValue("@Khoa", cbkhoa.SelectedValue.ToString());
                commandsua.Parameters.AddWithValue("@NgaySinh", dateTimePickerSuaNV.Value.Date);
                commandsua.Parameters.AddWithValue("@CMND", txtcmnd.Text);
                commandsua.Parameters.AddWithValue("@IdChucVu", cbchucvu.SelectedValue.ToString());
                //int cbchoice = Convert.ToInt32(cbgt.SelectedValue.ToString());
                //commandsua.Parameters.AddWithValue("@Idgt", cbchoice);
                commandsua.Parameters.AddWithValue("@Idgt",cbgt.SelectedValue.ToString());
                commandsua.ExecuteNonQuery();
                this.Close();
                MessageBox.Show("Lưu thành công");
            }
        }

        private void btboqua_Click(object sender, EventArgs e)
        {

            DialogResult tb = new DialogResult();
            tb = MessageBox.Show("Bạn có chắc muốn thoát ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tb == DialogResult.Yes)
            {
                this.Close();
            }
        
        }

    }


    }
    



