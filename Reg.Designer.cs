using System.Drawing;
using System.Windows.Forms;

namespace Tickets
{
    partial class Reg
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
            passtext = new Label();
            textBox1 = new TextBox();
            button1 = new Button();
            datetext = new Label();
            FIOtext = new Label();
            logintext = new Label();
            textBox2 = new TextBox();
            textBox4 = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            textBox3 = new TextBox();
            pasporttext = new Label();
            SuspendLayout();
            // 
            // passtext
            // 
            passtext.AutoSize = true;
            passtext.Location = new Point(12, 132);
            passtext.Name = "passtext";
            passtext.Size = new Size(49, 15);
            passtext.TabIndex = 0;
            passtext.Text = "Пароль";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 36);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 1;
            // 
            // button1
            // 
            button1.ForeColor = SystemColors.ActiveCaptionText;
            button1.Location = new Point(12, 305);
            button1.Name = "button1";
            button1.Size = new Size(130, 23);
            button1.TabIndex = 2;
            button1.Text = "Зарегистрироваться";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // datetext
            // 
            datetext.AutoSize = true;
            datetext.Location = new Point(12, 191);
            datetext.Name = "datetext";
            datetext.Size = new Size(90, 15);
            datetext.TabIndex = 0;
            datetext.Text = "Дата Рождения";
            // 
            // FIOtext
            // 
            FIOtext.AutoSize = true;
            FIOtext.Location = new Point(12, 18);
            FIOtext.Name = "FIOtext";
            FIOtext.Size = new Size(34, 15);
            FIOtext.TabIndex = 0;
            FIOtext.Text = "ФИО";
            // 
            // logintext
            // 
            logintext.AutoSize = true;
            logintext.Location = new Point(12, 72);
            logintext.Name = "logintext";
            logintext.Size = new Size(41, 15);
            logintext.TabIndex = 0;
            logintext.Text = "Логин";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(12, 90);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 1;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(12, 263);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(100, 23);
            textBox4.TabIndex = 1;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(12, 209);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(144, 23);
            dateTimePicker1.TabIndex = 3;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(12, 150);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(100, 23);
            textBox3.TabIndex = 4;
            // 
            // pasporttext
            // 
            pasporttext.AutoSize = true;
            pasporttext.Location = new Point(12, 245);
            pasporttext.Name = "pasporttext";
            pasporttext.Size = new Size(144, 15);
            pasporttext.TabIndex = 5;
            pasporttext.Text = "Серия и номер паспорта";
            // 
            // Reg
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(389, 392);
            Controls.Add(pasporttext);
            Controls.Add(textBox3);
            Controls.Add(dateTimePicker1);
            Controls.Add(button1);
            Controls.Add(textBox4);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(logintext);
            Controls.Add(FIOtext);
            Controls.Add(datetext);
            Controls.Add(passtext);
            Name = "Reg";
            Text = "Reg";
            Load += Reg_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label passtext;
        private TextBox textBox1;
        private Button button1;
        private Label datetext;
        private Label FIOtext;
        private Label logintext;
        private TextBox textBox2;
        private TextBox textBox4;
        private DateTimePicker dateTimePicker1;
        private TextBox textBox3;
        private Label pasporttext;
    }
}