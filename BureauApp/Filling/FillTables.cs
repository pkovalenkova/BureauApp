using BureauApp.Windows;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Controls;

namespace BureauApp
{
    class FillTables
    {
        public static void FillTableHouse(Query query, DataGrid DG)
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter(query.Sql, query.Conn);

            DataSet ds = new DataSet();

            ChangeColumnNameOnFriend.Change(adapter, "houses");
            adapter.Fill(ds, "houses");
            DG.DataContext = ds.Tables[0];
        }

        public static void FillTableFlats(Query query, DataGrid DG)
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter(query.Sql, query.Conn);

            DataSet ds = new DataSet();

            ChangeColumnNameOnFriend.Change(adapter, "flats");
            adapter.Fill(ds, "flats");
            DG.DataContext = ds.Tables[0];
        }
        public static void FillTableRooms(Query query, DataGrid DG)
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter(query.Sql, query.Conn);

            DataSet ds = new DataSet();

            ChangeColumnNameOnFriend.Change(adapter, "rooms");
            adapter.Fill(ds, "rooms");
            DG.DataContext = ds.Tables[0];
        }

        public static void FillRefTable(Query query, RefWindow window)
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter(query.Sql, query.Conn);

            DataSet ds = new DataSet();

            //ChangeColumnNameOnFriend.Change(adapter, window.TableList.SelectedItem.ToString());
            adapter.Fill(ds);
            window.DG.DataContext = ds.Tables[0];
        }
        public static void FillTableUsers(Query query, DataGrid DG)
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter(query.Sql, query.Conn);

            DataSet ds = new DataSet();

            ChangeColumnNameOnFriend.Change(adapter, "users");
            adapter.Fill(ds, "users");
            DG.DataContext = ds.Tables[0];
        }
    }
}
