using System;
using System.Windows;
using MySql.Data.MySqlClient;
using System.Data;

namespace BureauApp.UpdateWindows
{
    /// <summary>
    /// Логика взаимодействия для UpdateHouse.xaml
    /// </summary>
    public partial class UpdateHouse : Window
    {
        DataRowView row;
        public UpdateHouse(DataRowView rw)
        {
            row = rw;
            InitializeComponent();
            Initialize.InitializeHouseFields(this, row);

        }

        private void Upd_btn_Click(object sender, RoutedEventArgs e)
        {
            UpdHouse();
        }
       
        private void CheckEmptyField()
        {
            if (city.Text == string.Empty) { throw new Exception("Не заполнено поле \"Город\""); }
            if (district.Text == string.Empty) { throw new Exception("Не заполнено поле \"Район\""); }
            if (street.Text == string.Empty) { throw new Exception("Не заполнено поле \"Улица\""); }
            if (house_number.Text == string.Empty) { throw new Exception("Не заполнено поле \"Номер дома\""); }
            if (line.Text == string.Empty) { throw new Exception("Не заполнено поле \"Расстояние до центра\""); }
            if (year.Text == string.Empty) { throw new Exception("Не заполнено поле \"Год постройки\""); }
            if (wear.Text == string.Empty) { throw new Exception("Не заполнено поле \"Износ\""); }
            if (@base.Text == string.Empty) { throw new Exception("Не заполнено поле \"Материал фундамента\""); }
            if (material.Text == string.Empty) { throw new Exception("Не заполнено поле \"Материал стен\""); }
            if (land.Text == string.Empty) { throw new Exception("Не заполнено поле \"Площадь участка\""); }
            if (square.Text == string.Empty) { throw new Exception("Не заполнено поле \"Площадь квартир\""); }
            if (flow.Text == string.Empty) { throw new Exception("Не заполнено поле \"Количество этажей\""); }
            if (hall.Text == string.Empty) { throw new Exception("Не заполнено поле \"Количество квартир\""); }
        }
        private void CheckWrongField()
        {
            int res;
            double resd;
            if (!Int32.TryParse(house_number.Text, out res)) { throw new Exception("Неправильный формат данных поля \"Номер дома\""); }
            else
            {
                if ((res < 1) || (res > 300)) { throw new Exception("Неправильный формат данных поля \"Номер дома\""); }
            }

            if (!Double.TryParse(line.Text, out resd)) { throw new Exception("Неправильный формат данных поля \"Расстояние до центра\""); }
            else
            {
                if ((resd < 1) || (resd > 100)) { throw new Exception("Неправильный формат данных поля \"Расстояние до центра\""); }
            }

            if (!Int32.TryParse(year.Text, out res)) { throw new Exception("Неправильный формат данных поля \"Год постройки\""); }
            else
            {
                if ((res < 1900) || (res > 2021)) { throw new Exception("Неправильный формат данных поля \"Год постройки\""); }
            }

            if (!Int32.TryParse(wear.Text, out res)) { throw new Exception("Неправильный формат данных поля \"Износ\""); }
            else
            {
                if ((res < 1) || (res > 100)) { throw new Exception("Неправильный формат данных поля \"Износ\""); }
            }

            if (!Int32.TryParse(land.Text, out res)) { throw new Exception("Неправильный формат данных поля \"Площадь участка\""); }
            else
            {
                if ((res < 1) || (res > 50000)) { throw new Exception("Неправильный формат данных поля \"Площадь участка\""); }
            }

            if (!Int32.TryParse(square.Text, out res)) { throw new Exception("Неправильный формат данных поля \"Площадь квартир\""); }
            else
            {
                if ((res < 1) || (res > 50000)) { throw new Exception("Неправильный формат данных поля \"Площадь квартир\""); }
            }

            if (!Int32.TryParse(flow.Text, out res)) { throw new Exception("Неправильный формат данных поля \"Количество этажей\""); }
            else
            {
                if ((res < 1) || (res > 100)) { throw new Exception("Неправильный формат данных поля \"Количество этажей\""); }
            }

            if (!Int32.TryParse(hall.Text, out res)) { throw new Exception("Неправильный формат данных поля \"Количество квартир\""); }
            else
            {
                if ((res < 1) || (res > 1000)) { throw new Exception("Неправильный формат данных поля \"Количество квартир\""); }
            }
        }
        private void CheckHouse(Query query)
        {
            Query help_query = new Query();
            if (help_query.Conn.State == ConnectionState.Closed)
                help_query.Conn.Open();
            
            query.Sql = $"SELECT COUNT(1) FROM house WHERE Kadastr='{kadastr.Text}' AND id_City='{GetID.GetCityID(help_query, city.Text)}' AND id_District='{GetID.GetDistrictID(help_query, district.Text)}' AND Street='{street.Text}' AND House_number='{house_number.Text}'";
            MySqlCommand cmd_CheckHouse = new MySqlCommand(query.Sql, query.Conn);
            string Kadastr = cmd_CheckHouse.ExecuteScalar().ToString();

            if (Kadastr != row.Row.ItemArray[0].ToString()) { throw new Exception("Здание с таким кадастром уже существует в таблице \"Здания\""); }
        }
        private void FillUpdSqlQuery(MySqlCommand cmd, Query help_query)
        {
            cmd.Parameters.AddWithValue("Kadastr", kadastr.Text);
            cmd.Parameters.AddWithValue("id_City", GetID.GetCityID(help_query, city.Text));
            cmd.Parameters.AddWithValue("Street", street.Text);
            cmd.Parameters.AddWithValue("House_number", house_number.Text);
            cmd.Parameters.AddWithValue("id_District", GetID.GetDistrictID(help_query, district.Text));
            cmd.Parameters.AddWithValue("Land", land.Text);
            cmd.Parameters.AddWithValue("Year", year.Text);
            cmd.Parameters.AddWithValue("id_Material", GetID.GetMaterialID(help_query, material.Text));
            cmd.Parameters.AddWithValue("id_Base", GetID.GetBaseID(help_query, @base.Text));
            cmd.Parameters.AddWithValue("Comment", comment.Text);
            cmd.Parameters.AddWithValue("Wear", wear.Text);
            cmd.Parameters.AddWithValue("Flow", flow.Text);
            cmd.Parameters.AddWithValue("Square", square.Text);
            cmd.Parameters.AddWithValue("Hall", hall.Text);
            if (elevator.IsChecked == true) cmd.Parameters.AddWithValue("Elevator", 1);
            else cmd.Parameters.AddWithValue("Elevator", 0);
        }
        private void UpdHouse()
        {
            Query query = new Query();
            Query help_query = new Query();
            try
            {
                if (query.Conn.State == ConnectionState.Closed)
                    query.Conn.Open();
                if (help_query.Conn.State == ConnectionState.Closed)
                    help_query.Conn.Open();
                CheckEmptyField();
                CheckWrongField();
                CheckHouse(query);

                MessageBoxButton btnMessageBox = MessageBoxButton.YesNo;

                switch (MessageBox.Show("Вы точно хотите изменить выбранную строку?", "Подтвердите действие", btnMessageBox))
                {
                    case MessageBoxResult.Yes:
                        query.Sql = $"UPDATE house SET id_City=@id_City, Street=@Street, House_number=@House_number, id_District=@id_District, " +
                                    $"Land=@Land, Year=@Year, id_Material=@id_Material, id_Base=@id_Base, Comment=@Comment, Wear=@Wear, Flow=@Flow, Line='{line.Text.Replace(',', '.')}', Square=@Square, Hall=@Hall, Elevator=@Elevator " +
                                    $"WHERE Kadastr=@Kadastr";

                        MySqlCommand cmd_UpdHouseRow = new MySqlCommand(query.Sql, query.Conn);

                        FillUpdSqlQuery(cmd_UpdHouseRow, help_query);
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
                help_query.Conn.Close();
            }
        }
    }
}
