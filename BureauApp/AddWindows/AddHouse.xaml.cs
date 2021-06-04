using System;
using System.Windows;
using MySql.Data.MySqlClient;
using System.Data;

namespace BureauApp.AddWindows
{
    /// <summary>
    /// Логика взаимодействия для AddHouse.xaml
    /// </summary>
    public partial class AddHouse : Window
    {
        public AddHouse()
        {
            InitializeComponent();
        }

        private void Add_btn_Click(object sender, RoutedEventArgs e)
        {
            Query query = new Query();
            Query help_query = new Query();
            try
            {
                if (query.Conn.State == ConnectionState.Closed)
                    query.Conn.Open();
                if (help_query.Conn.State == ConnectionState.Closed)
                    help_query.Conn.Open();

                CheckKadastr(query);
                CheckEmptyField();
                CheckWrongField();
                

                query.Sql = $"INSERT INTO House (Kadastr, id_City, Street, House_number, id_District, Land, Year, id_Material, id_Base, Comment, Wear, Flow, Line, Square, Hall, Elevator) VALUES (@Kadastr, @id_City, @Street, @House_number, @id_District, @Land, @Year, @id_Material, @id_Base, @Comment, @Wear, @Flow, '{line.Text.Replace(',', '.')}', @Square, @Hall, @Elevator)";
                MySqlCommand cmd_AddHouseRow = new MySqlCommand(query.Sql, query.Conn);
                FillAddSqlQuery(cmd_AddHouseRow, help_query);

                MessageBox.Show("Было добавлено строк " + cmd_AddHouseRow.ExecuteNonQuery().ToString(), "Успех");
                this.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Ошибка при работе с базой данных. "+ex.Message, "Ошибка");
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
        private void CheckEmptyField()
        {
            if (kadastr.Text == string.Empty) { throw new Exception("Не заполнено поле \"Кадастр\""); }
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
            double resD;
            if (!Int32.TryParse(house_number.Text, out res)) { throw new Exception("Неправильный формат данных поля \"Номер дома\""); }
            else
            {
                if ((res<1)||(res>300)) { throw new Exception("Неправильный формат данных поля \"Номер дома\""); }
            }


            if (!Double.TryParse(line.Text, out resD)) { throw new Exception("Неправильный формат данных поля \"Расстояние до центра\""); }
            else
            {
                if ((resD < 1) || (resD > 100)) { throw new Exception("Неправильный формат данных поля \"Расстояние до центра\""); }
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

        private void CheckKadastr(Query query)
        {
            query.Sql = $"SELECT COUNT(1) FROM house WHERE Kadastr='{kadastr.Text}'";
            MySqlCommand cmd_CheckKadastr = new MySqlCommand(query.Sql, query.Conn);
            int countCity = Convert.ToInt32(cmd_CheckKadastr.ExecuteScalar());

            if (countCity != 0) { throw new Exception("Здание с таким кадастром уже существует в таблице \"Здания\""); }
        }
        private int GetCityID(Query query)
        {
            int city_ID;
            query.Sql = $"SELECT COUNT(1) FROM city_r WHERE CityName='{city.Text}'";
            MySqlCommand cmd_CheckCity = new MySqlCommand(query.Sql, query.Conn);
            int countCity = Convert.ToInt32(cmd_CheckCity.ExecuteScalar());

            if (countCity == 0)
            {
                query.Sql = $"INSERT INTO city_r (CityName) VALUES('{city.Text}')";
                MySqlCommand cmd_AddNewCity = new MySqlCommand(query.Sql, query.Conn);
                cmd_AddNewCity.ExecuteNonQuery();
            }

            query.Sql = $"SELECT City_ID FROM city_r WHERE CityName='{city.Text}'";
            MySqlCommand cmd_GetCityID = new MySqlCommand(query.Sql, query.Conn);
            city_ID = Convert.ToInt32(cmd_GetCityID.ExecuteScalar());

            return city_ID;
        }
        private int GetDistrictID(Query query)
        {
            int district_ID;
            query.Sql = $"SELECT COUNT(1) FROM district_r WHERE DistrictName='{district.Text}'";
            MySqlCommand cmd_CheckDistrict = new MySqlCommand(query.Sql, query.Conn);
            int countDistrict = Convert.ToInt32(cmd_CheckDistrict.ExecuteScalar());

            if (countDistrict == 0)
            {
                query.Sql = $"INSERT INTO district_r (DistrictName) VALUES('{district.Text}')";
                MySqlCommand cmd_AddNewDistrict = new MySqlCommand(query.Sql, query.Conn);
                cmd_AddNewDistrict.ExecuteNonQuery();
            }

            query.Sql = $"SELECT District_ID FROM district_r WHERE DistrictName='{district.Text}'";
            MySqlCommand cmd_GetDistrictID = new MySqlCommand(query.Sql, query.Conn);
            district_ID = Convert.ToInt32(cmd_GetDistrictID.ExecuteScalar());

            return district_ID;
        }
        private int GetMaterialID(Query query)
        {
            int material_ID;
            query.Sql = $"SELECT COUNT(1) FROM wallmaterial_r WHERE MaterialType='{material.Text}'";
            MySqlCommand cmd_CheckMaterial = new MySqlCommand(query.Sql, query.Conn);
            int countMaterial = Convert.ToInt32(cmd_CheckMaterial.ExecuteScalar());

            if (countMaterial == 0)
            {
                query.Sql = $"INSERT INTO wallmaterial_r (MaterialType) VALUES('{material.Text}')";
                MySqlCommand cmd_AddNewMaterial = new MySqlCommand(query.Sql, query.Conn);
                cmd_AddNewMaterial.ExecuteNonQuery();
            }

            query.Sql = $"SELECT Material_ID FROM wallmaterial_r WHERE MaterialType='{material.Text}'";
            MySqlCommand cmd_GetMaterialID = new MySqlCommand(query.Sql, query.Conn);
            material_ID = Convert.ToInt32(cmd_GetMaterialID.ExecuteScalar());

            return material_ID;
        }
        private int GetBaseID(Query query)
        {
            int base_ID;
            query.Sql = $"SELECT COUNT(1) FROM basematerial_r WHERE BaseType='{@base.Text}'";
            MySqlCommand cmd_CheckBase = new MySqlCommand(query.Sql, query.Conn);
            int countBase = Convert.ToInt32(cmd_CheckBase.ExecuteScalar());

            if (countBase == 0)
            {
                query.Sql = $"INSERT INTO basematerial_r (BaseType) VALUES('{@base.Text}')";
                MySqlCommand cmd_AddNewBase = new MySqlCommand(query.Sql, query.Conn);
                cmd_AddNewBase.ExecuteNonQuery();
            }

            query.Sql = $"SELECT Base_ID FROM basematerial_r WHERE BaseType='{@base.Text}'";
            MySqlCommand cmd_GetBaseID = new MySqlCommand(query.Sql, query.Conn);
            base_ID = Convert.ToInt32(cmd_GetBaseID.ExecuteScalar());

            return base_ID;
        }

        private void FillAddSqlQuery(MySqlCommand cmd, Query help_query)
        {
            cmd.Parameters.AddWithValue("Kadastr", kadastr.Text);
            cmd.Parameters.AddWithValue("id_City", GetCityID(help_query));
            cmd.Parameters.AddWithValue("Street", street.Text);
            cmd.Parameters.AddWithValue("House_number", house_number.Text);
            cmd.Parameters.AddWithValue("id_District", GetDistrictID(help_query));
            cmd.Parameters.AddWithValue("Land", land.Text);
            cmd.Parameters.AddWithValue("Year", year.Text);
            cmd.Parameters.AddWithValue("id_Material", GetMaterialID(help_query));
            cmd.Parameters.AddWithValue("id_Base", GetBaseID(help_query));
            cmd.Parameters.AddWithValue("Comment", comment.Text);
            cmd.Parameters.AddWithValue("Wear", wear.Text);
            cmd.Parameters.AddWithValue("Flow", flow.Text);
            cmd.Parameters.AddWithValue("Square", square.Text);
            cmd.Parameters.AddWithValue("Hall", hall.Text);
            if (elevator.IsChecked == true) cmd.Parameters.AddWithValue("Elevator", 1);
            else cmd.Parameters.AddWithValue("Elevator", 0);
        }
    }
}
