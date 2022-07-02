using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using Excel = Microsoft.Office.Interop.Excel;
namespace Программа_для_косметологического_салона
{
    public partial class Окно_работника : Window
    {
        static int ID_user = 0;
        List<Service> service = new List<Service> { };
        public Окно_работника(int a)
        {
            InitializeComponent();
            ID_user = a;
            FillGrid();
            FindComboBox.Items.Add("Поиск по названию услуги");
            FindComboBox.Items.Add("Поиск по ФИО клиета");
            Date.SelectedDate = DateTime.Now;
        }
        private void Cabinet_Click(object sender, RoutedEventArgs e)
        {
            Личный_кабинет a = new Личный_кабинет(ID_user);
            a.Show();
        }
        private void Report_Click(object sender, RoutedEventArgs e)
        {
            Excel.Application a = new Excel.Application();
            a.DisplayFullScreen = true;
            a.Workbooks.Add();
            Excel.Worksheet b = (Excel.Worksheet)a.ActiveSheet;
            Excel.Range c = null;
            b.Name = "История услуг";
            b.Cells[1, 1] = "Дата: " + Convert.ToString(DateTime.Now.ToShortDateString());
            b.Cells[2, 1] = "Количество услуг: " + service.Count;
            c = a.get_Range("A3:F3");
            c.Interior.Color = Excel.XlRgbColor.rgbYellow;
            c = a.get_Range("A1");
            c.ColumnWidth = 38;
            c = a.get_Range("B1");
            c.ColumnWidth = 50;
            c = a.get_Range("C1");
            c.ColumnWidth = 5;
            c = a.get_Range("D1");
            c.ColumnWidth = 10;
            c = a.get_Range("E1");
            c.ColumnWidth = 6;
            c = a.get_Range("F1");
            c.ColumnWidth = 35;
            b.Cells[3, 1] = "Тип услуги";
            b.Cells[3, 2] = "Название услуги";
            b.Cells[3, 3] = "Цена";
            b.Cells[3, 4] = "Дата";
            b.Cells[3, 5] = "Время";
            b.Cells[3, 6] = "ФИО клиента";
            for (int i = 4; i < service.Count + 4; i++)
            {
                b.Cells[i, 1] = service[i - 4].Type;
                b.Cells[i, 2] = service[i - 4].Name;
                b.Cells[i, 3] = service[i - 4].Price;
                b.Cells[i, 4] = service[i - 4].Date;
                b.Cells[i, 5] = service[i - 4].Time;
                b.Cells[i, 6] = service[i - 4].User;
            }
            int sum = 0;
            for(int i = 0; i < service.Count; i++)
                sum += service[i].Price;
            sum -= sum / 5;
            b.Cells[service.Count + 4, 1] = "Прибыль: " + sum;
            a.Visible = true;
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            string Query = $"DELETE FROM Заказ WHERE ID_заказа = { service[OrderComboBox.SelectedIndex].ID }";
            Service.SQLFunction(Query);
            Query = $"UPDATE Время SET Статус = 1 WHERE ID_времени = { service[OrderComboBox.SelectedIndex].ID_time }";
            Service.SQLFunction(Query);
            MessageBox.Show("Вы успешно отменили запись на услугу!");
            FillGrid();
        }
        private void FillGrid(string Query = "")
        {
            string MainQuery = $"SELECT ID_заказа, Тип, Название, Цена_заказа, Дата, Время, Заказ.ID_времени, ФИО FROM Услуга INNER JOIN Заказ ON Услуга.ID_услуги = Заказ.ID_услуги INNER JOIN Время ON Заказ.ID_времени = Время.ID_времени INNER JOIN Дата ON Время.ID_даты = Дата.ID_даты INNER JOIN Пользователи ON Заказ.ID_пользователя = Пользователи.ID_пользователя INNER JOIN Тип ON Услуга.ID_типа_услуг = Тип.ID_типа_услуг WHERE Заказ.ID_работника = { ID_user }" + Query;
            Информация.ItemsSource = null;
            service.Clear();
            OrderComboBox.ItemsSource = null;
            OrderComboBox.SelectedIndex = 0;
            List<string> b = new List<string> { };
            SqlConnection Connection = new SqlConnection(Service.ConnectionString);
            try
            {
                Connection.Open();
                SqlCommand Command = new SqlCommand(MainQuery, Connection);
                SqlDataReader Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    service.Add(new Service(Convert.ToInt32(Reader[0]), Convert.ToString(Reader[1]), Convert.ToString(Reader[2]), Convert.ToInt32(Reader[3]), Convert.ToString(Reader[4]), Convert.ToString(Reader[5]), Convert.ToInt32(Reader[6]), Convert.ToString(Reader[7])));
                    b.Add(Convert.ToString(Reader[1]));
                }
            }
            catch
            {
                MessageBox.Show("Ошибка подключения к БД!");
            }
            finally
            {
                Connection.Close();
            }
            Информация.ItemsSource = service;
            OrderComboBox.ItemsSource = b;
        }
        private void Find_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (FindComboBox.SelectedIndex == 0)
                FillGrid($" AND Название = '{ Find.Text }' OR Название LIKE '{ Find.Text }%'");
            else
                FillGrid($" AND ФИО = '{ Find.Text }' OR ФИО LIKE'{ Find.Text }%'");
        }
        private void AddDate_Click(object sender, RoutedEventArgs e)
        {
            string[] time = new string[9] { "10:00", "11:00", "12:00", "13:00", "14:00", "15:00", "16:00", "17:00", "18:00", };
            string Query = $"INSERT INTO Дата(Дата, ID_пользователя) VALUES('{ Date.Text }', { ID_user })";
            Service.SQLFunction(Query);
            Query = $"SELECT ID_даты FROM Дата WHERE Дата = '{ Date.Text }'";
            int id = Service.SQLFunctionGetID(Query);          
            for (int i = 0; i < 9; i++)
            {
                Query = $"INSERT INTO Время(Время, ID_даты, Статус) VALUES('{ time[i] }', { id }, 1)";
                Service.SQLFunction(Query);
            }
            MessageBox.Show("Рабочий день успешно добавлен!");
        }
    }
}