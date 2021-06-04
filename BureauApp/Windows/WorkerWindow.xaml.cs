using System.Linq;
using System.Windows;
using MySql.Data.MySqlClient;
using BureauApp.SearchWindows;
using BureauApp.AddWindows;
using BureauApp.ReportWindows;

namespace BureauApp.Windows
{
    /// <summary>
    /// Логика взаимодействия для WorkerWindow.xaml
    /// </summary>
    public partial class WorkerWindow : Window
    {
        public WorkerWindow()
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

        private void Ref_Btn_Click(object sender, RoutedEventArgs e)
        {
            Menu.Ref();
        }
    }
}
