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
        Query query = new Query();
        public WorkerWindow()
        {
            InitializeComponent();
            User.SelectedTable = "house";

            try
            {
                query.Sql = "Select * from houses";
                FillTables.FillTableHouse(query, DG1);
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
            switch (User.SelectedTable)
            {
                case "house":
                    HouseSearch house_search_window = new HouseSearch();
                    house_search_window.ShowDialog();
                    break;
                case "flat":
                    FlatSearch flat_search_window = new FlatSearch();
                    flat_search_window.ShowDialog();
                    break;
                case "room":
                    RoomSearch room_search_window = new RoomSearch();
                    room_search_window.ShowDialog();
                    break;
            }
        }

        private void Add_Btn_Click(object sender, RoutedEventArgs e)
        {
            switch (User.SelectedTable)
            {
                case "house":
                    AddHouse addHouse_window = new AddHouse();
                    addHouse_window.ShowDialog();
                    FillTables.FillTableHouse(query, DG1);
                    break;
                case "flat":
                    AddFlat addFlat_window = new AddFlat();
                    addFlat_window.ShowDialog();
                    FillTables.FillTableFlats(query, DG1);
                    break;
                case "room":
                    AddRoom addRoom_window = new AddRoom();
                    addRoom_window.ShowDialog();
                    FillTables.FillTableRooms(query, DG1);
                    break;
            }
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

        private void Report_Btn_Click(object sender, RoutedEventArgs e)
        {
            Report report_window = new Report();
            report_window.ShowDialog();
        }

        private void House_btn_Click(object sender, RoutedEventArgs e)
        {
            User.SelectedTable = "house";
            query.Sql = "Select * from houses";
            FillTables.FillTableHouse(query, DG1);
        }

        private void Flat_btn_Click(object sender, RoutedEventArgs e)
        {
            User.SelectedTable = "flat";
            query.Sql = "Select * from flats";
            FillTables.FillTableFlats(query, DG1);
        }

        private void Room_btn_Click(object sender, RoutedEventArgs e)
        {
            User.SelectedTable = "room";
            query.Sql = "Select * from rooms";
            FillTables.FillTableRooms(query, DG1);
        }

        private void Ref_Btn_Click(object sender, RoutedEventArgs e)
        {
            var windows = (Application.Current.Windows);
            bool refWindowIs = false;
            foreach (var wnd in windows.OfType<Window>())
            {
                if (wnd.GetType() == typeof(RefWindow))
                {
                    refWindowIs = true;
                    wnd.Focus();
                }
            }

            if (!refWindowIs)
            {
                RefWindow refWindow = new RefWindow();
                refWindow.Show();
            }
        }
    }
}
