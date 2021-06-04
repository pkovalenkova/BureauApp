using MySql.Data.MySqlClient;
using System;
using System.Windows;

namespace BureauApp.AddWindows
{
    /// <summary>
    /// Логика взаимодействия для AddRoom.xaml
    /// </summary>
    public partial class AddRoom : Window
    {
        public AddRoom()
        {
            InitializeComponent();
        }

        private void Add_btn_Click(object sender, RoutedEventArgs e)
        {
            AddRoomRow();
        }

        private void CheckEmptyField()
        {
            if (kadastr.Text == string.Empty) { throw new Exception("Не заполнено поле \"Кадастр здания\""); }
            if (flat_number.Text == string.Empty) { throw new Exception("Не заполнено поле \"Номер квартиры\""); }
            if (record.Text == string.Empty) { throw new Exception("Не заполнено поле \"Номер помещения на плане\""); }
            if (name_part_name.Text == string.Empty) { throw new Exception("Не заполнено поле \"Назначение\""); }
            if (height.Text == string.Empty) { throw new Exception("Не заполнено поле \"Высота помещения\""); }
            if (socket.Text == string.Empty) { throw new Exception("Не заполнено поле \"Число розеток\""); }
            if (section.Text == string.Empty) { throw new Exception("Не заполнено поле \"Число радиаторов отполения\""); }
            if (square.Text == string.Empty) { throw new Exception("Не заполнено поле \"Площадь\""); }
            if (lenght.Text == string.Empty) { throw new Exception("Не заполнено поле \"Длина\""); }
            if (width.Text == string.Empty) { throw new Exception("Не заполнено поле \"Ширина\""); }
            if (wall.Text == string.Empty) { throw new Exception("Не заполнено поле \"Отделка стен\""); }
            if (floor.Text == string.Empty) { throw new Exception("Не заполнено поле \"Отделка пола\""); }
            if (ceiling.Text == string.Empty) { throw new Exception("Не заполнено поле \"Отделка потолка\""); }
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

            if (!Int32.TryParse(record.Text, out res)) { throw new Exception("Неправильный формат данных поля \"Номер помещения на плане\""); }
            else
            {
                if ((res < 1) || (res > 30)) { throw new Exception("Неправильный формат данных поля \"Номер помещения на плане\""); }
            }

            if (!Int32.TryParse(socket.Text, out res)) { throw new Exception("Неправильный формат данных поля \"Число розеток\""); }
            else
            {
                if ((res < 0) || (res > 20)) { throw new Exception("Неправильный формат данных поля \"Число розеток\""); }
            }

            if (!Int32.TryParse(section.Text, out res)) { throw new Exception("Неправильный формат данных поля \"Число радиаторов отопления\""); }
            else
            {
                if ((res < 0) || (res > 20)) { throw new Exception("Неправильный формат данных поля \"Число радиаторов отопления\""); }
            }

            if (!Double.TryParse(height.Text, out resD)) { throw new Exception("Неправильный формат данных поля \"Высота помещения\""); }
            else
            {
                if ((resD < 1) || (resD > 10)) { throw new Exception("Неправильный формат данных поля \"Высота помещения\""); }
            }

            if (!Double.TryParse(square.Text, out resD)) { throw new Exception("Неправильный формат данных поля \"Площадь помещения\""); }
            else
            {
                if ((resD < 1) || (resD > 200)) { throw new Exception("Неправильный формат данных поля \"Площадь помещения\""); }
            }

            if (!Double.TryParse(lenght.Text, out resD)) { throw new Exception("Неправильный формат данных поля \"Длина\""); }
            else
            {
                if ((resD < 1) || (resD > 200)) { throw new Exception("Неправильный формат данных поля \"Длина\""); }
            }

            if (!Double.TryParse(width.Text, out resD)) { throw new Exception("Неправильный формат данных поля \"Ширина\""); }
            else
            {
                if ((resD < 1) || (resD > 200)) { throw new Exception("Неправильный формат данных поля \"Ширина\""); }
            }

        }
        private void CheckFlat(Query query)
        {
            query.Sql = $"SELECT COUNT(1) FROM flat WHERE FK_Kadastr='{kadastr.Text}' AND Flat_number='{flat_number.Text}'";
            MySqlCommand cmd_CheckFlat = new MySqlCommand(query.Sql, query.Conn);
            int countFlat = Convert.ToInt32(cmd_CheckFlat.ExecuteScalar());

            if (countFlat == 0) { throw new Exception("Квартиры, для которой добавляется помещение, не существует в таблице \"Квартира\", невозможно добавить новое помещение"); }
        }

        private void CheckRoom(Query query)
        {
            query.Sql = $"SELECT COUNT(1) FROM room WHERE FK_Kadastr='{kadastr.Text}' AND Flat_number='{flat_number.Text}' AND Record='{record.Text}'";
            MySqlCommand cmd_CheckRoom = new MySqlCommand(query.Sql, query.Conn);
            int countRoom = Convert.ToInt32(cmd_CheckRoom.ExecuteScalar());

            if (countRoom != 0) { throw new Exception("Такое помоещение уже существует в данной квартире"); }
        }
        private void FillAddSqlQuery(MySqlCommand cmd, Query help_query)
        {
            cmd.Parameters.AddWithValue("FK_FLAT_ID", GetID.GetFlatID(help_query, kadastr.Text, flat_number.Text));
            cmd.Parameters.AddWithValue("id_NamePart", GetID.GetNamePartID(help_query, name_part_name.Text));
            cmd.Parameters.AddWithValue("Record", record.Text);

            cmd.Parameters.AddWithValue("id_WallDecoration", GetID.GetWallDecorationID(help_query, wall.Text));

            cmd.Parameters.AddWithValue("id_FloorDecoration", GetID.GetFloorDecorationID(help_query, floor.Text));
            cmd.Parameters.AddWithValue("id_CeilingDecoration", GetID.GetCeilingDecorationID(help_query, ceiling.Text));

            cmd.Parameters.AddWithValue("Socket", socket.Text);
            cmd.Parameters.AddWithValue("Sections", section.Text);
        }
        private void AddRoomRow()
        {
            Query query = new Query();
            Query help_query = new Query();
            try
            {
                if (query.Conn.State == System.Data.ConnectionState.Closed)
                    query.Conn.Open();
                if (help_query.Conn.State == System.Data.ConnectionState.Closed)
                    help_query.Conn.Open();

                CheckEmptyField();
                CheckWrongField();
                CheckFlat(query);
                CheckRoom(query);

                query.Sql = $"INSERT INTO room (FK_FLAT_ID, Record, id_NamePart, SquarePart, Length, Width, id_WallDecoration, id_FloorDecoration, id_CeilingDecoration, HeightPart, Socket, Sections) " +
                    $"VALUES (@FK_FLAT_ID, @Record, @id_NamePart, '{square.Text.Replace(',', '.')}', '{lenght.Text.Replace(',', '.')}', '{width.Text.Replace(',', '.')}', @id_WallDecoration, @id_FloorDecoration, @id_CeilingDecoration, '{height.Text.Replace(',', '.')}', @Socket, @Sections)";

                MySqlCommand cmd_AddHouseRow = new MySqlCommand(query.Sql, query.Conn);
                FillAddSqlQuery(cmd_AddHouseRow, help_query);

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
                help_query.Conn.Close();
            }
        }
    }
}
