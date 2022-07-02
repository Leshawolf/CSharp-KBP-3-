using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;
namespace Программа_для_косметологического_салона
{
    class Service
    {
        static public string ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=Салон;Integrated Security=True";
        public int ID { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public int ID_time { get; set; }
        public string User { get; set; }
        public Service(int a, string b, string c, int d, string e, string f, int g, string h)
        {
            ID = a;
            Type = b;
            Name = c;
            Price = d;
            Date = e;
            Time = f;
            ID_time = g;
            User = h;
        }
        static public void SQLFunction(string Query)
        {
            SqlConnection Connection = new SqlConnection(ConnectionString);
            try
            {
                Connection.Open();
                SqlCommand Command = new SqlCommand(Query, Connection);
                SqlDataReader Reader = Command.ExecuteReader();
            }
            catch
            {
                MessageBox.Show("Ошибка подключения к БД!");
            }
            finally
            {
                Connection.Close();
            }
        }
        static public int SQLFunctionGetID(string Query)
        {
            int ID = 0;
            SqlConnection Connection = new SqlConnection(Service.ConnectionString);
            try
            {
                Connection.Open();
                SqlCommand Command = new SqlCommand(Query, Connection);
                SqlDataReader Reader = Command.ExecuteReader();
                while (Reader.Read())
                    ID = Convert.ToInt32(Reader[0]);
            }
            catch
            {
                MessageBox.Show("Ошибка подключения к БД!");
            }
            finally
            {
                Connection.Close();
            }
            return ID;
        }
        static public List<string> SQLFunctionGetList(string Query)
        {
            List<String> a = new List<String> { };
            string ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=Салон;Integrated Security=True";
            SqlConnection Connection = new SqlConnection(ConnectionString);
            try
            {
                Connection.Open();
                SqlCommand Command = new SqlCommand(Query, Connection);
                SqlDataReader Reader = Command.ExecuteReader();
                while (Reader.Read())
                    a.Add(Convert.ToString(Reader[0]));
            }
            catch
            {
                MessageBox.Show("Ошибка подключения к БД!");
            }
            finally
            {
                Connection.Close();
            }
            return a;
        }
    }
    public partial class Главное_окно : Window
    {
        int Check = 1;
        int Price;
        int ID_user;
        int ID_worker;
        int ID_service;
        int ID_time;
        public Главное_окно(int a)
        {
            InitializeComponent();
            ID_user = a;
            MainFunction();         
        }
        private void Manicure_Click(object sender, RoutedEventArgs e)
        {
            Check = 1;
            MainFunction();
        }
        private void Pedicure_Click(object sender, RoutedEventArgs e)
        {
            Check = 2;
            MainFunction();
        }
        private void Haircut_Click(object sender, RoutedEventArgs e)
        {
            Check = 3;
            MainFunction();
        }
        private void Сomplex_сoloring_Click(object sender, RoutedEventArgs e)
        {
            Check = 4;
            MainFunction();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Check = 5;
            MainFunction();
        }
        private void Brows_Click(object sender, RoutedEventArgs e)
        {
            Check = 6;
            MainFunction();
        }
        private void Orders_Click(object sender, RoutedEventArgs e)
        {
            Заказы_клиенты a = new Заказы_клиенты(ID_user);
            a.Show();
        }
        private void Cabinet_Click(object sender, RoutedEventArgs e)
        {
            Личный_кабинет a = new Личный_кабинет(ID_user);
            a.Show();
        }
        private void MainFunction()
        {
            string Query = $"SELECT ФИО FROM Пользователи WHERE ID_типа_услуги = '{ Check }'";
            WorkerComboBox.ItemsSource = Service.SQLFunctionGetList(Query);
            Query = $"SELECT Название FROM Услуга WHERE ID_типа_услуг = '{ Check }'";
            ServiceComboBox.ItemsSource = Service.SQLFunctionGetList(Query);
            WorkerComboBox.SelectedIndex = 0;
            ServiceComboBox.SelectedIndex = 0;
        }
        private void WorkerComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            string Query = $"SELECT ID_пользователя FROM Пользователи WHERE ФИО = '{ WorkerComboBox.SelectedItem }'";
            ID_worker = Service.SQLFunctionGetID(Query);
            Query = $"SELECT Дата FROM Дата WHERE ID_Пользователя = { ID_worker }";
            DateComboBox.ItemsSource = Service.SQLFunctionGetList(Query);
            DateComboBox.SelectedIndex = 0;
        }
        private void DateComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            string Query = $"SELECT ID_даты FROM Дата WHERE Дата = '{ DateComboBox.SelectedItem }'";
            int ID_date = Service.SQLFunctionGetID(Query);
            Query = $"SELECT Время FROM Время WHERE ID_даты = { ID_date } AND Статус = 1";
            TimeComboBox.ItemsSource = Service.SQLFunctionGetList(Query);
            TimeComboBox.SelectedIndex = 0;
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            string Query = $"SELECT Услуга.ID_услуги FROM Услуга INNER JOIN Цена ON Услуга.ID_услуги = Цена.ID_услуги WHERE Название = '{ ServiceComboBox.SelectedItem }'";
            ID_service = Service.SQLFunctionGetID(Query);
            Query = $"SELECT Стоимость FROM Услуга INNER JOIN Цена ON Услуга.ID_услуги = Цена.ID_услуги WHERE Название = '{ ServiceComboBox.SelectedItem }'";
            Price = Service.SQLFunctionGetID(Query);
            Query = $"SELECT ID_времени FROM Время WHERE Время = '{ TimeComboBox.SelectedItem }'";
            ID_time = Service.SQLFunctionGetID(Query);        
            Query = $"INSERT INTO Заказ(Цена_заказа, ID_пользователя, ID_услуги, ID_времени, ID_работника)VALUES({ Price }, { ID_user }, { ID_service }, { ID_time }, { ID_worker })";
            Service.SQLFunction(Query);
            Query = $"UPDATE Время SET Статус = 2 WHERE ID_времени = { ID_time }";
            Service.SQLFunction(Query);
            MessageBox.Show("Вы успешно записались на услугу!");
            Hiden();
        }
        private void Hide_Click(object sender, RoutedEventArgs e)
        {
            Hiden();
        }
        private void Hiden()
        {
            Check = 1;
            WorkerComboBox.SelectedIndex = 0;
            ServiceComboBox.SelectedIndex = 0;
            DateComboBox.SelectedIndex = 0;
            TimeComboBox.SelectedIndex = 0;
            MainFunction();
        }
    }
}