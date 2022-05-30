using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace WinFormsApp1
{
    public partial class Deletestu : Form
    {
        public Deletestu()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //Index index = new Index();
            this.Hide();
            //index.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            #region 连接数据库
            //定义连接字符串
            string connStr = "Database=StudentStatusManagement;Data Source=127.0.0.1;port=3306;User Id=root;Password=password;";
            MySqlConnection conn = new MySqlConnection(connStr);//创建Connection对象
            conn.Open();//打开数据库
            #endregion

            string stuid = textBox1.Text;
            string sql = "SELECT * FROM StudentTest WHERE studentId='" + stuid + "'";
            MySqlCommand com = new MySqlCommand(sql, conn);
            MySqlDataReader reader = com.ExecuteReader();
            //边读边输入
            while (reader.Read())
            {
                textBox2.Text = (string)reader[1];               
            }
           
            reader.Close();

        }



        private void button1_Click(object sender, EventArgs e)
        {
            #region 连接数据库
            //定义连接字符串
            string connStr = "Database=StudentStatusManagement;Data Source=127.0.0.1;port=3306;User Id=root;Password=password;";
            MySqlConnection conn = new MySqlConnection(connStr);//创建Connection对象
            conn.Open();//打开数据库
            #endregion
            string studentid = textBox1.Text;
            string studentname = textBox2.Text;
            

            #region 删除
            string sql1 = "DELETE FROM StudentTest WHERE studentId='" + studentid + "'";
            MySqlCommand cmd = new MySqlCommand(sql1, conn);
            cmd.ExecuteNonQuery();
            #endregion
            
            //Index index = new Index();
            this.Hide();
            //index.Show();



        }

    }
    

}
