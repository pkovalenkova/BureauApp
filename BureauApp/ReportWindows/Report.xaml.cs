using MySql.Data.MySqlClient;
using System;
using System.Windows;

namespace BureauApp.ReportWindows
{
    /// <summary>
    /// Логика взаимодействия для ReportHouse.xaml
    /// </summary>
    public partial class Report : Window
    {
        Query query=new Query();
        public Report()
        {
            InitializeComponent();
            Flat_Grid.Visibility = Visibility.Hidden;
        }

        private void Wear_btn_Click(object sender, RoutedEventArgs e)
        {
            DG_house.Visibility = Visibility.Visible;
            Flat_Grid.Visibility = Visibility.Hidden;
            try
            {
                if (query.Conn.State == System.Data.ConnectionState.Closed)
                    query.Conn.Open();
                query.Sql = "SELECT * FROM houses WHERE Wear>65";
                FillTables.FillTableHouse(query, DG_house);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Ошибка при работе с базой данных. " + ex.Message, "Ошибка");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        private void Exp_btn_Click(object sender, RoutedEventArgs e)
        {
            Menu.Export(this);
        }

        private void Flat_btn_Click(object sender, RoutedEventArgs e)
        {
            DG_house.Visibility = Visibility.Hidden;
            Flat_Grid.Visibility = Visibility.Visible;
            try
            {
                if (query.Conn.State == System.Data.ConnectionState.Closed)
                    query.Conn.Open();
                CheckEmptyField();
                CheckWrongField();
                CheckFlat(query);
                
                query.Sql = $"SELECT * FROM flats WHERE FK_Kadastr='{kadastr.Text}' AND Flat_number='{flat_number.Text}'";
                FillTables.FillTableFlats(query, DG_flat);
                query.Sql = $"SELECT * FROM rooms WHERE FK_Kadastr='{kadastr.Text}' AND Flat_number='{flat_number.Text}'";
                FillTables.FillTableRooms(query, DG_room);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Ошибка при работе с базой данных. " + ex.Message, "Ошибка");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }

        }
        private void CheckEmptyField()
        {
            if (kadastr.Text == string.Empty) throw new Exception("Не заполнено поле \"Кадастр\"");
            if (flat_number.Text == string.Empty) throw new Exception("Не заполнено поле \"Номер квартиры\"");
        }

        private void CheckWrongField()
        {
            int res;
            if (!Int32.TryParse(flat_number.Text, out res)) { throw new Exception("Неправильный формат данных поля \"Номер квартиры\""); }
            else
            {
                if ((res < 1) || (res > 1000)) { throw new Exception("Неправильный формат данных поля \"Номер квартиры\""); }
            }
        }
        private void CheckFlat(Query query)
        {
            query.Sql = $"SELECT COUNT(1) FROM flat WHERE FK_Kadastr='{kadastr.Text}' AND Flat_number='{flat_number.Text}'";
            MySqlCommand cmd_CheckFlat = new MySqlCommand(query.Sql, query.Conn);
            int countFlat = Convert.ToInt32(cmd_CheckFlat.ExecuteScalar());

            if (countFlat == 0) { throw new Exception("Заданной квартиры не существует"); }

        }

    }
}
