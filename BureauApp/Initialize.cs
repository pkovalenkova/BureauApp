using BureauApp.UpdateWindows;
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
    class Initialize
    {
        public static void IniInitializeTable(DataGrid DG)
        {
            Query query = new Query();
            try
            {
                if (query.Conn.State == ConnectionState.Closed)
                    query.Conn.Open();
                if (User.Role == "admin")
                {
                    User.SelectedTable = "users";
                    query.Sql = "Select * from users";
                    FillTables.FillTableUsers(query, DG);
                }
                else
                {
                    User.SelectedTable = "house";
                    query.Sql = "Select * from houses";
                    FillTables.FillTableHouse(query, DG);

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
        public static void InitializeUserFields(UpdateUser window, DataRowView row)
        {
            string[] roles = { "user", "worker", "admin" };
            window.login.Text = row.Row.ItemArray[1].ToString();
            window.pass.Text = row.Row.ItemArray[2].ToString();

            window.role.ItemsSource = roles;
            window.role.SelectedItem = row.Row.ItemArray[3].ToString();
        }
        public static void InitializeHouseFields(UpdateHouse window, DataRowView row)
        {
            window.kadastr.Text = row.Row.ItemArray[0].ToString();
            window.city.Text = row.Row.ItemArray[1].ToString();
            window.district.Text = row.Row.ItemArray[4].ToString();
            window.street.Text = row.Row.ItemArray[2].ToString();
            window.house_number.Text = row.Row.ItemArray[3].ToString();
            window.land.Text = row.Row.ItemArray[5].ToString();
            window.year.Text = row.Row.ItemArray[6].ToString();
            window.material.Text = row.Row.ItemArray[7].ToString();
            window.@base.Text = row.Row.ItemArray[8].ToString();
            window.comment.Text = row.Row.ItemArray[9].ToString();
            window.wear.Text = row.Row.ItemArray[10].ToString();
            window.flow.Text = row.Row.ItemArray[11].ToString();
            window.line.Text = row.Row.ItemArray[12].ToString();
            window.square.Text = row.Row.ItemArray[13].ToString();
            window.hall.Text = row.Row.ItemArray[14].ToString();
            window.elevator.IsChecked = Convert.ToBoolean(row.Row.ItemArray[15].ToString());
        }
        public static void InitializeFlatFields(UpdateFlat window, DataRowView row)
        {
            window.kadastr.Text = row.Row.ItemArray[0].ToString();
            window.flat_number.Text = row.Row.ItemArray[2].ToString();
            window.storey.Text = row.Row.ItemArray[3].ToString();
            window.rooms.Text = row.Row.ItemArray[4].ToString();
            window.height.Text = row.Row.ItemArray[10].ToString();
            window.square_hall.Text = row.Row.ItemArray[6].ToString();
            window.living_square.Text = row.Row.ItemArray[7].ToString();
            window.branch.Text = row.Row.ItemArray[8].ToString();
            window.balcony.Text = row.Row.ItemArray[9].ToString();
            window.level.IsChecked = Convert.ToBoolean(row.Row.ItemArray[5].ToString());
        }
        public static void InitializeRoomFields(UpdateRoom window, DataRowView row)
        {
            window.kadastr.Text = row.Row.ItemArray[0].ToString();
            window.flat_number.Text = row.Row.ItemArray[1].ToString();
            window.record.Text = row.Row.ItemArray[3].ToString();
            window.name_part_name.Text = row.Row.ItemArray[4].ToString();
            window.square.Text = row.Row.ItemArray[5].ToString();
            window.lenght.Text = row.Row.ItemArray[6].ToString();
            window.width.Text = row.Row.ItemArray[7].ToString();
            window.wall.Text = row.Row.ItemArray[8].ToString();
            window.floor.Text = row.Row.ItemArray[9].ToString();
            window.ceiling.Text = row.Row.ItemArray[10].ToString();
            window.height.Text = row.Row.ItemArray[11].ToString();
            window.socket.Text = row.Row.ItemArray[12].ToString();
            window.section.Text = row.Row.ItemArray[13].ToString();
        }
    }
}
