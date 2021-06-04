using MySql.Data.MySqlClient;
using System;
using System.Windows;

namespace BureauApp.AddWindows
{
    /// <summary>
    /// Логика взаимодействия для AddFlat.xaml
    /// </summary>
    public partial class AddFlat : Window
    {
        public AddFlat()
        {
            InitializeComponent();
        }

        private void Add_btn_Click(object sender, RoutedEventArgs e)
        {
            AddFlatRow();
        }

        private void CheckEmptyField()
        {
            if (kadastr.Text == string.Empty) { throw new Exception("Не заполнено поле \"Кадастр\""); }
            if (flat_number.Text == string.Empty) { throw new Exception("Не заполнено поле \"Номер квартиры\""); }
            if (storey.Text == string.Empty) { throw new Exception("Не заполнено поле \"Этаж\""); }
            if (rooms.Text == string.Empty) { throw new Exception("Не заполнено поле \"Количество комнат\""); }
            if (height.Text == string.Empty) { throw new Exception("Не заполнено поле \"Высота потолков\""); }
            if (square_hall.Text == string.Empty) { throw new Exception("Не заполнено поле \"Общая площадь\""); }
            if (living_square.Text == string.Empty) { throw new Exception("Не заполнено поле \"Жилая площадь\""); }
            if (branch.Text == string.Empty) { throw new Exception("Не заполнено поле \"Вспомогательная площадь\""); }
            if (balcony.Text == string.Empty) { throw new Exception("Не заполнено поле \"Плоащдь балкона\""); }
        }

        private void CheckWrongField()
        {
            int res;
            double resD;
            if (!Int32.TryParse(flat_number.Text, out res)) { throw new Exception("Неправильный формат данных поля \"Номер квартиры\""); }
            else
            {
                if ((res < 1) || (res > 1000)) { throw new Exception("Неправильный формат данных поля \"Номер квартиры\""); }
            }

            if (!Int32.TryParse(storey.Text, out res)) { throw new Exception("Неправильный формат данных поля \"Этаж\""); }
            else
            {
                if ((res < 1) || (res > 100)) { throw new Exception("Неправильный формат данных поля \"Этаж\""); }
            }

            if (!Int32.TryParse(rooms.Text, out res)) { throw new Exception("Неправильный формат данных поля \"Количество комнат\""); }
            else
            {
                if ((res < 1) || (res > 20)) { throw new Exception("Неправильный формат данных поля \"Количество комнат\""); }
            }

            if (!Double.TryParse(height.Text, out resD)) { throw new Exception("Неправильный формат данных поля \"Высота потолков\""); }
            else
            {
                if ((resD < 1) || (resD > 10)) { throw new Exception("Неправильный формат данных поля \"Высота потолков\""); }
            }

            if (!Double.TryParse(square_hall.Text, out resD)) { throw new Exception("Неправильный формат данных поля \"Общая площадь\""); }
            else
            {
                if ((resD < 1) || (resD > 200)) { throw new Exception("Неправильный формат данных поля \"Общая площадь\""); }
            }

            if (!Double.TryParse(living_square.Text, out resD)) { throw new Exception("Неправильный формат данных поля \"Жилая площадь\""); }
            else
            {
                if ((resD < 1) || (resD > 200)) { throw new Exception("Неправильный формат данных поля \"Жилая площадь\""); }
            }

            if (!Double.TryParse(branch.Text, out resD)) { throw new Exception("Неправильный формат данных поля \"Вспомогателньая площадь\""); }
            else
            {
                if ((resD < 1) || (resD > 200)) { throw new Exception("Неправильный формат данных поля \"Вспомогателньая площадь\""); }
            }

            if (!Double.TryParse(balcony.Text, out resD)) { throw new Exception("Неправильный формат данных поля \"Площадь балкона\""); }
            else
            {
                if ((resD < 1) || (resD > 20)) { throw new Exception("Неправильный формат данных поля \"Площадь балкона\""); }
            }
        }

        private void CheckKadastr(Query query)
        {
            query.Sql = $"SELECT COUNT(1) FROM house WHERE Kadastr='{kadastr.Text}'";
            MySqlCommand cmd_CheckKadastr = new MySqlCommand(query.Sql, query.Conn);
            int countCity = Convert.ToInt32(cmd_CheckKadastr.ExecuteScalar());

            if (countCity == 0) { throw new Exception("Здание с таким кадастром не существует в таблице \"Здания\", нельзя добавить квартиру несуществуещего здания"); }
        }
        private void CheckFlat(Query query)
        {
            query.Sql = $"SELECT COUNT(1) FROM flat WHERE FK_Kadastr='{kadastr.Text}' AND Flat_number='{flat_number.Text}'";
            MySqlCommand cmd_CheckFlat = new MySqlCommand(query.Sql, query.Conn);
            int countFlat = Convert.ToInt32(cmd_CheckFlat.ExecuteScalar());

            if (countFlat != 0) { throw new Exception("Уже существует квартира с таким номером в данном здании."); }
        }

        private void FillAddSqlQuery(MySqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("FK_Kadastr", kadastr.Text);
            cmd.Parameters.AddWithValue("Flat_number", flat_number.Text);
            cmd.Parameters.AddWithValue("Storey", storey.Text);
            cmd.Parameters.AddWithValue("Rooms", rooms.Text);
            cmd.Parameters.AddWithValue("SquareHall", square_hall.Text);
            cmd.Parameters.AddWithValue("LivingSquare", living_square.Text);
            cmd.Parameters.AddWithValue("Branch", branch.Text);
            cmd.Parameters.AddWithValue("Balcony", balcony.Text);
            cmd.Parameters.AddWithValue("Height", height.Text);

            if (level.IsChecked == true) cmd.Parameters.AddWithValue("Level", 1);
            else cmd.Parameters.AddWithValue("Level", 0);
        }
        private void AddFlatRow()
        {
            Query query = new Query();
            try
            {
                if (query.Conn.State == System.Data.ConnectionState.Closed)
                    query.Conn.Open();


                CheckEmptyField();
                CheckWrongField();
                CheckKadastr(query);
                CheckFlat(query);


                query.Sql = $"INSERT INTO flat (FK_Kadastr, Flat_number, Storey, Rooms, Level, SquareHall, LivingSquare, Branch, Balcony, Height) VALUES (@FK_Kadastr, @Flat_number, @Storey, @Rooms, @Level, '{square_hall.Text.Replace(',', '.')}', '{living_square.Text.Replace(',', '.')}', '{branch.Text.Replace(',', '.')}', '{balcony.Text.Replace(',', '.')}', '{height.Text.Replace(',', '.')}')";

                MySqlCommand cmd_AddHouseRow = new MySqlCommand(query.Sql, query.Conn);
                FillAddSqlQuery(cmd_AddHouseRow);

                MessageBox.Show("Было добавлено строк " + cmd_AddHouseRow.ExecuteNonQuery().ToString(), "Успех");
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
    }
}
