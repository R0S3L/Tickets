using System.Drawing;
using System.Windows.Forms;

namespace Tickets
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            Namee = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            Login = new Label();
            Pass = new Label();
            FIO = new Label();
            Pasport = new Label();
            Birth = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            label1 = new Label();
            button5 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(256, 43);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(826, 294);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
            // 
            // Namee
            // 
            Namee.AutoSize = true;
            Namee.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            Namee.Location = new Point(12, 9);
            Namee.Name = "Namee";
            Namee.Size = new Size(83, 32);
            Namee.TabIndex = 1;
            Namee.Text = "label1";
            // 
            // textBox1
            // 
            textBox1.Enabled = false;
            textBox1.Location = new Point(23, 80);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            textBox2.Enabled = false;
            textBox2.Location = new Point(23, 128);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 2;
            // 
            // textBox3
            // 
            textBox3.Enabled = false;
            textBox3.Location = new Point(23, 182);
            textBox3.Name = "textBox3";
            textBox3.ReadOnly = true;
            textBox3.Size = new Size(100, 23);
            textBox3.TabIndex = 2;
            // 
            // textBox4
            // 
            textBox4.Enabled = false;
            textBox4.Location = new Point(23, 285);
            textBox4.Name = "textBox4";
            textBox4.ReadOnly = true;
            textBox4.Size = new Size(100, 23);
            textBox4.TabIndex = 2;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Enabled = false;
            dateTimePicker1.Location = new Point(23, 234);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 3;
            // 
            // Login
            // 
            Login.AutoSize = true;
            Login.Location = new Point(23, 62);
            Login.Name = "Login";
            Login.Size = new Size(41, 15);
            Login.TabIndex = 1;
            Login.Text = "Логин";
            // 
            // Pass
            // 
            Pass.AutoSize = true;
            Pass.Location = new Point(23, 110);
            Pass.Name = "Pass";
            Pass.Size = new Size(49, 15);
            Pass.TabIndex = 1;
            Pass.Text = "Пароль";
            // 
            // FIO
            // 
            FIO.AutoSize = true;
            FIO.Location = new Point(23, 164);
            FIO.Name = "FIO";
            FIO.Size = new Size(31, 15);
            FIO.TabIndex = 1;
            FIO.Text = "Имя";
            // 
            // Pasport
            // 
            Pasport.AutoSize = true;
            Pasport.Location = new Point(23, 267);
            Pasport.Name = "Pasport";
            Pasport.Size = new Size(146, 15);
            Pasport.TabIndex = 1;
            Pasport.Text = "Серия и Номер паспорта";
            // 
            // Birth
            // 
            Birth.AutoSize = true;
            Birth.Location = new Point(23, 216);
            Birth.Name = "Birth";
            Birth.Size = new Size(90, 15);
            Birth.TabIndex = 1;
            Birth.Text = "Дата рождения";
            // 
            // button1
            // 
            button1.Location = new Point(54, 314);
            button1.Name = "button1";
            button1.Size = new Size(146, 23);
            button1.TabIndex = 4;
            button1.Text = "Изменить данные";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackgroundImage = Properties.Resources.pen;
            button2.BackgroundImageLayout = ImageLayout.Stretch;
            button2.Location = new Point(23, 314);
            button2.Name = "button2";
            button2.Size = new Size(27, 23);
            button2.TabIndex = 5;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(23, 364);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 6;
            button3.Text = "Выйти";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(103, 364);
            button4.Name = "button4";
            button4.Size = new Size(120, 23);
            button4.TabIndex = 7;
            button4.Text = "Удалить аккаунт";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(256, 8);
            label1.Name = "label1";
            label1.Size = new Size(173, 32);
            label1.TabIndex = 1;
            label1.Text = "Ваши билеты";
            // 
            // button5
            // 
            button5.Location = new Point(256, 343);
            button5.Name = "button5";
            button5.Size = new Size(137, 27);
            button5.TabIndex = 8;
            button5.Text = "Забронировать билет";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1094, 401);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dateTimePicker1);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(Birth);
            Controls.Add(Pasport);
            Controls.Add(FIO);
            Controls.Add(Pass);
            Controls.Add(Login);
            Controls.Add(label1);
            Controls.Add(Namee);
            Controls.Add(dataGridView1);
            Name = "Main";
            Text = "Main";
            Load += Main_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label Namee;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private DateTimePicker dateTimePicker1;
        private Label Login;
        private Label Pass;
        private Label FIO;
        private Label Pasport;
        private Label Birth;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Label label1;
        private Button button5;
    }
}