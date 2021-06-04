using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows;

namespace BureauApp.UpdateWindows
{
    /// <summary>
    /// Логика взаимодействия для UpdateRoom.xaml
    /// </summary>
    public partial class UpdateRoom : Window
    {
        static DataRowView row;
        public UpdateRoom(DataRowView rw)
        {
            InitializeComponent();
            row = rw;
            kadastr.Text = row.Row.ItemArray[0].ToString();
            flat_number.Text = row.Row.ItemArray[1].ToString();
            record.Text = row.Row.ItemArray[3].ToString();
            name_part_name.Text = row.Row.ItemArray[4].ToString();
            square.Text = row.Row.ItemArray[5].ToString();
            lenght.Text = row.Row.ItemArray[6].ToString();
            width.Text = row.Row.ItemArray[7].ToString();
            wall.Text = row.Row.ItemArray[8].ToString();
            floor.Text = row.Row.ItemArray[9].ToString();
            ceiling.Text = row.Row.ItemArray[10].ToString();
            height.Text = row.Row.ItemArray[11].ToString();
            socket.Text = row.Row.ItemArray[12].ToString();
            section.Text = row.Row.ItemArray[13].ToString();
        }

        private void Upd_btn_Click(object sender, RoutedEventArgs e)
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
                CheckFlat(query);

                MessageBoxButton btnMessageBox = MessageBoxButton.YesNo;

                switch (MessageBox.Show("Вы точно хотите изменить выбранную строку?", "Подтвердите действие", btnMessageBox))
                {
                    case MessageBoxResult.Yes:
                        query.Sql = $"UPDATE room SET FK_FLAT_ID=@FK_FLAT_ID, id_NamePart=@id_NamePart, Record=@Record, SquarePart='{square.Text.Replace(',', '.')}', " +
                                    $"id_WallDecoration=@id_WallDecoration, Length='{lenght.Text.Replace(',', '.')}', Width='{width.Text.Replace(',', '.')}', id_FloorDecoration=@id_FloorDecoration, id_CeilingDecoration=@id_CeilingDecoration, " +
                                    $"HeightPart='{height.Text.Replace(',', '.')}', Socket=@Socket, Sections=@Sections " +
                                    $"WHERE Room_ID='{row.Row.ItemArray[2].ToString()}'";

                        MySqlCommand cmd_UpdRoomRow = new MySqlCommand(query.Sql, query.Conn);

                        FillUpdSqlQuery(cmd_UpdRoomRow, help_query);
                        cmd_UpdRoomRow.ExecuteNonQuery();
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
                if ((res < 1) || (res > 20)) { throw new Exception("Неправильный формат данных поля \"Число розеток\""); }
            }

