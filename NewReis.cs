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

namespace Tickets
{
    public partial class NewReis : Form
    {
        string SQLconnect = "server = localhost; port=3306; userid=root; password=t9qd9jqs; database=train_tickets_sokolov; sslmode=none; charset=utf8 ";
        int idadmin;
        public NewReis(int idadmin)
        {
            InitializeComponent();
            this.idadmin = idadmin;
        }
        void Insert()
        {
            MySqlConnection con = new MySqlConnection(SQLconnect);
            con.Open();
            string Querry = "INSERT INTO `reis` (`Пункт_Отправки`, `Пункт_Назначения`, `Кол-во_Вагонов`, `Кол-во_Билетов`, `Платформа`, `Дата_и_Время`, `Цена`   ) " +
                "VALUES (" +
               $" '{textBox1.Text}' ," +
               $" '{textBox2.Text}' ," +
               $" '{textBox3.Text}' ," +
               $" '{textBox4.Text}' ," +
               $" '{textBox5.Text}' ," +
               $" '{dateTimePicker1.Value.ToString("yyyy-MM-dd")}'," +
               $" '{textBox7.Text}' " +
               ") ";
            MySqlCommand cmd = new MySqlCommand(Querry, con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Добавление успешно", "Успешно выполнено", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            Adm_Main pick = new Adm_Main(idadmin);
            this.Hide();
            if (pick.ShowDialog() == DialogResult.OK)
            {

            }
            pick.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Insert();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Adm_Main pick = new Adm_Main(idadmin);
            this.Hide();
            if (pick.ShowDialog() == DialogResult.OK)
            {
                
            }
            pick.Show();
        }
    }
}
