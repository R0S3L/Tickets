
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Tickets
{
    public partial class BuyTicket : Form
    {
        string SQLconnect = "server = localhost; port=3306; userid=root; password=t9qd9jqs; database=train_tickets_sokolov; sslmode=none; charset=utf8 ";
        string search;
        int userId;
        public BuyTicket(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            fillCombo();
            get_reis();
        }
        void get_reis()
        {
            MySqlConnection con = new MySqlConnection(SQLconnect);
            con.Open();
            String que = $"SELECT * FROM `reis`";
            MySqlDataAdapter msda = new MySqlDataAdapter(que, con);
            DataTable table = new DataTable();
            msda.Fill(table);
            dataGridView1.DataSource = table;
            dataGridView1.Columns["idreis"].Visible = false;
            con.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(SQLconnect);
            conn.Open();
            string cmdString = $"SELECT * FROM reis WHERE {search} LIKE '{textBox1.Text}%' ";
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmdString, SQLconnect);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            conn.Close();
        }
        void fillCombo()
        {
            MySqlConnection conn = new MySqlConnection(SQLconnect);
            conn.Open();
            MySqlCommand cmdReader;
            MySqlDataReader myReader;
            String query = $"SELECT * FROM `reis`";
            try
            {
                cmdReader = new MySqlCommand(query, conn);
                myReader = cmdReader.ExecuteReader();

                while (myReader.Read())
                {
                    for (int index = 1; index < myReader.FieldCount; index++)
                    {
                        if ((index == 1 || index == 2 || index == 6)&& comboBox1.Items.Count < 3)
                        {
                            comboBox1.Items.Add(myReader.GetName(index));
                            
                        }
                    }
                }
                myReader.Close();
            }
            catch (Exception)
            {

            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            search = comboBox1.SelectedItem.ToString();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            NewTicket pick = new NewTicket(dataGridView1.SelectedRows[0].Cells[0].Value, userId);
            this.Hide();
            if (pick.ShowDialog() == DialogResult.OK)
            {
                get_reis();
            }
            pick.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Main b = new Main(userId);
            this.Hide();
            if (b.ShowDialog() == DialogResult.OK)
            {
                get_reis();
            }
            b.Show();
        }
    }
}

