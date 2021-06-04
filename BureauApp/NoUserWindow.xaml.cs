using System;
using System.Windows;
using MySql.Data.MySqlClient;

namespace BureauApp
{
    /// <summary>
    /// Логика взаимодействия для NoUserWindow.xaml
    /// </summary>
    public partial class NoUserWindow : Window
    {
        Query query = new Query();
        string login, password;
        public NoUserWindow(string log, string pass)
        {
            InitializeComponent();
            login = log;
            password = pass;
        }

        private void Create_Btn_Click(object sender, RoutedEventArgs e)
        {
            Registration();
        }

        private void Repeat_Btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddNewUserInDB()
        {
            query.Sql = "INSERT INTO users (Login, Password, Role) VALUES (@login, @pass, @role)";
            MySqlCommand cmd_AddNewUser = new MySqlCommand(query.Sql, query.Conn);
            cmd_AddNewUser.Parameters.AddWithValue("login", login);
            cmd_AddNewUser.Parameters.AddWithValue("pass", Hash.GetHash(password));
            cmd_AddNewUser.Parameters.AddWithValue("role", "user");
            cmd_AddNewUser.ExecuteNonQuery();
        }

        private void Registration()
        {
            try
            {
                CheckLogin(query);
                AddNewUserInDB();
                MessageBox.Show("Ваша учетная запись была успешно создана", "Успех");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Ошибка работы с базой данных. "+ex.Message, "Ошибка");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
            finally
            {
                this.Close();
            }
        }
        private void CheckLogin(Query query)
        {
                if (query.Conn.State == System.Data.ConnectionState.Closed)
                    query.Conn.Open();
                query.Sql = $"SELECT COUNT(1) FROM users WHERE Login='{login}'";
                MySqlCommand cmd_CheckLogin = new MySqlCommand(query.Sql, query.Conn);
                int countLogin = Convert.ToInt32(cmd_CheckLogin.ExecuteScalar());

                if (countLogin != 0) { throw new Exception("Учетная запись с таким логином уже существует!"); }
        }
    }
}
