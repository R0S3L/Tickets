using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Tickets
{
    public partial class Main : Form
    {
        string SQLconnect = "server = localhost; port=3306; userid=root; password=t9qd9jqs; database=train_tickets_sokolov; sslmode=none; charset=utf8 ";
        int userId;
        public Main(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            get_data();
            get_info();
        }
        void get_info()
        {
            MySqlConnection conn = new MySqlConnection(SQLconnect);
            conn.Open();
            string queU = $"SELECT * FROM `user` WHERE `user`.`iduser`='{userId}'";
            MySqlCommand cmd = new MySqlCommand(queU, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                //user data
                Namee.Text = reader["ФИО"].ToString();
                textBox1.Text = reader["Логин"].ToString();
                textBox2.Text = reader["Пароль"].ToString();
                textBox3.Text = reader["ФИО"].ToString();
                textBox4.Text = reader["Серия_Номер_Паспорта"].ToString();
                dateTimePicker1.Text = reader["Дата_Рождения"].ToString();
            }
            conn.Close();
        }
        void get_data()
        {

            MySqlConnection con1 = new MySqlConnection(SQLconnect);
            String que = $"SELECT * FROM `tickets`" +
                $" LEFT JOIN `user` ON (`user`.`iduser`= `tickets`.`iduser`)" +
                $" LEFT JOIN `reis`  ON (`reis`.`idreis` = `tickets`.`idreis`)" +
                $" WHERE `user`.`iduser`='{userId}'";
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
            dataGridView1.Columns["iduser"].Visible = false;
            dataGridView1.Columns["idtickets"].Visible = false;
            dataGridView1.Columns["Кол-во_Вагонов"].Visible = false;
            dataGridView1.Columns["Кол-во_Билетов"].Visible = false;
            dataGridView1.Columns["idreis1"].Visible = false;
            dataGridView1.Columns["iduser1"].Visible = false;
            dataGridView1.Columns["Логин"].Visible = false;
            dataGridView1.Columns["Пароль"].Visible = false;
            dataGridView1.Columns["Дата_Рождения"].Visible = false;
            dataGridView1.Columns["Серия_Номер_Паспорта"].Visible = false;
            dataGridView1.Columns["ФИО"].Visible = false;
            //columns in the right position
            dataGridView1.Columns["Пункт_Отправки"].DisplayIndex = 0;
            dataGridView1.Columns["Пункт_Назначения"].DisplayIndex = 1;
            dataGridView1.Columns["ФИО"].DisplayIndex = 2;
            con1.Close();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы действительно хотите изменить аккаунт?", "Подтвердите действие", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                MySqlConnection con = new MySqlConnection(SQLconnect);
                con.Open();
                string que = $"UPDATE `user` " +
                    $"SET" +
                    $" `ФИО` = '{textBox3.Text}' , " +
                    $" `Логин` = '{textBox1.Text}' , " +
                    $" `Пароль` = '{textBox2.Text}' , " +
                    $" `Серия_Номер_Паспорта` = '{textBox4.Text}' , " +
                    $" `Дата_Рождения` = '{dateTimePicker1.Value.ToString("yyyy-MM-dd")}' " +
                    $"  WHERE `iduser` = '{userId}' ";
                MySqlCommand cmd = new MySqlCommand(que, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Изменено успешно\n Войдите заново ", "Успешно изменено", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            }
            else if (result == DialogResult.No)
            {
                MessageBox.Show("Изменения отменены", "Отмена", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            dateTimePicker1.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Authorization pick = new Authorization(userId);
            this.Hide();
            if (pick.ShowDialog() == DialogResult.OK)
            {
                get_data();
            }
            pick.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы действительно хотите удалить аккаунт?", "Подтвердите действие", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                MySqlConnection con = new MySqlConnection(SQLconnect);
                con.Open();
                string DelQeury = $"SET FOREIGN_KEY_CHECKS=0; " +
                    $"Delete `user`, `tickets` from `user` JOIN `tickets` ON (`tickets`.`iduser` = `user`.`iduser`) where `user`.`iduser`='{userId}';" +
                    $"SET FOREIGN_KEY_CHECKS=1 ";
                MySqlCommand cmdDel = new MySqlCommand(DelQeury, con);
                cmdDel.ExecuteNonQuery();
                MessageBox.Show("Аккаунт удален успешно,\n Авторизируйтесь или зарегистрируйтесь снова", "Успешно удалено", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                con.Close();
                Authorization back = new Authorization(userId);
                this.Hide();
                if (back.ShowDialog() == DialogResult.OK)
                {
                    get_data();
                }
                back.Show();
            }
            else if (result == DialogResult.No)
            {
                MessageBox.Show("Изменения отменены", "Отмена", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            YourTicket ticket = new YourTicket(dataGridView1.SelectedRows[0].Cells[0].Value, userId);
            this.Hide();
            if (ticket.ShowDialog() == DialogResult.OK)
            {
                get_data();
            }
            ticket.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            BuyTicket buy = new BuyTicket(userId);
            this.Hide();
            if (buy.ShowDialog() == DialogResult.OK)
            {
                get_data();
            }
            buy.Show();
        }
    }
}