            if (!Int32.TryParse(section.Text, out res)) { throw new Exception("Неправильный формат данных поля \"Число радиаторов отопления\""); }
            else
            {
                if ((res < 1) || (res > 20)) { throw new Exception("Неправильный формат данных поля \"Число радиаторов отопления\""); }
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

        private int GetFlatID(Query query)
        {
            query.Sql = $"SELECT Flat_ID FROM flat WHERE FK_Kadastr='{kadastr.Text}' AND Flat_number='{flat_number.Text}'";
            MySqlCommand cmd_CheckFlat = new MySqlCommand(query.Sql, query.Conn);
            int Flat_ID = Convert.ToInt32(cmd_CheckFlat.ExecuteScalar());
            return Flat_ID;
        }


        private int GetNamePartID(Query query)
        {
            int name_part_ID;
            query.Sql = $"SELECT COUNT(1) FROM namepart_r WHERE NamePartName='{name_part_name.Text}'";
            MySqlCommand cmd_NamePart = new MySqlCommand(query.Sql, query.Conn);
            int countNamePart = Convert.ToInt32(cmd_NamePart.ExecuteScalar());

            if (countNamePart == 0)
            {
                query.Sql = $"INSERT INTO namepart_r (NamePartName) VALUES('{name_part_name.Text}')";
                MySqlCommand cmd_AddNewNamePart = new MySqlCommand(query.Sql, query.Conn);
                cmd_AddNewNamePart.ExecuteNonQuery();
            }

            query.Sql = $"SELECT NamePart_ID FROM namepart_r WHERE NamePartName='{name_part_name.Text}'";
            MySqlCommand cmd_NamePartID = new MySqlCommand(query.Sql, query.Conn);
            name_part_ID = Convert.ToInt32(cmd_NamePartID.ExecuteScalar());

            return name_part_ID;
        }

        private int GetWallDecorationID(Query query)
        {
            int walldecoration_ID;
            query.Sql = $"SELECT COUNT(1) FROM walldecoration_r WHERE WallDecorationType='{wall.Text}'";
            MySqlCommand cmd_WallDecoration = new MySqlCommand(query.Sql, query.Conn);
            int countWallDecoration = Convert.ToInt32(cmd_WallDecoration.ExecuteScalar());

            if (countWallDecoration == 0)
            {
                query.Sql = $"INSERT INTO walldecoration_r (WallDecorationType) VALUES('{wall.Text}')";
                MySqlCommand cmd_AddNewWallDecoration = new MySqlCommand(query.Sql, query.Conn);
                cmd_AddNewWallDecoration.ExecuteNonQuery();
            }

            query.Sql = $"SELECT WallDecoration_ID FROM walldecoration_r WHERE WallDecorationType='{wall.Text}'";
            MySqlCommand cmd_WallDecorationID = new MySqlCommand(query.Sql, query.Conn);
            walldecoration_ID = Convert.ToInt32(cmd_WallDecorationID.ExecuteScalar());

            return walldecoration_ID;
        }
        private int GetFloorDecorationID(Query query)
        {
            int floordecoration_ID;
            query.Sql = $"SELECT COUNT(1) FROM floordecoration_r WHERE FloorDecorationType='{floor.Text}'";
            MySqlCommand cmd_FloorDecoration = new MySqlCommand(query.Sql, query.Conn);
            int countFloorDecoration = Convert.ToInt32(cmd_FloorDecoration.ExecuteScalar());

            if (countFloorDecoration == 0)
            {
                query.Sql = $"INSERT INTO floordecoration_r (FloorDecorationType) VALUES('{floor.Text}')";
                MySqlCommand cmd_AddNewFloorDecoration = new MySqlCommand(query.Sql, query.Conn);
                cmd_AddNewFloorDecoration.ExecuteNonQuery();
            }

            query.Sql = $"SELECT FloorDecoration_ID FROM floordecoration_r WHERE FloorDecorationType='{floor.Text}'";
            MySqlCommand cmd_FloorDecorationID = new MySqlCommand(query.Sql, query.Conn);
            floordecoration_ID = Convert.ToInt32(cmd_FloorDecorationID.ExecuteScalar());

            return floordecoration_ID;
        }
        private int GetCeilingDecorationID(Query query)
        {
            int ceilingdecoration_ID;
            query.Sql = $"SELECT COUNT(1) FROM ceilingdecoration_r WHERE CeilingDecorationType='{ceiling.Text}'";
            MySqlCommand cmd_CeilingDecoration = new MySqlCommand(query.Sql, query.Conn);
            int countCeilingDecoration = Convert.ToInt32(cmd_CeilingDecoration.ExecuteScalar());

            if (countCeilingDecoration == 0)
            {
                query.Sql = $"INSERT INTO ceilingdecoration_r (CeilingDecorationType) VALUES('{ceiling.Text}')";
                MySqlCommand cmd_AddNewCeilingDecoration = new MySqlCommand(query.Sql, query.Conn);
                cmd_AddNewCeilingDecoration.ExecuteNonQuery();
            }

            query.Sql = $"SELECT CeilingDecoration_ID FROM ceilingdecoration_r WHERE CeilingDecorationType='{ceiling.Text}'";
            MySqlCommand cmd_CeilingDecorationID = new MySqlCommand(query.Sql, query.Conn);
            ceilingdecoration_ID = Convert.ToInt32(cmd_CeilingDecorationID.ExecuteScalar());

            return ceilingdecoration_ID;
        }

        private void FillUpdSqlQuery(MySqlCommand cmd, Query help_query)
        {
            cmd.Parameters.AddWithValue("FK_FLAT_ID", GetFlatID(help_query));
            cmd.Parameters.AddWithValue("id_NamePart", GetNamePartID(help_query));
            cmd.Parameters.AddWithValue("Record", record.Text);

            cmd.Parameters.AddWithValue("id_WallDecoration", GetWallDecorationID(help_query));

            cmd.Parameters.AddWithValue("id_FloorDecoration", GetFloorDecorationID(help_query));
            cmd.Parameters.AddWithValue("id_CeilingDecoration", GetCeilingDecorationID(help_query));

            cmd.Parameters.AddWithValue("Socket", socket.Text);
            cmd.Parameters.AddWithValue("Sections", section.Text);
        }
    }
}
