using Microsoft.VisualBasic.ApplicationServices;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Net;
using System.Windows.Forms;

namespace Tickets
{
    public partial class Authorization : Form
    {
        int userID;
        string SQLconnect = "server = localhost; port=3306; userid=root; password=t9qd9jqs; database=train_tickets_sokolov; sslmode=none; charset=utf8 ";
        public Authorization(int userID)
        {
            InitializeComponent();
            this.userID = userID;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void Enter_User()
        {
            MySqlConnection con1 = new MySqlConnection(SQLconnect);
            con1.Open();
            string query = "SELECT * FROM user WHERE Логин=@login and Пароль=@password";
            MySqlCommand com = new MySqlCommand(query, con1);
            com.Parameters.AddWithValue("@login", textBox1.Text);
            com.Parameters.AddWithValue("@password", textBox2.Text);
            MySqlDataReader Dr = com.ExecuteReader();
            while (Dr.Read())
                if (Dr.HasRows == true)
                {
                    Main mn = new Main(Convert.ToInt32(Dr["iduser"]));
                    this.Hide();
                    if (mn.ShowDialog() == DialogResult.OK)
                    {
                        Enter_User();
                    }
                    mn.Show();
                    break;
                }
                else
                {
                    MessageBox.Show("Такого логина или пароля не существует: \n\n1) Проверьте правильность ввода\n\n2) Обратитесь к администартору", "Ошибка авторизации", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
        }

        private void Enter_Adm()
        {
            MySqlConnection con1 = new MySqlConnection(SQLconnect);
            con1.Open();
            string query = "SELECT * FROM admin WHERE Логин=@login and Пароль=@password";
            MySqlCommand com = new MySqlCommand(query, con1);
            com.Parameters.AddWithValue("@login", textBox1.Text);
            com.Parameters.AddWithValue("@password", textBox2.Text);
            MySqlDataReader Dr = com.ExecuteReader();
            while(Dr.Read())
            if (Dr.HasRows == true)
            {
                Adm_Main mn = new Adm_Main(Convert.ToInt32(Dr["idadmin"]));
                this.Hide();
                if (mn.ShowDialog() == DialogResult.OK)
                {
                    Enter_User();
                }
                mn.Show();
                break;
            }
            else
            {
                MessageBox.Show("Такого логина или пароля не существует: \n\n1) Проверьте правильность ввода", "Ошибка авторизации", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Enter_User();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Enter_Adm();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Reg pick = new Reg();
            this.Hide();
            if (pick.ShowDialog() == DialogResult.OK)
            {
                Enter_User();
            }
            pick.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}