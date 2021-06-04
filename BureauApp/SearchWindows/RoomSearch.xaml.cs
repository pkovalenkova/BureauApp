using System;
using System.Windows;
using System.Windows.Controls;

namespace BureauApp.SearchWindows
{
    /// <summary>
    /// Логика взаимодействия для RoomSearch.xaml
    /// </summary>
    public partial class RoomSearch : Window
    {
        public RoomSearch()
        {
            InitializeComponent();
        }
        private void DoSearch_btn_Click(object sender, RoutedEventArgs e)
        {
            Scroll.ScrollToEnd();
            Query query = new Query();
            if (query.Conn.State == System.Data.ConnectionState.Closed)
                query.Conn.Open();

            FillSearchSqlQuery.FillRoomSearch(query, this);
            FillTables.FillTableRooms(query, SearchResult);

        }
        private void Exp_btn_Click(object sender, RoutedEventArgs e)
        {
            ExportToXls.Export(SearchResult);
        }
        private void flat_number_low_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (flat_number_low.Text != string.Empty)
                    flat_number_sldr.LowerValue = Convert.ToDouble(flat_number_low.Text);
            }
            catch (System.FormatException ex)
            {
                MessageBox.Show(ex.Message + "Пример заполненного поля: 48,5.");
            }
        }
        private void flat_number_high_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (flat_number_high.Text != string.Empty)
                    flat_number_sldr.HigherValue = Convert.ToDouble(flat_number_high.Text);
            }
            catch (System.FormatException ex)
            {
                MessageBox.Show(ex.Message + "Пример заполненного поля: 48,5.");
            }
        }
        private void flat_number_sldr_LowerValueChanged(object sender, RoutedEventArgs e)
        {
            flat_number_low.Text = Convert.ToInt32(flat_number_sldr.LowerValue).ToString();
        }
        private void flat_number_sldr_HigherValueChanged(object sender, RoutedEventArgs e)
        {
            flat_number_high.Text = Convert.ToInt32(flat_number_sldr.HigherValue).ToString();
        }
        private void record_low_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (record_low.Text != string.Empty)
                    record_sldr.LowerValue = Convert.ToDouble(record_low.Text);
            }
            catch (System.FormatException ex)
            {
                MessageBox.Show(ex.Message + "Пример заполненного поля: 48,5.");
            }
        }
        private void record_high_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (record_high.Text != string.Empty)
                    record_sldr.HigherValue = Convert.ToDouble(record_high.Text);
            }
            catch (System.FormatException ex)
            {
                MessageBox.Show(ex.Message + "Пример заполненного поля: 48,5.");
            }
        }
        private void record_sldr_LowerValueChanged(object sender, RoutedEventArgs e)
        {
            record_low.Text = Convert.ToInt32(record_sldr.LowerValue).ToString();
        }
        private void record_sldr_HigherValueChanged(object sender, RoutedEventArgs e)
        {
            record_high.Text = Convert.ToInt32(record_sldr.HigherValue).ToString();
        }
        private void socket_low_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (socket_low.Text != string.Empty)
                    socket_sldr.LowerValue = Convert.ToDouble(socket_low.Text);
            }
            catch (System.FormatException ex)
            {
                MessageBox.Show(ex.Message + "Пример заполненного поля: 48,5.");
            }
        }
        private void socket_high_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (socket_high.Text != string.Empty)
                    socket_sldr.HigherValue = Convert.ToDouble(socket_high.Text);
            }
            catch (System.FormatException ex)
            {
                MessageBox.Show(ex.Message + "Пример заполненного поля: 48,5.");
            }
        }
        private void socket_sldr_LowerValueChanged(object sender, RoutedEventArgs e)
        {
            socket_low.Text = Convert.ToInt32(socket_sldr.LowerValue).ToString();
        }
        private void socket_sldr_HigherValueChanged(object sender, RoutedEventArgs e)
        {
            socket_high.Text = Convert.ToInt32(socket_sldr.HigherValue).ToString();
        }
        private void section_low_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (section_low.Text != string.Empty)
                    section_sldr.LowerValue = Convert.ToDouble(section_low.Text);
            }
            catch (System.FormatException ex)
            {
                MessageBox.Show(ex.Message + "Пример заполненного поля: 48,5.");
            }
        }
        private void section_high_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (section_high.Text != string.Empty)
                    section_sldr.HigherValue = Convert.ToDouble(section_high.Text);
            }
            catch (System.FormatException ex)
            {
                MessageBox.Show(ex.Message + "Пример заполненного поля: 48,5.");
            }
        }
        private void section_sldr_LowerValueChanged(object sender, RoutedEventArgs e)
        {
            section_low.Text = Convert.ToInt32(section_sldr.LowerValue).ToString();
        }
        private void section_sldr_HigherValueChanged(object sender, RoutedEventArgs e)
        {
            section_high.Text = Convert.ToInt32(section_sldr.HigherValue).ToString();
        }
        private void height_low_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (height_low.Text != string.Empty)
                    height_sldr.LowerValue = Convert.ToDouble(height_low.Text);
            }
            catch (System.FormatException ex)
            {
                MessageBox.Show(ex.Message + "Пример заполненного поля: 48,5.");
            }
        }
        private void height_high_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (height_high.Text != string.Empty)
                    height_sldr.HigherValue = Convert.ToDouble(height_high.Text);
            }
            catch (System.FormatException ex)
            {
                MessageBox.Show(ex.Message + "Пример заполненного поля: 48,5.");
            }
        }
        private void height_sldr_LowerValueChanged(object sender, RoutedEventArgs e)
        {
            height_low.Text = (Math.Round(Convert.ToDouble(height_sldr.LowerValue), 2)).ToString();
        }
        private void height_sldr_HigherValueChanged(object sender, RoutedEventArgs e)
        {
            height_high.Text = (Math.Round(Convert.ToDouble(height_sldr.HigherValue), 2)).ToString();
        }
        private void square_part_low_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (square_part_low.Text != string.Empty)
                    square_part_sldr.LowerValue = Convert.ToDouble(square_part_low.Text);
            }
            catch (System.FormatException ex)
            {
                MessageBox.Show(ex.Message + "Пример заполненного поля: 48,5.");
            }
        }
        private void square_part_high_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (square_part_high.Text != string.Empty)
                    square_part_sldr.HigherValue = Convert.ToDouble(square_part_high.Text);
            }
            catch (System.FormatException ex)
            {
                MessageBox.Show(ex.Message + "Пример заполненного поля: 48,5.");
            }
        }
        private void square_part_sldr_LowerValueChanged(object sender, RoutedEventArgs e)
        {
            square_part_low.Text = (Math.Round(Convert.ToDouble(square_part_sldr.LowerValue), 2)).ToString();
        }
        private void square_part_sldr_HigherValueChanged(object sender, RoutedEventArgs e)
        {
            square_part_high.Text = (Math.Round(Convert.ToDouble(square_part_sldr.HigherValue), 2)).ToString();
        }
        private void lenght_low_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (lenght_low.Text != string.Empty)
                    lenght_sldr.LowerValue = Convert.ToDouble(lenght_low.Text);
            }
            catch (System.FormatException ex)
            {
                MessageBox.Show(ex.Message + "Пример заполненного поля: 48,5.");
            }
        }
        private void lenght_high_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (lenght_high.Text != string.Empty)
                    lenght_sldr.HigherValue = Convert.ToDouble(lenght_high.Text);
            }
            catch (System.FormatException ex)
            {
                MessageBox.Show(ex.Message + "Пример заполненного поля: 48,5.");
            }
        }
        private void lenght_sldr_LowerValueChanged(object sender, RoutedEventArgs e)
        {
            lenght_low.Text = (Math.Round(Convert.ToDouble(lenght_sldr.LowerValue), 2)).ToString();
        }
        private void lenght_sldr_HigherValueChanged(object sender, RoutedEventArgs e)
        {
            lenght_high.Text = (Math.Round(Convert.ToDouble(lenght_sldr.HigherValue), 2)).ToString();
        }
        private void width_low_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (width_low.Text != string.Empty)
                    width_sldr.LowerValue = Convert.ToDouble(width_low.Text);
            }
            catch (System.FormatException ex)
            {
                MessageBox.Show(ex.Message + "Пример заполненного поля: 48,5.");
            }
        }
        private void width_high_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (width_high.Text != string.Empty)
                    width_sldr.HigherValue = Convert.ToDouble(width_high.Text);
            }
            catch (System.FormatException ex)
            {
                MessageBox.Show(ex.Message + "Пример заполненного поля: 48,5.");
            }
        }
        private void width_sldr_LowerValueChanged(object sender, RoutedEventArgs e)
        {
            width_low.Text = (Math.Round(Convert.ToDouble(width_sldr.LowerValue), 2)).ToString();
        }
        private void width_sldr_HigherValueChanged(object sender, RoutedEventArgs e)
        {
            width_high.Text = (Math.Round(Convert.ToDouble(width_sldr.HigherValue), 2)).ToString();
        }
    }
}
