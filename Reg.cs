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
    public partial class Reg : Form
    {
        public int userID;
        string SQLconnect = "server = localhost; port=3306; userid=root; password=t9qd9jqs; database=train_tickets_sokolov; sslmode=none; charset=utf8 ";
        public Reg()
        {
            InitializeComponent();
            get_data();
        }
        void get_data()
        {
            MySqlConnection conn = new MySqlConnection(SQLconnect);
            conn.Open();
            String que = "Select * from `user`";
            MySqlDataAdapter msda = new MySqlDataAdapter(que, conn);
            DataTable table = new DataTable();
            msda.Fill(table);

        }
        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(SQLconnect);
            con.Open();
            string Querry = "INSERT INTO `user` (`ФИО`, `Логин`, `Пароль`, `Дата_Рождения`, `Серия_Номер_Паспорта` ) " +
                "VALUES (" +
               $" '{textBox1.Text}' ," +
               $" '{textBox2.Text}' ," +
               $" '{textBox3.Text}' ," +
               $" '{dateTimePicker1.Value.ToString("yyyy-MM-dd")}'," +
               $" '{textBox4.Text}' " +
               ") ";
            MySqlCommand cmd = new MySqlCommand(Querry, con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Реистрация успешна", "Успешно выполнено", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            Authorization authorization = new Authorization(userID);
            this.Close();
            authorization.Show();
        }

        private void Reg_Load(object sender, EventArgs e)
        {

        }
    }
}
