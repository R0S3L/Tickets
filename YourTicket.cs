using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tickets
{
    public partial class YourTicket : Form
    {
        string SQLconnect = "server = localhost; port=3306; userid=root; password=t9qd9jqs; database=train_tickets_sokolov; sslmode=none; charset=utf8 ";
        object ticketId = null;
        int userId;
        public YourTicket(object ticketId, int userId)
        {
            InitializeComponent();
            this.ticketId = ticketId;
            this.userId = userId;
            get_ticket();

        }
        void get_ticket()
        {
            MySqlConnection conn = new MySqlConnection(SQLconnect);
            conn.Open();
            string query = "SELECT * FROM `tickets`  " +
                $" LEFT JOIN `user` ON (`user`.`iduser`= `tickets`.`iduser`)" +
                $" LEFT JOIN `reis`  ON (`reis`.`idreis` = `tickets`.`idreis`)" +
                $" WHERE `tickets`.`idtickets`='{ticketId}'";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                textBox1.Text = read["Пункт_Отправки"].ToString();
                textBox2.Text = read["Пункт_Назначения"].ToString();
                textBox3.Text = read["Цена"].ToString();
                textBox5.Text = read["Место"].ToString();
                textBox7.Text = read["Платформа"].ToString();
                textBox6.Text = read["Дата_и_Время"].ToString();
                textBox8.Text = read["ФИО"].ToString();
                textBox9.Text = read["Серия_Номер_Паспорта"].ToString();
            }
            conn.Close();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            Main pick = new Main(userId);
            this.Hide();
            if (pick.ShowDialog() == DialogResult.OK)
            {
                get_ticket();
            }
            pick.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы действительно хотите отменить бронь?", "Подтвердите действие", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                MySqlConnection con = new MySqlConnection(SQLconnect);
                con.Open();
                string DelQeury = $"Delete from `tickets` where `idtickets`='{ticketId}'";
                MySqlCommand cmdDel = new MySqlCommand(DelQeury, con);
                cmdDel.ExecuteNonQuery();
                MessageBox.Show("Бронь отменена успешно", "Успешно удалено", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Main mn = new Main(userId);
                this.Hide();
                if (mn.ShowDialog() == DialogResult.OK)
                {
                    get_ticket();
                }
                con.Close();
            }
            else if (result == DialogResult.No)
            {
                MessageBox.Show("Изменения отменены", "Отмена", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
