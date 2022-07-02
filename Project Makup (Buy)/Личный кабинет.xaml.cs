using System;
using System.Windows;
using System.Data.SqlClient;
namespace Программа_для_косметологического_салона
{
    public partial class Личный_кабинет : Window
    {
        int ID_user;      
        public Личный_кабинет(int a)
        {
            InitializeComponent();
            ID_user = a;
            SqlConnection Connection = new SqlConnection(Service.ConnectionString);
            string Query = $"SELECT Логин, ФИО, Дата_рождения, Телефон, Электронная_почта FROM Пользователи WHERE ID_пользователя = { ID_user }";
            try
            {
                Connection.Open();
                SqlCommand Command = new SqlCommand(Query, Connection);
                SqlDataReader Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    Login.Text = Convert.ToString(Reader[0]);
                    FIO.Text = Convert.ToString(Reader[1]);
                    DayOfBirthday.Text = Convert.ToString(Reader[2]);
                    Telephone.Text = Convert.ToString(Reader[3]);
                    Email.Text = Convert.ToString(Reader[4]);
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
        }
        private void SetNewPassword_Click(object sender, RoutedEventArgs e)
        {
            OldPassword.Visibility = Visibility.Visible;
            OldPasswordLabel.Visibility = Visibility.Visible;
            NewPassword.Visibility = Visibility.Visible;
            NewPasswordLabel.Visibility = Visibility.Visible;
            Update.Visibility = Visibility.Visible;
            Cancel.Visibility = Visibility.Visible;
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (Login.Text == "")
                MessageBox.Show("Логин не может быть пустым!");
            else
            {
                string Query = $"UPDATE Пользователи SET Логин = '{ Login.Text }', ФИО = '{ FIO.Text }', Дата_рождения = '{ DayOfBirthday.Text }', Телефон = '{ Telephone.Text }', Электронная_почта = '{ Email.Text }' WHERE ID_пользователя = { ID_user}";
                Service.SQLFunction(Query);
                MessageBox.Show("Данные успешно изменены!");
            }
        }
        private void Update_Click(object sender, RoutedEventArgs e)
        {
            string ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=Салон;Integrated Security=True";
            SqlConnection Connection = new SqlConnection(ConnectionString);
            string Query = $"SELECT Пароль FROM Пользователи WHERE Логин = '{ Login.Text }'";
            string a = null;
            try
            {
                Connection.Open();
                SqlCommand Command = new SqlCommand(Query, Connection);
                SqlDataReader Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    a = Convert.ToString(Reader[0]);
                }
                if (a == OldPassword.Text)
                {
                    Query = $"UPDATE Пользователи SET Пароль = '{ NewPassword.Text }' WHERE ID_пользователя = { ID_user}";
                    Service.SQLFunction(Query);
                    MessageBox.Show("Пароль успешно изменён!");
                    Hidden();
                }
                else
                    MessageBox.Show("Старый пароль не совпадает!");
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
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Hidden();
        }
        private void Hidden()
        {
            OldPassword.Visibility = Visibility.Hidden;
            OldPassword.Text = "";
            OldPasswordLabel.Visibility = Visibility.Hidden;
            NewPassword.Visibility = Visibility.Hidden;
            NewPassword.Text = "";
            NewPasswordLabel.Visibility = Visibility.Hidden;
            Update.Visibility = Visibility.Hidden;
            Cancel.Visibility = Visibility.Hidden;
        }
    }
}