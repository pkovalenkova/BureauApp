using System.Linq;
using System.Windows;
using MySql.Data.MySqlClient;
using BureauApp.SearchWindows;
using BureauApp.AddWindows;
using BureauApp.ReportWindows;

namespace BureauApp.Windows
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        Query query = new Query();
        public AdminWindow()
        {
            InitializeComponent();
            User.SelectedTable = "users";

            try
            {
                query.Sql = "Select * from users";
                FillTables.FillTableUsers(query, DG1);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Ошибка при работе с базой данных:" + ex.Message);
            }
        }

        private void Exit_Btn_Click(object sender, RoutedEventArgs e)
        {
            var windows = (Application.Current.Windows);
            foreach (var wnd in windows.OfType<Window>())
            {
                wnd.Close();
            }
        }

        private void Search_Btn_Click(object sender, RoutedEventArgs e)
        {
            UserSearch userSearch = new UserSearch();
            userSearch.ShowDialog();
        }

        private void Add_Btn_Click(object sender, RoutedEventArgs e)
        {
            AddUser addUser = new AddUser();
            addUser.ShowDialog();
            query.Sql = "Select * from users";
            FillTables.FillTableUsers(query, DG1);
        }

        private void Del_Btn_Click(object sender, RoutedEventArgs e)
        {
            DelRows.DelRow(DG1);
        }

        private void Profile_Btn_Click(object sender, RoutedEventArgs e)
        {
            Profile profileWindow = new Profile();
            profileWindow.ShowDialog();
        }

        private void Update_Btn_Click(object sender, RoutedEventArgs e)
        {
            UpdRows.UpdRow(DG1);
        }

        private void Save_Btn_Click(object sender, RoutedEventArgs e)
        {
            ExportToXls.Export(DG1);
        }
    }
}
