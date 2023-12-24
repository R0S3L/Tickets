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

namespace Tickets
{
    public partial class ThisReis : Form
    {
        object id;
        int idadmin;
        string SQLconnect = "server = localhost; port=3306; userid=root; password=t9qd9jqs; database=train_tickets_sokolov; sslmode=none; charset=utf8 ";
        public ThisReis(object id, int idadmin)
        {
            InitializeComponent();
            this.id = id;
            this.idadmin = idadmin;
            SelectedReis();
        }
        void SelectedReis()
        {
            MySqlConnection conn = new MySqlConnection(SQLconnect);
            conn.Open();
            string query = "SELECT * FROM `reis`  " +
                $" WHERE `reis`.`idreis`='{id}'";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                textBox1.Text = read["Пункт_Отправки"].ToString();
                textBox2.Text = read["Пункт_Назначения"].ToString();
                textBox3.Text = read["Кол-во_Вагонов"].ToString();
                textBox4.Text = read["Кол-во_Билетов"].ToString();
                textBox5.Text = read["Платформа"].ToString();
                textBox6.Text = read["Цена"].ToString();
                dateTimePicker1.Text = read["Дата_и_Время"].ToString();
            }
            conn.Close();
        }
        void back()
        {
            Adm_Main pick = new Adm_Main(idadmin);
            this.Hide();
            if (pick.ShowDialog() == DialogResult.OK)
            {

            }
            pick.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(SQLconnect);
            conn.Open();
            string query = "UPDATE `reis`" +
                $"SET" +
                $"`Пункт_Отправки`='{textBox1.Text}'," +
                $"`Пункт_Назначения`='{textBox2.Text}'," +
                $"`Кол-во_Вагонов`='{textBox3.Text}'," +
                $"`Кол-во_Билетов`='{textBox4.Text}'," +
                $"`Платформа`='{textBox5.Text}'," +
                $"`Цена`='{textBox6.Text}'," +
                $"`Дата_и_Время`='{dateTimePicker1.Value.ToString("yyyy-MM-dd")}'" +
                $" WHERE `reis`.`idreis`= '{id}'";


            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Изменено успешно", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            back();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            back();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы действительно хотите удаить рейс?", "Подтвердите действие", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                MySqlConnection con = new MySqlConnection(SQLconnect);
                con.Open();
                string DelQeury = $"SET FOREIGN_KEY_CHECKS=0; " +
                    $"Delete`reis`,`tickets` from `reis` JOIN `tickets` ON (`tickets`.`idreis` = `reis`.`idreis`) where `idreis`='{id}';" +
                    $"SET FOREIGN_KEY_CHECKS=1; ";
                MySqlCommand cmdDel = new MySqlCommand(DelQeury, con);
                cmdDel.ExecuteNonQuery();
                MessageBox.Show("Рейс удален", "Успешно удалено", MessageBoxButtons.OK, MessageBoxIcon.Information);
                back();
            }
            else if (result == DialogResult.No)
            {
                MessageBox.Show("Изменения отменены", "Отмена", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
