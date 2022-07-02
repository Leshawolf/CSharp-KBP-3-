using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
namespace Программа_для_косметологического_салона
{ 
    public partial class Заказы_клиенты : Window
    {
        int ID_user;
        List<Service> service = new List<Service> { };
        public Заказы_клиенты(int a)
        {
            InitializeComponent();
            ID_user = a;
            FillGrid();
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
        private void Print_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog a = new PrintDialog();
            if (a.ShowDialog() == true)
                a.PrintVisual(Информация, "Печать");
        }
        private void FillGrid()
        {
            Информация.ItemsSource = null;
            OrderComboBox.ItemsSource = null;
            service.Clear();
            List<string> b = new List<string> { };
            string Query = $"SELECT ID_заказа, Тип, Название, Цена_заказа, Дата, Время, Заказ.ID_времени, ФИО FROM Услуга INNER JOIN Заказ ON Услуга.ID_услуги = Заказ.ID_услуги INNER JOIN Время ON Заказ.ID_времени = Время.ID_времени INNER JOIN Дата ON Время.ID_даты = Дата.ID_даты INNER JOIN Пользователи ON Заказ.ID_работника = Пользователи.ID_пользователя INNER JOIN Тип ON Услуга.ID_типа_услуг = Тип.ID_типа_услуг WHERE Заказ.ID_пользователя = { ID_user }";
            SqlConnection Connection = new SqlConnection(Service.ConnectionString);
            try
            {
                Connection.Open();
                SqlCommand Command = new SqlCommand(Query, Connection);
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
    }
}