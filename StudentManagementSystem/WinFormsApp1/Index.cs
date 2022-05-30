using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//00000000000
using MySql.Data.MySqlClient;
namespace WinFormsApp1
{
    public partial class Index : Form
    {
       
        public static string[] array = new string[100];
        public Index()
        {
            InitializeComponent();
        }
       
        //初始化页面的数据
        private void index_Load(object sender, EventArgs e)
        {
            //显示登录进来的用户名
            label1.Text = "欢迎登录此系统！ ";                      
            //设置一个定时器,1000ms(1s)刷新一次
            timer1.Interval = 1000;
            //开启定时器
            timer1.Start();
            //显示时间
            label2.Text = "当前时间为: " + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");

            #region 连接数据库
            //定义连接字符串
            string connStr = "Database=StudentStatusManagement;Data Source=127.0.0.1;port=3306;User Id=root;Password=password;";
            MySqlConnection conn = new MySqlConnection(connStr);//创建Connection对象
            conn.Open();//打开数据库
            #endregion         
            string sql = "SELECT * FROM StudentTest";
            MySqlCommand com = new MySqlCommand(sql, conn);
            MySqlDataReader reader = com.ExecuteReader();
            listView1.Items.Clear();
            //数据更新，UI暂时挂起，直到EndUpdate绘制控件，可以有效避免闪烁并大大提高加载速度
            listView1.BeginUpdate();
            //边读边输入
            int i = 0;
            while (reader.Read())
            {
                ListViewItem lvi = listView1.Items.Add((string)reader[0]);
                lvi.SubItems.Add((string)reader[1]);
                lvi.SubItems.Add((string)reader[2]);
                lvi.SubItems.Add(string.Format("{0}", reader[3]));
                lvi.SubItems.Add(string.Format("{0}", reader[4]));
                array[i++] = (string)reader[0];//将编号依次存入数组
            }
            //结束数据处理，UI界面一次性绘制。
            listView1.EndUpdate(); 
            reader.Close();
        }

        //根据定时器的间隔时间刷新页面数据
        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = "  当前时间为: " + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
        }

        private void 新建学生信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //跳转到Sudent界面
            Student stu = new Student();
            //this.Hide();
            stu.Show();
           

        }
        private void 删除学生信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            #region 连接数据库
            //定义连接字符串
            string connStr = "Database=StudentStatusManagement;Data Source=127.0.0.1;port=3306;User Id=root;Password=password;";
            MySqlConnection conn = new MySqlConnection(connStr);//创建Connection对象
            conn.Open();//打开数据库
            #endregion  
            if (listView1.SelectedIndices != null && listView1.SelectedIndices.Count > 0)
            {
                
                // **获取行号**
                int nRow = listView1.Items[listView1.SelectedIndices[0]].Index;
                DialogResult dr = MessageBox.Show(("是否确定删除学号为"+array[nRow]+"的学生"), "提示", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    //删除
                    #region 删除
                    string sql = "DELETE FROM StudentTest WHERE studentId='" + array[nRow] + "'";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    MessageBox.Show("删除成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    listView1.EndUpdate();
                    //this.Hide();
                }
                else
                {

                }

            }
            else
            {
                Deletestu deletestu = new Deletestu();
                deletestu.Show();
            }   
            
        }

        private void 导入学生信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Iditstu iditstu = new Iditstu();
            //this.Hide();
            //iditstu.Show();
            if (listView1.SelectedIndices != null && listView1.SelectedIndices.Count > 0)
            {
                // **获取行号**
                int nRow = listView1.Items[listView1.SelectedIndices[0]].Index;
                iditstu.setnrow(array[nRow]);
                iditstu.Show();

            }
            else
            {
                iditstu.setnrow("");
                iditstu.Show();
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            login logi = new login();
            this.Hide();
            logi.Show();
        }
    }
}
