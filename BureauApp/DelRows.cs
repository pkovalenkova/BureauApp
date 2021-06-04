using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace BureauApp
{
    class DelRows
    {
        public static void DelRow(DataGrid DG)
        {
            Query query = new Query();
            try
            {
                if (query.Conn.State == ConnectionState.Closed)
                    query.Conn.Open();
                if (DG.SelectedItem == null) throw new Exception("Строка не выбрана");
                MessageBoxButton btnMessageBox = MessageBoxButton.YesNo;

                switch (MessageBox.Show("Вы точно хотите удалить выбранную строку?", "Подтвердите действие", btnMessageBox))
                {
                    case MessageBoxResult.Yes:
                        DataRowView row = DG.SelectedItem as DataRowView;
                        MySqlCommand cmd_DeleteRow = new MySqlCommand(query.Sql, query.Conn);
                        switch (User.SelectedTable)
                        {
                            case "house":
                                switch (MessageBox.Show("Удаление здания приведет к удалению записей всех квартир и помещений, относящихся к нему. Желаете продолжить?", "Подтвердите действие", btnMessageBox)) 
                                {
                                    case MessageBoxResult.Yes:
                                        query.Sql = $"DELETE FROM room WHERE FK_FLAT_ID=(SELECT Flat_ID FROM flat WHERE FK_Kadastr='{row.Row.ItemArray[0]}')";
                                        cmd_DeleteRow.CommandText = query.Sql;
                                        cmd_DeleteRow.ExecuteNonQuery();
                                        query.Sql= $"DELETE FROM flat WHERE FK_Kadastr='{row.Row.ItemArray[0]}'";
                                        cmd_DeleteRow.CommandText = query.Sql;
                                        cmd_DeleteRow.ExecuteNonQuery();
                                        query.Sql = $"DELETE FROM house WHERE Kadastr='{row.Row.ItemArray[0]}'";
                                        cmd_DeleteRow.CommandText = query.Sql;
                                        cmd_DeleteRow.ExecuteNonQuery();
                                        query.Sql = "Select * from houses";
                                        FillTables.FillTableHouse(query, DG);
                                        break;

                                    case MessageBoxResult.No:
                                        break;
                                }
                                break;
                            case "flat":
                                switch (MessageBox.Show("Удаление квартиры приведет к удалению записей всех помещений, относящихся к нему. Желаете продолжить?", "Подтвердите действие", btnMessageBox))
                                {
                                    case MessageBoxResult.Yes:
                                        query.Sql = $"DELETE FROM room WHERE FK_FLAT_ID='{row.Row.ItemArray[1]}'";
                                        cmd_DeleteRow.CommandText = query.Sql;
                                        cmd_DeleteRow.ExecuteNonQuery();
                                        query.Sql = $"DELETE FROM flat WHERE Flat_ID='{row.Row.ItemArray[1]}'";
                                        cmd_DeleteRow.CommandText = query.Sql;
                                        cmd_DeleteRow.ExecuteNonQuery();
                                        query.Sql = "Select * from flats";
                                        FillTables.FillTableFlats(query, DG);
                                        break;
                                    case MessageBoxResult.No:
                                        break;
                                }

                                break;
                            case "room":
                                query.Sql = $"DELETE FROM room WHERE Room_ID='{row.Row.ItemArray[2]}'";
                                cmd_DeleteRow.CommandText = query.Sql;
                                cmd_DeleteRow.ExecuteNonQuery();
                                query.Sql = "Select * from rooms";
                                FillTables.FillTableRooms(query, DG);
                                break;
                            case "users":
                                query.Sql = $"DELETE FROM users WHERE User_ID='{row.Row.ItemArray[0].ToString()}'";
                                cmd_DeleteRow.CommandText = query.Sql;
                                cmd_DeleteRow.ExecuteNonQuery();
                                query.Sql = "Select * from users";
                                FillTables.FillTableUsers(query, DG);
                                break;
                        }

                        MessageBox.Show("Выбранная строка удалена", "Успех");
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
