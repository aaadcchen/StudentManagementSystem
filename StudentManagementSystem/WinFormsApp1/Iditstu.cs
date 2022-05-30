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
    public partial class Iditstu : Form
    {
        public static string nrowItem;
        public void setnrow(string n)
        {
            nrowItem = n;
        }
        public Iditstu()
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
                textBox3.Text = (string)reader[2];
                textBox4.Text = string.Format("{0}", reader[3]);
                textBox5.Text = string.Format("{0}", reader[4]);                
            }
            //结束数据处理，UI界面一次性绘制。
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
            if (textBox2.Text == "")
            {
                MessageBox.Show("学生姓名不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                string studentid = textBox1.Text;
                string studentname = textBox2.Text;
                string classId = textBox3.Text;
                string birthday = textBox4.Text;
                string address = textBox5.Text;

                #region 删除
                string sql1 = "DELETE FROM StudentTest WHERE studentId='" + studentid + "'";
                MySqlCommand cmd = new MySqlCommand(sql1, conn);
                cmd.ExecuteNonQuery();
                #endregion
                string sql2 = "insert into studentTest set studentId='" + studentid + "',studentName='" + studentname + "',class='" + classId + "',birthday='" + birthday + "',address='" + address + "'";
                MySqlCommand com1 = new MySqlCommand(sql2, conn);
                com1.ExecuteNonQuery();
                MessageBox.Show("编辑成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                //Index index = new Index();
                this.Hide();
                //index.Show();
            }
        }

        

        private void Iditstu_Load(object sender, EventArgs e)
        {
            #region 连接数据库
            //定义连接字符串
            string connStr = "Database=StudentStatusManagement;Data Source=127.0.0.1;port=3306;User Id=root;Password=password;";
            MySqlConnection conn = new MySqlConnection(connStr);//创建Connection对象
            conn.Open();//打开数据库
            #endregion
            if (nrowItem != null)
            {
                string sql = "SELECT * FROM StudentTest WHERE studentId='" + nrowItem + "'";
                MySqlCommand com = new MySqlCommand(sql, conn);
                MySqlDataReader reader = com.ExecuteReader();
                //边读边输入
                while (reader.Read())
                {
                    textBox1.Text= (string)reader[0];
                    textBox2.Text = (string)reader[1];
                    textBox3.Text = (string)reader[2];
                    textBox4.Text = string.Format("{0}", reader[3]);
                    textBox5.Text = string.Format("{0}", reader[4]);
                }
                //结束数据处理，UI界面一次性绘制。
                reader.Close();
            }
            else
                textBox1.Focus();
        }
    }
    
}


