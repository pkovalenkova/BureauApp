using System.Linq;
using System.Windows;
using MySql.Data.MySqlClient;
using BureauApp.SearchWindows;
using BureauApp.ReportWindows;

namespace BureauApp.Windows
{
    /// <summary>
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        public UserWindow()
        {
            InitializeComponent();
            Initialize.IniInitializeTable(DG1);
        }
      
        private void Exit_Btn_Click(object sender, RoutedEventArgs e)
        {
            Menu.Exit();
        }

        private void Search_Btn_Click(object sender, RoutedEventArgs e)
        {
            Menu.Search();
        }

        private void Profile_Btn_Click(object sender, RoutedEventArgs e)
        {
            Menu.Profile();
        }

        private void Save_Btn_Click(object sender, RoutedEventArgs e)
        {
            Menu.Export(DG1);
        }

        private void Report_Btn_Click(object sender, RoutedEventArgs e)
        {
            Menu.Report();
        }

        private void House_btn_Click(object sender, RoutedEventArgs e)
        {
            Menu.HouseClick(DG1);
        }

        private void Flat_btn_Click(object sender, RoutedEventArgs e)
        {
            Menu.FlatClick(DG1);
        }

        private void Room_btn_Click(object sender, RoutedEventArgs e)
        {
            Menu.RoomClick(DG1);
        }
    }
}
