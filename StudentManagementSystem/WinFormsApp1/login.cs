using MySql.Data.MySqlClient;


namespace WinFormsApp1
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
            //初始化页面需要使用的数据
            
        }

       
        private void button2_Click(object sender, EventArgs e)
        {

            //跳转到register界面
            register info = new register();
            this.Hide();
            info.Show();
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            #region 连接数据库
            //定义连接字符串
            string connStr = "Database=StudentStatusManagement;Data Source=127.0.0.1;port=3306;User Id=root;Password=password;";
            MySqlConnection conn = new MySqlConnection(connStr);//创建Connection对象
            conn.Open();//打开数据库
            #endregion
            if (comboBox1.Text=="")
            {
                MessageBox.Show("身份不能为空", "用户登录", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            else if (comboBox1.Text != "学生")
            {
                MessageBox.Show("请选择学生，其他身份还未开发", "用户登录", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (userName.Text == "")
            {
                MessageBox.Show("用户名不能为空", "用户登录", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            else if (passWord.Text == "")
            {
                MessageBox.Show("密码不能为空", "用户登录", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (verification.Text == "")
            {
                MessageBox.Show("验证码不能为空", "用户登录", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (verification.Text != label6.Text)
            {
                MessageBox.Show("验证码错误，请重新输入", "用户登录", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                //查询数据库账户信息
                string username = userName.Text;
                string password = passWord.Text;
                string sql = "SELECT COUNT(*) FROM USER WHERE userName='" + username + "' AND userPassword = '" + password + "'; ";
                MySqlCommand com = new MySqlCommand(sql, conn);
                if (Convert.ToInt32(com.ExecuteScalar()) == 0)
                {
                    MessageBox.Show("用户名或者密码错误，请重新输入", "用户登录", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    //跳转到index界面
                    Index1 index = new Index1();
                    this.Hide();
                    index.Show();
                }
            }
        }

        private void login_Load(object sender, EventArgs e)
        {
            userName.Focus();
            Random rd = new Random();
            label6.Text = Convert.ToString(rd.Next(1000, 10000));
        }
    }
}
