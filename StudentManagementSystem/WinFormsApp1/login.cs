using MySql.Data.MySqlClient;


namespace WinFormsApp1
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
            //��ʼ��ҳ����Ҫʹ�õ�����
            
        }

       
        private void button2_Click(object sender, EventArgs e)
        {

            //��ת��register����
            register info = new register();
            this.Hide();
            info.Show();
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            #region �������ݿ�
            //���������ַ���
            string connStr = "Database=StudentStatusManagement;Data Source=127.0.0.1;port=3306;User Id=root;Password=password;";
            MySqlConnection conn = new MySqlConnection(connStr);//����Connection����
            conn.Open();//�����ݿ�
            #endregion
            if (comboBox1.Text=="")
            {
                MessageBox.Show("��ݲ���Ϊ��", "�û���¼", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            else if (comboBox1.Text != "ѧ��")
            {
                MessageBox.Show("��ѡ��ѧ����������ݻ�δ����", "�û���¼", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (userName.Text == "")
            {
                MessageBox.Show("�û�������Ϊ��", "�û���¼", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            else if (passWord.Text == "")
            {
                MessageBox.Show("���벻��Ϊ��", "�û���¼", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (verification.Text == "")
            {
                MessageBox.Show("��֤�벻��Ϊ��", "�û���¼", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (verification.Text != label6.Text)
            {
                MessageBox.Show("��֤���������������", "�û���¼", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                //��ѯ���ݿ��˻���Ϣ
                string username = userName.Text;
                string password = passWord.Text;
                string sql = "SELECT COUNT(*) FROM USER WHERE userName='" + username + "' AND userPassword = '" + password + "'; ";
                MySqlCommand com = new MySqlCommand(sql, conn);
                if (Convert.ToInt32(com.ExecuteScalar()) == 0)
                {
                    MessageBox.Show("�û������������������������", "�û���¼", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    //��ת��index����
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
