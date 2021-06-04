using System.Windows;
using System.Windows.Controls;

namespace BureauApp.Windows
{
    /// <summary>
    /// Логика взаимодействия для RefWindow.xaml
    /// </summary>
    public partial class RefWindow : Window
    {
        public RefWindow()
        {
            InitializeComponent();
            string[] table_names = { "Районы", "Города", "Материал фундамента", "Материал стен", "Назначение помещения", "Отделка стен", "Отделка пола", "Отделка потолка" };
            TableList.ItemsSource = table_names;
        }

        private void TableList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Query query = new Query();
            switch (TableList.SelectedIndex)
            {
                case 0:
                    query.Sql = "Select * from district_r";
                    break;
                case 1:
                    query.Sql = "Select * from city_r";
                    break;
                case 2:
                    query.Sql = "Select * from basematerial_r";
                    break;
                case 3:
                    query.Sql = "Select * from wallmaterial_r";
                    break;
                case 4:
                    query.Sql = "Select * from namepart_r";
                    break;
                case 5:
                    query.Sql = "Select * from walldecoration_r";
                    break;
                case 6:
                    query.Sql = "Select * from floordecoration_r";
                    break;
                case 7:
                    query.Sql = "Select * from ceilingdecoration_r";
                    break;
            }
            FillTables.FillRefTable(query, this);
        }
    }
}
