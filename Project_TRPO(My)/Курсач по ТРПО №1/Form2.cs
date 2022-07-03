using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Курсач_по_ТРПО__1
{
    public partial class Form2 : Form
    {
        private SQLiteConnection DB;
        public Form2()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();//По нажатию на картинку, закрыттие приложения
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();//Закрытие визуальное окна
            Form1 form1 = new Form1();//Создание потока под форму1
            form1.Show();//Отктие формы1
        }
        Point lastPoint;//Создание локальной переменной
        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)//Передвижение окна по оси X и Y
            {
                this.Left += e.X - lastPoint.X;//Ось X
                this.Top += e.Y - lastPoint.Y;//Ось Y
            }
        }

        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            DB = new SQLiteConnection("Data Source = UsersInfo.db; Version = 3");
            DB.Open();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            DB.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "" && textBox2.Text != "")
            {

                if (textBox2.Text != textBox3.Text)
                {
                    MessageBox.Show("Неправильно введёт повторно пароль");
                }
                else
                {

                    SQLiteCommand CMD = DB.CreateCommand();
                    CMD.CommandText = "insert into Users(Login,Password) values(@Login,@Password)";
                    CMD.Parameters.Add("@Login", DbType.String).Value = textBox1.Text.ToUpper();
                    CMD.Parameters.Add("@Password", DbType.String).Value = textBox2.Text.ToUpper();
                    CMD.ExecuteNonQuery();
                    MessageBox.Show("Регистрация аккаунта прошла успешно.");
                }
            }
            else
            {
                MessageBox.Show("Одна из строк пустая");
            }
        }
    }
}
