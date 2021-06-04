using System;
using System.Data;
using BureauApp.UpdateWindows;
using System.Windows;
using System.Windows.Controls;

namespace BureauApp
{
    class UpdRows
    {
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
    }
}
