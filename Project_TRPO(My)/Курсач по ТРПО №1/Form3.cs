using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Курсач_по_ТРПО__1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }
        Point lastPoint;

        private void Form3_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void Form3_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "Название фильма" && textBox2.Text != "Описание фильма" && textBox3.Text != "Ваш отзыв о фильме" && textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                string film = textBox1.Text;
                string film_info = textBox2.Text;
                string feedback = textBox3.Text;
                dataGridView1.Rows.Add(film, film_info, feedback);
            }
            else {MessageBox.Show("Одна из строк пустая или неверный ввод данных", "Ошибка");}
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                int ind = dataGridView1.SelectedCells[0].RowIndex;
                dataGridView1.Rows.RemoveAt(ind);
            }
            catch
            {
                MessageBox.Show("Нельзя данную строку удалить.", "Ошибка");
            }

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
        }
    }
}
