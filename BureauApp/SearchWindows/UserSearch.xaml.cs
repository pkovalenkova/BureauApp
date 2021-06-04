using MySql.Data.MySqlClient;
using System.Windows;
using System.Windows.Controls;

namespace BureauApp.SearchWindows
{
    /// <summary>
    /// Логика взаимодействия для UserSearchxaml.xaml
    /// </summary>
    public partial class UserSearch : Window
    {
        Query query = new Query();
        public UserSearch()
        {
            InitializeComponent();

            try
            {
                query.Sql = "Select * from users";
                FillTables.FillTableUsers(query, SearchResult);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Ошибка при работе с базой данных:" + ex.Message);
            }
        }

        private void Reset_btn_Click(object sender, RoutedEventArgs e)
        {
            login.Clear();
            role.Clear();
            query.Sql = "Select * from users";
            FillTables.FillTableUsers(query, SearchResult);
        }

       
        private void login_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchSqlQuery();
        }

        private void role_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchSqlQuery();
        }

        private void Exp_btn_Click(object sender, RoutedEventArgs e)
        {
            ExportToXls.Export(SearchResult);
        }

        private void SearchSqlQuery()
        {
            query.Sql = $"SELECT * FROM users WHERE Login LIKE '{login.Text}%' AND Role LIKE '{role.Text}%'";
            FillTables.FillTableUsers(query, SearchResult);
        }
    }
}
