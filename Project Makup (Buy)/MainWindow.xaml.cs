using System;
using System.Data.SqlClient;
using System.Windows;
namespace Программа_для_косметологического_салона
{
    public partial class MainWindow : Window
    {
        int check = 0;      
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Log_in_Click(object sender, RoutedEventArgs e)
        {
            if (Login.Text == "" && Password.Password != "")
                MessageBox.Show("Вы не ввели логин!");
            else if (Login.Text != "" && Password.Password == "")
                MessageBox.Show("Вы не ввели пароль!");
            else if (Login.Text == "" && Password.Password == "")
                MessageBox.Show("Вы не ввели логин и пароль!");
            else
            {
                if (check == 0)
                {
                    if (Login.Text == "Admin" && Password.Password == "Admin")
                    {
                        Меню_администратора c3 = new Меню_администратора();
                        c3.Show();
                    }
                    else
                    {
                        SqlConnection Connection = new SqlConnection(Service.ConnectionString);
                        string Query = $"SELECT ID_пользователя, Пароль, Уровень FROM Пользователи WHERE Логин = '{ Login.Text }'";
                        int a = 0;
                        string b = null;
                        int c = 0;
                        try
                        {
                            Connection.Open();
                            SqlCommand Command = new SqlCommand(Query, Connection);
                            SqlDataReader Reader = Command.ExecuteReader();
                            while (Reader.Read())
                            {
                                a = Convert.ToInt32(Reader[0]);
                                b = Convert.ToString(Reader[1]);
                                c = Convert.ToInt32(Reader[2]);
                            }
                            if (b == null)
                                MessageBox.Show("Логин не найден!");
                            else if (Check_password(b))
                            {
                                MessageBox.Show("Здравствуйте, " + Login.Text);
                                Главное_окно c1 = new Главное_окно(a);
                                Окно_работника c2 = new Окно_работника(a);
                                if (c == 1)
                                    c1.Show();
                                else
                                    c2.Show();
                                this.Close();
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
                }
                else
                {
                    string Query = $"INSERT INTO Пользователи(Логин, Пароль, Уровень)VALUES('{ Login.Text }', '{ Password.Password }', 1)";
                    Service.SQLFunction(Query);
                    MessageBox.Show("Здравствуйте, " + Login.Text);
                    Query = $"SELECT ID_пользователя FROM Пользователи WHERE Логин = '{ Login.Text }'";
                    int id = Service.SQLFunctionGetID(Query);                   
                    Главное_окно a = new Главное_окно(id);
                    a.Show();
                    this.Close();
                }
            }
        }
        private bool Check_password(string b)
        {
            if (b == Password.Password)
                return true;
            else
            {
                MessageBox.Show("Не правильно введён пароль!");
                return false;
            }
        }
        private void NoAccount_Click(object sender, RoutedEventArgs e)
        {
            if (check == 0)
            {
                check = 1;
                Label.Content = "Регистрация";
                Log_in.Content = "Зарегистрировать";
                NoAccount.Content = "Есть аккаунт";
            }
            else
            {
                check = 0;
                Label.Content = "Авторизация";
                Log_in.Content = "Войти";
                NoAccount.Content = "Нет аккаунта";
            }
        }
    }
}