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
  
namespace QuanLySieuThi
{
    public partial class Dangnhap : Form

    {
        public static string sqlcon = @"Data Source=LAPTOP-GTIKGADL\MAY1;Initial Catalog=quanlyst1;User ID=sa;Password=sa";
        
        public static SqlConnection mycon;
        public static SqlCommand com;
        public static SqlDataAdapter ad;
        public static DataTable dt;
        public static SqlCommandBuilder bd;

        public static string getNameUser(string fullname )
        {
            return fullname;
        }

        public static string username;
        public Dangnhap()
        {
            InitializeComponent();
        }
        public static void Chuoiketnoi(string chuoi, DataGridView db1)
        {
            try
            {

                ad = new SqlDataAdapter(chuoi, sqlcon);
                dt = new DataTable();
                bd = new SqlCommandBuilder(ad);
                ad.Fill(dt);
                db1.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể kết nối " + ex, "Thông báo ! ");

            }
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_tk.Text) || string.IsNullOrEmpty(txt_mk.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            using (SqlConnection mycon = new SqlConnection(sqlcon))
            {
                mycon.Open();

                string sql1 = "SELECT COUNT(*) FROM taikhoan WHERE username=@username AND password=@password";
                SqlCommand com = new SqlCommand(sql1, mycon);
                com.Parameters.AddWithValue("@username", txt_tk.Text.Trim());
                com.Parameters.AddWithValue("@password", txt_mk.Text.Trim());

                int a = (int)com.ExecuteScalar();

                if (a == 0)
                {
                    MessageBox.Show("Username hoặc password sai! Bạn vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK);
                }
                else
                {
                    string sql = "SELECT isAdmin FROM taikhoan WHERE username=@username";
                    SqlCommand getIsAdmin = new SqlCommand(sql, mycon);
                    getIsAdmin.Parameters.AddWithValue("@username", txt_tk.Text.Trim());

                    int getRole = (int)getIsAdmin.ExecuteScalar();

                    if (getRole == 0)
                    {
                        MessageBox.Show("Đăng nhập thành công", "Thông báo", MessageBoxButtons.OK);

                        main2 a1 = new main2();

                        a1.lb_quyen.Text = GetFullname(0, txt_tk.Text.Trim()) + " (Quản trị)";

                        a1.Show();
                        this.Hide();
                    }
                   
                }
            }
        }

        public static string GetFullname(int isAdmin,string username)
        {
            string sqlGetFullname = "Select fullname from taikhoan where isAdmin=" +isAdmin+ " and username='"+ username+"'";
            mycon = new SqlConnection(sqlcon);
            mycon.Open();
            SqlCommand getFullname = new SqlCommand(sqlGetFullname, mycon);
            string Fullname = getFullname.ExecuteScalar().ToString();     

            return Fullname;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát không ?", "Thông báo ", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
               
                this.Hide();
            }
        }

        private void Dangnhap_Load(object sender, EventArgs e)
        {

        }

        private void txt_mk_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
