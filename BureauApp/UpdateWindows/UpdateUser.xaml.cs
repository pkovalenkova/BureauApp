using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows;

namespace BureauApp.UpdateWindows
{
    /// <summary>
    /// Логика взаимодействия для UpdateUser.xaml
    /// </summary>
    public partial class UpdateUser : Window
    {
        DataRowView row;
        string[] roles = { "user", "worker", "admin" };
        public UpdateUser(DataRowView rw )
        {
            InitializeComponent();
            row = rw;
            login.Text = row.Row.ItemArray[1].ToString();
            pass.Text = row.Row.ItemArray[2].ToString();

            role.ItemsSource = roles;
            role.SelectedItem = row.Row.ItemArray[3].ToString();
        }

        private void Upd_btn_Click(object sender, RoutedEventArgs e)
        {
            Query query = new Query();

            try
            {
                if (query.Conn.State == ConnectionState.Closed)
                    query.Conn.Open();


                MessageBoxButton btnMessageBox = MessageBoxButton.YesNo;

                switch (MessageBox.Show("Вы точно хотите изменить выбранную строку?", "Подтвердите действие", btnMessageBox))
                {
                    case MessageBoxResult.Yes:
                        query.Sql = $"UPDATE users SET Login='{login.Text}', Password='{Hash.GetHash(pass.Text)}', Role='{role.SelectionBoxItem}' " +
                                    $"WHERE User_ID='{row.Row.ItemArray[0]}'";

                        MySqlCommand cmd_UpdUserRow = new MySqlCommand(query.Sql, query.Conn);


                        cmd_UpdUserRow.ExecuteNonQuery();
                        MessageBox.Show("Выбранная строка успешно обновлена", "Успех");
                        this.Close();
                        break;

                    case MessageBoxResult.No:
                        break;
                }
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
    }
}
