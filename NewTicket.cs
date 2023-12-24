
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Tickets
{
    public partial class NewTicket : Form
    {
        object id;
        int userId;
        string SQLconnect = "server = localhost; port=3306; userid=root; password=t9qd9jqs; database=train_tickets_sokolov; sslmode=none; charset=utf8 ";
        public NewTicket(object id, int userId)
        {
            InitializeComponent();
            this.id = id;
            this.userId = userId;
            FillBoxes();
            get_reis();

        }
        void get_reis()
        {
            MySqlConnection conn = new MySqlConnection(SQLconnect);
            conn.Open();
            string query = $"SELECT * FROM `reis`  WHERE `idreis`='{id}' ";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                textBox1.Text = read["Пункт_Отправки"].ToString();
                textBox2.Text = read["Пункт_Назначения"].ToString();
                textBox3.Text = read["Дата_и_Время"].ToString();
                textBox5.Text = read["Цена"].ToString();
            }
            conn.Close();
        }

        void FillBoxes()
        {
            MySqlConnection conn = new MySqlConnection(SQLconnect);
            conn.Open();
            MySqlCommand cmdReader;
            MySqlDataReader myReader;
            String query = $"SELECT * FROM `reis` WHERE `idreis`={id}";
            cmdReader = new MySqlCommand(query, conn);
            myReader = cmdReader.ExecuteReader();
            while (myReader.Read())
            {
                for (int index = 1; index <= (int)myReader["Кол-во_Вагонов"]; index++)
                {  
                    comboBox1.Items.Add(index);
                }
            }
            myReader.Close();
            String queryP = $"SELECT * FROM `reis` WHERE `idreis`={id}";
            cmdReader = new MySqlCommand(query, conn);
            myReader = cmdReader.ExecuteReader();
            while (myReader.Read())
            {
                for (int index = 1; index <= 10; index++)
                {
                    comboBox2.Items.Add(index);
                }
            }
            myReader.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            FindEqual();
            Insert();
        }
        void Insert()
        {
            MySqlConnection con = new MySqlConnection(SQLconnect);
            con.Open();
            DialogResult result = MessageBox.Show("Подтвердите покупку", "Подтвердите действие", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string buyquery =
                "INSERT INTO `tickets` (`Место`,`Вагон`,`idreis`,`iduser`)" +
                " VALUES(" +
                $"'{comboBox2.Text}'," +
                $"'{comboBox1.Text}'," +
                $"'{id}'," +
                $"'{userId}'" +
                $");";
                MySqlCommand cmd = new MySqlCommand(buyquery, con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Билет забронирован", "Бронь", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Hide();
                Main mn = new Main(userId);
                mn.Show();
            }
            if (result == DialogResult.No)
            {
                MessageBox.Show("Бронь отменена", "Бронь", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        void FindEqual()
        {
            MySqlConnection connection = new MySqlConnection(SQLconnect);
            {
                connection.Open();
                string selectQuery = $"SELECT * FROM tickets WHERE Место LIKE '{comboBox2.Text}%' AND Вагон LIKE '{comboBox1.Text}%' ";
                MySqlCommand command = new MySqlCommand(selectQuery, connection); 
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        int ticketId = (int)reader["Место"];
                        comboBox2.Items.RemoveAt(ticketId);
                    }
                }
                else
                {
                    return;
                } 
            }
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            BuyTicket back = new BuyTicket(userId);
            this.Hide();
            if (back.ShowDialog() == DialogResult.OK)
            {
                get_reis();
            }
            back.Show();
        }


    }
}
