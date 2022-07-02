using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;
using Excel = Microsoft.Office.Interop.Excel;
namespace Программа_для_косметологического_салона
{
    public partial class Меню_администратора : Window
    {
        int Check = 0;
        public Меню_администратора()
        {
            InitializeComponent();
            Hides();
        }
        private void AddWorker_Click(object sender, RoutedEventArgs e)
        {
            Hides();
            LoginLabel.Visibility = Visibility.Visible;
            Login.Visibility = Visibility.Visible;
            TypeLabel.Visibility = Visibility.Visible;
            TypeComboBox.Visibility = Visibility.Visible;
            string Query = "SELECT Тип FROM Тип";
            TypeComboBox.ItemsSource = Service.SQLFunctionGetList(Query);
            Use.Visibility = Visibility.Visible;
            Cancel.Visibility = Visibility.Visible;
            Check = 1;
        }
        private void DeleteWorker_Click(object sender, RoutedEventArgs e)
        {
            Hides();
            SelectLoginLabel.Visibility = Visibility.Visible;
            WorkerComboBox.Visibility = Visibility.Visible;
            string Query = "SELECT Логин FROM Пользователи";
            WorkerComboBox.ItemsSource = Service.SQLFunctionGetList(Query);
            Use.Visibility = Visibility.Visible;
            Cancel.Visibility = Visibility.Visible;
            Check = 2;
        }
        private void AddService_Click(object sender, RoutedEventArgs e)
        {
            Hides();
            TypeLabel.Visibility = Visibility.Visible;
            TypeComboBox.Visibility = Visibility.Visible;
            string Query = "SELECT Тип FROM Тип";
            TypeComboBox.ItemsSource = Service.SQLFunctionGetList(Query);
            NameLabel.Visibility = Visibility.Visible;
            Name.Visibility = Visibility.Visible;
            PriceLabel.Visibility = Visibility.Visible;
            Price.Visibility = Visibility.Visible;
            Use.Visibility = Visibility.Visible;
            Cancel.Visibility = Visibility.Visible;
            Check = 3;
        }
        private void EditService_Click(object sender, RoutedEventArgs e)
        {
            Hides();
            ServiceLabel.Visibility = Visibility.Visible;
            ServiceComboBox.Visibility = Visibility.Visible;
            string Query = "SELECT Название FROM Услуга";
            ServiceComboBox.ItemsSource = Service.SQLFunctionGetList(Query);
            TypeLabel.Visibility = Visibility.Visible;
            TypeComboBox.Visibility = Visibility.Visible;
            Query = "SELECT Тип FROM Тип";
            TypeComboBox.ItemsSource = Service.SQLFunctionGetList(Query);
            NameLabel.Visibility = Visibility.Visible;
            Name.Visibility = Visibility.Visible;
            PriceLabel.Visibility = Visibility.Visible;
            Price.Visibility = Visibility.Visible;
            Use.Visibility = Visibility.Visible;
            Cancel.Visibility = Visibility.Visible;
            SqlConnection Connection = new SqlConnection(Service.ConnectionString);
            Query = $"SELECT ID_типа_услуг, Название, Стоимость FROM Услуга INNER JOIN Цена ON Услуга.ID_услуги = Цена.ID_услуги WHERE Услуга.ID_услуги =  { Service.SQLFunctionGetID($"SELECT ID_услуги FROM Услуга WHERE Название = '{ ServiceComboBox.SelectedItem }'") }";
            try
            {
                Connection.Open();
                SqlCommand Command = new SqlCommand(Query, Connection);
                SqlDataReader Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    TypeComboBox.SelectedIndex = Convert.ToInt32(Reader[0]) - 1;
                    Name.Text = Convert.ToString(Reader[1]);
                    Price.Text = Convert.ToString(Reader[2]);
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
            Check = 4;
        }
        private void DeleteService_Click(object sender, RoutedEventArgs e)
        {
            Hides();
            ServiceComboBox.Visibility = Visibility.Visible;
            ServiceLabel.Visibility = Visibility.Visible;
            string Query = "SELECT Название FROM Услуга";
            ServiceComboBox.ItemsSource = Service.SQLFunctionGetList(Query);
            Use.Visibility = Visibility.Visible;
            Cancel.Visibility = Visibility.Visible;
            Check = 5;
        }
        private void ServiceComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {   
            SqlConnection Connection = new SqlConnection(Service.ConnectionString);
            string Query = $"SELECT ID_типа_услуг, Название, Стоимость FROM Услуга INNER JOIN Цена ON Услуга.ID_услуги = Цена.ID_услуги WHERE Услуга.ID_услуги = {  Service.SQLFunctionGetID($"SELECT ID_услуги FROM Услуга WHERE Название = '{ ServiceComboBox.SelectedItem }'") }";
            try
            {
                Connection.Open();
                SqlCommand Command = new SqlCommand(Query, Connection);
                SqlDataReader Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    TypeComboBox.SelectedIndex = Convert.ToInt32(Reader[0]) - 1;
                    Name.Text = Convert.ToString(Reader[1]);
                    Price.Text = Convert.ToString(Reader[2]);
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
            Check = 4;
        }
        private void Report_Click(object sender, RoutedEventArgs e)
        {
            List<Service> service = new List<Service> { };
            string Query = $"SELECT ID_заказа, Тип, Название, Цена_заказа, Дата, Время, Заказ.ID_времени, ФИО FROM Услуга INNER JOIN Заказ ON Услуга.ID_услуги = Заказ.ID_услуги INNER JOIN Время ON Заказ.ID_времени = Время.ID_времени INNER JOIN Дата ON Время.ID_даты = Дата.ID_даты INNER JOIN Пользователи ON Заказ.ID_пользователя = Пользователи.ID_пользователя INNER JOIN Тип ON Услуга.ID_типа_услуг = Тип.ID_типа_услуг";
            SqlConnection Connection = new SqlConnection(Service.ConnectionString);
            try
            {
                Connection.Open();
                SqlCommand Command = new SqlCommand(Query, Connection);
                SqlDataReader Reader = Command.ExecuteReader();
                while (Reader.Read())
                    service.Add(new Service(Convert.ToInt32(Reader[0]), Convert.ToString(Reader[1]), Convert.ToString(Reader[2]), Convert.ToInt32(Reader[3]), Convert.ToString(Reader[4]), Convert.ToString(Reader[5]), Convert.ToInt32(Reader[6]), Convert.ToString(Reader[7])));
            }
            catch
            {
                MessageBox.Show("Ошибка подключения к БД!");
            }
            finally
            {
                Connection.Close();
            }
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
            for (int i = 0; i < service.Count; i++)
                sum += service[i].Price;
            sum /= 5;
            b.Cells[service.Count + 4, 1] = "Прибыль: " + sum;
            a.Visible = true;
        }
        private void Use_Click(object sender, RoutedEventArgs e)
        {
            string Query = "";
            switch (Check)
            {
                case 1:
                    if (Login.Text == "")
                        MessageBox.Show("Логин не может быть пустым!");
                    else
                    {
                        string chars = "abcdefghijklnopqrstuvwxyz";
                        string password = "";
                        Random rand = new Random();
                        for (int i = 0; i < 7; i++)
                            password += chars[rand.Next(0, 25)];
                        Query = $"INSERT INTO Пользователи(Логин, Пароль, Уровень, ID_типа_услуги) VALUES('{ Login.Text }', '{ password }', 2, { TypeComboBox.SelectedIndex + 1})";
                        Service.SQLFunction(Query);
                        MessageBox.Show("Работник успешно добавлен!\nЛогин: " + Login.Text + "\nПароль: " + password);
                    }
                    break;
                case 2:
                    Query = $"DELETE FROM Пользователи WHERE Логин = '{ WorkerComboBox.SelectedItem }'";
                    Service.SQLFunction(Query);
                    MessageBox.Show("Работник успешно удалён!");
                    break;
                case 3:
                    Query = $"INSERT INTO Услуга(Название, ID_типа_услуг) VALUES('{ Name.Text }', { TypeComboBox.SelectedIndex + 1 })";
                    Service.SQLFunction(Query);
                    Query = $"SELECT ID_услуги FROM Услуга WHERE Название = '{ Name.Text }'";                    
                    int id = Service.SQLFunctionGetID($"SELECT ID_услуги FROM Услуга WHERE Название = '{ Name.Text }'");
                    Query = $"INSERT INTO Цена(Стоимость, ID_услуги) VALUES({ Convert.ToInt32(Price.Text) }, { id })";
                    Service.SQLFunction(Query);
                    MessageBox.Show("Услуга успешно добавлена!");
                    break;
                case 4:
                    Query = $"UPDATE Услуга SET Название = '{ Name.Text }', ID_типа_услуг = { TypeComboBox.SelectedIndex + 1 } WHERE ID_услуги = { Service.SQLFunctionGetID($"SELECT ID_услуги FROM Услуга WHERE Название = '{ ServiceComboBox.SelectedItem }'") }";
                    Service.SQLFunction(Query);
                    Query = $"UPDATE Цена SET Стоимость = { Price.Text }, WHERE ID_услуги = { Service.SQLFunctionGetID($"SELECT ID_услуги FROM Услуга WHERE Название = '{ ServiceComboBox.SelectedItem }'") }";
                    MessageBox.Show("Данные успешно изменены!");
                    break;
                case 5:
                    Query = $"DELETE FROM Цена WHERE ID_услуги = { Service.SQLFunctionGetID($"SELECT ID_услуги FROM Услуга WHERE Название = '{ ServiceComboBox.SelectedItem }'") }";
                    Service.SQLFunction(Query);
                    Query = $"DELETE FROM Услуга WHERE ID_услуги = { Service.SQLFunctionGetID($"SELECT ID_услуги FROM Услуга WHERE Название = '{ ServiceComboBox.SelectedItem }'") }";
                    Service.SQLFunction(Query);
                    MessageBox.Show("Услуга успешно удалена!");
                    break;
            }
            Hides();
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Hides();
        }
        private void Hides()
        {
            LoginLabel.Visibility = Visibility.Hidden;
            Login.Visibility = Visibility.Hidden;
            Login.Text = "";
            SelectLoginLabel.Visibility = Visibility.Hidden;
            WorkerComboBox.Visibility = Visibility.Hidden;
            WorkerComboBox.SelectedIndex = 0;
            ServiceLabel.Visibility = Visibility.Hidden;
            ServiceComboBox.Visibility = Visibility.Hidden;
            ServiceComboBox.SelectedIndex = 0;
            TypeLabel.Visibility = Visibility.Hidden;
            TypeComboBox.Visibility = Visibility.Hidden;
            TypeComboBox.SelectedIndex = 0;
            NameLabel.Visibility = Visibility.Hidden;
            Name.Visibility = Visibility.Hidden;
            Name.Text = "";
            PriceLabel.Visibility = Visibility.Hidden;
            Price.Visibility = Visibility.Hidden;
            Price.Text = "";
            Use.Visibility = Visibility.Hidden;
            Cancel.Visibility = Visibility.Hidden;
        }
    }
}