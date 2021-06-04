using System;
using System.Windows;
using MySql.Data.MySqlClient;
using BureauApp.Windows;

namespace BureauApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Athr_Btn_Click(object sender, RoutedEventArgs e)
        {
            Authorization();
        }
        void SetFields(MySqlCommand cmd)
        {
            if (login.Text == string.Empty)
                throw new Exception("Введите логин");
            else
                cmd.Parameters.AddWithValue("login", login.Text);
            if (password.Password.ToString() == string.Empty)
                throw new Exception("Введите пароль");
            else 
                cmd.Parameters.AddWithValue("pass", Hash.GetHash(password.Password));
        }
        private int CheckUser(Query query)
        {

            query.Sql = "SELECT COUNT(1) FROM users WHERE Login=@login AND Password=@pass";
            MySqlCommand cmd_CheckUser = new MySqlCommand(query.Sql, query.Conn);

            SetFields(cmd_CheckUser);

            return Convert.ToInt32(cmd_CheckUser.ExecuteScalar());
        }
            
        private void SetUsersFields(Query query)
        {
            User.Login = login.Text;
            query.Sql = "SELECT Role FROM users WHERE Login=@login AND Password=@pass";
            MySqlCommand cmd_GetRoleUser = new MySqlCommand(query.Sql, query.Conn);
            SetFields(cmd_GetRoleUser);
            User.Role = cmd_GetRoleUser.ExecuteScalar().ToString();
        }
        private void Authorization()
        {
            Query query = new Query();
            try
            {
                if (query.Conn.State == System.Data.ConnectionState.Closed)
                    query.Conn.Open();

                if (CheckUser(query) == 0)
                {
                    NoUserWindow noUserWindow = new NoUserWindow(login.Text, password.Password.ToString());
                    noUserWindow.ShowDialog();
                }
                else
                {
                    SetUsersFields(query);
                    switch (User.Role)
                    {
                        case "user":
                            UserWindow userWindow = new UserWindow();
                            this.Close();
                            userWindow.Show();
                            break;
                        case "worker":
                            WorkerWindow workerWindow = new WorkerWindow();
                            this.Close();
                            workerWindow.Show();
                            break;
                        case "admin":
                            AdminWindow adminWindow = new AdminWindow();
                            this.Close();
                            adminWindow.Show();
                            break;

                    }

                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Ошибка при работе с базой данных. "+ex.Message, "Ошибка");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
            finally
            {
                query.Conn.Close();
            }
        }

        private void Reg_Btn_Click(object sender, RoutedEventArgs e)
        {
            Registration();
        }

        private void Registration()
        {
            Query query = new Query();
            try
            {
                if (query.Conn.State == System.Data.ConnectionState.Closed)
                    query.Conn.Open();
                if (CheckUser(query) == 0)
                {
                    CheckLogin(query);
                    query.Sql = $"INSERT INTO users (Login, Password, Role) VALUES ('{login.Text}', '{Hash.GetHash(password.Password)}', 'user')";

                    MySqlCommand cmd_AddUserRow = new MySqlCommand(query.Sql, query.Conn);
                    cmd_AddUserRow.ExecuteNonQuery();

                    MessageBox.Show("Новый пользователь был зарегестрирован", "Успех");

                }
                else
                {
                    throw new Exception("Такая учетная запись уже существует, попробуйте осуществить вход!");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Ошибка при работе с базой данных. " + ex.Message, "Ошибка");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
            finally
            {
                query.Conn.Close();
            }
        }
        private void CheckLogin(Query query)
        {
            query.Sql = $"SELECT COUNT(1) FROM users WHERE Login='{login.Text}'";
            MySqlCommand cmd_CheckLogin = new MySqlCommand(query.Sql, query.Conn);
            int countLogin = Convert.ToInt32(cmd_CheckLogin.ExecuteScalar());

            if (countLogin != 0) { throw new Exception("Учетная запись с таким логином уже существует!"); }
        }

    }


}
