using Microsoft.VisualBasic.ApplicationServices;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;

namespace Tickets
{
    public partial class Adm_Main : Form
    {
        int idadmin;
        string SQLconnect = "server = localhost; port=3306; userid=root; password=t9qd9jqs; database=train_tickets_sokolov; sslmode=none; charset=utf8 ";
        public Adm_Main(int idadmin)
        {
            InitializeComponent();
            this.idadmin = idadmin;
            adm_info();
            get_reis();
        }
        void adm_info()
        {
            MySqlConnection conn = new MySqlConnection(SQLconnect);
            conn.Open();
            string queU = $"SELECT * FROM `admin` WHERE `admin`.`idadmin`='{idadmin}'";
            MySqlCommand cmd = new MySqlCommand(queU, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                //admin data
                label1.Text = reader["ФИО"].ToString();
                textBox1.Text = reader["Логин"].ToString();
                textBox2.Text = reader["Пароль"].ToString();

            }
            conn.Close();
        }
        void get_reis()
        {
            MySqlConnection con1 = new MySqlConnection(SQLconnect);
            String que = $"SELECT * FROM `reis`";
            MySqlDataAdapter msda = new MySqlDataAdapter(que, con1);
            DataTable table = new DataTable();
            msda.Fill(table);
            dataGridView1.DataSource = table;
            //active or not
            table.Columns.Add("Активен", typeof(string));
            DateTime date;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {

                if (dataGridView1.Rows[i].Cells["Дата_и_Время"].Value != null)
                {
                    date = Convert.ToDateTime(dataGridView1.Rows[i].Cells["Дата_и_Время"].Value);
                    if (date >= DateTime.Now)
                    {
                        dataGridView1.Rows[i].Cells["Активен"].Value = "да";
                    }
                    else
                    {
                        dataGridView1.Rows[i].Cells["Активен"].Value = "нет";
                    }
                }
            }
            //invisible columns
            dataGridView1.Columns["idreis"].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NewReis pick = new NewReis(idadmin);
            this.Hide();
            if (pick.ShowDialog() == DialogResult.OK)
            {
                get_reis();
            }
            pick.Show();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ThisReis reis = new ThisReis(dataGridView1.SelectedRows[0].Cells[0].Value, idadmin);
            this.Hide();
            if (reis.ShowDialog() == DialogResult.OK)
            {
                get_reis();
            }
            reis.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Authorization pick = new Authorization(idadmin);
            this.Hide();
            if (pick.ShowDialog() == DialogResult.OK)
            {
                get_reis();
            }
            pick.Show();
        }
    }
}
