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
    public partial class Form1 : Form
    {
        private SQLiteConnection DB;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DB = new SQLiteConnection("Data Source = UsersInfo.db; Version = 3");//Создание потока для базы данных с инфомрацией о пользователях
            DB.Open();//Открытие базы данных
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();//Закрывает главное открытое окно
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();//Визуально скриывает главное окно
            Form2 form2 = new Form2();//Создаёт поток для формы2
            form2.Show();//Открываем форму2
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if(textBox1.Text!="" || textBox2.Text!="") //Проверка текстобоксов на ввод пустой строки
            {
                SQLiteCommand CMD = DB.CreateCommand();//Подключение к базе данных
                CMD.CommandText = "select * from Users where Password like '%' || @Password || '%' and Login like '%' || @Login || '%'";//Создание Password and Login место которых в дальнейшем будут вводные данные
                CMD.Parameters.Add("@Login", DbType.String).Value = textBox1.Text.ToUpper();//Берёт с текстбокса 1 информациию и добавляет в базу данных
                CMD.Parameters.Add("@Password", DbType.String).Value = textBox2.Text.ToUpper();//Берёт с текстбокса 2 информацию и добавляет в базу данных
                SQLiteDataReader SQL= CMD.ExecuteReader();//Передача полной инфомрации в БАзу данных
                if (SQL.HasRows)//Проврка через базу данных, для перехода на след окер
                {
                    this.Hide();//Скрываем открытое окно
                    Form3 form3 = new Form3();// Создаём поток для формы3
                    form3.Show();//Открываем форму3
                }
                else //Если не проходит блок if, то переходит  
                {
                    MessageBox.Show("Неправильно введены какие-то данные. Проверьте введённые данные.", "Ошибка");//Вывод сообщения в Боксе
                }
 
            }
            else
            {
                MessageBox.Show("Одно из полей пустное.", "Ошибка");//Вывод сообщение об ошибке
            }
            

        }
        Point lastPoint;//Создание локальное перменной
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button==MouseButtons.Left)//Проверка удерживание мышки на окне
            {
                this.Left += e.X - lastPoint.X;//Передвижение окна по X-у
                this.Top  += e.Y - lastPoint.Y;//Передвижение окна по Y-у
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);//Передвижение формы вниз
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            DB.Close();//Закрытие поток для базы данных
        }
    }
}
