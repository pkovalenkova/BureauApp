using MySql.Data.MySqlClient;
using System;
using System.Windows;

namespace BureauApp.AddWindows
{
    /// <summary>
    /// Логика взаимодействия для AddUserxaml.xaml
    /// </summary>
    public partial class AddUser : Window
    {
        string[] roles = { "user", "worker", "admin" };
        public AddUser()
        {
            InitializeComponent();
            role.ItemsSource = roles;
            role.SelectedItem = roles[0];
        }

        private void Add_btn_Click(object sender, RoutedEventArgs e)
        {
            Query query = new Query();
            try
            {
                if (query.Conn.State == System.Data.ConnectionState.Closed)
                    query.Conn.Open();

                CheckEmptyField();
                CheckLogin(query);

                query.Sql = $"INSERT INTO users (Login, Password, Role) VALUES ('{login.Text}', '{Hash.GetHash(pass.Text)}', '{role.SelectionBoxItem}')";
                MySqlCommand cmd_AddUserRow = new MySqlCommand(query.Sql, query.Conn);
                MessageBox.Show("Было добавлено строк " + cmd_AddUserRow.ExecuteNonQuery().ToString(), "Успех");
                this.Close();
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
        private void CheckEmptyField()
        {
            if (login.Text == string.Empty) { throw new Exception("Не заполнено поле \"Логин\""); }
            if (pass.Text == string.Empty) { throw new Exception("Не заполнено поле \"Пароль\""); }
        }

        private void CheckLogin (Query query)
        {
            query.Sql= $"SELECT COUNT(1) FROM users WHERE Login='{login.Text}'";
            MySqlCommand cmd_CheckLogin = new MySqlCommand(query.Sql, query.Conn);
            int countLogin = Convert.ToInt32(cmd_CheckLogin.ExecuteScalar());

            if (countLogin != 0) { throw new Exception("Учетная запись с таким логином уже существует!"); }
        }
    }
}
