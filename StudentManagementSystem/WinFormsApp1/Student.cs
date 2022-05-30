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
    public partial class Student : Form
    {
        public Student()
        {
            InitializeComponent();
        }
       
        private void button2_Click(object sender, EventArgs e)
        {
            //Index index = new Index();
            this.Hide();
            //index.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            #region 连接数据库
            //定义连接字符串
            string connStr = "Database=StudentStatusManagement;Data Source=127.0.0.1;port=3306;User Id=root;Password=password;";
            MySqlConnection conn = new MySqlConnection(connStr);//创建Connection对象
            conn.Open();//打开数据库
            #endregion   
            if (textBox1.Text == "")
            {
                MessageBox.Show("学号不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (textBox2.Text == "")
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
                string sql1 = "select count(*) from StudentTest where studentId='" + studentid + "'";
                MySqlCommand com = new MySqlCommand(sql1, conn);
                if (Convert.ToInt32(com.ExecuteScalar()) > 0)//学生存在
                {
                    MessageBox.Show("此学生已存在", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else//添加进数据库
                {
                    string sql2 = "insert into studentTest set studentId='" + studentid + "',studentName='" + studentname + "',class='" + classId + "',birthday='" + birthday + "',address='" + address +  "'";
                    MySqlCommand com1 = new MySqlCommand(sql2, conn);
                    com1.ExecuteNonQuery();
                    MessageBox.Show("添加成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    //Index index=new Index();
                    this.Hide();
                    //index.Show();
                }
            }
        }

        
    }
}
