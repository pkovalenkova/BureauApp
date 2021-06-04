using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows;

namespace BureauApp.UpdateWindows
{
    /// <summary>
    /// Логика взаимодействия для UpdateFlat.xaml
    /// </summary>
    public partial class UpdateFlat : Window
    {
        static DataRowView row;
        public UpdateFlat(DataRowView rw)
        {
            InitializeComponent();
            row = rw;
            Initialize.InitializeFlatFields(this, row);

        }

        private void Upd_btn_Click(object sender, RoutedEventArgs e)
        {
            UpdFlat();
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
        private void CheckFlat(Query query)
        {
            query.Sql = $"SELECT Flat_ID FROM flat WHERE FK_Kadastr='{kadastr.Text}' AND Flat_number='{flat_number.Text}'";
            MySqlCommand cmd_CheckFlat = new MySqlCommand(query.Sql, query.Conn);
            int Flat_ID = Convert.ToInt32(cmd_CheckFlat.ExecuteScalar());

            if (Flat_ID!= Convert.ToInt32(row.Row.ItemArray[1])) { throw new Exception("Уже существует квартира с таким номером в данном здании."); }
        }
        private void FillUpdSqlQuery(MySqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("FK_Kadastr", kadastr.Text);
            cmd.Parameters.AddWithValue("Flat_number", flat_number.Text);
            cmd.Parameters.AddWithValue("Storey", storey.Text);
            cmd.Parameters.AddWithValue("Rooms", rooms.Text);

            if (level.IsChecked == true) cmd.Parameters.AddWithValue("Level", 1);
            else cmd.Parameters.AddWithValue("Level", 0);
        }
        private void UpdFlat()
        {
            Query query = new Query();

            try
            {
                if (query.Conn.State == System.Data.ConnectionState.Closed)
                    query.Conn.Open();
                CheckEmptyField();
                CheckWrongField();
                CheckFlat(query);

                MessageBoxButton btnMessageBox = MessageBoxButton.YesNo;

                switch (MessageBox.Show("Вы точно хотите изменить выбранную строку?", "Подтвердите действие", btnMessageBox))
                {
                    case MessageBoxResult.Yes:
                        query.Sql = $"UPDATE flat SET FK_Kadastr=@FK_Kadastr, Flat_number=@Flat_number, Storey=@Storey, Rooms=@Rooms, SquareHall='{square_hall.Text.Replace(',', '.')}', " +
                                    $"LivingSquare='{living_square.Text.Replace(',', '.')}', Branch='{branch.Text.Replace(',', '.')}', Balcony='{balcony.Text.Replace(',', '.')}', Height='{height.Text.Replace(',', '.')}', Level=@Level " +
                                    $"WHERE Flat_ID='{row.Row.ItemArray[1]}'";

                        MySqlCommand cmd_UpdHouseRow = new MySqlCommand(query.Sql, query.Conn);

                        FillUpdSqlQuery(cmd_UpdHouseRow);
                        cmd_UpdHouseRow.ExecuteNonQuery();
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
