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
        public AdminWindow()
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

        private void Add_Btn_Click(object sender, RoutedEventArgs e)
        {
            Menu.AddRow(DG1);
        }

        private void Del_Btn_Click(object sender, RoutedEventArgs e)
        {
            Menu.DelRow(DG1);
        }

        private void Profile_Btn_Click(object sender, RoutedEventArgs e)
        {
            Menu.Profile();
        }

        private void Update_Btn_Click(object sender, RoutedEventArgs e)
        {
            Menu.UpdRow(DG1);
        }

        private void Save_Btn_Click(object sender, RoutedEventArgs e)
        {
            Menu.Export(DG1);
        }
    }
}
