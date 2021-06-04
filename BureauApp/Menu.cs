using BureauApp.AddWindows;
using BureauApp.ReportWindows;
using BureauApp.SearchWindows;
using BureauApp.UpdateWindows;
using BureauApp.Windows;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BureauApp
{
    class Menu
    {
        public static void Profile()
        {
            Profile profileWindow = new Profile();
            profileWindow.ShowDialog();
        }
        public static void Search()
        {
            Query query = new Query();

            try
            {
                if (query.Conn.State == ConnectionState.Closed)
                    query.Conn.Open();

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
                    case "users":
                        UserSearch userSearch = new UserSearch();
                        userSearch.ShowDialog();
                        break;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Ошибка при работе с базой данных:" + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }
        public static void AddRow(DataGrid DG)
        {
            Query query = new Query();

            try
            {
                if (query.Conn.State == ConnectionState.Closed)
                    query.Conn.Open();

                switch (User.SelectedTable)
                {
                    case "house":
                        AddHouse addHouse_window = new AddHouse();
                        addHouse_window.ShowDialog();
                        query.Sql = "Select * from houses";
                        FillTables.FillTableHouse(query, DG);
                        break;
                    case "flat":
                        AddFlat addFlat_window = new AddFlat();
                        addFlat_window.ShowDialog();
                        query.Sql = "Select * from flats";
                        FillTables.FillTableFlats(query, DG);
                        break;
                    case "room":
                        AddRoom addRoom_window = new AddRoom();
                        addRoom_window.ShowDialog();
                        query.Sql = "Select * from rooms";
                        FillTables.FillTableRooms(query, DG);
                        break;
                    case "users":
                        AddUser addUser_window = new AddUser();
                        addUser_window.ShowDialog();
                        query.Sql = "Select * from users";
                        FillTables.FillTableUsers(query, DG);
                        break;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Ошибка при работе с базой данных:" + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }
        public static void UpdRow(DataGrid DG)
        {
            Query query = new Query();

            try
            {
                if (query.Conn.State == ConnectionState.Closed)
                    query.Conn.Open();
                if (DG.SelectedItem == null) throw new Exception("Строка не выбрана");
                DataRowView row = DG.SelectedItem as DataRowView;
                switch (User.SelectedTable)
                {
                    case "house":
                        UpdateHouse updateHouse_window = new UpdateHouse(row);
                        updateHouse_window.ShowDialog();
                        query.Sql = "Select * from houses";
                        FillTables.FillTableHouse(query, DG);
                        break;
                    case "flat":
                        UpdateFlat updateFlat_window = new UpdateFlat(row);
                        updateFlat_window.ShowDialog();
                        query.Sql = "Select * from flats";
                        FillTables.FillTableFlats(query, DG);
                        break;
                    case "room":
                        UpdateRoom updateRoom_window = new UpdateRoom(row);
                        updateRoom_window.ShowDialog();
                        query.Sql = "Select * from rooms";
                        FillTables.FillTableRooms(query, DG);
                        break;
                    case "users":
                        UpdateUser updateUser_window = new UpdateUser(row);
                        updateUser_window.ShowDialog();
                        query.Sql = "Select * from users";
                        FillTables.FillTableUsers(query, DG);
                        break;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }
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
                                        query.Sql = $"DELETE FROM flat WHERE FK_Kadastr='{row.Row.ItemArray[0]}'";
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
        public static void Export(DataGrid DG)
        {
            ExportToXls.ExportTable(DG);
        }
        public static void Export(Report report_window)
        {
            ExportToXls.ExportTable(report_window);
        }
        public static void Report()
        {
            Report report_window = new Report();
            report_window.ShowDialog();
        }
        public static void Ref()
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
        public static void Exit()
        {
            var windows = (Application.Current.Windows);
            foreach (var wnd in windows.OfType<Window>())
            {
                wnd.Close();
            }
        }
        public static void HouseClick(DataGrid DG)
        {
            Query query = new Query();
            
            try
            {
                if (query.Conn.State == ConnectionState.Closed)
                    query.Conn.Open();

                User.SelectedTable = "house";
                query.Sql = "Select * from houses";
                FillTables.FillTableHouse(query, DG);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Ошибка при работе с базой данных:" + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }
        public static void FlatClick(DataGrid DG)
        {
            Query query = new Query();
            try
            {
                if (query.Conn.State == ConnectionState.Closed)
                    query.Conn.Open();

                User.SelectedTable = "flat";
                query.Sql = "Select * from flats";
                FillTables.FillTableFlats(query, DG);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Ошибка при работе с базой данных:" + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }
        public static void RoomClick(DataGrid DG)
        {
            Query query = new Query();
            try
            {
                if (query.Conn.State == ConnectionState.Closed)
                    query.Conn.Open();

                User.SelectedTable = "room";
                query.Sql = "Select * from rooms";
                FillTables.FillTableRooms(query, DG);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Ошибка при работе с базой данных:" + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }
    }
}
